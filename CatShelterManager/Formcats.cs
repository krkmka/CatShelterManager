using CatShelterManager.Models;
using CatShelterManager.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CatShelterManager
{
    public partial class FormCats : Form
    {
        // -------------------------------------------------------
        // Репозиторії приходять ззовні (з FormMain) — не створюємо
        // нові, а працюємо з тими самими даними що й FormLocations
        // -------------------------------------------------------
        private readonly CatRepository _catRepo;
        private readonly LocationRepository _locationRepo;

        public FormCats(CatRepository catRepo, LocationRepository locationRepo)
        {
            _catRepo = catRepo;
            _locationRepo = locationRepo;

            InitializeComponent();

            SetupCombos();
            RefreshGrid();
        }

        // Заповнити обидва ComboBox-и при відкритті форми
        private void SetupCombos()
        {
            // HealthStatus — всі значення enum
            cmbHealth.DataSource = Enum.GetValues(typeof(HealthStatus));

            // Локації — список з репозиторію
            cmbLocation.DataSource = null;
            cmbLocation.DataSource = _locationRepo.GetAll().ToList();
            cmbLocation.DisplayMember = "Number";
            cmbLocation.ValueMember = "Id";
            cmbLocation.SelectedIndex = -1;
        }

        // -------------------------------------------------------
        // READ — оновити таблицю
        // -------------------------------------------------------
        private void RefreshGrid()
        {
            dgvCats.DataSource = _catRepo.GetAll()
                .Select(c => new
                {
                    c.Id,
                    Кличка = c.Nickname,
                    Вік = c.Age,
                    Здоров_я = c.HealthStatus switch
                    {
                        HealthStatus.Healthy => "Здоровий",
                        HealthStatus.NeedsCheckup => "Потребує огляду",
                        HealthStatus.InTreatment => "На лікуванні",
                        _ => c.HealthStatus.ToString()
                    },
                    Локація = c.CurrentLocation.Number
                })
                .ToList();

            if (dgvCats.Columns.Contains("Id"))
                dgvCats.Columns["Id"].Visible = false;
        }

        // -------------------------------------------------------
        // CREATE
        // -------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // <<Include>> з Use Case: локація обов'язкова
            if (cmbLocation.SelectedItem == null)
            {
                MessageBox.Show(
                    "Оберіть місце утримання.\n" +
                    "Кіт повинен бути прив'язаний до локації.",
                    "Обов'язкове поле",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var location = (Location)cmbLocation.SelectedItem;
                int newId = _catRepo.GetAll().Count > 0
                    ? _catRepo.GetAll().Max(c => c.Id) + 1 : 1;

                var cat = new Cat(
                    id: newId,
                    nickname: txtName.Text,
                    age: (int)numAge.Value,
                    status: (HealthStatus)cmbHealth.SelectedItem!,
                    location: location
                );

                _catRepo.Add(cat);
                RefreshGrid();
                ClearFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Невірні дані",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // -------------------------------------------------------
        // UPDATE
        // -------------------------------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCats.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть кота для редагування.", "Підказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbLocation.SelectedItem == null)
            {
                MessageBox.Show("Оберіть місце утримання.", "Обов'язкове поле",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cat = GetSelectedCat();
            if (cat == null) return;

            try
            {
                // private set — тільки через методи моделі
                cat.UpdateCatDetails(
                    txtName.Text,
                    (int)numAge.Value,
                    (HealthStatus)cmbHealth.SelectedItem!
                );

                var newLoc = (Location)cmbLocation.SelectedItem;
                if (cat.CurrentLocation.Id != newLoc.Id)
                    cat.AssignLocation(newLoc); // двонаправлений зв'язок

                RefreshGrid();
                ClearFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Невірні дані",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // -------------------------------------------------------
        // DELETE
        // -------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCats.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть кота для видалення.", "Підказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cat = GetSelectedCat();
            if (cat == null) return;

            var confirm = MessageBox.Show(
                $"Видалити кота '{cat.Nickname}'?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Відв'язати від локації перед видаленням
                cat.CurrentLocation.RemoveCat(cat);
                _catRepo.Remove(cat.Id);

                RefreshGrid();
                ClearFields();
            }
        }

        // -------------------------------------------------------
        // SEARCH — <<Extends>> з Use Case
        // -------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                RefreshGrid();
                return;
            }

            dgvCats.DataSource = _catRepo.GetAll()
                .Where(c => c.Nickname.ToLower().Contains(query)
                         || c.CurrentLocation.Number.ToLower().Contains(query))
                .Select(c => new
                {
                    c.Id,
                    Кличка = c.Nickname,
                    Вік = c.Age,
                    Здоров_я = c.HealthStatus switch
                    {
                        HealthStatus.Healthy => "Здоровий",
                        HealthStatus.NeedsCheckup => "Потребує огляду",
                        HealthStatus.InTreatment => "На лікуванні",
                        _ => c.HealthStatus.ToString()
                    },
                    Локація = c.CurrentLocation.Number
                })
                .ToList();

            if (dgvCats.Columns.Contains("Id"))
                dgvCats.Columns["Id"].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            RefreshGrid();
        }

        // -------------------------------------------------------
        // ВИБІР РЯДКА — заповнити поля для редагування
        // -------------------------------------------------------
        private void dgvCats_SelectionChanged(object sender, EventArgs e)
        {
            var cat = GetSelectedCat();
            if (cat == null) return;

            txtName.Text = cat.Nickname;
            numAge.Value = cat.Age;
            cmbHealth.SelectedItem = cat.HealthStatus;
            cmbLocation.SelectedItem = _locationRepo.GetById(cat.CurrentLocation.Id);
        }

        // -------------------------------------------------------
        // ДОПОМІЖНІ
        // -------------------------------------------------------
        private Cat? GetSelectedCat()
        {
            if (dgvCats.SelectedRows.Count == 0) return null;
            int id = (int)dgvCats.SelectedRows[0].Cells["Id"].Value;
            return _catRepo.GetById(id);
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            numAge.Value = 0;
            cmbHealth.SelectedIndex = 0;
            cmbLocation.SelectedIndex = -1;
            dgvCats.ClearSelection();
        }
    }
}
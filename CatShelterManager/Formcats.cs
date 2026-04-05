using System;
using System.Linq;
using System.Windows.Forms;
using CatShelterManager.Models;
using CatShelterManager.Repositories;

namespace CatShelterManager
{
    public partial class FormCats : Form
    {
        private readonly IRepository<Cat> _catRepo;
        private readonly IRepository<Location> _locationRepo;

        public FormCats(IRepository<Cat> catRepo, IRepository<Location> locationRepo)
        {
            _catRepo = catRepo;
            _locationRepo = locationRepo;

            InitializeComponent();
            SetupCombos();
            RefreshGrid();
        }

        private void SetupCombos()
        {
            cmbHealth.DataSource = Enum.GetValues(typeof(HealthStatus));

            cmbLocation.DataSource = null;
            cmbLocation.DataSource = _locationRepo.GetAll().ToList();
            cmbLocation.DisplayMember = "Number"; // або просто ToString() — вже є override
            cmbLocation.SelectedIndex = -1;
        }

        // READ — пряме прив'язування об'єктів до grid.
        // ToString() у Location забезпечує коректний вивід колонки CurrentLocation.
        private void RefreshGrid()
        {
            dgvCats.DataSource = _catRepo.GetAll().ToList();

            if (!dgvCats.Columns.Contains("Nickname")) return;

            dgvCats.Columns["Nickname"].HeaderText = "Кличка";
            dgvCats.Columns["Age"].HeaderText = "Вік";
            dgvCats.Columns["HealthStatus"].HeaderText = "Здоров'я";
            dgvCats.Columns["CurrentLocation"].HeaderText = "Локація";

            if (dgvCats.Columns.Contains("Id"))
                dgvCats.Columns["Id"].Visible = false;
        }

        // CREATE
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedItem == null)
            {
                MessageBox.Show("Оберіть місце утримання — це обов'язкова умова.",
                    "Обов'язкове поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int newId = _catRepo.GetAll().Count > 0
                    ? _catRepo.GetAll().Max(c => c.Id) + 1 : 1;

                var cat = new Cat(
                    newId,
                    txtName.Text,
                    (int)numAge.Value,
                    (HealthStatus)cmbHealth.SelectedItem!,
                    (Location)cmbLocation.SelectedItem
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

        // UPDATE — змінюємо об'єкт через методи моделі, потім повідомляємо репозиторій
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCats.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть кота для редагування.",
                    "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbLocation.SelectedItem == null)
            {
                MessageBox.Show("Оберіть місце утримання.",
                    "Обов'язкове поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримуємо кота напряму з рядка grid — не потрібен GetById
            var cat = dgvCats.SelectedRows[0].DataBoundItem as Cat;
            if (cat == null) return;

            try
            {
                cat.UpdateCatDetails(
                    txtName.Text,
                    (int)numAge.Value,
                    (HealthStatus)cmbHealth.SelectedItem!
                );

                var newLoc = (Location)cmbLocation.SelectedItem;
                if (cat.CurrentLocation.Id != newLoc.Id)
                    cat.AssignLocation(newLoc);

                // Повідомляємо репозиторій про зміну —
                // важливо для майбутнього JsonRepository
                _catRepo.Update(cat);

                RefreshGrid();
                ClearFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Невірні дані",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCats.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть кота для видалення.",
                    "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cat = dgvCats.SelectedRows[0].DataBoundItem as Cat;
            if (cat == null) return;

            var confirm = MessageBox.Show(
                $"Видалити кота '{cat.Nickname}'?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                cat.CurrentLocation.RemoveCat(cat);
                _catRepo.Remove(cat.Id);

                RefreshGrid();
                ClearFields();
            }
        }

        // SEARCH через Find — предикат можна розширювати
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query)) { RefreshGrid(); return; }

            dgvCats.DataSource = _catRepo
                .Find(c => c.Nickname.ToLower().Contains(query)
                        || c.CurrentLocation.Number.ToLower().Contains(query));

            if (dgvCats.Columns.Contains("Id"))
                dgvCats.Columns["Id"].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            RefreshGrid();
        }

        // Вибір рядка — DataBoundItem дає об'єкт напряму, GetById більше не потрібен
        private void dgvCats_SelectionChanged(object sender, EventArgs e)
        {
            var cat = dgvCats.SelectedRows.Count > 0
                ? dgvCats.SelectedRows[0].DataBoundItem as Cat
                : null;

            if (cat == null) return;

            txtName.Text = cat.Nickname;
            numAge.Value = cat.Age;
            cmbHealth.SelectedItem = cat.HealthStatus;
            cmbLocation.SelectedItem = _locationRepo.GetById(cat.CurrentLocation.Id);
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
using System;
using System.Linq;
using System.Windows.Forms;
using CatShelterManager.Models;
using CatShelterManager.Repositories;

namespace CatShelterManager
{
    public partial class FormLocations : Form
    {
        private readonly IRepository<Location> _locationRepo;
        private readonly IRepository<Cat> _catRepo;

        public FormLocations(IRepository<Location> locationRepo, IRepository<Cat> catRepo)
        {
            _locationRepo = locationRepo;
            _catRepo = catRepo;

            InitializeComponent();
            RefreshGrid();
        }

        // READ — пряме прив'язування об'єктів
        private void RefreshGrid()
        {
            dgvLocations.DataSource = _locationRepo.GetAll().ToList();

            if (!dgvLocations.Columns.Contains("Number")) return;

            dgvLocations.Columns["Number"].HeaderText = "Номер";
            dgvLocations.Columns["Description"].HeaderText = "Опис";
            dgvLocations.Columns["Cats"].HeaderText = "Коти";

            if (dgvLocations.Columns.Contains("Id"))
                dgvLocations.Columns["Id"].Visible = false;
        }

        // CREATE
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Введіть номер локації.",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int newId = _locationRepo.GetAll().Count > 0
                    ? _locationRepo.GetAll().Max(l => l.Id) + 1 : 1;

                _locationRepo.Add(new Location(newId, txtNumber.Text, txtDesc.Text));

                RefreshGrid();
                ClearFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Невірні дані",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // UPDATE
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть локацію для редагування.",
                    "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var location = dgvLocations.SelectedRows[0].DataBoundItem as Location;
            if (location == null) return;

            try
            {
                location.Rename(txtNumber.Text);
                location.UpdateDescription(txtDesc.Text);

                // Повідомляємо репозиторій про зміну
                _locationRepo.Update(location);

                RefreshGrid();
                ClearFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Невірні дані",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // DELETE — перевірка з Use Case: не можна видалити якщо є коти
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть локацію для видалення.",
                    "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var location = dgvLocations.SelectedRows[0].DataBoundItem as Location;
            if (location == null) return;

            if (location.Cats.Count > 0)
            {
                MessageBox.Show(
                    $"Не можна видалити '{location.Number}': " +
                    $"прив'язано {location.Cats.Count} кіт(ів).\n" +
                    "Спочатку переведіть або видаліть котів.",
                    "Видалення заблоковано",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Видалити локацію '{location.Number}'?", "Підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _locationRepo.Remove(location.Id);
                RefreshGrid();
                ClearFields();
            }
        }

        // SEARCH через Find
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query)) { RefreshGrid(); return; }

            dgvLocations.DataSource = _locationRepo
                .Find(l => l.Number.ToLower().Contains(query)
                        || l.Description.ToLower().Contains(query));

            if (dgvLocations.Columns.Contains("Id"))
                dgvLocations.Columns["Id"].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            RefreshGrid();
        }

        // Вибір рядка — DataBoundItem напряму
        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            var location = dgvLocations.SelectedRows.Count > 0
                ? dgvLocations.SelectedRows[0].DataBoundItem as Location
                : null;

            if (location == null) return;

            txtNumber.Text = location.Number;
            txtDesc.Text = location.Description;
        }

        private void ClearFields()
        {
            txtNumber.Text = string.Empty;
            txtDesc.Text = string.Empty;
            dgvLocations.ClearSelection();
        }
    }
}
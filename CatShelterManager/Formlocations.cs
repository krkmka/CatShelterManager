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

            txtNumber.TextChanged += Field_ValueChanged;
            txtDesc.TextChanged += Field_ValueChanged;

            btnSave.Enabled = false;
        }

        private bool _isPopulatingFields = false;
        private void Field_ValueChanged(object? sender, EventArgs e)
        {
            if (!_isPopulatingFields && dgvLocations.CurrentRow != null)
            {
                btnSave.Enabled = true;
            }
        }

        private void RefreshGrid()
        {
            dgvLocations.DataSource = _locationRepo.GetAll().ToList();
        }

        // Колонка "Котів" не має DataPropertyName — заповнюємо тут
        private void dgvLocations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLocations.Columns[e.ColumnIndex].Name != "Cats") return;

            var location = dgvLocations.Rows[e.RowIndex].DataBoundItem as Location;
            if (location == null) return;

            e.Value = _catRepo.Find(c => c.LocationId == location.Id).Count.ToString();
            e.FormattingApplied = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Введіть номер локації.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newId = _locationRepo.GetAll().Any()
        ? _locationRepo.GetAll().Max(l => l.Id) + 1 : 1;

            var newLocation = new Location(newId, txtNumber.Text, txtDesc.Text);

            if (!ValidationHelper.TryValidate(newLocation, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Помилка введення даних",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            _locationRepo.Add(newLocation);
            RefreshGrid();
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0) return;

            var location = dgvLocations.SelectedRows[0].DataBoundItem as Location;
            if (location == null) return;

            location.Rename(txtNumber.Text);
            location.UpdateDescription(txtDesc.Text);

            if (!ValidationHelper.TryValidate(location, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Помилка валідації",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshGrid();
                return;
            }

            _locationRepo.Update(location);
            RefreshGrid();
            ClearFields();
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0) return;

            var location = dgvLocations.SelectedRows[0].DataBoundItem as Location;
            if (location == null) return;

            if (_catRepo.Find(c => c.LocationId == location.Id).Any())
            {
                MessageBox.Show(
                    $"Не можна видалити '{location.Number}': є прив'язані коти.\n" +
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(query)) { RefreshGrid(); return; }

            dgvLocations.DataSource = _locationRepo
                .Find(l => l.Number.ToLower().Contains(query)
                        || l.Description.ToLower().Contains(query))
                .ToList();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            RefreshGrid();
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            var location = dgvLocations.SelectedRows.Count > 0
                ? dgvLocations.SelectedRows[0].DataBoundItem as Location
                : null;

            if (location == null) return;
            _isPopulatingFields = true;

            txtNumber.Text = location.Number;
            txtDesc.Text = location.Description;

            _isPopulatingFields = false; 
            btnSave.Enabled = false;     
        }

        private void ClearFields()
        {
            _isPopulatingFields = true;

            txtNumber.Text = string.Empty;
            txtDesc.Text = string.Empty;
            dgvLocations.ClearSelection();

            _isPopulatingFields = false; 
            btnSave.Enabled = false;     
        }

        private void dgvLocations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
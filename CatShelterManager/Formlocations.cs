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

            try
            {
                int newId = _locationRepo.GetAll().Any()
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0) return;

            var location = dgvLocations.SelectedRows[0].DataBoundItem as Location;
            if (location == null) return;

            try
            {
                location.Rename(txtNumber.Text);
                location.UpdateDescription(txtDesc.Text);
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

            txtNumber.Text = location.Number;
            txtDesc.Text = location.Description;
        }

        private void ClearFields()
        {
            txtNumber.Text = string.Empty;
            txtDesc.Text = string.Empty;
            dgvLocations.ClearSelection();
        }

        private void dgvLocations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
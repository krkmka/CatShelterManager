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
            dgvLocations.DataSource = _locationRepo.GetAll()
                .Select(l => new
                {
                    l.Id,
                    Номер = l.Number,
                    Опис = l.Description,
                    Котів = _catRepo.Find(c => c.LocationId == l.Id).Count
                })
                .ToList();

            if (dgvLocations.Columns.Contains("Id"))
                dgvLocations.Columns["Id"].Visible = false;
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
                _locationRepo.Add(new Location(0, txtNumber.Text, txtDesc.Text));
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

            int id = (int)dgvLocations.SelectedRows[0].Cells["Id"].Value;
            var location = _locationRepo.GetById(id);
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

            int id = (int)dgvLocations.SelectedRows[0].Cells["Id"].Value;
            var location = _locationRepo.GetById(id);
            if (location == null) return;

            if (_catRepo.Find(c => c.LocationId == id).Any())
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
                _locationRepo.Remove(id);
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
                .Select(l => new
                {
                    l.Id,
                    Номер = l.Number,
                    Опис = l.Description,
                    Котів = _catRepo.Find(c => c.LocationId == l.Id).Count
                })
                .ToList();

            if (dgvLocations.Columns.Contains("Id"))
                dgvLocations.Columns["Id"].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            RefreshGrid();
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0) return;

            int id = (int)dgvLocations.SelectedRows[0].Cells["Id"].Value;
            var location = _locationRepo.GetById(id);
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
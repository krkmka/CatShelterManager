using System;
using System.Linq;
using System.Windows.Forms;
using CatShelterManager.Models;
using CatShelterManager.Repositories;

namespace CatShelterManager
{
    public partial class FormLocations : Form
    {
        private readonly LocationRepository _locationRepo;
        private readonly CatRepository _catRepo;

        // catRepo потрібен щоб перевіряти чи є коти у локації перед видаленням
        public FormLocations(LocationRepository locationRepo, CatRepository catRepo)
        {
            _locationRepo = locationRepo;
            _catRepo = catRepo;

            InitializeComponent();
            RefreshGrid();
        }

        // -------------------------------------------------------
        // READ
        // -------------------------------------------------------
        private void RefreshGrid()
        {
            dgvLocations.DataSource = _locationRepo.GetAll()
                .Select(l => new
                {
                    l.Id,
                    Номер = l.Number,
                    Опис = l.Description,
                    Котів = l.Cats.Count
                })
                .ToList();

            if (dgvLocations.Columns.Contains("Id"))
                dgvLocations.Columns["Id"].Visible = false;
        }

        // -------------------------------------------------------
        // CREATE
        // -------------------------------------------------------
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
                int newId = _locationRepo.GetAll().Count > 0
                    ? _locationRepo.GetAll().Max(l => l.Id) + 1 : 1;

                var location = new Location(newId, txtNumber.Text, txtDesc.Text);
                _locationRepo.Add(location);

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
            if (dgvLocations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть локацію для редагування.", "Підказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var location = GetSelectedLocation();
            if (location == null) return;

            try
            {
                location.Rename(txtNumber.Text);
                location.UpdateDescription(txtDesc.Text);

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
        // DELETE — з перевіркою з Use Case діаграми
        // -------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть локацію для видалення.", "Підказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var location = GetSelectedLocation();
            if (location == null) return;

            // Обмеження з Use Case: видалення заблоковане якщо є коти
            if (location.Cats.Count > 0)
            {
                MessageBox.Show(
                    $"Не можна видалити локацію '{location.Number}':\n" +
                    $"до неї прив'язано {location.Cats.Count} кіт(ів).\n\n" +
                    "Спочатку переведіть або видаліть котів з цієї локації.",
                    "Видалення заблоковано",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Видалити локацію '{location.Number}'?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _locationRepo.Remove(location.Id);
                RefreshGrid();
                ClearFields();
            }
        }

        // -------------------------------------------------------
        // SEARCH
        // -------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                RefreshGrid();
                return;
            }

            dgvLocations.DataSource = _locationRepo.GetAll()
                .Where(l => l.Number.ToLower().Contains(query)
                         || l.Description.ToLower().Contains(query))
                .Select(l => new
                {
                    l.Id,
                    Номер = l.Number,
                    Опис = l.Description,
                    Котів = l.Cats.Count
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

        // -------------------------------------------------------
        // ВИБІР РЯДКА
        // -------------------------------------------------------
        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            var location = GetSelectedLocation();
            if (location == null) return;

            txtNumber.Text = location.Number;
            txtDesc.Text = location.Description;
        }

        // -------------------------------------------------------
        // ДОПОМІЖНІ
        // -------------------------------------------------------
        private Location? GetSelectedLocation()
        {
            if (dgvLocations.SelectedRows.Count == 0) return null;
            int id = (int)dgvLocations.SelectedRows[0].Cells["Id"].Value;
            return _locationRepo.GetById(id);
        }

        private void ClearFields()
        {
            txtNumber.Text = string.Empty;
            txtDesc.Text = string.Empty;
            dgvLocations.ClearSelection();
        }
    }
}
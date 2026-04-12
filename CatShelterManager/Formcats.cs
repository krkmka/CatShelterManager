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
            cmbLocation.DisplayMember = "Number";
            cmbLocation.SelectedIndex = -1;
        }

        private void RefreshGrid()
        {
            dgvCats.DataSource = _catRepo.GetAll().ToList();

            if (!dgvCats.Columns.Contains("Nickname")) return;

            foreach (DataGridViewColumn col in dgvCats.Columns)
                col.Visible = false;

            dgvCats.Columns["Nickname"].Visible = true;
            dgvCats.Columns["Age"].Visible = true;
            dgvCats.Columns["HealthStatus"].Visible = true;
            dgvCats.Columns["LocationId"].Visible = true;

            dgvCats.Columns["Nickname"].HeaderText = "Кличка";
            dgvCats.Columns["Age"].HeaderText = "Вік";
            dgvCats.Columns["HealthStatus"].HeaderText = "Здоров'я";
            dgvCats.Columns["LocationId"].HeaderText = "Локація";
        }

        private void dgvCats_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCats.Columns[e.ColumnIndex].Name == "LocationId" && e.Value is int locId)
            {
                var location = _locationRepo.GetById(locId);
                if (location != null)
                {
                    e.Value = location.Number;
                    e.FormattingApplied = true;
                }
            }

            if (dgvCats.Columns[e.ColumnIndex].Name == "HealthStatus" && e.Value is HealthStatus status)
            {
                e.Value = status switch
                {
                    HealthStatus.Healthy => "Здоровий",
                    HealthStatus.NeedsCheckup => "Потребує огляду",
                    HealthStatus.InTreatment => "На лікуванні",
                    _ => status.ToString()
                };
                e.FormattingApplied = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedItem is not Location location)
            {
                MessageBox.Show("Оберіть місце утримання.", "Обов'язкове поле",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _catRepo.Add(new Cat(0, txtName.Text, (int)numAge.Value,
                    (HealthStatus)cmbHealth.SelectedItem!, location));
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
            if (dgvCats.SelectedRows.Count == 0) return;
            if (cmbLocation.SelectedItem is not Location newLoc)
            {
                MessageBox.Show("Оберіть місце утримання.", "Обов'язкове поле",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cat = dgvCats.SelectedRows[0].DataBoundItem as Cat;
            if (cat == null) return;

            try
            {
                cat.UpdateCatDetails(txtName.Text, (int)numAge.Value,
                    (HealthStatus)cmbHealth.SelectedItem!);
                cat.UpdateLocation(newLoc.Id);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCats.SelectedRows.Count == 0) return;

            var cat = dgvCats.SelectedRows[0].DataBoundItem as Cat;
            if (cat == null) return;

            if (MessageBox.Show($"Видалити кота '{cat.Nickname}'?", "Підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _catRepo.Remove(cat.Id);
                RefreshGrid();
                ClearFields();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(query)) { RefreshGrid(); return; }

            dgvCats.DataSource = _catRepo
                .Find(c => c.Nickname.ToLower().Contains(query)
                        || (_locationRepo.GetById(c.LocationId)?.Number ?? "").ToLower().Contains(query))
                .Select(c => new
                {
                    c.Id,
                    Кличка = c.Nickname,
                    Вік = c.Age,
                    Здоров_я = c.HealthStatus,
                    Локація = _locationRepo.GetById(c.LocationId)?.Number ?? "—"
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

        private void dgvCats_SelectionChanged(object sender, EventArgs e)
{
    var cat = dgvCats.SelectedRows.Count > 0
        ? dgvCats.SelectedRows[0].DataBoundItem as Cat
        : null;

    if (cat == null) return;

    txtName.Text             = cat.Nickname;
    numAge.Value             = cat.Age;
    cmbHealth.SelectedItem   = cat.HealthStatus;
    cmbLocation.SelectedItem = _locationRepo.GetById(cat.LocationId);
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
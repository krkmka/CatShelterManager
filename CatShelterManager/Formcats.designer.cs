namespace CatShelterManager
{
    partial class FormCats
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvCats;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.GroupBox grpFields;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.ComboBox cmbHealth;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            dgvCats = new System.Windows.Forms.DataGridView();
            grpSearch = new System.Windows.Forms.GroupBox();
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            btnClearSearch = new System.Windows.Forms.Button();
            grpFields = new System.Windows.Forms.GroupBox();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblAge = new System.Windows.Forms.Label();
            numAge = new System.Windows.Forms.NumericUpDown();
            lblHealth = new System.Windows.Forms.Label();
            cmbHealth = new System.Windows.Forms.ComboBox();
            lblLocation = new System.Windows.Forms.Label();
            cmbLocation = new System.Windows.Forms.ComboBox();
            pnlButtons = new System.Windows.Forms.Panel();
            btnAdd = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvCats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            grpSearch.SuspendLayout();
            grpFields.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // dgvCats
            dgvCats.Location = new System.Drawing.Point(12, 12);
            dgvCats.Size = new System.Drawing.Size(860, 250);
            dgvCats.AutoGenerateColumns = true;
            dgvCats.ReadOnly = true;
            dgvCats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvCats.MultiSelect = false;
            dgvCats.AllowUserToAddRows = false;
            dgvCats.AllowUserToDeleteRows = false;
            dgvCats.RowHeadersVisible = false;
            dgvCats.BackgroundColor = System.Drawing.Color.White;
            dgvCats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvCats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvCats.Name = "dgvCats";
            dgvCats.TabIndex = 0;
            dgvCats.SelectionChanged += dgvCats_SelectionChanged;
            dgvCats.CellFormatting += dgvCats_CellFormatting;

            // grpSearch
            grpSearch.Location = new System.Drawing.Point(12, 272);
            grpSearch.Size = new System.Drawing.Size(860, 52);
            grpSearch.Text = "Пошук";
            grpSearch.Name = "grpSearch";
            grpSearch.TabIndex = 1;

            txtSearch.Location = new System.Drawing.Point(10, 18);
            txtSearch.Size = new System.Drawing.Size(630, 24);
            txtSearch.PlaceholderText = "Кличка або локація...";
            txtSearch.Name = "txtSearch";
            txtSearch.TabIndex = 0;

            btnSearch.Text = "Знайти";
            btnSearch.Location = new System.Drawing.Point(648, 16);
            btnSearch.Size = new System.Drawing.Size(90, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.TabIndex = 1;
            btnSearch.Click += btnSearch_Click;

            btnClearSearch.Text = "Скинути";
            btnClearSearch.Location = new System.Drawing.Point(746, 16);
            btnClearSearch.Size = new System.Drawing.Size(100, 28);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.TabIndex = 2;
            btnClearSearch.Click += btnClearSearch_Click;

            grpSearch.Controls.AddRange(new System.Windows.Forms.Control[]
                { txtSearch, btnSearch, btnClearSearch });

            // grpFields
            grpFields.Location = new System.Drawing.Point(12, 334);
            grpFields.Size = new System.Drawing.Size(860, 60);
            grpFields.Text = "Дані кота";
            grpFields.Name = "grpFields";
            grpFields.TabIndex = 2;

            lblName.Text = "Кличка:";
            lblName.Location = new System.Drawing.Point(10, 24);
            lblName.Size = new System.Drawing.Size(60, 22);
            lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblName.Name = "lblName";

            txtName.Location = new System.Drawing.Point(74, 22);
            txtName.Size = new System.Drawing.Size(150, 24);
            txtName.Name = "txtName";
            txtName.TabIndex = 0;

            lblAge.Text = "Вік:";
            lblAge.Location = new System.Drawing.Point(234, 24);
            lblAge.Size = new System.Drawing.Size(36, 22);
            lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblAge.Name = "lblAge";

            numAge.Location = new System.Drawing.Point(274, 22);
            numAge.Size = new System.Drawing.Size(60, 24);
            numAge.Minimum = 0;
            numAge.Maximum = 30;
            numAge.Name = "numAge";
            numAge.TabIndex = 1;

            lblHealth.Text = "Здоров'я:";
            lblHealth.Location = new System.Drawing.Point(344, 24);
            lblHealth.Size = new System.Drawing.Size(72, 22);
            lblHealth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblHealth.Name = "lblHealth";

            cmbHealth.Location = new System.Drawing.Point(420, 22);
            cmbHealth.Size = new System.Drawing.Size(170, 24);
            cmbHealth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbHealth.Name = "cmbHealth";
            cmbHealth.TabIndex = 2;

            lblLocation.Text = "Локація:";
            lblLocation.Location = new System.Drawing.Point(600, 24);
            lblLocation.Size = new System.Drawing.Size(64, 22);
            lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblLocation.Name = "lblLocation";

            cmbLocation.Location = new System.Drawing.Point(668, 22);
            cmbLocation.Size = new System.Drawing.Size(178, 24);
            cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbLocation.Name = "cmbLocation";
            cmbLocation.TabIndex = 3;

            grpFields.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblName, txtName, lblAge, numAge, lblHealth, cmbHealth, lblLocation, cmbLocation });

            // pnlButtons
            pnlButtons.Location = new System.Drawing.Point(12, 406);
            pnlButtons.Size = new System.Drawing.Size(860, 44);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.TabIndex = 3;

            btnAdd.Text = "Додати";
            btnAdd.Location = new System.Drawing.Point(0, 6);
            btnAdd.Size = new System.Drawing.Size(120, 34);
            btnAdd.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Name = "btnAdd";
            btnAdd.TabIndex = 0;
            btnAdd.Click += btnAdd_Click;

            btnEdit.Text = "Редагувати";
            btnEdit.Location = new System.Drawing.Point(128, 6);
            btnEdit.Size = new System.Drawing.Size(120, 34);
            btnEdit.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Name = "btnEdit";
            btnEdit.TabIndex = 1;
            btnEdit.Click += btnEdit_Click;

            btnDelete.Text = "Видалити";
            btnDelete.Location = new System.Drawing.Point(256, 6);
            btnDelete.Size = new System.Drawing.Size(120, 34);
            btnDelete.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Name = "btnDelete";
            btnDelete.TabIndex = 2;
            btnDelete.Click += btnDelete_Click;

            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[]
                { btnAdd, btnEdit, btnDelete });

            // FormCats
            this.Text = "Керування котами";
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.MinimumSize = new System.Drawing.Size(900, 510);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FormCats";

            this.Controls.AddRange(new System.Windows.Forms.Control[]
                { dgvCats, grpSearch, grpFields, pnlButtons });

            ((System.ComponentModel.ISupportInitialize)dgvCats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpFields.ResumeLayout(false);
            grpFields.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
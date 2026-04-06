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

        // Контроли
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
            this.SuspendLayout();

            this.Text = "Керування котами";
            this.Size = new System.Drawing.Size(900, 560);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.BackColor = System.Drawing.Color.White;

            // DataGridView
            dgvCats = new System.Windows.Forms.DataGridView
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(860, 250),
                ReadOnly = true,
                SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(245, 250, 255)
                }
            };
            dgvCats.SelectionChanged += dgvCats_SelectionChanged;

            // Пошук
            grpSearch = new System.Windows.Forms.GroupBox
            {
                Text = "Пошук",
                Location = new System.Drawing.Point(12, 272),
                Size = new System.Drawing.Size(860, 52)
            };
            txtSearch = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(10, 18),
                Size = new System.Drawing.Size(630, 24),
                PlaceholderText = "Кличка або локація..."
            };
            btnSearch = new System.Windows.Forms.Button
            {
                Text = "Знайти",
                Location = new System.Drawing.Point(648, 16),
                Size = new System.Drawing.Size(90, 28)
            };
            btnClearSearch = new System.Windows.Forms.Button
            {
                Text = "Скинути",
                Location = new System.Drawing.Point(746, 16),
                Size = new System.Drawing.Size(100, 28)
            };
            btnSearch.Click += btnSearch_Click;
            btnClearSearch.Click += btnClearSearch_Click;
            grpSearch.Controls.AddRange(new System.Windows.Forms.Control[]
                { txtSearch, btnSearch, btnClearSearch });


            // Поля редагування
            grpFields = new System.Windows.Forms.GroupBox
            {
                Text = "Дані кота",
                Location = new System.Drawing.Point(12, 334),
                Size = new System.Drawing.Size(860, 66)
            };

            lblName = new System.Windows.Forms.Label
            {
                Text = "Кличка:",
                Location = new System.Drawing.Point(10, 26),
                Size = new System.Drawing.Size(60, 22),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtName = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(74, 24),
                Size = new System.Drawing.Size(150, 24)
            };

            lblAge = new System.Windows.Forms.Label
            {
                Text = "Вік:",
                Location = new System.Drawing.Point(234, 26),
                Size = new System.Drawing.Size(36, 22),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            numAge = new System.Windows.Forms.NumericUpDown
            {
                Location = new System.Drawing.Point(274, 24),
                Size = new System.Drawing.Size(60, 24),
                Minimum = 0,
                Maximum = 30
            };

            lblHealth = new System.Windows.Forms.Label
            {
                Text = "Здоров'я:",
                Location = new System.Drawing.Point(344, 26),
                Size = new System.Drawing.Size(72, 22),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            cmbHealth = new System.Windows.Forms.ComboBox
            {
                Location = new System.Drawing.Point(420, 24),
                Size = new System.Drawing.Size(170, 24),
                DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            };

            lblLocation = new System.Windows.Forms.Label
            {
                Text = "Локація:",
                Location = new System.Drawing.Point(600, 26),
                Size = new System.Drawing.Size(64, 22),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            cmbLocation = new System.Windows.Forms.ComboBox
            {
                Location = new System.Drawing.Point(668, 24),
                Size = new System.Drawing.Size(178, 24),
                DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            };

            grpFields.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblName, txtName, lblAge, numAge,
                lblHealth, cmbHealth, lblLocation, cmbLocation
            });

            // Кнопки
            pnlButtons = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(12, 412),
                Size = new System.Drawing.Size(860, 44)
            };

            btnAdd = new System.Windows.Forms.Button
            {
                Text = "Додати",
                Location = new System.Drawing.Point(0, 6),
                Size = new System.Drawing.Size(120, 34),
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10f)
            };
            btnAdd.FlatAppearance.BorderSize = 0;

            btnEdit = new System.Windows.Forms.Button
            {
                Text = "Редагувати",
                Location = new System.Drawing.Point(128, 6),
                Size = new System.Drawing.Size(120, 34),
                BackColor = System.Drawing.Color.FromArgb(33, 150, 243),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10f)
            };
            btnEdit.FlatAppearance.BorderSize = 0;


            btnDelete = new System.Windows.Forms.Button
            {
                Text = "Видалити",
                Location = new System.Drawing.Point(256, 6),
                Size = new System.Drawing.Size(120, 34),
                BackColor = System.Drawing.Color.FromArgb(244, 67, 54),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10f)
            };
            btnDelete.FlatAppearance.BorderSize = 0;

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[]
                { btnAdd, btnEdit, btnDelete });

            this.Controls.AddRange(new System.Windows.Forms.Control[]
                { dgvCats, grpSearch, grpFields, pnlButtons });

            this.ResumeLayout(false);
        }
    }
}

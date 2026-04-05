namespace CatShelterManager
{
    partial class FormLocations
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvLocations;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.GroupBox grpFields;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Text = "Керування локаціями";
            this.Size = new System.Drawing.Size(900, 480);
            this.MinimumSize = new System.Drawing.Size(900, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.BackColor = System.Drawing.Color.White;

            // DataGridView
            dgvLocations = new System.Windows.Forms.DataGridView
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
                    BackColor = System.Drawing.Color.FromArgb(250, 245, 255)
                }
            };
            dgvLocations.SelectionChanged += dgvLocations_SelectionChanged;

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
                PlaceholderText = "Номер або опис локації..."
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
                Text = "Дані локації",
                Location = new System.Drawing.Point(12, 334),
                Size = new System.Drawing.Size(860, 60)
            };

            lblNumber = new System.Windows.Forms.Label
            {
                Text = "Номер/Назва:",
                Location = new System.Drawing.Point(10, 24),
                Size = new System.Drawing.Size(90, 22),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtNumber = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(104, 22),
                Size = new System.Drawing.Size(180, 24)
            };

            lblDesc = new System.Windows.Forms.Label
            {
                Text = "Опис:",
                Location = new System.Drawing.Point(296, 24),
                Size = new System.Drawing.Size(44, 22),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtDesc = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(344, 22),
                Size = new System.Drawing.Size(500, 24)
            };

            grpFields.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblNumber, txtNumber, lblDesc, txtDesc });

            // Кнопки
            pnlButtons = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(12, 406),
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
                BackColor = System.Drawing.Color.FromArgb(156, 39, 176),
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
                { dgvLocations, grpSearch, grpFields, pnlButtons });

            this.ResumeLayout(false);
        }
    }
}
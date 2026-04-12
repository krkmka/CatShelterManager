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
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCats;
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            dgvLocations = new System.Windows.Forms.DataGridView();
            colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpSearch = new System.Windows.Forms.GroupBox();
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            btnClearSearch = new System.Windows.Forms.Button();
            grpFields = new System.Windows.Forms.GroupBox();
            lblNumber = new System.Windows.Forms.Label();
            txtNumber = new System.Windows.Forms.TextBox();
            lblDesc = new System.Windows.Forms.Label();
            txtDesc = new System.Windows.Forms.TextBox();
            pnlButtons = new System.Windows.Forms.Panel();
            btnAdd = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvLocations).BeginInit();
            grpSearch.SuspendLayout();
            grpFields.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // колонки
            colNumber.Name = "Number";
            colNumber.HeaderText = "Номер";
            colNumber.DataPropertyName = "Number";
            colNumber.FillWeight = 25;
            colNumber.MinimumWidth = 6;

            colDescription.Name = "Description";
            colDescription.HeaderText = "Опис";
            colDescription.DataPropertyName = "Description";
            colDescription.FillWeight = 65;
            colDescription.MinimumWidth = 6;

            colCats.Name = "Cats";
            colCats.HeaderText = "Котів";
            colCats.DataPropertyName = "";
            colCats.FillWeight = 10;
            colCats.MinimumWidth = 6;

            dgvLocations.Location = new System.Drawing.Point(12, 12);
            dgvLocations.Size = new System.Drawing.Size(860, 250);
            dgvLocations.AutoGenerateColumns = false;
            dgvLocations.ReadOnly = true;
            dgvLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLocations.MultiSelect = false;
            dgvLocations.AllowUserToAddRows = false;
            dgvLocations.AllowUserToDeleteRows = false;
            dgvLocations.RowHeadersVisible = false;
            dgvLocations.BackgroundColor = System.Drawing.Color.White;
            dgvLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvLocations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocations.ColumnHeadersHeight = 29;
            dgvLocations.Name = "dgvLocations";
            dgvLocations.TabIndex = 0;
            dgvLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                { colNumber, colDescription, colCats });
            dgvLocations.CellFormatting += dgvLocations_CellFormatting;
            dgvLocations.SelectionChanged += dgvLocations_SelectionChanged;
            dgvLocations.CellContentClick += dgvLocations_CellContentClick;

            grpSearch.Location = new System.Drawing.Point(12, 272);
            grpSearch.Size = new System.Drawing.Size(860, 58);
            grpSearch.Text = "Пошук";
            grpSearch.Name = "grpSearch";
            grpSearch.TabIndex = 1;

            txtSearch.Location = new System.Drawing.Point(10, 22);
            txtSearch.Size = new System.Drawing.Size(630, 26);
            txtSearch.PlaceholderText = "Номер або опис локації...";
            txtSearch.Name = "txtSearch";
            txtSearch.TabIndex = 0;

            btnSearch.Text = "Знайти";
            btnSearch.Location = new System.Drawing.Point(648, 20);
            btnSearch.Size = new System.Drawing.Size(90, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.TabIndex = 1;
            btnSearch.Click += btnSearch_Click;

            btnClearSearch.Text = "Скинути";
            btnClearSearch.Location = new System.Drawing.Point(746, 20);
            btnClearSearch.Size = new System.Drawing.Size(100, 28);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.TabIndex = 2;
            btnClearSearch.Click += btnClearSearch_Click;

            grpSearch.Controls.AddRange(new System.Windows.Forms.Control[]
                { txtSearch, btnSearch, btnClearSearch });

            grpFields.Location = new System.Drawing.Point(12, 340);
            grpFields.Size = new System.Drawing.Size(860, 66);
            grpFields.Text = "Дані локації";
            grpFields.Name = "grpFields";
            grpFields.TabIndex = 2;

            lblNumber.Text = "Номер/Назва:";
            lblNumber.Location = new System.Drawing.Point(10, 28);
            lblNumber.Size = new System.Drawing.Size(110, 22);
            lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblNumber.Name = "lblNumber";
            lblNumber.AutoSize = true;

            txtNumber.Location = new System.Drawing.Point(125, 26);
            txtNumber.Size = new System.Drawing.Size(180, 26);
            txtNumber.Name = "txtNumber";
            txtNumber.TabIndex = 0;

            lblDesc.Text = "Опис:";
            lblDesc.Location = new System.Drawing.Point(306, 28);
            lblDesc.Size = new System.Drawing.Size(48, 22);
            lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblDesc.Name = "lblDesc";

            txtDesc.Location = new System.Drawing.Point(358, 26);
            txtDesc.Size = new System.Drawing.Size(486, 26);
            txtDesc.Name = "txtDesc";
            txtDesc.TabIndex = 1;

            grpFields.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblNumber, txtNumber, lblDesc, txtDesc });

            pnlButtons.Location = new System.Drawing.Point(12, 418);
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

            btnSave.Text = "Зберегти зміни";
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(128, 6);
            btnSave.Size = new System.Drawing.Size(120, 34);
            btnSave.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Name = "btnSave";
            btnSave.TabIndex = 1;
            btnSave.Click += btnSave_Click;

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
                { btnAdd, btnSave, btnDelete });

            this.Text = "Керування локаціями";
            this.ClientSize = new System.Drawing.Size(884, 474);
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FormLocations";

            this.Controls.AddRange(new System.Windows.Forms.Control[]
                { dgvLocations, grpSearch, grpFields, pnlButtons });

            ((System.ComponentModel.ISupportInitialize)dgvLocations).EndInit();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpFields.ResumeLayout(false);
            grpFields.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
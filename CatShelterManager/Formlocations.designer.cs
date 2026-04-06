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
            dgvLocations = new DataGridView();
            grpSearch = new GroupBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            grpFields = new GroupBox();
            lblNumber = new Label();
            txtNumber = new TextBox();
            lblDesc = new Label();
            txtDesc = new TextBox();
            pnlButtons = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).BeginInit();
            grpSearch.SuspendLayout();
            grpFields.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLocations
            // 
            dgvLocations.ColumnHeadersHeight = 29;
            dgvLocations.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvLocations.Location = new Point(0, 0);
            dgvLocations.Name = "dgvLocations";
            dgvLocations.RowHeadersWidth = 51;
            dgvLocations.Size = new Size(240, 150);
            dgvLocations.TabIndex = 0;
            dgvLocations.CellContentClick += dgvLocations_CellContentClick;
            dgvLocations.CellFormatting += dgvLocations_CellFormatting;
            dgvLocations.SelectionChanged += dgvLocations_SelectionChanged;
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(btnClearSearch);
            grpSearch.Location = new Point(0, 0);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(200, 100);
            grpSearch.TabIndex = 1;
            grpSearch.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 29);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(0, 0);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(75, 23);
            btnClearSearch.TabIndex = 2;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // grpFields
            // 
            grpFields.Controls.Add(lblNumber);
            grpFields.Controls.Add(txtNumber);
            grpFields.Controls.Add(lblDesc);
            grpFields.Controls.Add(txtDesc);
            grpFields.Location = new Point(0, 0);
            grpFields.Name = "grpFields";
            grpFields.Size = new Size(200, 100);
            grpFields.TabIndex = 2;
            grpFields.TabStop = false;
            // 
            // lblNumber
            // 
            lblNumber.Location = new Point(0, 0);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(100, 23);
            lblNumber.TabIndex = 0;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(0, 0);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(100, 29);
            txtNumber.TabIndex = 1;
            // 
            // lblDesc
            // 
            lblDesc.Location = new Point(0, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(100, 23);
            lblDesc.TabIndex = 2;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(0, 0);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(100, 29);
            txtDesc.TabIndex = 3;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Location = new Point(0, 0);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(200, 100);
            pnlButtons.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Location = new Point(0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Location = new Point(0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // FormLocations
            // 
            BackColor = Color.White;
            ClientSize = new Size(882, 433);
            Controls.Add(dgvLocations);
            Controls.Add(grpSearch);
            Controls.Add(grpFields);
            Controls.Add(pnlButtons);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(900, 480);
            Name = "FormLocations";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Керування локаціями";
            ((System.ComponentModel.ISupportInitialize)dgvLocations).EndInit();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpFields.ResumeLayout(false);
            grpFields.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
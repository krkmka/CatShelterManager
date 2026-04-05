namespace CatShelterManager
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Button btnCats;
        private System.Windows.Forms.Button btnLocations;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlButtons;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ФОРМА
            this.Text = "CatShelter Manager — Менеджер притулку";
            this.Size = new System.Drawing.Size(460, 340);
            this.MinimumSize = new System.Drawing.Size(460, 340);
            this.MaximumSize = new System.Drawing.Size(460, 340);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.BackColor = System.Drawing.Color.White;

            // ЗАГОЛОВОК
            pnlHeader = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 110,
                BackColor = System.Drawing.Color.FromArgb(33, 150, 243)
            };

            lblTitle = new System.Windows.Forms.Label
            {
                Text = "CatShelter Manager",
                Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(400, 40),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            lblSubtitle = new System.Windows.Forms.Label
            {
                Text = "Система управління притулком для котів",
                Font = new System.Drawing.Font("Segoe UI", 10f),
                ForeColor = System.Drawing.Color.FromArgb(220, 240, 255),
                Location = new System.Drawing.Point(22, 62),
                Size = new System.Drawing.Size(400, 26),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // КНОПКИ НАВІГАЦІЇ
            pnlButtons = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(0, 110),
                Size = new System.Drawing.Size(460, 190),
                BackColor = System.Drawing.Color.White
            };

            btnCats = new System.Windows.Forms.Button
            {
                Text = "Керування котами",
                Location = new System.Drawing.Point(40, 40),
                Size = new System.Drawing.Size(360, 44),
                Font = new System.Drawing.Font("Segoe UI", 11f),
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            btnCats.FlatAppearance.BorderSize = 0;

            btnLocations = new System.Windows.Forms.Button
            {
                Text = "Керування локаціями",
                Location = new System.Drawing.Point(40, 100),
                Size = new System.Drawing.Size(360, 44),
                Font = new System.Drawing.Font("Segoe UI", 11f),
                BackColor = System.Drawing.Color.FromArgb(156, 39, 176),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            btnLocations.FlatAppearance.BorderSize = 0;

            btnCats.Click += btnCats_Click;
            btnLocations.Click += btnLocations_Click;

            pnlButtons.Controls.Add(btnCats);
            pnlButtons.Controls.Add(btnLocations);

            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlButtons);

            this.ResumeLayout(false);
        }
    }
}
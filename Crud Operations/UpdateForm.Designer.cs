namespace Crud_Operations
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEmertimi;
        private System.Windows.Forms.TextBox txtEmertimi;
        private System.Windows.Forms.Label lblNjesia;
        private System.Windows.Forms.TextBox txtNjesia;
        private System.Windows.Forms.Label lblDataSkadences;
        private System.Windows.Forms.DateTimePicker dtpDataSkadences;
        private System.Windows.Forms.Label lblCmimi;
        private System.Windows.Forms.TextBox txtCmimi;
        private System.Windows.Forms.Label lblLloj;
        private System.Windows.Forms.GroupBox grpLloj;
        private System.Windows.Forms.RadioButton rbI;
        private System.Windows.Forms.RadioButton rbV;
        private System.Windows.Forms.CheckBox chkTvsh;
        private System.Windows.Forms.Label lblTipi;
        private System.Windows.Forms.ComboBox cmbTipi;
        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            lblEmertimi = new System.Windows.Forms.Label();
            txtEmertimi = new System.Windows.Forms.TextBox();
            lblNjesia = new System.Windows.Forms.Label();
            txtNjesia = new System.Windows.Forms.TextBox();
            lblDataSkadences = new System.Windows.Forms.Label();
            dtpDataSkadences = new System.Windows.Forms.DateTimePicker();
            lblCmimi = new System.Windows.Forms.Label();
            txtCmimi = new System.Windows.Forms.TextBox();
            lblLloj = new System.Windows.Forms.Label();
            grpLloj = new System.Windows.Forms.GroupBox();
            rbI = new System.Windows.Forms.RadioButton();
            rbV = new System.Windows.Forms.RadioButton();
            chkTvsh = new System.Windows.Forms.CheckBox();
            lblTipi = new System.Windows.Forms.Label();
            cmbTipi = new System.Windows.Forms.ComboBox();
            lblBarkod = new System.Windows.Forms.Label();
            txtBarkod = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            int labelX = 20;
            int controlX = 160;
            int startY = 20;
            int spacing = 50;
            int controlHeight = 27;

            // Emertimi
            lblEmertimi.Text = "Emertimi:"; lblEmertimi.Location = new System.Drawing.Point(labelX, startY); lblEmertimi.AutoSize = true;
            txtEmertimi.Location = new System.Drawing.Point(controlX, startY - 3); txtEmertimi.Size = new System.Drawing.Size(250, controlHeight);

            // Njesia
            lblNjesia.Text = "Njesia:"; lblNjesia.Location = new System.Drawing.Point(labelX, startY + spacing); lblNjesia.AutoSize = true;
            txtNjesia.Location = new System.Drawing.Point(controlX, startY + spacing - 3); txtNjesia.Size = new System.Drawing.Size(250, controlHeight);

            // Data Skadences
            lblDataSkadences.Text = "Data Skadences:"; lblDataSkadences.Location = new System.Drawing.Point(labelX, startY + 2 * spacing); lblDataSkadences.AutoSize = true;
            dtpDataSkadences.Location = new System.Drawing.Point(controlX, startY + 2 * spacing - 3); dtpDataSkadences.Size = new System.Drawing.Size(250, controlHeight);
            dtpDataSkadences.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Cmimi
            lblCmimi.Text = "Cmimi:"; lblCmimi.Location = new System.Drawing.Point(labelX, startY + 3 * spacing); lblCmimi.AutoSize = true;
            txtCmimi.Location = new System.Drawing.Point(controlX, startY + 3 * spacing - 3); txtCmimi.Size = new System.Drawing.Size(250, controlHeight);

            // Lloj (Radio buttons)
            lblLloj.Text = "Lloj:"; lblLloj.Location = new System.Drawing.Point(labelX, startY + 4 * spacing); lblLloj.AutoSize = true;
            grpLloj.Location = new System.Drawing.Point(controlX, startY + 4 * spacing - 5); grpLloj.Size = new System.Drawing.Size(250, 40); grpLloj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rbI.Text = "Importi"; rbI.Location = new System.Drawing.Point(10, 10); rbI.AutoSize = true;
            rbV.Text = "Vendi"; rbV.Location = new System.Drawing.Point(120, 10); rbV.AutoSize = true; rbV.Checked = true;
            grpLloj.Controls.Add(rbI); grpLloj.Controls.Add(rbV);

            // TVSH checkbox
            chkTvsh.Text = "Ka TVSH?"; chkTvsh.Location = new System.Drawing.Point(controlX, startY + 5 * spacing - 3); chkTvsh.AutoSize = true;

            // Tipi ComboBox
            lblTipi.Text = "Tipi:"; lblTipi.Location = new System.Drawing.Point(labelX, startY + 6 * spacing); lblTipi.AutoSize = true;
            cmbTipi.Location = new System.Drawing.Point(controlX, startY + 6 * spacing - 3); cmbTipi.Size = new System.Drawing.Size(250, controlHeight);
            cmbTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipi.Items.AddRange(new string[] { "Ushqimore", "Bulmet", "Pije", "Embelsire" });

            // Barkod
            lblBarkod.Text = "Barkod/Kod:"; lblBarkod.Location = new System.Drawing.Point(labelX, startY + 7 * spacing); lblBarkod.AutoSize = true;
            txtBarkod.Location = new System.Drawing.Point(controlX, startY + 7 * spacing - 3); txtBarkod.Size = new System.Drawing.Size(250, controlHeight);

            // Buttons
            btnSave.Text = "Save"; btnSave.Location = new System.Drawing.Point(50, startY + 8 * spacing); btnSave.Size = new System.Drawing.Size(100, 30); btnSave.Click += btnSave_Click;
            btnCancel.Text = "Cancel"; btnCancel.Location = new System.Drawing.Point(180, startY + 8 * spacing); btnCancel.Size = new System.Drawing.Size(100, 30); btnCancel.Click += btnCancel_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(450, startY + 9 * spacing);
            this.Controls.Add(lblEmertimi); this.Controls.Add(txtEmertimi);
            this.Controls.Add(lblNjesia); this.Controls.Add(txtNjesia);
            this.Controls.Add(lblDataSkadences); this.Controls.Add(dtpDataSkadences);
            this.Controls.Add(lblCmimi); this.Controls.Add(txtCmimi);
            this.Controls.Add(lblLloj); this.Controls.Add(grpLloj);
            this.Controls.Add(chkTvsh);
            this.Controls.Add(lblTipi); this.Controls.Add(cmbTipi);
            this.Controls.Add(lblBarkod); this.Controls.Add(txtBarkod);
            this.Controls.Add(btnSave); this.Controls.Add(btnCancel);

            this.Name = "UpdateForm";
            this.Text = "Edit Artikull";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

namespace Crud_Operations
{
    partial class AddForm
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
        private System.Windows.Forms.RadioButton rbI;
        private System.Windows.Forms.RadioButton rbV;
        private System.Windows.Forms.GroupBox grpLloj;

        private System.Windows.Forms.CheckBox chkTvsh;

        private System.Windows.Forms.Label lblTipi;
        private System.Windows.Forms.ComboBox cmbTipi;

        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblEmertimi = new System.Windows.Forms.Label();
            this.txtEmertimi = new System.Windows.Forms.TextBox();

            this.lblNjesia = new System.Windows.Forms.Label();
            this.txtNjesia = new System.Windows.Forms.TextBox();

            this.lblDataSkadences = new System.Windows.Forms.Label();
            this.dtpDataSkadences = new System.Windows.Forms.DateTimePicker();

            this.lblCmimi = new System.Windows.Forms.Label();
            this.txtCmimi = new System.Windows.Forms.TextBox();

            this.lblLloj = new System.Windows.Forms.Label();
            this.rbI = new System.Windows.Forms.RadioButton();
            this.rbV = new System.Windows.Forms.RadioButton();
            this.grpLloj = new System.Windows.Forms.GroupBox();

            this.chkTvsh = new System.Windows.Forms.CheckBox();

            this.lblTipi = new System.Windows.Forms.Label();
            this.cmbTipi = new System.Windows.Forms.ComboBox();

            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

         
            int labelX = 20;
            int controlX = 160;
            int startY = 20;
            int verticalSpacing = 40;

            // Emertimi
            this.lblEmertimi.Text = "Emertimi:";
            this.lblEmertimi.Location = new System.Drawing.Point(labelX, startY);
            this.lblEmertimi.AutoSize = true;

            this.txtEmertimi.Location = new System.Drawing.Point(controlX, startY - 3);
            this.txtEmertimi.Size = new System.Drawing.Size(250, 27);

            // Njesia
            this.lblNjesia.Text = "Njesia:";
            this.lblNjesia.Location = new System.Drawing.Point(labelX, startY + verticalSpacing);
            this.lblNjesia.AutoSize = true;

            this.txtNjesia.Location = new System.Drawing.Point(controlX, startY + verticalSpacing - 3);
            this.txtNjesia.Size = new System.Drawing.Size(250, 27);

            // Data Skadences
            this.lblDataSkadences.Text = "Data Skadences:";
            this.lblDataSkadences.Location = new System.Drawing.Point(labelX, startY + 2 * verticalSpacing);
            this.lblDataSkadences.AutoSize = true;

            this.dtpDataSkadences.Location = new System.Drawing.Point(controlX, startY + 2 * verticalSpacing - 3);
            this.dtpDataSkadences.Size = new System.Drawing.Size(250, 27);
            this.dtpDataSkadences.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Cmimi
            this.lblCmimi.Text = "Cmimi:";
            this.lblCmimi.Location = new System.Drawing.Point(labelX, startY + 3 * verticalSpacing);
            this.lblCmimi.AutoSize = true;

            this.txtCmimi.Location = new System.Drawing.Point(controlX, startY + 3 * verticalSpacing - 3);
            this.txtCmimi.Size = new System.Drawing.Size(250, 27);

            // Lloj (Radio buttons)
            this.lblLloj.Text = "Lloj:";
            this.lblLloj.Location = new System.Drawing.Point(labelX, startY + 4 * verticalSpacing);
            this.lblLloj.AutoSize = true;

            this.grpLloj.Location = new System.Drawing.Point(controlX, startY + 4 * verticalSpacing - 5);
            this.grpLloj.Size = new System.Drawing.Size(250, 40);
            this.grpLloj.Controls.Add(this.rbI);
            this.grpLloj.Controls.Add(this.rbV);
            this.grpLloj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.rbI.Text = "I";
            this.rbI.Location = new System.Drawing.Point(10, 10);
            this.rbI.AutoSize = true;

            this.rbV.Text = "V";
            this.rbV.Location = new System.Drawing.Point(80, 10);
            this.rbV.AutoSize = true;

            // Ka TVSH (CheckBox)
            this.chkTvsh.Text = "Ka TVSH?";
            this.chkTvsh.Location = new System.Drawing.Point(controlX, startY + 5 * verticalSpacing - 3);
            this.chkTvsh.AutoSize = true;

            // Tipi (ComboBox)
            this.lblTipi.Text = "Tipi:";
            this.lblTipi.Location = new System.Drawing.Point(labelX, startY + 6 * verticalSpacing);
            this.lblTipi.AutoSize = true;

            this.cmbTipi.Location = new System.Drawing.Point(controlX, startY + 6 * verticalSpacing - 3);
            this.cmbTipi.Size = new System.Drawing.Size(250, 27);
            this.cmbTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipi.Items.AddRange(new string[] { "Ushqimore", "Bulmet", "Pije", "Embelsire" });

            // Barkod
            this.lblBarkod.Text = "Barkod/Kod:";
            this.lblBarkod.Location = new System.Drawing.Point(labelX, startY + 7 * verticalSpacing);
            this.lblBarkod.AutoSize = true;

            this.txtBarkod.Location = new System.Drawing.Point(controlX, startY + 7 * verticalSpacing - 3);
            this.txtBarkod.Size = new System.Drawing.Size(250, 27);

            // Buttons
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(50, startY + 8 * verticalSpacing);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(180, startY + 8 * verticalSpacing);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddForm
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.lblEmertimi);
            this.Controls.Add(this.txtEmertimi);
            this.Controls.Add(this.lblNjesia);
            this.Controls.Add(this.txtNjesia);
            this.Controls.Add(this.lblDataSkadences);
            this.Controls.Add(this.dtpDataSkadences);
            this.Controls.Add(this.lblCmimi);
            this.Controls.Add(this.txtCmimi);
            this.Controls.Add(this.lblLloj);
            this.Controls.Add(this.grpLloj);
            this.Controls.Add(this.chkTvsh);
            this.Controls.Add(this.lblTipi);
            this.Controls.Add(this.cmbTipi);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.Text = "Shto Artikuj";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

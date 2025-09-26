using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Crud_Operations.Data;

namespace Crud_Operations
{
    public partial class UpdateForm : Form
    {
        private DatabaseHelper dbHelper;
        private int artikullId;

        public UpdateForm(DatabaseHelper helper, int id, string emertimi, string njesia, string dataSkadences,
                          double cmimi, string lloj, int tvsh, string tipi, string barkod)
        {
            InitializeComponent();
            dbHelper = helper;
            artikullId = id;

            txtEmertimi.Text = emertimi;
            txtNjesia.Text = njesia;
            dtpDataSkadences.Value = DateTime.Parse(dataSkadences);
            txtCmimi.Text = cmimi.ToString("F2");
            rbI.Checked = lloj == "I";
            rbV.Checked = lloj == "V";
            chkTvsh.Checked = tvsh == 1;
            cmbTipi.SelectedItem = tipi;
            txtBarkod.Text = barkod;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();

                string emertimi = string.IsNullOrWhiteSpace(txtEmertimi.Text) ? null : txtEmertimi.Text.Trim();
                string njesia = string.IsNullOrWhiteSpace(txtNjesia.Text) ? null : txtNjesia.Text.Trim();
                string dataSkadences = dtpDataSkadences.Value.ToString("yyyy-MM-dd");
                string lloj = rbI.Checked ? "I" : "V";
                int tvsh = chkTvsh.Checked ? 1 : 0;
                string tipi = cmbTipi.SelectedItem?.ToString();
                string barkod = string.IsNullOrWhiteSpace(txtBarkod.Text) ? null : txtBarkod.Text.Trim();

                // Check if barcode already exists 
                if (!string.IsNullOrWhiteSpace(barkod))
                {
                    var existing = dbHelper.ExecuteQuery(
                        "SELECT COUNT(*) FROM artikuj WHERE barkod=@barkod AND id<>@id",
                        new SqliteParameter("@barkod", barkod),
                        new SqliteParameter("@id", artikullId)
                    );

                    if (existing.Rows.Count > 0 && Convert.ToInt32(existing.Rows[0][0]) > 0)
                    {
                        MessageBox.Show("Barkodi tashmë ekziston! Ju lutem shkruani një barkod tjetër.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = "UPDATE artikuj SET ";
                var parameters = new System.Collections.Generic.List<SqliteParameter>();

                if (emertimi != null) { query += "emertimi=@emertimi, "; parameters.Add(new SqliteParameter("@emertimi", emertimi)); }
                if (njesia != null) { query += "njesia=@njesia, "; parameters.Add(new SqliteParameter("@njesia", njesia)); }

                query += "data_skadences=@data, lloj=@lloj, ka_tvsh=@tvsh";
                parameters.Add(new SqliteParameter("@data", dataSkadences));
                parameters.Add(new SqliteParameter("@lloj", lloj));
                parameters.Add(new SqliteParameter("@tvsh", tvsh));

                if (double.TryParse(txtCmimi.Text.Trim(), out double cmimi)) { query += ", cmimi=@cmimi"; parameters.Add(new SqliteParameter("@cmimi", cmimi)); }
                if (!string.IsNullOrWhiteSpace(tipi)) { query += ", tipi=@tipi"; parameters.Add(new SqliteParameter("@tipi", tipi)); }
                if (barkod != null) { query += ", barkod=@barkod"; parameters.Add(new SqliteParameter("@barkod", barkod)); }

                query += " WHERE id=@id";
                parameters.Add(new SqliteParameter("@id", artikullId));

                dbHelper.ExecuteNonQuery(query, parameters.ToArray());

                MessageBox.Show("Artikulli u perditesua me sukses!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error duke perditesuar artikullin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

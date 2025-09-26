using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Crud_Operations.Data;

namespace Crud_Operations
{
    public partial class AddForm : Form
    {
        private DatabaseHelper dbHelper;

        public AddForm(DatabaseHelper helper)
        {
            InitializeComponent();
            dbHelper = helper;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmertimi.Text) ||
                    string.IsNullOrWhiteSpace(txtNjesia.Text) ||
                    string.IsNullOrWhiteSpace(txtCmimi.Text))
                {
                    MessageBox.Show("Ju lutem plotësoni të gjitha fushat e detyrueshme!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kontrollo Cmimin
                if (!double.TryParse(txtCmimi.Text.Trim(), out double cmimi))
                {
                    MessageBox.Show("Ju lutem shkruani një numër të vlefshëm për Cmimin!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string emertimi = txtEmertimi.Text.Trim();
                string njesia = txtNjesia.Text.Trim();
                string dataSkadences = dtpDataSkadences.Value.ToString("yyyy-MM-dd");
                string lloj = rbI.Checked ? "I" : "V";
                int tvsh = chkTvsh.Checked ? 1 : 0;
                string tipi = cmbTipi.SelectedItem?.ToString() ?? "";
                string barkod = txtBarkod.Text.Trim();

                // Check if barcode already exists
                var existing = dbHelper.ExecuteQuery(
                    "SELECT COUNT(*) FROM artikuj WHERE barkod = @barkod",
                    new SqliteParameter("@barkod", barkod)
                );

                if (existing.Rows.Count > 0 && Convert.ToInt32(existing.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Barkodi tashmë ekziston! Ju lutem shkruani një barkod tjetër.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ruaj në databazë
                dbHelper.ExecuteNonQuery(
                    "INSERT INTO artikuj (emertimi, njesia, data_skadences, cmimi, lloj, ka_tvsh, tipi, barkod) " +
                    "VALUES (@emertimi,@njesia,@data,@cmimi,@lloj,@tvsh,@tipi,@barkod)",
                    new SqliteParameter("@emertimi", emertimi),
                    new SqliteParameter("@njesia", njesia),
                    new SqliteParameter("@data", dataSkadences),
                    new SqliteParameter("@cmimi", cmimi),
                    new SqliteParameter("@lloj", lloj),
                    new SqliteParameter("@tvsh", tvsh),
                    new SqliteParameter("@tipi", tipi),
                    new SqliteParameter("@barkod", barkod)
                );

                MessageBox.Show("Artikulli u shtua me sukses!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error duke shtuar artikullin: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

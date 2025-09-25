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
                
                string emertimi = txtEmertimi.Text.Trim();
                string njesia = txtNjesia.Text.Trim();
                string dataSkadences = dtpDataSkadences.Value.ToString("yyyy-MM-dd"); 
                double cmimi = double.Parse(txtCmimi.Text.Trim());
                string lloj = rbI.Checked ? "I" : "V"; 
                int tvsh = chkTvsh.Checked ? 1 : 0; 
                string tipi = cmbTipi.SelectedItem?.ToString() ?? "";
                string barkod = txtBarkod.Text.Trim();

               
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

                MessageBox.Show("Artikuj u shtuan!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding artikuj: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

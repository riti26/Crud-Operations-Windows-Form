using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Crud_Operations.Data;

namespace Crud_Operations
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();

            string dbPath = @"C:\Users\Riti\Desktop\mydb.sqlite";
            dbHelper = new DatabaseHelper(dbPath);
            LoadData();
            AddActionButtons();
            btnAdd.Click += btnAdd_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        // Load data from DB into DataGridView
        private void LoadData()
        {
            DataTable dt = dbHelper.ExecuteQuery("SELECT * FROM artikuj");
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Contains("id"))
                dataGridView1.Columns["id"].Visible = false;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = (col.Name == "Update" || col.Name == "Delete")
                    ? DataGridViewAutoSizeColumnMode.AllCells
                    : DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddForm(dbHelper))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["id"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {
                string emertimi = row.Cells["emertimi"].Value.ToString();
                string njesia = row.Cells["njesia"].Value.ToString();
                string dataSkadences = row.Cells["data_skadences"].Value.ToString();
                double cmimi = Convert.ToDouble(row.Cells["cmimi"].Value);
                string lloj = row.Cells["lloj"].Value.ToString();
                int tvsh = Convert.ToInt32(row.Cells["ka_tvsh"].Value);
                string tipi = row.Cells["tipi"].Value.ToString();
                string barkod = row.Cells["barkod"].Value.ToString();

                using (var updateForm = new UpdateForm(dbHelper, id, emertimi, njesia, dataSkadences, cmimi, lloj, tvsh, tipi, barkod))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("A jeni i sigurt qe deshironi te fshini kete artikull?", "Konfirmo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbHelper.ExecuteNonQuery("DELETE FROM artikuj WHERE id=@id", new SqliteParameter("@id", id));
                    LoadData();
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text.Trim().Replace("'", "''"); // Escape single quotes

            if (dataGridView1.DataSource is DataTable dt)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = $"emertimi LIKE '%{filterText}%' OR lloj LIKE '%{filterText}%'";
                }
            }
        }
    }
}

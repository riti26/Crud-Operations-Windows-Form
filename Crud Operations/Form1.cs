using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Crud_Operations.Data;

namespace Crud_Operations
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;
        private string dbPath;

        public Form1()
        {
            InitializeComponent();

            
            dbPath = Path.Combine(Application.StartupPath, "mydb.sqlite");

           
            if (!File.Exists(dbPath))
            {
                DatabaseHelper.CreateDatabase(dbPath); 
            }

            dbHelper = new DatabaseHelper(dbPath);

            this.Load += Form1_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string searchTerm = "")
        {
            try
            {
                string query = "SELECT * FROM artikuj";
                SqliteParameter[] parameters = null;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE emertimi LIKE @term OR lloj LIKE @term";
                    parameters = new[] { new SqliteParameter("@term", "%" + searchTerm + "%") };
                }

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                dataGridView1.DataSource = dt;

                AddDeleteButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void AddDeleteButton()
        {
            if (dataGridView1.Columns.Contains("Delete"))
                dataGridView1.Columns.Remove("Delete");

            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "🗑",
                UseColumnTextForButtonValue = true,
                Width = 60,
                FlatStyle = FlatStyle.Standard
            });

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = (col.Name == "Delete")
                    ? DataGridViewAutoSizeColumnMode.AllCells
                    : DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                var result = MessageBox.Show("Je i sigurte qe do te fshishe kete artikull?",
                    "Konfirmo fshirjen", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dbHelper.ExecuteNonQuery("DELETE FROM artikuj WHERE id=@id",
                        new SqliteParameter("@id", id));

                    LoadData(txtSearch.Text.Trim());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddForm(dbHelper))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}

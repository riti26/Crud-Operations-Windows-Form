using Microsoft.Data.Sqlite;
using System.Data;
using System.IO;

namespace Crud_Operations.Data
{
    public class DatabaseHelper
    {
        private readonly string connectionString;
        private static string _dbPath;

        public DatabaseHelper()
        {
            connectionString = $"Data Source={_dbPath}";
        }

        public DataTable ExecuteQuery(string query, params SqliteParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (var con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqliteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public int ExecuteNonQuery(string query, params SqliteParameter[] parameters)
        {
            using (var con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqliteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateDatabase(string dbPath)
        {
            _dbPath = dbPath;
            if (File.Exists(dbPath))
                return;

            using (var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE artikuj (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        emertimi TEXT NOT NULL,
                        njesia TEXT NOT NULL,
                        data_skadences TEXT,
                        cmimi REAL,
                        lloj TEXT,
                        ka_tvsh INTEGER,
                        tipi TEXT,
                        barkod TEXT
                    );";
                using (var cmd = new SqliteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

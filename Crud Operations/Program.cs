using Crud_Operations.Data;

namespace Crud_Operations
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string dbPath = Path.Combine(Application.StartupPath, "mydb.sqlite");

            if (!File.Exists(dbPath))
            {
                DatabaseHelper.CreateDatabase(dbPath);
            }
            Application.Run(new Form1());
        }
    }
}
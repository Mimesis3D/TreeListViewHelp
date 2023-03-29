using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace EntityFramework
{
    public class MainDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        private string? _connectionString;
        private string? dbDirectory;

        public MainDbContext CreateDbContext(string[]? args = null)
        {
            dbDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                @"\DevExpressHelpMe\db\";

            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            _connectionString = "Data Source=" + dbDirectory + "Example.db";

            return new MainDbContext(new DbContextOptionsBuilder().UseSqlite(_connectionString).Options);
        }
    }
}

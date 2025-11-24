using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Data.Sqlite;
using System.IO;

namespace WebGoatCore.Data
{
    public class NorthwindContextFactory : IDesignTimeDbContextFactory<NorthwindContext>
    {
        public NorthwindContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();

            // Build the connection string for design-time
            var builder = new SqliteConnectionStringBuilder();

            // Use current directory or specify the path to your NORTHWND.sqlite
            builder.DataSource = Path.Combine(Directory.GetCurrentDirectory(), "NORTHWND.sqlite");

            // Or if the database is in a specific location:
            // builder.DataSource = @"C:\path\to\your\NORTHWND.sqlite";

            optionsBuilder.UseSqlite(builder.ConnectionString);

            return new NorthwindContext(optionsBuilder.Options);
        }
    }
}
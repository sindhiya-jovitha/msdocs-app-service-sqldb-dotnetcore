using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreSqlDb.Data // <-- Make sure this namespace matches your project
{
    public class MyDatabaseContextFactory : IDesignTimeDbContextFactory<MyDatabaseContext>
    {
        public MyDatabaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MyDatabaseContext>();

            // IMPORTANT: Replace "MyConnectionString" with the name of your connection string in appsettings.json
            var connectionString = configuration.GetConnectionString("MyConnectionString"); 

            optionsBuilder.UseSqlServer(connectionString); // Or UseSqlite(), UseNpgsql(), etc.

            return new MyDatabaseContext(optionsBuilder.Options);
        }
    }
}
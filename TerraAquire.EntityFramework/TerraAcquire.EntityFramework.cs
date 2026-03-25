using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TerraAcquire.EntityFramework
{
    public class DefaultDbContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
    {
        public DefaultDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DefaultDbContext>();

            // Use your MySQL connection string here
            optionsBuilder.UseMySql(
                "server=localhost;database=TerraAcquireDb;user=root;password=your_password",
                new MySqlServerVersion(new Version(8, 0, 33))
            );

            return new DefaultDbContext(optionsBuilder.Options);
        }
    }
}
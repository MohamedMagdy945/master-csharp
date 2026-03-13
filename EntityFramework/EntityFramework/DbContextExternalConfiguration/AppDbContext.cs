

using EntityFrameworkCore_DotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_DotNet.DbContextExternalConfiguration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public static void Main1()
        {
            var options = new DbContextOptionsBuilder().
                UseSqlServer("Server=.;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;").Options;

            //var context = new AppDbContext(options);

            using (var context = new AppDbContext(options))
            {

            }

        }
    }

}

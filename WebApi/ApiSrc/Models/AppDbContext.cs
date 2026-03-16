using Microsoft.EntityFrameworkCore;

namespace ApiSrc.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=CompnayDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

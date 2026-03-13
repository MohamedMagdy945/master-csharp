

using EntityFrameworkCore_DotNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore_DotNet.DbContextDependencyInjection
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlServer("Server=.;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    public class Program
    {
        public static void Main()
        {
            var options = new DbContextOptionsBuilder();

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                foreach (var emp in context!.Employees)
                {
                    Console.WriteLine($"Id : {emp.Id} - Name {emp.Name}  -  Salary : {emp.Salary}");
                }
            }

        }
    }

}
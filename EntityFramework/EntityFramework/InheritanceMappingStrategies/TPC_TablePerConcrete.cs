using EntityFrameworkCore_DotNet.Entities.InheritanceMappingStrategies;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_DotNet.InheritanceMappingStrategies
{
    class TPC_TablePerConcrete
    {
        public class AppDbContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Person>().UseTpcMappingStrategy();
            }
        }
        public class Program
        {
            public void Run()
            {
                using var context = new AppDbContext();

                context.Add(new Student
                {
                    Name = "Ali",
                    Grade = 90
                });

                context.Add(new Teacher
                {
                    Name = "Sara",
                    Salary = 5000
                });

                context.SaveChanges();
            }
        }
    }
}

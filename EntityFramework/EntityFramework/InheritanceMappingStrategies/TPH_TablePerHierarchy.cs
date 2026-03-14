using EntityFrameworkCore_DotNet.Entities.InheritanceMappingStrategies;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_DotNet.InheritanceMappingStrategies
{
    class TPH_TablePerHierarchy
    {
        public class AppDbContext : DbContext
        {
            public DbSet<Person> People { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Person>()
                    .HasDiscriminator<string>("PersonType")
                    .HasValue<Student>("Student")
                    .HasValue<Teacher>("Teacher");
            }

        }
        public class Program
        {
            public static void Run()
            {
                using var context = new AppDbContext();

                // Add a student
                context.Add(new Student
                {
                    Name = "Ali",
                    Grade = 90
                });

                // Add a teacher
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

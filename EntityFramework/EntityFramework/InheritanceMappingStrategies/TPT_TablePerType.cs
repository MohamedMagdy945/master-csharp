using EntityFrameworkCore_DotNet.Entities.InheritanceMappingStrategies;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_DotNet.InheritanceMappingStrategies
{
    class TPT_TablePerType
    {
        public class AppDbContext : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Person>().ToTable("People");
                modelBuilder.Entity<Student>().ToTable("Students");
                modelBuilder.Entity<Teacher>().ToTable("Teachers");
            }
        }
        public class Program
        {
            public static void Run()
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

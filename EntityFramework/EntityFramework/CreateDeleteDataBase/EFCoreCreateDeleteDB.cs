using EntityFrameworkCore_DotNet.Data;
using EntityFrameworkCore_DotNet.Entities;

namespace EntityFrameworkCore_DotNet.CreateDeleteDataBase
{
    internal class EFCoreCreateDeleteDB
    {
        class Program
        {
            public static void Run()
            {
                using var context = new AppDbContext();


                context.Database.EnsureCreated();

                context.Employees.Add(new Employee
                {
                    Name = "Ali"
                });

                context.Employees.Add(new Employee
                {
                    Name = "Sara"
                });

                context.SaveChanges();

                context.Database.EnsureDeleted();
            }
        }

    }
}

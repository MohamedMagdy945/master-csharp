using EntityFrameworkCore_DotNet.Data;
using EntityFrameworkCore_DotNet.Entities;

namespace EntityFrameworkCore_DotNet.SeedData
{
    internal class DynamicSeedData
    {
        class Program
        {

            public static void Seed(AppDbContext context)
            {
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee
                        {
                            Name = "Ali"
                        },
                        new Employee
                        {
                            Name = "Sara"
                        }
                    );
                }
            }
        }
    }
}

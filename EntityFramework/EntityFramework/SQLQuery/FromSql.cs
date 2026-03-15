using EntityFrameworkCore_DotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_DotNet.SQLQuery
{
    internal class FromSql
    {
        public static void Run()
        {
            using var context = new AppDbContext();

            int empId = 1;

            // استخدام FromSqlRaw بدل FromSql (لأنه FromSql deprecated في EF Core 7+)
            var c1 = context.Employees
                .FromSqlRaw($"SELECT * FROM dbo.Employees WHERE Id = {empId}")
                .FirstOrDefault();

        }
    }
}

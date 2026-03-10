
namespace Linq.master.Group
{
    internal class GroupDemo
    {
        // -----------------------
        // GroupBy
        // -----------------------
        public void GroupByDepartment()
        {
            var _employees = Employee.GetEmployees();
            var groups = _employees.GroupBy(e => e.Department).ToList();

            foreach (var group in groups)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var emp in group)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine("--------------------");
            }
        }
        // -----------------------
        // ToLookup
        // -----------------------
        public void LookupByDepartment()
        {
            var _employees = Employee.GetEmployees();
            var lookup = _employees.ToLookup(e => e.Department);

            Console.WriteLine("Employees in HR:");

            foreach (var emp in lookup["HR"])
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("--------------------");

            Console.WriteLine("Employees in IT:");

            foreach (var emp in lookup["IT"])
            {
                Console.WriteLine(emp);
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee> {
                new Employee{ Id=1, Name="Alice", Department="HR"},
                new Employee{ Id=2, Name="Bob", Department="Finance"},
                new Employee{ Id=3, Name="Charlie", Department="IT"},
                new Employee{ Id=4, Name="David", Department="HR"},
                new Employee{ Id=5, Name="Eve", Department="IT"}
            };
        }
        public override string ToString()
            => $"{Id} - {Name} - {Department}";
    }
}

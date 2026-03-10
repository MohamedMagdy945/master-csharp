
namespace Linq.master.Quantifier
{
    internal class QuantifierDemo
    {
        // --------------------------------
        // Any : هل يوجد عنصر يحقق الشرط؟
        // --------------------------------
        public List<Employee> _employees { get; set; } = Employee.GetEmployees();
        public void AnyExample()
        {
            bool result = _employees.Any(e => e.Salary > 5500);

            Console.WriteLine("Any Salary > 5500 ?");
            Console.WriteLine(result);
            Console.WriteLine("-------------------");
        }

        // --------------------------------
        // All : Do all elements meet the condition?
        // --------------------------------
        public void AllExample()
        {
            bool result = _employees.All(e => e.Salary > 4000);

            Console.WriteLine("All Salary > 4000 ?");
            Console.WriteLine(result);
            Console.WriteLine("-------------------");
        }

        // --------------------------------
        // Contains :Do elements exists ?
        // --------------------------------
        public void ContainsExample()
        {
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 5000 };

            bool result = _employees.Contains(employee);

            Console.WriteLine("Contains Alice object ?");
            Console.WriteLine(result);
            Console.WriteLine("-------------------");
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>() {             
                new Employee { Id = 1, Name = "Alice", Salary = 5000 },
                new Employee { Id = 2, Name = "Bob", Salary = 4500 },
                new Employee { Id = 3, Name = "Charlie", Salary = 6000 },
                new Employee { Id = 4, Name = "David", Salary = 5500 }
            };
        }
        public override string ToString() => $"{Id} - {Name} - {Salary}";
    }

    class QuatifierExample
    {
        public static void Use()
        {
            QuantifierDemo demo = new QuantifierDemo();

            demo.AnyExample();
            demo.AllExample();
            demo.ContainsExample();
        }
    }
}

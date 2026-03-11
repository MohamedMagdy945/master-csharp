using System;
using System.Collections;


namespace Linq.master.Sets
{
    internal class SetDemo
    {
        public class SetsDemo
        {

           public static void Run() {
                List<Employee> _employees1 = Employee.GetEmployees1();
                List<Employee> _employees2 = Employee.GetEmployees2();
                // 1️ Distinct
                var distinctList = _employees1.Distinct();
                Console.WriteLine("Distinct list1:");
                foreach (var e in distinctList) Console.WriteLine(e);

                Console.WriteLine("------------------");

                // 2️ Union
                var union = _employees1.Union(_employees2);
                Console.WriteLine("Union list1 + list2:");
                foreach (var e in union) Console.WriteLine(e);

                Console.WriteLine("------------------");

                // 3️ Intersect
                var intersect = _employees1.Intersect(_employees2);
                Console.WriteLine("Intersect list1 & list2:");
                foreach (var e in intersect) Console.WriteLine(e);

                Console.WriteLine("------------------");

                // 4️ Except
                var except = _employees1.Except(_employees2);
                Console.WriteLine("Except list1 - list2:");
                foreach (var e in except) Console.WriteLine(e);

                Console.WriteLine("------------------");

                // 5️ Contains
                var emp = new Employee { Id = 2, Name = "Bob" };
                Console.WriteLine($"Does _employees1 contain Bob? {_employees1.Contains(emp)}");
            }
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }


            public static List<Employee> GetEmployees1()
            {
                return new List<Employee>
                {
                    new Employee{ Id=1, Name="Alice"},
                    new Employee{ Id=2, Name="Bob"},
                    new Employee{ Id=3, Name="Charlie"},
                    new Employee{ Id=2, Name="Bob"} // duplicate
                };
            }
            public static List<Employee> GetEmployees2()
            {
                return new List<Employee>
                {
                    new Employee{ Id=2, Name="Bob"},
                    new Employee{ Id=4, Name="David"},
                    new Employee{ Id=3, Name="Charlie"}
                };
            }

            public override string ToString() => $"{Id} - {Name}";

            // For Distinct and set operations, override equality
            public override bool Equals(object obj)
            {
                return obj is Employee e && e.Id == Id && e.Name == Name;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name);
            }
        }

    }
}

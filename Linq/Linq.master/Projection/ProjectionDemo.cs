
namespace Linq.master.Projection
{
    internal class ProjectionDemo
    {
        public static void SelectExample1()
        {
            List<string> words = new List<string>() { "i" , "learn" , "asp.net" , "core" };
            var result = words.Select(x => x.ToUpper());
            
            var result2 = from word in words
                          select word.ToUpper();  

            // I LEARN ASP.NET CORE
            foreach (string word in result)
            {
                Console.Write(word + " ");
            }
        }
        public static void SelectExample2()
        {
            var emps = Employee.GetSampleEmployees();

            var result = emps.Select(e => new EmployeeDTO() { Id = e.Id, SkillsCount = e.Skills.Count(), });

            foreach (var emp in result)
            {
                Console.WriteLine($"Id : {emp.Id} , SkillsCount : {emp.SkillsCount}"); 
            }    
        }
        public static void SelectMany()
        {
            var emps = Employee.GetSampleEmployees();
            var result = emps.SelectMany(e => e.Skills) ;

            var result2 = from emp in emps
                          from skill in emp.Skills
                          select skill;

            foreach (var skill in result2)
            {
                Console.Write(skill + " ");
            }
            Console.WriteLine();
            foreach (var skill in result2)
            {
                Console.Write(skill + " ");
            }
        }
        public static void Zip()
        {
            string[] colorName = { "Red", "Green", "Blue" };
            string[] colorHEX = { "FF0000", "00FF00", "0000FF" };

            var colors = colorName.Zip(colorHEX, (name, hex) => $"{name} ({hex})");

            foreach (var c in colors)
            {
                Console.WriteLine(c);
            }

            Console.ReadKey();
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; } 
        public List<string> Skills { get; set; } = new List<string>();
        public static List<Employee> GetSampleEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR" , Skills = new() { "c#" , "ASP" } },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Skills = new() { "Java" , "SprintBoot" }},
                new Employee { Id = 3, Name = "Charlie", Department = "Finance" , Skills = new() { "Python" , "ASP" }},
                new Employee { Id = 4, Name = "David", Department = "Marketing" , Skills = new() { "C++" , "GameDevelopment" }}
            };
        }
    }
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int SkillsCount { get; set; }
    }
}

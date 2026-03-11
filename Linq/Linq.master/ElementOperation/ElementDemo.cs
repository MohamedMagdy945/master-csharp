
namespace Linq.master.ElementOperation
{
    internal class ElementIterationDemo
    {
        public static IEnumerable<int> GenerateNumbers(int count)
        {
            return Enumerable.Range(1, count); // 1,2,3,...count
        }


        public  static void Run()
        {
            var numbers = GenerateNumbers(5); // 1,2,3,4,5

            // 1️⃣ foreach
            Console.WriteLine("=== Foreach ===");
            foreach (var n in numbers)
                Console.WriteLine(n);

            // 2️⃣ ElementAt
            Console.WriteLine("\n=== ElementAt(2) ===");
            Console.WriteLine(numbers.ElementAt(2)); // (0-based index) 3th element

            // 3️⃣ First / FirstOrDefault
            Console.WriteLine("\n=== First / FirstOrDefault ===");
            Console.WriteLine(numbers.First());          // first element
            Console.WriteLine(numbers.FirstOrDefault()); // first element or default if not exists

            // 4️⃣ Last / LastOrDefault
            Console.WriteLine("\n=== Last / LastOrDefault ===");
            Console.WriteLine(numbers.Last());          //  last element
            Console.WriteLine(numbers.LastOrDefault()); // first element or default if not exists

            // 5️⃣ Single / SingleOrDefault
            Console.WriteLine("\n=== Single / SingleOrDefault ===");
            var singleNumber = Enumerable.Range(10, 1); // element
            Console.WriteLine(singleNumber.Single(x => x==10)); // 10

            // 6️⃣ Take / Skip
            Console.WriteLine("\n=== Take(3) ===");
            foreach (var n in numbers.Take(3))
                Console.WriteLine(n); // 1,2,3

            Console.WriteLine("\n=== Skip(2) ===");
            foreach (var n in numbers.Skip(2))
                Console.WriteLine(n); // 3,4,5

            var numberList = numbers.ToList();
            var numberArray = numbers.ToArray();
            Console.WriteLine("\n=== Stored in List / Array ===");
            Console.WriteLine("List count: " + numberList.Count);
            Console.WriteLine("Array length: " + numberArray.Length);
        }
    }
  
}

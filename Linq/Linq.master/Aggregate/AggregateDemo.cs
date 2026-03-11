namespace Linq.master.Aggregate
{
    internal class AggregateDemo
    {
        public static void Run()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // 1️) sum number
            var sum = numbers.Aggregate((acc, n) => acc + n);
            Console.WriteLine($"Sum = {sum}");

            // 2️) multiple number
            var mulitple = numbers.Aggregate((acc, n) => acc * n);
            Console.WriteLine($"Mulitple = {mulitple}");

            // 3) use seed value
            var sumWithSeed = numbers.Aggregate(10, (acc, n) => acc + n);
            Console.WriteLine($"Sum with seed = {sumWithSeed}");

            // 4) convert list to string
            var text = numbers.Aggregate("Numbers:",
                (acc, n) => acc + " ||  " + n);

            Console.WriteLine(text);

            // 5) max
            var max = numbers.Aggregate((acc, n) =>
                acc > n ? acc : n);

            Console.WriteLine($"Max = {max}");
        }
    }
}

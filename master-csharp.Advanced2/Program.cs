

namespace master_csharp.Advanced2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RecordUsage.Use();

            string x = test();

            Console.WriteLine(x.ToLower());   

            Person p1 = null ;

            Console.WriteLine(p1.Name.ToString());

            bool ij = IsLong(x);

        }
        public static bool IsLong(string? s)
        {
            if (test().Length < 2)
            {
                s = ",s";
                //s = null;
                Console.WriteLine("s");
            }
            
            return s.Length > 10;
        }
        public static string test()
        {
            return null ;
            return "x";
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

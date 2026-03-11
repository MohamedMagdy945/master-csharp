
using Linq.master.ElementOperation;
using Linq.master.Quantifier;

namespace Linq.master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DefferdDemo.Use();
            //ProjectionDemo.SelectExample2(); 
            //ProjectionDemo.SelectMany(); 
            //QuatifierExample.Use();
            //List<string> names = new() { "ahmed", "mohamed" , "mohamed"};

            //string? name = names.FirstOrDefault(x => x == "mohamed");

            //Console.WriteLine(name);
            ElementIterationDemo.Run();

        }
    }
}

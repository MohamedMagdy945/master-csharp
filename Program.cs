using master_csharp.App.Indexer;

namespace master_csharp.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Indexer 

            Student std = new Student();
            std["Math"] = 1;
            Console.WriteLine(std["Math"]);
       
        }
      
    }
}

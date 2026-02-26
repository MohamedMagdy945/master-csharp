

namespace master_csharp.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                StructUsage stuctUsage = new StructUsage();
                StructUsage.Test();

                //EnumUsage en = new EnumUsage();
                //en.Test();

                GenericUsage.Test();
                string x = " sd";
                x.ToString();   
                Console.ReadLine();
            }
        }
    }
}


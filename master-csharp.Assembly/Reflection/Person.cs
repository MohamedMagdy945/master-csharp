using System;
using System.Reflection;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {Name}");
    }
}

class Program
{
    static void Main()
    {
        Type type = typeof(Person); // Get type information

        Console.WriteLine("Properties:");
        foreach (var prop in type.GetProperties())
        {
            Console.WriteLine(prop.Name + " : " + prop.PropertyType);
        }

        Console.WriteLine("\nMethods:");
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine(method.Name);
        }
    }
}
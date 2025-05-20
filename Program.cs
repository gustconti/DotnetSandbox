using DotnetSandbox.DataStructures;
using DotnetSandbox.DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("== Data Structure Demos ==");

        // StackDemo.Run();
        Console.WriteLine("== LinkedListDemo Demo ==");
        LinkedListDemo.Run();
        Console.WriteLine("== ListDemo Demo ==");
        ListDemo.Run();
        Console.WriteLine("== QueueDemo Demo ==");
        QueueDemo.Run();
        Console.WriteLine("== DictionaryDemo Demo ==");
        DictionaryDemo.Run();

        // Console.WriteLine("\n== Design Pattern Demos ==");

        // SingletonDemo.Run();
        // FactoryDemo.Run();

        // Person personA = new() { Name = "Gustavo", Age = 31 };
        // Person personB = new() { Name = "Gustavo", Age = 31 }; // duplicate
        // Person personC = new() { Name = "Joe", Age = 40 };

        // Console.WriteLine(personA == personB);
        // Console.WriteLine(personA.Equals(personB));
        // Console.WriteLine(personA is Person);

        // int a = 1;
        // int b = 1;
        // Console.WriteLine(a == b);

        // var dict = new Dictionary<Person, string>
        // {
        //     [personA] = "Gay",
        //     [personB] = "Hetero"
        // };

        // Console.WriteLine("\n");
        // Console.WriteLine("OI {0}", dict);

        // foreach (var kvp in dict)
        // {
        //     Console.WriteLine("Age: {0}, Name: {1}, Value: {2}", kvp.Key.Age, kvp.Key.Name, kvp.Value);
        // }

        // Console.WriteLine("\n");
        // Console.WriteLine("\n");
        // Console.WriteLine("Contains person A? {0}", dict.ContainsKey(personA));
        // Console.WriteLine("Contains person B? {0}", dict.ContainsKey(personB));
        // Console.WriteLine("Contains person C? {0}", dict.ContainsKey(personC));
    }
    // public class Person
    // {
    //     public string Name { get; set; } = String.Empty;
    //     public int Age { get; set; }
    //     public override bool Equals(object? obj)
    //     {
    //         if (obj is Person other)
    //         {
    //             return Name == other.Name && Age == other.Age;
    //         }
    //         return false;
    //     }
    //     public override int GetHashCode()
    //     {
    //         return HashCode.Combine(Age, Name);
    //     }
    // }
}



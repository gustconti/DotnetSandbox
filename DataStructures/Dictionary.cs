using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace DotnetSandbox.DataStructures;

public static class DictionaryDemo
{

    public static void ValuesDictionary()
    {
        string personA = "Gustavo";
        string personB = "Gustavo";
        string personC = "John";
        var telephoneList = new Dictionary<string, string>
        {
            [personA] = "+55(11)91234-0000",
            [personC] = "+55(11)91234-0002"
        };

        /* personA and personB are value type variables.
         * They can be equated to each other, and also 
         * used interchangibly as indexes
         */
        var equalityOperator = personA == personB;
        var indexTest = telephoneList[personA] == telephoneList[personB];
        var equalsMethodTest = telephoneList[personA].Equals(telephoneList[personB]);
        var containsTest = telephoneList.ContainsKey(personB);

        Console.WriteLine("personA == personB? {0}", equalityOperator);
        Console.WriteLine("dictionary[personA] == dictionary[personB] {0}", indexTest);
        Console.WriteLine("Equals(personB) {0}", equalsMethodTest);
        Console.WriteLine("Contains(personB) {0}", containsTest);
    }
    public static void RefsDictionary()
    {

        var personA = new Person() { Name = "Gustavo", Age = 31 };
        var personB = new Person() { Name = "Gustavo", Age = 31 };
        var personC = new Person() { Name = "John", Age = 30 };

        var telephoneList = new Dictionary<Person, string>
        {
            [personA] = "+55(11)91234-0000",
            [personC] = "+55(11)91234-0002",
        };

        foreach (var element in telephoneList)
        {
            Console.WriteLine("Name: {0}, Telephone: {1}", element.Key.Name, element.Value);
        }

        /* personA and personB are value type variables.
         * They can be equated to each other, and also 
         * used interchangibly as indexes
         */
        var equalityOperator = personA == personB;
        var indexTest = telephoneList[personA] == telephoneList[personB];
        var equalsMethodTest = telephoneList[personA].Equals(telephoneList[personB]);
        var containsTest = telephoneList.ContainsKey(personB);

        Console.WriteLine("personA == personB? {0}", equalityOperator);
        Console.WriteLine("dictionary[personA] == dictionary[personB] {0}", indexTest);
        Console.WriteLine("Equals(personB) {0}", equalsMethodTest);
        Console.WriteLine("Contains(personB) {0}", containsTest);
    }

    public static void Run()
    {
        RefsDictionary();
        ValuesDictionary();
    }
    
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        // Equals() now compares prop values instead of referenced class instance
        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return Name == other.Name && Age == other.Age;
            }
            return false;
        }

        public override int GetHashCode()
        {
            /*
             * Generated hash code is now based on prop values instead of 
             * referenced class instance, making more complex 
             */
            return HashCode.Combine(Name, Age);
        }
    }
}
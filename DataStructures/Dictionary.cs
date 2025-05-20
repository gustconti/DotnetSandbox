namespace DotnetSandbox.DataStructures;

public static class DictionaryDemo
{
    public static void ValuesDictionary()
    {
        // Value type variables holding strings as values
        string personA = "Gustavo";
        string personB = "Gustavo"; // same value as personA
        string personC = "John";

        // Dictionary using strings (value types) as keys
        var telephoneList = new Dictionary<string, string>
        {
            [personA] = "+55(11)91234-0000",
            [personC] = "+55(11)91234-0002"
        };

        // Iterating through dictionary items using foreach
        foreach (var element in telephoneList)
        {
            Console.WriteLine("Name: {0}, Telephone: {1}", element.Key, element.Value);
        }

        // Dictionary allows duplicate values
        telephoneList.Add("Bob", "+55(11)91234-0000");

        // But not duplicate keys. TryAdd avoids exception.
        telephoneList.TryAdd("Gustavo", "+55(11)91234-0001");

        // Value comparison: strings with same content are equal
        Console.WriteLine("personA == personB? {0}", personA == personB);

        // Keys with same value resolve to same entry
        Console.WriteLine("dictionary[personA] == dictionary[personB] {0}",
            telephoneList[personA] == telephoneList[personB]
        );

        // Equals also compares string values
        Console.WriteLine("Equals(personB) {0}",
            telephoneList[personA].Equals(telephoneList[personB]));

        // ContainsKey uses Equals() and GetHashCode() under the hood
        Console.WriteLine("Contains(personB) {0}\n",
            telephoneList.ContainsKey(personB));
    }

    public static void RefsDictionary()
    {
        // Reference type variables (Person objects)
        var personA = new Person { Name = "Gustavo", Age = 31 };
        var personB = new Person { Name = "Gustavo", Age = 31 }; // same data, different instance
        var personC = new Person { Name = "John", Age = 30 };

        // Dictionary using reference types as keys
        var telephoneList = new Dictionary<Person, string>
        {
            [personA] = "+55(11)91234-0000",
            [personC] = "+55(11)91234-0002",
        };

        // Reference equality check (false for different instances)
        Console.WriteLine("personA == personB? {0}", personA == personB);

        // Compares dictionary values. Works even though personA == personB returns false, 
        // because Equals() and GetHashCode() have been overriden
        Console.WriteLine("dictionary[personA] == dictionary[personB] {0}",
            telephoneList[personA] == telephoneList[personB]); // Will throw without Equals + GetHashCode override

        // Equals() would return false without the override. Here, it compares the 
        // prop values between the referrenced class instances and returns true 
        Console.WriteLine("Equals(personB) {0}",
            telephoneList[personA].Equals(telephoneList[personB]));

        // ContainsKey relies on Equals() and GetHashCode()
        Console.WriteLine("Contains(personB) {0}",
            telephoneList.ContainsKey(personB));
    }

    public static void Run()
    {
        ValuesDictionary();
        RefsDictionary();
    }

    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        // Overriding Equals() to compare values instead of reference
        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return Name == other.Name && Age == other.Age;
            }
            return false;
        }

        // Overriding GetHashCode() to build hash codes based on prop values
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }
}

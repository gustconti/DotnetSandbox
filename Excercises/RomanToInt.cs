namespace DotnetSandbox.Excercises
{
    public class RomanToIntsProblem
    {
        private static readonly int[] arabicValues = new int[128];
        public static void Run()
        {
            string test1 = "III", test2 = "LVIII", test3 = "MCMXCIV";
            Console.WriteLine($"{test1} = {RomanToInt(test1)}");
            Console.WriteLine($"{test2} = {RomanToInt(test2)}");
            Console.WriteLine($"{test3} = {RomanToInt(test3)}");
        }

        // Array approach, more performant
        public static int RomanToInt(ReadOnlySpan<char> s)
        {
            // Using chars as the indexes is possible just like in C
            // because arrays are equivalent to their ASCII numeric values
            arabicValues['I'] = 1;
            arabicValues['V'] = 5;
            arabicValues['X'] = 10;
            arabicValues['L'] = 50;
            arabicValues['C'] = 100;
            arabicValues['D'] = 500;
            arabicValues['M'] = 1000;

            int convertedNumber = 0, previousValue = 0, currentValue = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                currentValue = arabicValues[s[i]];
                if (currentValue >= previousValue) convertedNumber += currentValue;
                else convertedNumber -= currentValue;
                previousValue = currentValue;
            }
            return convertedNumber;
        }

        // Dict approach, less performant
        // private static void AddRomanCharToNum(int value, ref int convertedNumber, ref int previousValue)
        // {
        //     if (value >= previousValue) convertedNumber += value;
        //     else convertedNumber -= value;
        //     previousValue = value;
        // }
        // private static int RomanToInt(ReadOnlySpan<char> s)
        // {
        //     var intValues = new Dictionary<char, int>()
        //     {
        //         ['I'] = 1,
        //         ['V'] = 5,
        //         ['X'] = 10,
        //         ['L'] = 50,
        //         ['C'] = 100,
        //         ['D'] = 500,
        //         ['M'] = 1000
        //     };
        //     int convertedNumber = 0, previousValue = 0;
        //     for (int i = s.Length - 1; i >= 0; i--)
        //     {
        //         AddRomanCharToNum(intValues[s[i]], ref convertedNumber, ref previousValue);
        //     }
        //     Console.WriteLine($"Backwards Loop - {s} = {convertedNumber}");
        //     return convertedNumber;
        // }
    }
}
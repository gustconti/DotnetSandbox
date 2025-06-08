namespace DotnetSandbox.Excercises
{
    public class LargestCommonPrefixProblem
    {
        public static void Run()
        {
            string[] test1 = ["flower", "flow", "flight"],
            test2 = ["dog", "racecar", "car"],
            test3 = ["big", "bigger", "biggest", "biggot", "biggoted"],
            test4 = ["ab", "a"];
            Console.WriteLine($"{string.Join(", ", test1)} = {LongestCommonPrefix(test1)}");
            Console.WriteLine($"{string.Join(", ", test2)} = {LongestCommonPrefix(test2)}");
            Console.WriteLine($"{string.Join(", ", test3)} = {LongestCommonPrefix(test3)}");
            Console.WriteLine($"{string.Join(", ", test4)} = {LongestCommonPrefix(test4)}");
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            string prefix = strs[0];

            // For each word starting from the second
            for (int i = 1; i < strs.Length; i++)
            {
                string currentWord = strs[i];
                int j = 0;
                
                while (j < currentWord.Length && j < prefix.Length && currentWord[j] == prefix[j])
                {
                    j++;
                }

                prefix = prefix[..j];
            }

            return prefix;
        }
    }
}
namespace DotnetSandbox.Excercises
{
    public class IntPalindromeProblem
    {
        public static void Run()
        {
            int test1 = 121, test2 = 123, test3 = 10, test4 = 1000001;

            Console.WriteLine($"Input: {test1}. Result: {IsPalindrome(test1)}");
            Console.WriteLine($"Input: {test2}. Result: {IsPalindrome(test2)}");
            Console.WriteLine($"Input: {test3}. Result: {IsPalindrome(test3)}");
            Console.WriteLine($"Input: {test4}. Result: {IsPalindrome(test4)}");
        }
        private static bool IsPalindrome(in int x)
        {

            int reversed = 0;

            // Variable to hold the changing 
            // source number as we remove its characters 
            int sourceNum = x;

            while (sourceNum > 0)
            {
                // The rest of a division by 10 is always the last digit of the number
                int digit = sourceNum % 10;

                // Multiply by 10 to move the digits left by one place 
                // then add the extracted digit to the units place 
                reversed = reversed * 10 + digit;

                // Integer division by 10 removes the last digit from the number
                sourceNum /= 10;
            }

            return x == reversed;
        }
    }
}
namespace DotnetSandbox.Excercises
{
    public class ValidBracketsProblem
    {

        public static void Run()
        {
            // '(', ')', '{', '}', '[', ']'
            // Open brackets must be closed by the same type of brackets.
            // Open brackets must be closed in the correct order.
            // Every close bracket has a corresponding open bracket of the same type.
            // Input: s = "()"
            // Output: true
            // Input: s = "()[]{}"
            // Output: true
            // Input: s = "(]"
            // Output: false
            // Input: s = "([])"
            // Output: true
            string
                   test1 = "())",
                   test2 = "()[]{}",
                   test3 = "(]",
                   test4 = "([])",
                   test5 = "([{}(){}]){{}",
                   test6 = ")[{}(){}]";

            Console.WriteLine($"{test1} = {IsValid(test1)}");
            Console.WriteLine($"{test2} = {IsValid(test2)}");
            Console.WriteLine($"{test3} = {IsValid(test3)}");
            Console.WriteLine($"{test4} = {IsValid(test4)}");
            Console.WriteLine($"{test5} = {IsValid(test5)}");
            Console.WriteLine($"{test6} = {IsValid(test6)}");
        }
        public static bool IsValid(string s)
        {
            // 1. First Solution
            // Dictionary<char, char> bracketPairs = new()
            // {
            //     ['('] = ')',
            //     ['['] = ']',
            //     ['{'] = '}'
            // };
            // Stack<char> openPairs = new();
            // // if the input string is empty, return false
            // if (string.IsNullOrEmpty(s)) return false;
            // // if the string begins with a closing bracket, return false
            // if (!bracketPairs.ContainsKey(s[0])) return false;
            // for (int i = 0; i < s.Length; i++)
            // {
            //     char currentChar = s[i];
            //     bool isOpeningBracket = bracketPairs.ContainsKey(currentChar);
            //     bool isClosingBracket = bracketPairs.ContainsValue(currentChar);
            //     if (!isOpeningBracket && !isClosingBracket) return false;
            //     // Store pair to be closed
            //     if (isOpeningBracket)
            //     {
            //         openPairs.Push(currentChar);
            //     }
            //     else if (isClosingBracket)
            //     {
            //         // if there are no pairs to close or brackets do not match
            //         if (openPairs.Count == 0 || currentChar != bracketPairs[openPairs.Peek()])
            //             return false;
            //         // "Close pair" removing it from stack
            //         openPairs.Pop();
            //     }
            // }
            // return openPairs.Count is 0;



            // 2. Solution with Replace
            // while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
            // {
            //     s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
            // }
            // return s.Length == 0;



            // // 3. Solution with stack to keep just the closing brackets
            // var k = new Stack<char>();
            // foreach(char c in s) {
            //     // Push closing round bracket onto the stack
            //     if (c == '(') { k.Push(')'); continue; }
            //     // Push closing curly bracket onto the stack
            //     if (c == '{') { k.Push('}'); continue; }
            //     // Push closing square bracket onto the stack
            //     if (c == '[') { k.Push(']'); continue; }
            //     // Look out for imbalanced strings or mismatches
            //     if (k.Count == 0 || c != k.Pop()) return false;
            // }
            // // Empty stack means string is valid and invalid otherwise
            // return k.Count == 0;


            // 4. Fastest Solution using stackalloc and Span<char>
            if(s[0]==')'||s[0]==']'||s[0]=='}') return false;
            // Avoids GC allocations by using stack memory
            Span<char> stack = stackalloc char[(s.Length + 1) / 2];
            // The top of the stack; starts at -1 to represent an empty stack
            int top = -1;

            // Iterate through each character in the input string
            foreach (char c in s)
            {
                // If it's an opening bracket, push it onto the stack
                if (c == '(' || c == '{' || c == '[')
                {
                    // Pre-increment top, then assign the character to that index
                    // Equivalent to: top++; stack[top] = c;
                    stack[++top] = c;
                }
                // If the stack is empty and we find a closing bracket,
                // there's no matching opening bracket — invalid input
                else if (top < 0)
                {
                    return false;
                }
                // If the character matches the last opening bracket in the stack,
                // it's a valid closing — so pop the stack by decrementing top
                else if ((c == ')' && stack[top] == '(')
                      || (c == '}' && stack[top] == '{')
                      || (c == ']' && stack[top] == '['))
                {
                    top--;
                }
                // If none of the conditions match, it's an invalid bracket sequence
                else
                {
                    return false;
                }
            }

            // If the stack is empty, all brackets matched correctly
            return top == -1;
        }
    }
}
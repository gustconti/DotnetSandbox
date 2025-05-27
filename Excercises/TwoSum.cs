namespace DotnetSandbox.Excercises
{
    public class Solution
    {
        public static void Run()
        {
            int[] test1 = [2, 7, 11, 15], test2 = [2, 7, 11, 15], test3 = [2, 7, 11, 15];
            int target1 = 9, target2 = 6, target3 = 6;
            Console.WriteLine($"array: {string.Join(", ", test1)}, target: {target1}, result: {TwoSum(test1, target1)}");
            Console.WriteLine($"array: {string.Join(", ", test2)}, target: {target2}, result: {TwoSum(test2, target2)}");
            Console.WriteLine($"array: {string.Join(", ", test3)}, target: {target3}, result: {TwoSum(test3, target3)}");
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            if (
                nums.Length < 2
                || nums.Length > 10_000
                || target < -1_000_000_000
                || target > 1_000_000_000
            ) return [];
            

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < -1_000_000_000 || nums[i] > 1_000_000_000) continue;
                int complement = target - nums[i];
                if (dict.TryGetValue(complement, out int index))
                {
                    return [index, i];
                }
                dict[nums[i]] = i;
            }

            return [];
        }
    }
}
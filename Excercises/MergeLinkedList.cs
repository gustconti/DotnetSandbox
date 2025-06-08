namespace DotnetSandbox.Excercises
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
        public override string ToString()
        {
            return val.ToString() + next?.ToString();
        }
    }
    public class MergeTwoListsProblem
    {
        public static void Run()
        {
            // Input: list1 = [1,2,4], list2 = [1,3,4]
            // Output: [1,1,2,3,4,4]
            // Input: list1 = [], list2 = []
            // Output: []
            // Input: list1 = [], list2 = [0]
            // Output: [0]

            ListNode head1 = new(1, new ListNode(2, new ListNode(4)));
            ListNode head2 = new(1, new ListNode(3, new ListNode(4)));
            ListNode head3 = new();
            ListNode head4 = new(0, null);

            Console.WriteLine($"{MergeTwoListsRecursive(head1, head2)}");
        }
        private static ListNode MergeTwoListsRecursive(ListNode head1, ListNode head2)
        {
            // Input: list1 = [1,2,4], list2 = [1,3,4]
            // Output: [1,1,2,3,4,4]
            if (head1 is null) return head2;
            if (head2 is null) return head1;

            if (head1.val <= head2.val)
            {
                head1.next = MergeTwoListsRecursive(head1.next, head2);
                return head1;
            }
            else
            {
                head2.next = MergeTwoListsRecursive(head1, head2.next);
                return head2;
            }
        }

        private static ListNode MergeTwoLists()
        {
            
        }
    }
}
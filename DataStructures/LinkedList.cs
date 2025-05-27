namespace DotnetSandbox.DataStructures
{
    public class LinkedListDemo
    {
        public static void CustomLinkedListTest()
        {

        }

        public class Node<T>(T value)
        {
            public T Value = value;
            public Node<T>? Next = null;
        }

        public class CustomLinkedList<T>()
        {
            public Node<T>? Head = null;

            public void AddFirst(T value)
            {
                Node<T> newNode = new(value)
                {
                    Next = Head
                };
                Head = newNode;
            }

            public void AddLast(T value)
            {
                Node<T> newNode = new(value);

                // If list head is empty, add new node to the head
                if (Head is null)
                {
                    Head = newNode;
                    return;
                }

                // Create variable to store current node
                Node<T> current = Head;

                // Iterate through the list
                while (current.Next is not null)
                {
                    // Store next node in 'current' variable 
                    current = current.Next;
                }
                // Once current.Next is null, fill it out with the newNode
                current.Next = newNode;
            }

            public bool AddBefore(T targetValue, T newValue)
            {
                // 1. If the very first node (Head) is null, the list is empty,
                //    there's nothing to insert before, so return false.
                if (Head is null) return false;

                // 2. If the very first node (Head) contains the targetValue,
                //    we just add the new node at the front (before Head).
                if (EqualityComparer<T>.Default.Equals(Head.Value, targetValue))
                {
                    AddFirst(newValue);
                    return true;
                }

                // 3. Otherwise, we start at the head and traverse the list.
                Node<T> current = Head;

                // 4. We look ahead to the next node in each iteration:
                //    We continue while the next node exists and its value is NOT the targetValue.
                while (current.Next is not null && !EqualityComparer<T>.Default.Equals(current.Next.Value, targetValue))
                {
                    current = current.Next;
                }

                // 5. If we reached the end of the list without finding targetValue,
                //    current.Next will be null and insertion can't happen.
                if (current.Next is null) return false;

                // 6. If we found the node whose value matches targetValue at current.Next,
                //    create a new node with newValue
                Node<T> newNode = new(newValue);

                // 7. Insert newNode before current.Next by:
                //    pointing newNode.Next to current.Next
                newNode.Next = current.Next;

                // 8. Linking current.Next to newNode
                current.Next = newNode;

                // 9. Return true to indicate successful insertion
                return true;
            }

        }

        public static void LinkedListClassTest()
        {

        }
        
        public static void Run()
        {
            LinkedList<string> a = new();

            a.AddFirst("first");
            a.AddFirst("first 2");

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

        }
    }
}
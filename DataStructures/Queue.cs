namespace DotnetSandbox.DataStructures;

public static class QueueDemo
{
    public static void Run()
    {
        var queue = new Queue<string>();
        queue.Enqueue($"A");
        queue.Enqueue($"B");
        queue.Enqueue($"C");

        Console.WriteLine("Queue Instantiated:");
        int index = 1;
        foreach (var item in queue)
        {
            Console.WriteLine($"item {index}: {item}");
            index++;
        }
        index = 1;
        foreach (var item in queue)
        {
            Console.WriteLine($"Dequeuing item {index}: {item}");
            index++;
        }
    }
}
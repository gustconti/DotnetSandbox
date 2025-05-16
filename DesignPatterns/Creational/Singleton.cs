
namespace DotnetSandbox.DesignPatterns.Creational;

public sealed class Singleton
{
    private static readonly Singleton _instance = new();
    public static Singleton Instance => _instance;

    private Singleton() { }

    public void DoSomething()
    {
        Console.WriteLine("Singleton instance called");
    }
}

public static class SingletonDemo
{
    public static void Run()
    {
        var singleton = Singleton.Instance;
        singleton.DoSomething();
    }
}

namespace GarbageCollector.Example2;

public class Human
{
    public string Name { get; set; }
    public Human ChildOne { get; set; }
    public Human ChildTwo { get; set; }

    ~Human()
    {
        Console.WriteLine($"   Collecting {Name}.");
    }
}
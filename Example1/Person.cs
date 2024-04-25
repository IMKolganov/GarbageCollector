namespace GarbageCollector;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    
    public Person ChildOne { get; set; }
    
    ~Person()
    {
        Console.WriteLine($"   Collecting Person {Name}.");
    }
}
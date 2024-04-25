namespace GarbageCollector;

public class Flag
{
    public FlagType Type { get; set; }
    public List<string> Colors { get; set; }
    public string Emblem { get; set; }
    public string Description { get; set; }
    
    ~Flag()
    {
        Console.WriteLine($"   Collecting Flag {Emblem}.");
    }
}
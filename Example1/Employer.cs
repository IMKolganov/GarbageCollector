namespace GarbageCollector;

public class Employer
{
    public Person Person { get; set; }
    public string Company { get; set; } 
    public string Department { get; set; } 
    
    ~Employer()
    {
        Console.WriteLine($"   Collecting Employer {Company} {Person.Name}.");
    }
}
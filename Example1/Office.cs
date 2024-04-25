namespace GarbageCollector;

public class Office
{
    public string Name { get; set; }
    public Country OfficeCountry { get; set; }
    public Person Owner { get; set; }
    public Person ChiefPerson { get; set; }
    // public Employer Chief { get; set; }

    ~Office()
    {
        Console.WriteLine($"   Collecting Office {Name}.");
    }
}
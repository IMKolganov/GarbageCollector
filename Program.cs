// See https://aka.ms/new-console-template for more information

using GarbageCollector;
using System;
using GarbageCollector.Example2;

public class Program
{
    #region example 1
    private static void Example1ShortLives(Office office)
    {
        var chief = new Employer()//chief будет уничтожен после выхода из метода т.к. на него нет ссылок
        {
            Person = new Person(){ Name = "Alice", Age = 35, Email = "alice@example.com" }, 
            Company = "Sber", 
            Department = "AI"
        };
        office.Owner = chief.Person;
    }
    private static void Example1Run()
    {
        var rusFlag = new Flag() { Type = FlagType.TriColor, Colors = ["White", "Blue", "Red"], 
            Description = "Horizontal stripes of white, blue, and red colors.", Emblem = "Double-headed eagle"};
        var rusCountry = new Country() { Name = "Russia", CountryFlag = rusFlag, ChortName = "RUS" }; 
        var moscowOffice = new Office() {Name = "Moscow", OfficeCountry = rusCountry};

        Example1ShortLives(moscowOffice);
        string chiefName = moscowOffice.Owner.Name;
        Console.WriteLine("end ShortLives");
        GC.Collect();//не используйте в реальности т.к. сам GC знает лучше, когда подходящее время для сборки мусора
        GC.WaitForPendingFinalizers();//для примера, программа не должна завершиться до сборки мусора
    }

    #endregion

    #region example 2

    static void Example2ShortLives (Human parent)
    {
        Human fred = new Human
        {
            Name = "Fred",
            ChildOne = new Human { Name = "Bamm-Bamm" }
        };

        parent.ChildTwo = fred.ChildOne;
    }

    static void Example2Run()
    {
        //этот пример взят с https://github.com/JasperKent/.NET-Garbage-Collection/blob/master/GarbageCollection/Program.cs
        //https://www.youtube.com/watch?v=BeuNvhd1L_g
        
        Human wilma = new Human 
        { 
            Name = "Wilma",
            ChildOne = new Human { Name = "Pebbles"}
        };

        Example2ShortLives(wilma);

        Console.WriteLine("Leaving 'ShortLives'...");

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    #endregion
    
    private static void Main(string[] args)
    {

        Console.WriteLine("Example 1");
        Example1Run();
        Console.WriteLine("end run");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        
        Console.WriteLine("Example 2");
        Example2Run();

        Console.WriteLine("\nLeaving 'Run'...");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        return;
    }
}

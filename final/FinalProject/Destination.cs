using System;

public class Destination
{
    private string _name;
    private string _country;
    private string _description;
    private string _historicalSignificance;

    public Destination(string name, string country,
        string description, string historicalSignificance)
    {
        _name = name;
        _country = country;
        _description = description;
        _historicalSignificance = historicalSignificance;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetCountry()
    {
        return _country;
    }

    public string GetDescription()
    {
        return _description;
    }

    public string GetHistoricalSignificance()
    {
        return _historicalSignificance;
    }

    public void DisplayDestination()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          DESTINATION DETAILS");
        Console.WriteLine("========================================");
        Console.WriteLine($"Location: {_name}");
        Console.WriteLine($"Country: {_country}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Historical Significance: {_historicalSignificance}");
    }
}
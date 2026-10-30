using System;

public class HistoricalSite
{
    private string _name;
    private string _country;
    private string _civilization;
    private string _historicalPeriod;
    private string _description;

    public HistoricalSite(
        string name,
        string country,
        string civilization,
        string historicalPeriod,
        string description)
    {
        _name = name;
        _country = country;
        _civilization = civilization;
        _historicalPeriod = historicalPeriod;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetCountry()
    {
        return _country;
    }

    public string GetCivilization()
    {
        return _civilization;
    }

    public string GetHistoricalPeriod()
    {
        return _historicalPeriod;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void DisplaySite()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        HISTORICAL SITE RESEARCH");
        Console.WriteLine("========================================");
        Console.WriteLine($"Site: {_name}");
        Console.WriteLine($"Country: {_country}");
        Console.WriteLine($"Civilization: {_civilization}");
        Console.WriteLine($"Historical Period: {_historicalPeriod}");
        Console.WriteLine($"Description: {_description}");
    }
}
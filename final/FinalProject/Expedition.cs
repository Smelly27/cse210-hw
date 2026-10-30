using System;

public class Expedition
{
    private string _name;
    private string _destination;
    private string _purpose;
    private bool _isCompleted;

    public Expedition(string name, string destination, string purpose)
    {
        _name = name;
        _destination = destination;
        _purpose = purpose;
        _isCompleted = false;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDestination()
    {
        return _destination;
    }

    public string GetPurpose()
    {
        return _purpose;
    }

    public bool IsCompleted()
    {
        return _isCompleted;
    }

    public void CompleteExpedition()
    {
        _isCompleted = true;
    }

    public void DisplayExpedition()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          EXPEDITION DETAILS");
        Console.WriteLine("========================================");
        Console.WriteLine($"Expedition: {_name}");
        Console.WriteLine($"Destination: {_destination}");
        Console.WriteLine($"Purpose: {_purpose}");
        Console.WriteLine($"Status: {(_isCompleted ? "Completed" : "Active")}");
    }
}
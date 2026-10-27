using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _tomorrowReflection;

    public void Display()
    {
        Console.WriteLine($"Question: {_promptText}");
        Console.WriteLine($"Answer: {_entryText}");
        // New Feature for reflection
        Console.WriteLine($"Tomorrow's Reflection: {_tomorrowReflection}");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine();
    }
}
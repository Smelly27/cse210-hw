using System;

public class JournalEntry
{
    private string _title;
    private string _date;
    private string _location;
    private string _content;
    private string _expeditionName;

    public JournalEntry(
        string title,
        string date,
        string location,
        string content,
        string expeditionName)
    {
        _title = title;
        _date = date;
        _location = location;
        _content = content;
        _expeditionName = expeditionName;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetLocation()
    {
        return _location;
    }

    public string GetContent()
    {
        return _content;
    }

    public string GetExpeditionName()
    {
        return _expeditionName;
    }

    public void UpdateContent(string newContent)
    {
        _content = newContent;
    }

    public void DisplayEntry()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          EXPLORER'S JOURNAL");
        Console.WriteLine("========================================");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Location: {_location}");
        Console.WriteLine($"Expedition: {_expeditionName}");
        Console.WriteLine();
        Console.WriteLine("Journal Entry:");
        Console.WriteLine(_content);
        Console.WriteLine("========================================");
    }
}
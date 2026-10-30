using System;
using System.Collections.Generic;

public class ExpeditionManager
{
    private List<Expedition> _expeditions;
    private List<JournalEntry> _journalEntries;
    private ResearchDatabase _researchDatabase;

    public ExpeditionManager()
    {
        _expeditions = new List<Expedition>();
        _journalEntries = new List<JournalEntry>();
        _researchDatabase = new ResearchDatabase();
    }

    public void AddExpedition(Expedition expedition)
    {
        _expeditions.Add(expedition);
    }

    public void DisplayExpeditions()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          EXPEDITION ARCHIVES");
        Console.WriteLine("========================================");

        if (_expeditions.Count == 0)
        {
            Console.WriteLine("No expeditions have been recorded yet.");
            return;
        }

        Console.WriteLine($"Total Expeditions: {_expeditions.Count}");

        foreach (Expedition expedition in _expeditions)
        {
            Console.WriteLine();
            expedition.DisplayExpedition();
        }
    }

    public void AddJournalEntry(JournalEntry entry)
    {
        _journalEntries.Add(entry);
    }

    public void DisplayJournal()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          EXPLORER'S JOURNAL");
        Console.WriteLine("========================================");

        if (_journalEntries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }

        foreach (JournalEntry entry in _journalEntries)
        {
            Console.WriteLine();
            entry.DisplayEntry();
        }
    }

    public void DisplayHistoricalSites()
    {
        _researchDatabase.DisplayHistoricalSites();
    }

    public void DisplayArtifacts()
    {
        _researchDatabase.DisplayArtifacts();
    }

    public void SearchHistoricalSite(string name)
    {
        _researchDatabase.SearchHistoricalSite(name);
    }

    public void SearchArtifact(string name)
    {
        _researchDatabase.SearchArtifact(name);
    }

    public void SaveData()
    {
        Console.WriteLine("The save system is under development.");
    }

    public void LoadData()
    {
        Console.WriteLine("The load system is under development.");
    }
}
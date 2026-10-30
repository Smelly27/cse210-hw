#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

    public void SaveData(Explorer? explorer)
    {
        try
        {
            List<ExpeditionSaveData> expeditionData =
                new List<ExpeditionSaveData>();

            foreach (Expedition expedition in _expeditions)
            {
                expeditionData.Add(new ExpeditionSaveData
                {
                    Name = expedition.GetName(),
                    Destination = expedition.GetDestination(),
                    Purpose = expedition.GetPurpose(),
                    IsCompleted = expedition.IsCompleted()
                });
            }

            List<JournalSaveData> journalData =
                new List<JournalSaveData>();

            foreach (JournalEntry entry in _journalEntries)
            {
                journalData.Add(new JournalSaveData
                {
                    Title = entry.GetTitle(),
                    Date = entry.GetDate(),
                    Location = entry.GetLocation(),
                    Content = entry.GetContent(),
                    ExpeditionName = entry.GetExpeditionName()
                });
            }

            ExplorerSaveFile saveFile = new ExplorerSaveFile
            {
                ExplorerName = explorer?.GetName() ?? "",
                ExplorerSpecialty = explorer?.GetSpecialty() ?? "",
                ExplorerExperienceLevel = explorer?.GetExperienceLevel() ?? 1,
                Expeditions = expeditionData,
                JournalEntries = journalData
            };

            string json = JsonSerializer.Serialize(
                saveFile,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText("explorer_data.json", json);

            Console.WriteLine("Explorer data saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save explorer data: {ex.Message}");
        }
    }

    public Explorer? LoadData()
    {
        if (!File.Exists("explorer_data.json"))
        {
            Console.WriteLine("No saved explorer data was found.");
            return null;
        }

        try
        {
            string json = File.ReadAllText("explorer_data.json");

            ExplorerSaveFile? saveFile =
                JsonSerializer.Deserialize<ExplorerSaveFile>(json);

            if (saveFile == null)
            {
                Console.WriteLine("Unable to load explorer data.");
                return null;
            }

            List<Expedition> loadedExpeditions = new List<Expedition>();
            List<JournalEntry> loadedJournalEntries = new List<JournalEntry>();

            foreach (ExpeditionSaveData data in saveFile.Expeditions)
            {
                Expedition expedition = new Expedition(
                    data.Name,
                    data.Destination,
                    data.Purpose
                );

                if (data.IsCompleted)
                {
                    expedition.CompleteExpedition();
                }

                loadedExpeditions.Add(expedition);
            }

            foreach (JournalSaveData data in saveFile.JournalEntries)
            {
                JournalEntry entry = new JournalEntry(
                    data.Title,
                    data.Date,
                    data.Location,
                    data.Content,
                    data.ExpeditionName
                );

                loadedJournalEntries.Add(entry);
            }

            Explorer? loadedExplorer = null;

            if (!string.IsNullOrWhiteSpace(saveFile.ExplorerName))
            {
                loadedExplorer = new Explorer(
                    saveFile.ExplorerName,
                    saveFile.ExplorerSpecialty,
                    saveFile.ExplorerExperienceLevel
                );
            }

            _expeditions = loadedExpeditions;
            _journalEntries = loadedJournalEntries;

            Console.WriteLine("Explorer data loaded successfully!");

            return loadedExplorer;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load explorer data: {ex.Message}");
            return null;
        }
    }
}

public class ExplorerSaveFile
{
    public string ExplorerName { get; set; } = "";
    public string ExplorerSpecialty { get; set; } = "";
    public int ExplorerExperienceLevel { get; set; } = 1;

    public List<ExpeditionSaveData> Expeditions { get; set; } = new();
    public List<JournalSaveData> JournalEntries { get; set; } = new();
}

public class ExpeditionSaveData
{
    public string Name { get; set; } = "";
    public string Destination { get; set; } = "";
    public string Purpose { get; set; } = "";
    public bool IsCompleted { get; set; }
}

public class JournalSaveData
{
    public string Title { get; set; } = "";
    public string Date { get; set; } = "";
    public string Location { get; set; } = "";
    public string Content { get; set; } = "";
    public string ExpeditionName { get; set; } = "";
}
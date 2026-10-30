#nullable enable
using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        Explorer? currentExplorer = null;
        ExpeditionManager manager = new ExpeditionManager();

        while (running)
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("         THE EXPLORER'S JOURNAL");
            Console.WriteLine("========================================");
            Console.WriteLine("     Adventure Awaits Beyond the Map");
            Console.WriteLine();

            if (currentExplorer != null)
            {
                Console.WriteLine($"Welcome back, {currentExplorer.GetName()}!");
            }
            else
            {
                Console.WriteLine("Welcome, Explorer!");
            }

            Console.WriteLine();
            Console.WriteLine("1. Create Explorer Profile");
            Console.WriteLine("2. View Expeditions");
            Console.WriteLine("3. Plan New Expedition");
            Console.WriteLine("4. Research Historical Sites");
            Console.WriteLine("5. Research Artifacts");
            Console.WriteLine("6. Open Explorer's Journal");
            Console.WriteLine("7. Save Explorer Data");
            Console.WriteLine("8. Load Explorer Data");
            Console.WriteLine("9. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("========================================");
                    Console.WriteLine("       CREATE EXPLORER PROFILE");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    Console.Write("Enter your explorer's name: ");
                    string name = Console.ReadLine() ?? "";

                    Console.Write("Enter your specialty (Archaeology, History, Exploration): ");
                    string specialty = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Explorer name cannot be empty.");
                        break;
                    }

                    currentExplorer = new Explorer(name, specialty);

                    Console.WriteLine();
                    Console.WriteLine("Explorer profile created successfully!");
                    Console.WriteLine();

                    currentExplorer.DisplayProfile();
                    break;

                case "2":
                    manager.DisplayExpeditions();
                    break;

                case "3":
                    Console.WriteLine("========================================");
                    Console.WriteLine("          PLAN NEW EXPEDITION");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    if (currentExplorer == null)
                    {
                        Console.WriteLine("You must create an explorer profile first!");
                        break;
                    }

                    Console.Write("Enter expedition name: ");
                    string expeditionName = Console.ReadLine() ?? "";

                    Console.Write("Enter destination: ");
                    string destination = Console.ReadLine() ?? "";

                    Console.Write("Enter expedition purpose: ");
                    string purpose = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(expeditionName) ||
                        string.IsNullOrWhiteSpace(destination))
                    {
                        Console.WriteLine("Expedition name and destination are required.");
                        break;
                    }

                    Expedition newExpedition = new Expedition(
                        expeditionName,
                        destination,
                        purpose
                    );

                    manager.AddExpedition(newExpedition);

                    Console.WriteLine();
                    Console.WriteLine("Expedition successfully added to your archives!");
                    Console.WriteLine();

                    newExpedition.DisplayExpedition();
                    break;

                case "4":
                    Console.WriteLine("========================================");
                    Console.WriteLine("        HISTORICAL SITE RESEARCH");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    Console.WriteLine("1. View All Historical Sites");
                    Console.WriteLine("2. Search Historical Site");
                    Console.WriteLine();
                    Console.Write("Select an option: ");

                    string siteChoice = Console.ReadLine() ?? "";

                    Console.WriteLine();

                    if (siteChoice == "1")
                    {
                        manager.DisplayHistoricalSites();
                    }
                    else if (siteChoice == "2")
                    {
                        Console.Write("Enter historical site name: ");
                        string siteName = Console.ReadLine() ?? "";

                        Console.WriteLine();
                        manager.SearchHistoricalSite(siteName);
                    }
                    else
                    {
                        Console.WriteLine("Invalid research selection.");
                    }
                    break;

                case "5":
                    Console.WriteLine("========================================");
                    Console.WriteLine("           ARTIFACT RESEARCH");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    Console.WriteLine("1. View All Artifacts");
                    Console.WriteLine("2. Search Artifact");
                    Console.WriteLine();
                    Console.Write("Select an option: ");

                    string artifactChoice = Console.ReadLine() ?? "";

                    Console.WriteLine();

                    if (artifactChoice == "1")
                    {
                        manager.DisplayArtifacts();
                    }
                    else if (artifactChoice == "2")
                    {
                        Console.Write("Enter artifact name: ");
                        string artifactName = Console.ReadLine() ?? "";

                        Console.WriteLine();
                        manager.SearchArtifact(artifactName);
                    }
                    else
                    {
                        Console.WriteLine("Invalid research selection.");
                    }
                    break;

                case "6":
                    Console.WriteLine("========================================");
                    Console.WriteLine("          EXPLORER'S JOURNAL");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    Console.WriteLine("1. View Journal Entries");
                    Console.WriteLine("2. Write New Journal Entry");
                    Console.WriteLine();
                    Console.Write("Select an option: ");

                    string journalChoice = Console.ReadLine() ?? "";

                    Console.WriteLine();

                    if (journalChoice == "1")
                    {
                        manager.DisplayJournal();
                    }
                    else if (journalChoice == "2")
                    {
                        if (currentExplorer == null)
                        {
                            Console.WriteLine("Create an explorer profile before writing a journal entry.");
                            break;
                        }

                        Console.Write("Enter journal title: ");
                        string journalTitle = Console.ReadLine() ?? "";

                        Console.Write("Enter location: ");
                        string journalLocation = Console.ReadLine() ?? "";

                        Console.Write("Enter expedition name: ");
                        string journalExpedition = Console.ReadLine() ?? "";

                        Console.Write("Write your journal entry: ");
                        string journalContent = Console.ReadLine() ?? "";

                        string journalDate = DateTime.Now.ToString("MMMM dd, yyyy");

                        JournalEntry newEntry = new JournalEntry(
                            journalTitle,
                            journalDate,
                            journalLocation,
                            journalContent,
                            journalExpedition
                        );

                        manager.AddJournalEntry(newEntry);

                        Console.WriteLine();
                        Console.WriteLine("Journal entry recorded successfully!");
                        Console.WriteLine();

                        newEntry.DisplayEntry();
                    }
                    else
                    {
                        Console.WriteLine("Invalid journal selection.");
                    }
                    break;

                case "7":
                    Console.WriteLine("========================================");
                    Console.WriteLine("          SAVE EXPLORER DATA");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    manager.SaveData(currentExplorer);
                    break;

                case "8":
                    Console.WriteLine("========================================");
                    Console.WriteLine("          LOAD EXPLORER DATA");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    if (System.IO.File.Exists("explorer_data.json"))
                    {
                        currentExplorer = manager.LoadData();

                        if (currentExplorer != null)
                        {
                            Console.WriteLine();
                            currentExplorer.DisplayProfile();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No saved explorer data was found.");
                    }
                    break;

                case "9":
                    Console.WriteLine("Until our next adventure, Explorer!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the main menu...");
                Console.ReadLine();
            }
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity feature:
        // Added "A Better Tomorrow" so users can write a reflection
        // about something they want to carry into the next day.
        // The reflection is displayed and saved with each journal entry.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome! Let's write about your day.");

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Knowing how today went, what's one thing you'd like to carry into tomorrow?");
                Console.Write("> ");
                string reflection = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._tomorrowReflection = reflection;

                journal.AddEntry(entry);

                Console.WriteLine();
                Console.WriteLine("Every day is another chance to become someone better.");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                if (System.IO.File.Exists(filename))
                {
                    journal.LoadFromFile(filename);
                }
                else
                {
                    Console.WriteLine("That file was not found.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Thanks for writing today!");
            }
            else
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
            }
        }
    }
}
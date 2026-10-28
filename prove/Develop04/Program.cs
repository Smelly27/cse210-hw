using System;

// W04 Mindfulness Program
//
// Creativity and exceeding requirements:
// 1. Added a session tracker that records how many times each
//    activity has been completed.
// 2. Added a session summary showing total activities completed
//    and total mindfulness time.
// 3. Reflection questions do not repeat until every question
//    has been used during that activity.
// 4. Added extra reflection and listing prompts for variety.

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        int totalMindfulnessSeconds = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("          MINDFULNESS PROGRAM");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View session summary");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();

                    breathingCount++;
                    totalMindfulnessSeconds += breathing.GetDuration();

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to the menu.");
                    Console.ReadLine();
                    break;
                }

                case "2":
                {
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();

                    reflectingCount++;
                    totalMindfulnessSeconds += reflecting.GetDuration();

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to the menu.");
                    Console.ReadLine();
                    break;
                }

                case "3":
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Run();

                    listingCount++;
                    totalMindfulnessSeconds += listing.GetDuration();

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to the menu.");
                    Console.ReadLine();
                    break;
                }

                case "4":
                {
                    Console.Clear();

                    Console.WriteLine("========================================");
                    Console.WriteLine("            SESSION SUMMARY");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    Console.WriteLine(
                        $"Breathing activities completed: {breathingCount}");

                    Console.WriteLine(
                        $"Reflecting activities completed: {reflectingCount}");

                    Console.WriteLine(
                        $"Listing activities completed: {listingCount}");

                    Console.WriteLine();

                    int totalActivities =
                        breathingCount + reflectingCount + listingCount;

                    Console.WriteLine(
                        $"Total activities completed: {totalActivities}");

                    Console.WriteLine(
                        $"Total mindfulness time: {totalMindfulnessSeconds} seconds");

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to the menu.");
                    Console.ReadLine();
                    break;
                }

                case "5":
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for taking time to be mindful!");
                    Console.WriteLine("Have a wonderful day!");
                    running = false;
                    break;
                }

                default:
                {
                    Console.WriteLine("Please select a number from 1 to 5.");
                    Console.WriteLine("Press ENTER to try again.");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
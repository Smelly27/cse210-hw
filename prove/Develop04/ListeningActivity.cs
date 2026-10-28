using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;
    private int _count;

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();
        _count = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are some blessings you are grateful for?",
            "What are some things that made you smile recently?"
        };
    }

    // Select a random listing prompt
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Read responses without blocking the activity timer
    private void CollectResponses(DateTime endTime)
    {
        StringBuilder currentResponse = new StringBuilder();

        Console.Write("> ");

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();

                    if (!string.IsNullOrWhiteSpace(currentResponse.ToString()))
                    {
                        _count++;
                    }

                    currentResponse.Clear();

                    if (DateTime.Now < endTime)
                    {
                        Console.Write("> ");
                    }
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (currentResponse.Length > 0)
                    {
                        currentResponse.Length--;

                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    currentResponse.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                // Brief pause prevents unnecessary CPU usage
                Thread.Sleep(25);
            }
        }

        Console.WriteLine();
    }

    // Run the listing activity
    public void Run()
    {
        DisplayStartingMessage();

        _count = 0;

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Start listing your responses!");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        CollectResponses(endTime);

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();

        DisplayEndingMessage();
    }
}
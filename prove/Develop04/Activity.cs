using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    // Constructor for the shared activity information
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Display the welcome message and ask for the duration
    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
        }

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    // Display the ending message shared by every activity
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");

        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");

        ShowSpinner(3);
        Console.WriteLine();
    }

    // Display a spinner animation for a given number of seconds
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);

            Thread.Sleep(250);

            Console.Write("\b \b");

            index = (index + 1) % spinner.Length;
        }

        Console.WriteLine();
    }

    // Display a countdown animation
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);

            Console.Write(new string('\b', i.ToString().Length));
            Console.Write(new string(' ', i.ToString().Length));
            Console.Write(new string('\b', i.ToString().Length));
        }
    }

    // Allow derived classes to access the duration safely
    public int GetDuration()
    {
        return _duration;
    }
}
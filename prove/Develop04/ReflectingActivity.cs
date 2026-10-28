using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectingActivity() : base(
        "Reflecting",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a personal challenge.",
            "Think of a time when you encouraged someone who was struggling."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this experience different from other experiences?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    // Select a random reflection prompt
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Select a question without repeating it until all questions are used
    private string GetRandomQuestion(List<string> availableQuestions)
    {
        int index = _random.Next(availableQuestions.Count);

        string question = availableQuestions[index];
        availableQuestions.RemoveAt(index);

        return question;
    }

    // Run the reflection activity
    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press ENTER to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions.");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        // Create a fresh list so questions do not repeat immediately
        List<string> availableQuestions = new List<string>(_questions);

        while (DateTime.Now < endTime)
        {
            // Refill the list only after all questions have been used
            if (availableQuestions.Count == 0)
            {
                availableQuestions = new List<string>(_questions);
            }

            string question = GetRandomQuestion(availableQuestions);

            Console.Write($"> {question} ");
            
            int remainingSeconds = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            int pauseSeconds = Math.Min(5, remainingSeconds);

            ShowSpinner(pauseSeconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
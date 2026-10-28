using System;

public class BreathingActivity : Activity
{
    // Pass the activity name and description to the parent class
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Run the breathing exercise for the selected duration
    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int remainingSeconds = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            int breatheInSeconds = Math.Min(4, remainingSeconds);

            Console.Write("Breathe in... ");
            ShowCountdown(breatheInSeconds);
            Console.WriteLine();

            remainingSeconds = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            if (remainingSeconds <= 0)
            {
                break;
            }

            int breatheOutSeconds = Math.Min(6, remainingSeconds);

            Console.Write("Breathe out... ");
            ShowCountdown(breatheOutSeconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
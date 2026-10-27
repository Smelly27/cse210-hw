using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the three constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);

        Console.WriteLine("Testing Fractions:");
        Console.WriteLine();

        DisplayFraction(fraction1);
        DisplayFraction(fraction2);
        DisplayFraction(fraction3);
        DisplayFraction(fraction4);

        // Test getters and setters
        Console.WriteLine();
        Console.WriteLine("Testing Getters and Setters:");

        fraction1.SetTop(6);
        fraction1.SetBottom(7);

        Console.WriteLine($"Top: {fraction1.GetTop()}");
        Console.WriteLine($"Bottom: {fraction1.GetBottom()}");

        DisplayFraction(fraction1);

        // Generate 20 random fractions
        Console.WriteLine();
        Console.WriteLine("20 Random Fractions:");
        Console.WriteLine();

        Random random = new Random();
        Fraction randomFraction = new Fraction();

        for (int i = 1; i <= 20; i++)
        {
            int top = random.Next(1, 11);
            int bottom = random.Next(1, 11);

            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);

            Console.WriteLine($"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}");
        }
    }

    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}
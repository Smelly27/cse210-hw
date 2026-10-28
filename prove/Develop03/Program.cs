using System;

// W03 Scripture Memorizer
//
// Creativity and exceeding requirements:
// 1. The program randomly selects from a bank of five LDS scriptures.
// 2. Users can choose between two different study modes:
//    - Memorization Mode gradually hides words.
//    - Flashcard Mode gradually reveals words.
// 3. Each scripture includes an optional hint that users can reveal.
// 4. The program uses a flashcard-inspired display.
// 5. Random word selection only chooses words that can change
//    visibility, preventing repeated selections.
// 6. Three random words are hidden or revealed each round.

class Program
{
    static void Main(string[] args)
    {
        ScriptureBank scriptureBank = new ScriptureBank();

        Console.Clear();

        Console.WriteLine("========================================");
        Console.WriteLine("          SCRIPTURE MEMORIZER");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine("Welcome! Choose how you want to study.");
        Console.WriteLine();

        Console.WriteLine("1. Memorization Mode");
        Console.WriteLine("   Start with the full scripture and");
        Console.WriteLine("   gradually hide words.");
        Console.WriteLine();

        Console.WriteLine("2. Flashcard Mode");
        Console.WriteLine("   Start with the scripture hidden and");
        Console.WriteLine("   gradually reveal words.");
        Console.WriteLine();

        Console.Write("Enter your choice (1 or 2): ");

        string mode = Console.ReadLine()?.Trim() ?? "";

        // Keep asking until a valid mode is selected
        while (mode != "1" && mode != "2")
        {
            Console.WriteLine();
            Console.WriteLine("Please enter 1 or 2.");
            Console.Write("Your choice: ");

            mode = Console.ReadLine()?.Trim() ?? "";
        }

        Scripture scripture = scriptureBank.GetRandomScripture();

        bool showHint = false;
        bool flashcardMode = mode == "2";

        // Flashcard Mode starts with all words hidden
        if (flashcardMode)
        {
            scripture.HideAllWords();
        }

        while (true)
        {
            Console.Clear();

            Console.WriteLine("========================================");

            if (flashcardMode)
            {
                Console.WriteLine("             FLASHCARD MODE");
            }
            else
            {
                Console.WriteLine("           MEMORIZATION MODE");
            }

            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Display the hint only when requested
            if (showHint)
            {
                Console.WriteLine($"Hint: {scripture.GetHint()}");
                Console.WriteLine();
            }

            // Check whether the study session is complete
            if (flashcardMode && scripture.IsCompletelyVisible())
            {
                Console.WriteLine("Great job! Every word has been revealed!");
                Console.WriteLine("Keep practicing and strengthening your memory.");
                break;
            }
            else if (!flashcardMode && scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Great job! You have hidden every word!");
                Console.WriteLine("Try reciting the entire scripture from memory.");
                break;
            }

            Console.WriteLine("----------------------------------------");

            if (flashcardMode)
            {
                Console.WriteLine("Press ENTER to reveal 3 random words.");
            }
            else
            {
                Console.WriteLine("Press ENTER to hide 3 random words.");
            }

            Console.WriteLine("Type 'hint' to reveal a helpful clue.");
            Console.WriteLine("Type 'quit' to exit.");
            Console.WriteLine("----------------------------------------");
            Console.Write("Your choice: ");

            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "quit")
            {
                Console.WriteLine();
                Console.WriteLine("Thanks for practicing! See you next time.");
                break;
            }
            else if (input == "hint")
            {
                showHint = true;
            }
            else if (input == "")
            {
                if (flashcardMode)
                {
                    scripture.RevealRandomWords(3);
                }
                else
                {
                    scripture.HideRandomWords(3);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please press ENTER, type 'hint', or type 'quit'.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
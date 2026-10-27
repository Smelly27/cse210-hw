using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "What is something that made your day today?",
        "Was there something today that you really appreciated?",
        "Was there something today that you did not appreciate?",
        "What was something that stood out to you that you thought about?",
        "If you could change anything about your day, what would it be, why?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}
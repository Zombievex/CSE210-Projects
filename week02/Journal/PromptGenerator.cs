using System;

public class PromptGenerator
{

    // Make new list
    List<string> prompts = new List<string>
    {
        "What new thing did you do today?",
        "What is something good that happened today?",
        "What made you worry today?",
    };

    // Prints to screen
    public string get_prompt()
    {
        Random random = new Random();

        int index = random.Next(prompts.Count);
        string randomPrompt = prompts[index];

        return randomPrompt;
    }
}
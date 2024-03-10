using System;

public class PromptGenerator {
    public string GetRandomPrompt() {
        var rand = new Random();
        int promptNumber = rand.Next(4);
        List<string> prompts = new List<string>();
        prompts.Add("What are your sweet and suck for the day?");
        prompts.Add("Is there anything outstanding you need to remember for tomorrow?");
        prompts.Add("Have you made long term plans that you'll need to check in on?");
        prompts.Add("Are there any friends you've not been talking to? How can you get back into contact with them?");
        prompts.Add("Do you have any worries that you need to get off your chest?");
        return prompts[promptNumber];
    }
}
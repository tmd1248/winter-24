using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator generator = new PromptGenerator();
        Journal journal = new Journal();
        bool programRunning = true;
        while(programRunning == true) {
        Console.WriteLine("Welcome to your journal!");
        Console.WriteLine("Please select options 1-5");
        Console.WriteLine("1 to write a new entry with a random prompt");
        Console.WriteLine("2 to display all journal entries");
        Console.WriteLine("3 to save the journal to a file");
        Console.WriteLine("4 to load from a file");
        Console.WriteLine("5 to exit the program");
        string choice = Console.ReadLine();
        switch (choice) {
            case "1": 
                Entry entry = new Entry();
                DateTime rightNow = DateTime.Now;
                string rightNowString = rightNow.ToShortDateString();
                entry.date = rightNowString;
                entry.promptText = generator.GetRandomPrompt();
                Console.WriteLine(entry.promptText);
                Console.WriteLine("Enter your response now in a single line, press enter when finished");
                entry.entryText = Console.ReadLine();
                journal.AddEntry(entry);
                break;
            case "2":
                journal.DisplayAll();
                break;
            case "3":
                Console.WriteLine("Choose the name of the file to save");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
                break;
            case "4":
                Console.WriteLine("Input the name of the file to be loaded, without the .txt");
                file = Console.ReadLine();
                journal.LoadFromFile(file);
                break;
            case "5":
                programRunning = false;
                break;
        }
    }
    }
}
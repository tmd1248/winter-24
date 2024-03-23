using System;

class ReflectionActivity : Activity {
    private List<int> count = new List<int>();
    private List<string> _prompts = ["Think of a time when you stood up for someone else in a personal or professional setting", "Think of a time when you did something really difficult.","Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."];
    private List<string> _questions = ["Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?"];
        public ReflectionActivity () {
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize your inner character.";
         _name = "Reflecting Activity";

    }
    public void Run() {
        DisplayStartingMessage();
        Console.WriteLine("Enter the number of questions you would like to run this activity for, up to six. Each question will remain onscreen for 9 seconds.");
        _duration = int.Parse(Console.ReadLine());
        DisplayPrompt();
        while(_duration > 0) {
            DisplayQuestion();
            DisplaySpinner(9);
            _duration -= 1;
        }
        DisplayEndingMessage();
    }
    public string GetRandomPrompt() {
        Random rand = new Random();
        int choice = rand.Next(_prompts.Count());
        string prompt = _prompts[choice];
        return prompt;
    }
    public string GetRandomQuestion() {
        Random rand = new();
        string question = "";
        bool tracker = false;
        while(tracker == false){
        int choice = rand.Next(_questions.Count());
        if(count.Contains(choice) == false ){
        question = _questions[choice];
        count.Add(choice);
        tracker = true;
        }
        }
        return question;
    }
    public void DisplayPrompt() {
        Console.WriteLine(GetRandomPrompt());
    }
    public void DisplayQuestion() {
        Console.WriteLine(GetRandomQuestion());
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breath = new BreathingActivity();
        ListingActivity list = new ListingActivity();
        ReflectionActivity reflect = new ReflectionActivity();
        bool tracker = false;
        string input;
        while(tracker == false) {
        Console.WriteLine("Hello and welcome to the mindfulness activity selector");
        Console.WriteLine("Please type a number 1-3 to begin an activity");
        Console.WriteLine("1 for breathing practice, 2 for a listing exercise, and 3 for a chance to reflect.");
        Console.WriteLine("Or Type 'quit' to exit the program");
        input = Console.ReadLine();
        switch(input) {
            case "1": 
                breath.Run();
                break;
            case "2": 
                list.Run();
                break;
            case "3":
                reflect.Run();
                break;
            case "quit": 
                tracker = true;
                break;
        }
        }
    }
}
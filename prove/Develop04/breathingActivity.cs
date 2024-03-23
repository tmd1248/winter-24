using System;

class BreathingActivity : Activity {
        public BreathingActivity() {
        _description = "This activity will assist with relaxation through measured breaths, helping you to clear your mind and focus upon this one exercise";
        _name = "Breathing Activity";
        }
    public void Run() {
        DisplayStartingMessage();
        Console.WriteLine("Enter the number of whole seconds you would like to run this activity for. This activity works in periods of 4 seconds.");
        string duration = Console.ReadLine();
        _duration = int.Parse(duration);
        while(_duration > 0) {
            Console.WriteLine("Breathe In...");
            DisplayTimer(2);
            Console.WriteLine("Breathe Out...");
            DisplayTimer(2);
            _duration -= 2;
        }
        DisplayEndingMessage();
    }
}
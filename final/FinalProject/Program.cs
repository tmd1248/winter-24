using System;

class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new();
        myMenu.logIn();
        bool tracker = false;
        while(tracker == false) {
             Console.WriteLine("Welcome to the event tracker, " + myMenu.LoggedInUser + "!");
            Console.WriteLine("Please decide what you would like to do today. Type 1 to create a new event, 2 to join an event, or 3 to log out");
            string choice = Console.ReadLine();
            switch (choice) {
                case "1": 
                myMenu.newEvent();
                break;
                case "2":
                myMenu.joinEvent();
                break;
                case "3":
                myMenu.logOut();
                tracker = true;
                break;
            }
        }
    }
}
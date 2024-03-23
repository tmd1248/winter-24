using System; 

class ListingActivity : Activity {
    private List<string> _prompts = ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"];
    public ListingActivity() {
        _description = "This activity will help you reflect on the good things in your life through listing based upon prompts provided by the program.";
         _name = "Listing Activity";
    }
    public void Run() {
        DisplayStartingMessage();
        Console.WriteLine("Enter the number of seconds you would like to think about the provided prompt for.");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine(GetRandomPrompt());
        DisplayTimer(_duration);
        List<string> userList = GetListFromUser();
        foreach(string useritem in userList) {
            Console.WriteLine(useritem);
        }
}
    public string GetRandomPrompt() {
        Random rand = new();
        int promptNumber = rand.Next(_prompts.Count());
        string prompt = _prompts[promptNumber];
        return prompt;
    }
    public static List<string> GetListFromUser() {
        bool tracker = false;
        List<string> tempList = [];
        while(tracker == false) {
            Console.WriteLine("Enter a response or type \"quit\" to quit");
            string response = Console.ReadLine();
            if (response == "quit") {
                tracker = true;
            }
            else {
                tempList.Add(response);
            }
        }
        return tempList;


        
    }
}
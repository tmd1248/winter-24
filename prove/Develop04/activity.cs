using System;

class Activity {

    protected string _name;
    protected string _description;
    protected int _duration;

    public void DisplayStartingMessage() {
        Console.WriteLine(_description);
    }
    
    public static void DisplayEndingMessage() {
        Console.WriteLine("Thank you for using this program. I hope it has been helpful to you");
    }

    public static void DisplaySpinner(int seconds) {
        List<string> spinnerList =
        [
            "|",
            "\\",
            "—",
            "/",
            "|",
            "\\",
            "—",
            "/",
            "|",
        ];
        foreach (string s in spinnerList) {
            Console.Write(s);
            Thread.Sleep(seconds / 9 * 1000);
            Console.Write("\b \b");
        }
    }

    public static void DisplayTimer(int seconds) {
        while(seconds > 0) {
            if(seconds >= 10) {
            Console.Write(seconds);
            Thread.Sleep(1000);
            seconds -= 1;
            Console.Write("\b\b");
            } else {
                Console.Write("0" + seconds);
                Thread.Sleep(1000);
                seconds -= 1;
                Console.Write("\b\b");
            }
        }
        Console.WriteLine("All Done!");
    }
}
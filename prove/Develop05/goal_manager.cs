using System;
using System.Text;
using System.Xml.Serialization;

class Goal_Manager {
    private int _points;
    public int points {
        get { return _points;}
        set { _points = value;}
    }
    private List<Goal> _goals = new List<Goal>();
    private string goalHelper = "";

    public void start() {
        if(File.Exists("points.txt")) {
            StreamReader sr = new StreamReader("points.txt");
            points = Int32.Parse(sr.ReadLine());
        }
        if(File.Exists("goals.txt")) {
            StreamReader sr = new StreamReader("goals.txt");
            goalHelper = sr.ReadLine();
            while(goalHelper != null) {
                        switch(goalHelper) {
                            case "simple":
                        Simple_Goal sg = new Simple_Goal
                        {
                            shortname = sr.ReadLine(),
                            description = sr.ReadLine(),
                            points = int.Parse(sr.ReadLine()),
                            isComplete = bool.Parse(sr.ReadLine())
                        };
                        _goals.Add(sg);
                                break;
                            case "eternal":
                        Eternal_Goal eg = new Eternal_Goal
                        {
                            shortname = sr.ReadLine(),
                            description = sr.ReadLine(),
                            points = int.Parse(sr.ReadLine())
                        };
                        _goals.Add(eg);                        
                                break;
                            case "checklist":
                        Checklist_Goal cg = new Checklist_Goal
                        {
                            shortname = sr.ReadLine(),
                            description = sr.ReadLine(),
                            points = int.Parse(sr.ReadLine()),
                            amountCompleted = int.Parse(sr.ReadLine()),
                            target = int.Parse(sr.ReadLine()),
                            bonus = int.Parse(sr.ReadLine())
                        };
                        _goals.Add(cg);
                                break;
                        }
                            goalHelper = sr.ReadLine();
                }
            }
        bool has_chosen = false;
        bool exit_program = false;
        string choice;
        while(exit_program == false) {
            Console.WriteLine("Welcome to the Eternal Quest");
            Console.WriteLine("The point of this program is to help you follow through on goals through gamifying them.");
            Console.WriteLine("Your current point total is " + _points);
            Console.WriteLine("To increase them, select a type of goal, simple, eternal, or checklist");
            Console.WriteLine("To learn more about the goals you have set, type listnames for the names, and listdetails for more detailed information.");
            Console.WriteLine("Or, for other functionality, type create to make a new goal, or save to save your current progress and log out.");
            choice = Console.ReadLine();
            switch(choice) {
                case "simple":
                    Console.WriteLine("Enter the name of the simple goal you wish to complete");
                    choice = Console.ReadLine();
                    foreach(Goal goal in _goals) {
                        if(goal.shortname == choice) {
                            goal.RecordEvent();
                            _points += goal.points;
                            has_chosen = true;
                            break;
                        }
                    }
                    if(has_chosen == false) {
                        Console.WriteLine("Oops, that's not the name of a goal. You can always add it with the word create");
                    }
                    has_chosen = false;
                    break;
                case "eternal":
                    Console.WriteLine("Enter the name of the eternal goal you wish to complete");
                    choice = Console.ReadLine();
                    foreach(Goal goal in _goals) {
                        if(goal.shortname == choice) {
                            _points += goal.points;
                            has_chosen = true;
                            break;
                        }
                    }
                    if(has_chosen == false) {
                        Console.WriteLine("Oops, that's not the name of a goal. You can always add it with the word create");
                    }
                    has_chosen = false;
                    break;
                case "checklist": 
                    Console.WriteLine("Enter the name of the checklist goal you wish to complete");
                    choice = Console.ReadLine();
                    foreach(Goal goal in _goals) {
                        if(goal.shortname == choice) {
                            goal.RecordEvent();
                            _points += goal.points;
                            has_chosen = true;
                            break;
                        }
                    }
                    if(has_chosen == false) {
                        Console.WriteLine("Oops, that's not the name of a goal. You can always add it with the word create");
                    }
                    has_chosen = false;
                    break;
                case "create":
                    CreateGoal();
                    break;
                case "listnames":
                    ListNames();
                    break;
                case "listdetails":
                    ListDetails();
                    break;
                case "save":
                    save();
                    exit_program = true;
                    break;

                 }
            }
        }



    void ListNames() {
            foreach(Goal goalName in _goals) {
                Console.WriteLine(goalName.shortname);
            }
        }
        void CreateGoal() {
            Console.WriteLine("Which type of goal would you like to make?");
            string choice = Console.ReadLine();
            switch (choice) {
                case "simple": 
                Simple_Goal sg = new();
                    Console.WriteLine("Name the goal you'd like to create");
                    sg.shortname = Console.ReadLine();
                    Console.WriteLine("Describe the goal you're creating");
                    sg.description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth?");
                    sg.points = int.Parse(Console.ReadLine());
                    _goals.Add(sg);
                    break;
                case "eternal": 
                    Eternal_Goal eg = new();
                    Console.WriteLine("Name the goal you'd like to create");
                    eg.shortname = Console.ReadLine();
                    Console.WriteLine("Describe the goal you're creating");
                    eg.description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth?");
                    eg.points = int.Parse(Console.ReadLine());
                    _goals.Add(eg);
                    break;
                case "checklist": 
                Checklist_Goal cg = new();
                    Console.WriteLine("Name the goal you'd like to create");
                    cg.shortname = Console.ReadLine();
                    Console.WriteLine("Describe the goal you're creating");
                    cg.description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth?");
                    cg.points = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many times should this goal be completed?");
                    cg.target = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many bonus points are awarded for going over that number?");
                    cg.bonus = int.Parse(Console.ReadLine());
                    _goals.Add(cg);
                    break;

            }
        }
        void ListDetails() {
            foreach (Goal goalInfo in _goals) {
                Console.WriteLine(goalInfo.description);
                if (goalInfo is Simple_Goal) {
                    if(goalInfo.isComplete) {
                        Console.WriteLine("[x]");
                    }
                    else {
                        Console.WriteLine("[ ]");
                    }
                }
            }
        }
        void save() {
            try {
                if (File.Exists("points.txt")) {
                    File.Delete("points.txt");
                    }
            using FileStream fileStream = new FileStream("points.txt", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.ASCII))
            {
                sw.Write(_points);
                sw.Close();
            }
        }
            catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }
            try {
                if (File.Exists("goals.txt")) {
                    File.Delete("goals.txt");
                    };
            using FileStream fileStream = new FileStream("goals.txt", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.ASCII)){
                foreach(Goal goal in _goals) {
                    if(goal is Simple_Goal) {
                        sw.WriteLine("simple");
                        sw.WriteLine(goal.shortname);
                        sw.WriteLine(goal.description);
                        sw.WriteLine(goal.points);
                        sw.WriteLine(goal.isComplete);
                    }
                    else if(goal is Eternal_Goal) {
                        sw.WriteLine("eternal");
                        sw.WriteLine(goal.shortname);
                        sw.WriteLine(goal.description);
                        sw.WriteLine(goal.points);
                    }
                    else {
                        Checklist_Goal cgoal = (Checklist_Goal)goal;
                        sw.WriteLine("checklist");
                        sw.WriteLine(cgoal.shortname);
                        sw.WriteLine(cgoal.description);
                        sw.WriteLine(cgoal.points);
                        sw.WriteLine(cgoal.amountCompleted);
                        sw.WriteLine(cgoal.target);
                        sw.WriteLine(cgoal.bonus);
                    }
                }
                sw.Close();}
                }
            catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
}


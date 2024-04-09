using System;

class Menu {
    private static readonly string memory = "EventTrackerMemory.txt";
    private List<Person> people = new();
    private List<Event> events = new();
    private Tracker EventTracker = new();
    private string loggedInUser = "";
    public string LoggedInUser {
        get {return loggedInUser;}
    }
    
    public void logIn() {
        if (File.Exists(memory)) {
        using(StreamReader file = new StreamReader(memory)) {
            string ln;
            while ((ln = file.ReadLine()) != "STOP") {
                ln = file.ReadLine();
                if(ln != "STOP") {
                    if(ln == "Adult"){
                        Adult adult = new();
                        ln = file.ReadLine();
                        adult.name = ln;
                        ln = file.ReadLine();
                        adult.Spouse = ln;
                        ln = file.ReadLine();
                        string[] availabilities = ln.Split(' ');
                        foreach(var availability in availabilities) {
                            adult.Availability.Add(int.Parse(availability));
                        }
                        ln = file.ReadLine();
                        string[] children = ln.Split(' ');
                        foreach(var child in children) {
                            adult.children.Add(child);
                        }
                        people.Add(adult);
                    } else if(ln == "Child") {
                       Child child = new();
                        ln = file.ReadLine();
                        child.name = ln;
                        ln = file.ReadLine();
                        string[] parents = ln.Split(' ');
                        foreach(var parent in parents) {
                            child.Parents.Add(parent);
                        }
                        ln = file.ReadLine();
                        string[] availabilities = ln.Split(' ');
                        foreach(var availability in availabilities) {
                            child.Availability.Add(int.Parse(availability));
                        }
                        ln = file.ReadLine();
                        string[] siblings = ln.Split(' ');
                        foreach(var sibling in siblings) {
                            child.siblings.Add(sibling);
                        }
                        people.Add(child);

                    }
                }
            } 
            while((ln = file.ReadLine()) != null) {
                if(ln == "Simple") {
                    SimpleEvent simple = new();
                    ln = file.ReadLine();
                    simple.What = ln;
                    ln = file.ReadLine();
                    simple.When = DateTime.Parse(ln);
                    ln = file.ReadLine();
                    simple.Where = ln;
                    ln=file.ReadLine();
                    string[] people = ln.Split(' ');
                    foreach (var person in people) {
                        simple.People.Add(person);
                    }
                    events.Add(simple);
                }
                if(ln == "Daily") {
                    dailyEvent daily = new();
                    ln = file.ReadLine();
                    daily.What = ln;
                    ln = file.ReadLine();
                    daily.When = TimeOnly.Parse(ln);
                    ln = file.ReadLine();
                    daily.Where = ln;
                    ln=file.ReadLine();
                    string[] people = ln.Split(' ');
                    foreach (var person in people) {
                        daily.People.Add(person);
                    }
                    events.Add(daily);
                }
                if(ln == "Periodic") {
                    periodicEvent periodic = new();
                    ln = file.ReadLine();
                    periodic.What = ln;
                    ln = file.ReadLine();
                    periodic.When = DateTime.Parse(ln);
                    ln = file.ReadLine();
                    periodic.Where = ln;
                    ln=file.ReadLine();
                    string[] people = ln.Split(' ');
                    foreach (var person in people) {
                        periodic.People.Add(person);
                    }
                    ln = file.ReadLine();
                    periodic.repeatPeriod = int.Parse(ln);
                    events.Add(periodic);

                }
            }
        }
        EventTracker.People = people;
        EventTracker.events = events;
        }
        bool loggedIn = false;
        while (loggedIn == false) {
        Console.WriteLine("Please Enter your Username or type 'LOGOUT' to exit program");
        string Username = Console.ReadLine();
        if(Username == "LOGOUT") {
            logOut();
            break;
        } else {
        bool tracker = false;
        foreach(Person person in people) {
            if(person.name == Username) {
                Console.WriteLine("Welcome " + Username);
                alert(Username);
                tracker = true;
                loggedIn = true;
                loggedInUser = Username;
            }
        } 
        if(tracker == false) {
            Console.WriteLine("You don't appear to be on the list of users. WOuld you like to create a new profile? type 'yes' to do so, or anything else to return to login");
            string choice = Console.ReadLine();
            if (choice == "yes") {
                signUp();
                loggedIn = true;
            }
        }
        }
        }
        
    }
    void signUp() {
        Console.WriteLine("Please enter the name you'd like to use for this program");
        string name = Console.ReadLine();
        bool tracker = false;
        while(tracker == false) {
        Console.WriteLine("Is this an adult or child account?");
        string response = Console.ReadLine();
        if(response == "Adult") {
            Adult adult = new();
            adult.name = name;
            Console.WriteLine("If you have a spose, enter their name, or type 'NULL' to move on");
            adult.Spouse = Console.ReadLine();
            Console.WriteLine("When does your sunday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your monday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your tuesday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your wednesday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your thursday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your friday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your saturday availability end? please enter in military time, or type 0 for no availability");
            adult.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("If you have any children, please enter their names one by one, or type 'NULL' if you have none. When done, type 'DONE' to move on");
            bool ChildrenDone = false;
            while(ChildrenDone == false) {
                string child = Console.ReadLine();
                if(child == "NULL") {
                    adult.children.Add(child);
                    ChildrenDone = true;
                } else if(child == "DONE") {
                    ChildrenDone = true;
                } else {adult.children.Add(child);}
            } tracker = true;
            people.Add(adult);
            loggedInUser = adult.name;
        } else if(response == "Child") {
            Child child = new();
            child.name = name;
            Console.WriteLine("If you have parents you'd like to list, enter their names, or type 'NULL' to move on");
            bool parentTracker = false;
            while (parentTracker == false) {
                string choice = Console.ReadLine();
                if(choice == "NULL") {
                    parentTracker = true;
                } else if(child.Parents.Count < 2) {
                    child.Parents.Add(choice);
                } else {parentTracker = true;}
            }
            Console.WriteLine("When does your sunday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your monday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your tuesday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your wednesday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your thursday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your friday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("When does your saturday availability end? please enter in military time, or type 0 for no availability");
            child.Availability.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("If you have any siblings, please enter their names one by one, or type 'NULL' if you have none. When done, type 'DONE' to move on");
            bool siblingsDone = false;
            while(siblingsDone == false) {
                string sibling = Console.ReadLine();
                if(sibling == "NULL") {
                    child.siblings.Add(sibling);
                    siblingsDone = true;
                } else if(sibling == "DONE") {
                    siblingsDone = true;
                } else {child.siblings.Add(sibling);}
            } tracker = true;
            people.Add(child);
            loggedInUser = child.name;
        }
        }
    }
     public void newEvent() {
        bool tracker = false;
        while (tracker == false) {
        Console.WriteLine("What type of event are you creating? simple, daily, or some other periodic but not daily?");
        string choice = Console.ReadLine();
        if(choice == "simple") {
            SimpleEvent simpleEvent = new();
            Console.WriteLine("What is the name of the event?");
            simpleEvent.What = Console.ReadLine();
            Console.WriteLine("Where is the event happening?");
            simpleEvent.Where = Console.ReadLine();
            Console.WriteLine("WHen is the event happening? Use this format" + DateTime.Now.ToString());
            simpleEvent.When = DateTime.Parse(Console.ReadLine());
            bool peopleTracker = false;
            while (peopleTracker == false) {
            Console.WriteLine("Enter everyone involved, you are signed up by default. type 'DONE' when done.");
            simpleEvent.People.Add(loggedInUser);
            string peoplechoice = Console.ReadLine();
            if( peoplechoice == "DONE") {
                peopleTracker = true;
            } else {
                simpleEvent.People.Add(peoplechoice);
            }
            }
            tracker = true;
        } else if(choice == "daily") {
            dailyEvent daily = new();
            Console.WriteLine("What is the name of the event?");
            daily.What = Console.ReadLine();
            Console.WriteLine("Where is the event happening?");
            daily.Where = Console.ReadLine();
            Console.WriteLine("WHen is the event happening? Use this format" + TimeOnly.FromDateTime(DateTime.Now).ToString());
            daily.When = TimeOnly.Parse(Console.ReadLine());
            bool peopleTracker = false;
            while (peopleTracker == false) {
            Console.WriteLine("Enter everyone involved, you are signed up by default. type 'DONE' when done.");
            daily.People.Add(loggedInUser);
            string peoplechoice = Console.ReadLine();
            if( peoplechoice == "DONE") {
                peopleTracker = true;
            } else {
                daily.People.Add(peoplechoice);
            }
            }
            tracker = true;
        } else if(choice == "periodic") {
            periodicEvent periodic = new();
            Console.WriteLine("What is the name of the event?");
            periodic.What = Console.ReadLine();
            Console.WriteLine("Where is the event happening?");
            periodic.Where = Console.ReadLine();
            Console.WriteLine("WHen is the event happening? Use this format" + DateTime.Now.ToString());
            periodic.When = DateTime.Parse(Console.ReadLine());
            bool peopleTracker = false;
            while (peopleTracker == false) {
            Console.WriteLine("Enter everyone involved, you are signed up by default. type 'DONE' when done.");
            periodic.People.Add(loggedInUser);
            string peoplechoice = Console.ReadLine();
            if( peoplechoice == "DONE") {
                peopleTracker = true;
            } else {
                periodic.People.Add(peoplechoice);
            }
            }
            tracker = true;
            Console.WriteLine("How often is this event happening in days?");
            periodic.repeatPeriod = int.Parse(Console.ReadLine());
        }
        }

    }
     void alert(string name) {
        EventTracker.alertUser(name);
    }
    public void joinEvent() {
        bool tracker = false;
        while (tracker == false)
        {
            Console.WriteLine("What event would you like to join? or type 'EXIT' to exit");
            string choice = Console.ReadLine();
            if(choice != "EXIT"){
            foreach (Event eventName in events) {
                if (eventName.What == choice) {
                    eventName.People.Add(loggedInUser);
                    tracker = true;
                }
            } if (tracker == false) {
                Console.WriteLine("We didn't recognize that event name. If it's not in the system, you can create it");
            }} else { tracker = true;}
        }

    }
    public void logOut() {
        if(File.Exists(memory)) {
            File.Delete(memory);
        }
        try{
            using(StreamWriter filewriter = new StreamWriter(memory)) {
                filewriter.WriteLine("PEOPLE");
                foreach(Person person in people) {
                    if(person is Adult) {
                        Adult adult = (Adult)person;
                        filewriter.WriteLine("Adult");
                        filewriter.WriteLine(adult.name);
                        filewriter.WriteLine(adult.Spouse);
                        filewriter.WriteLine("");
                        foreach(var availabilities in adult.Availability) {
                            filewriter.Write(availabilities.ToString() + " ");
                        }
                        filewriter.WriteLine("");
                        foreach(var child in adult.children) {
                            filewriter.Write(child + " ");
                        }
                    }
                    else if (person is Child) {
                        Child child = (Child)person;
                        filewriter.WriteLine("Child");
                        filewriter.WriteLine(child.name);
                        filewriter.WriteLine("");
                        foreach(var parent in child.Parents) {
                            filewriter.Write(parent + " ");
                        }
                        filewriter.WriteLine("");
                        foreach(var availabilities in child.Availability) {
                            filewriter.Write(availabilities + " ");
                        }
                        filewriter.WriteLine("");
                        foreach(var sibling in child.siblings) {
                            filewriter.Write(sibling + " ");
                        }
                    }
                    }
                    filewriter.WriteLine("STOP");
                    foreach(Event event1 in events) {
                        if(event1 is SimpleEvent) {
                            SimpleEvent simpleEvent = (SimpleEvent)event1;
                            filewriter.WriteLine("Simple");
                            filewriter.WriteLine(simpleEvent.What);
                            filewriter.WriteLine(simpleEvent.When.ToString());
                            filewriter.WriteLine(simpleEvent.Where);
                            filewriter.WriteLine("");
                            foreach(var person in simpleEvent.People) {
                                filewriter.Write(person + " ");
                            }
                        }
                        else if(event1 is dailyEvent) {
                            dailyEvent dailyevent = (dailyEvent)event1;
                            filewriter.WriteLine("Daily");
                            filewriter.WriteLine(dailyevent.What);
                            filewriter.WriteLine(dailyevent.When.ToString());
                            filewriter.WriteLine(dailyevent.Where);
                            filewriter.WriteLine("");
                            foreach(var person in dailyevent.People) {
                                filewriter.Write(person + " ");
                            }                            
                        }
                        else if (event1 is periodicEvent) {
                            periodicEvent periodicevent = (periodicEvent)event1;
                            filewriter.WriteLine("Periodic");
                            filewriter.WriteLine(periodicevent.What);
                            filewriter.WriteLine(periodicevent.When.ToString());
                            filewriter.WriteLine(periodicevent.Where);
                            filewriter.WriteLine("");
                            foreach(var person in periodicevent.People) {
                                filewriter.Write(person + " ");
                            }
                            filewriter.WriteLine(periodicevent.repeatPeriod.ToString());
                        }
                    }
                }
            }
            catch (IOException exception){
                Console.WriteLine(exception.Message);
            }

        }
    }


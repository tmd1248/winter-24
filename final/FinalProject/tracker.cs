using System;

class Tracker {
    private List<Event> _events = new();
    public List<Event> events {
        get {return _events;}
        set {_events = value;}
    }
    private List<Person> _people = new();
    public List<Person> People {
        get {return _people;}
        set {_people = value;}
    }
    public void alertUser( string person) {
        foreach(Person person1 in _people) {
            if (person1.name == person) {
            foreach (Event eventName in events) {
                if (eventName.People.Contains(person)) {
                    Console.WriteLine("You are signed up for " + eventName.What + " located at " + eventName.Where + " on " + eventName.When.ToString());
                    Console.WriteLine("");
                }
            }
        } else {Console.WriteLine("Please sign in to check membership");}
    }
}
}
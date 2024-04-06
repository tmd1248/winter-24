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
    private void alertUser( Person person) {

    }
}
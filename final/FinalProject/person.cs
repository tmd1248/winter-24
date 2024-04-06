using System;

abstract class Person {
    protected string _name = "";
    public string name {
        get {return _name;}
        set {name = value;}
    }
    protected List<int> _availability = new();
    public List<int> Availability {
        get {return _availability;}
        set {_availability = value;}
    }
    protected List<Event> _events = new();
    public List<Event> events {
        get {return _events;}
        set {_events = value;}
    }
    
}
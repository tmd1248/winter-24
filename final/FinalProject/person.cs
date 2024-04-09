using System;

abstract class Person {
    protected string _name = "";
    public string name {
        get {return _name;}
        set {_name = value;}
    }
    protected List<int> _availability = new();
    public List<int> Availability {
        get {return _availability;}
        set {_availability = value;}
    }
    
}
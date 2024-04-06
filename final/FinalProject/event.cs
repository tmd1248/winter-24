using System;
using System.IO.Pipes;

abstract class Event {
    protected List<Person> _people = new();
    public List<Person> People {
        get {return _people;}
        set {_people = value;}
    }
    protected DateTime _when;
    public DateTime When {
        get {return _when;}
        set {_when = value;}
    }
    protected string _where = "";
    public string Where {
        get {return _where;}
        set {_where = value;}
    }
    protected string _what = "";
    public string What {
        get {return _what;}
        set {_what = value;}
    }

    protected void signUp(Person person) {
        _people.Add(person);
    }
    protected void removeFromEvent(Person person) {
        if (People.Contains(person)) {
            People.Remove(person);
        } else {
            Console.WriteLine(person.name + "Is not signed up for the event");
        }
    }
}
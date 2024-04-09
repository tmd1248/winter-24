using System;

abstract class Event {
    protected List<string> _people = new();
    public List<string> People {
        get {return _people;}
        set {_people = value;}
    }
    protected DateTime _when = new();
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



}
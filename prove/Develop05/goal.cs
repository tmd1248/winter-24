using System;

abstract class Goal {
    protected string _shortname;
    public string shortname {
        get {return _shortname;}
        set {_shortname = value;}
    }
    protected string _description;
    public string description {
        get {return _description;}
        set {_description = value;}
    }
    protected int _points;
    public int points {
        get {return _points;}
        set {_points = value;}
    }
    
    protected bool _isComplete;
    public bool isComplete {
        get {return _isComplete;}
        set {_isComplete = value;}
    }
    public abstract void RecordEvent();
}
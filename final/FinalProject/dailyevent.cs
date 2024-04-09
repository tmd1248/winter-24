using System;

class dailyEvent: Event { 
    private new TimeOnly _when = new();
    public new TimeOnly When {
        get {return _when;}
        set {_when = value;}
    }
}
using System;

class periodicEvent: Event {
    private int _repeatPeriod;
    public int repeatPeriod {
        get {return _repeatPeriod;}
        set {_repeatPeriod = value;}
    }
    
}
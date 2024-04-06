using System;

class Child : Person {
    private List<string> _parents = new();
    public List<string> Parents {
        get {return _parents;}
        set {_parents = value;}
    }

        private List<string> _siblings = new();
    public List<string> siblings {
        get {return _siblings;}
        set {_siblings = value;}
    }
    
}
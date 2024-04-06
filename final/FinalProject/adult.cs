using System;

class Adult : Person {
    private string _spouse = "";
    public string Spouse {
        get {return _spouse;}
        set {_spouse = value;}
    }

        private List<string> _children = new();
    public List<string> children {
        get {return _children;}
        set {_children = value;}
    }
    
}
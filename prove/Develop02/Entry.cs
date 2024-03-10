using System;

public class Entry() {
    private string _date;
    private string _promptText;
    private string _entryText;
    public string date {
        get {return _date;}
        set {_date = value;}
    }
    public string promptText {
        get {return _promptText;}
        set {_promptText = value;}
    }
    public string entryText {
        get {return _entryText;}
        set {_entryText = value;}
    }

    public void Display() {
        Console.WriteLine(_date);
        Console.WriteLine(_promptText);
        Console.WriteLine(_entryText);
    }
}
using System;

public class Word {
    private string _text;
    public string Text {
        get {return _text;}
        set {_text = value;}
    }
    public void Hide() {
        string hider = "";
        int counter = 0;
        while (counter <= _text.Length) {
            hider += "_";
            counter += 1;
        }
        _text = hider;
    }
}
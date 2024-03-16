using System;

public class Scripture {
    private string[] scriptureHolder;
    private int counter = 0;
    private string scriptureReturn;
    
    List<Word> _scripture = new List<Word>();
    List<int> hiddenWords = new List<int>();
    public string scripture {
        get {
            while (counter < _scripture.Count()) {
                scriptureReturn += _scripture[counter].Text + " ";
                counter += 1;
            }
            return scriptureReturn;
            } 
        set {scriptureHolder = value.Split(' ');
            foreach (var wordToBeAdded in scriptureHolder) {
                Word word = new Word();
                word.Text = wordToBeAdded;
                _scripture.Add(word);
        }
        }
    }
    public int Len {
        get { return _scripture.Count();}
    }
    
    public void HideRandomWords() {
        Random rand = new Random();
        bool tracker = false;
        while (tracker == false) {
            counter = 0;
            int selection = rand.Next(_scripture.Count());
            if (hiddenWords.Contains(selection) == false) {
                _scripture[selection].Hide();
                hiddenWords.Add(selection);
                tracker = true;
                scriptureReturn = "";
            } else if (hiddenWords.Count() == _scripture.Count()) {
                tracker = true;
            }
        }
    }

}
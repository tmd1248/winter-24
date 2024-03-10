using System;

public class Journal() {
    private List<Entry> entries = new List<Entry>();
    public void AddEntry(Entry entry) {
        entries.Add(entry);
    }
    public void DisplayAll() {
        foreach(Entry entry in entries) {
            entry.Display();
        }
    }
    public void SaveToFile(string file) {
        using (StreamWriter outputFile = new StreamWriter(file + ".txt")) {
            foreach (Entry entry in entries) {
                outputFile.WriteLine(entry.date);
                outputFile.WriteLine(entry.promptText);
                outputFile.WriteLine(entry.entryText);
            }
        }
    }
    public void LoadFromFile(string file) {
        int lineCounter = 0;
        string[] lines = System.IO.File.ReadAllLines(file + ".txt");
        Entry entry = new Entry();
        entries = new List<Entry>();

        foreach (string line in lines)
            {
                lineCounter++;
                if (lineCounter % 3 == 1){
                        entry.date = line;
                }
                    else if(lineCounter % 3 == 2){
                        entry.promptText = line;
                    }
                    else{
                        entry.entryText = line;
                        entries.Add(entry);
                    }
                }

            }
    }
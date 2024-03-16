using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the scripture memorizer. This tool will hide a random word from a given scripture at a time");
        Console.WriteLine("Type the word 'quit' to exit the program early, otherwise, pressing enter once the entire scripture is hidden will terminate the program");
        Console.WriteLine("Please enter the reference of the scripture you would like to memorize, chapter and verse");
        Reference reference = new Reference();
        reference.reference = Console.ReadLine();
        Console.WriteLine("Now enter the associated text of the scripture");
        Scripture scripture = new Scripture
        {
            scripture = Console.ReadLine()
        };
        int length = scripture.Len + 1;
        int counter= 0;
        while (counter < length) {
            Console.Clear();
            Console.WriteLine(reference.reference);
            Console.WriteLine(scripture.scripture);
            Console.WriteLine("Type the word Quit to exit early, or type anything else to repeat this process");
            string choice = Console.ReadLine();
            if (choice == "quit" || choice == "Quit") {
                counter = length;
            }
            else {
                counter += 1;
                scripture.HideRandomWords();
            }
        }
        
    }
}
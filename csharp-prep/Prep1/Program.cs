using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Tell me your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("Tell me your last name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
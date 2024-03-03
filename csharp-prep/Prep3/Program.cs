using System;

class Program
{
    static void Main(string[] args)
    {
        bool playing = true;
        while(playing == true) {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guessCounter = 0;

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
                guessCounter += 1;
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
                guessCounter += 1;
            }
            else
            {
                Console.WriteLine("You guessed it!");
                guessCounter += 1;
                Console.WriteLine("It took " + guessCounter + " tries"); 
            }

        }
            Console.WriteLine("Would you like to play again?");
            string answer = Console.ReadLine();
            if(answer != "yes") {
                playing = false;
            }

        }   
    }
}
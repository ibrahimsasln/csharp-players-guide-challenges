using System;
using System.Collections.Generic;

class CookieException : Exception
{
    public CookieException() : base("You picked the oatmeal raisin cookie!") { }
}

class Program
{
    static void Main()
    {
        List<int> chocolateCookies = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        List<int> previousGuesses = new(10);

        int randomNum = Random.Shared.Next(0, 10); // 10 exclusive
        chocolateCookies.Remove(randomNum);

        try
        {
            while (true)
            {
                Console.WriteLine("Pick a number between 0-9");

                if (!int.TryParse(Console.ReadLine(), out int userInput) || userInput < 0 || userInput > 9)
                {
                    Console.WriteLine("Invalid input used. Try again.");
                    continue;
                }

                if (chocolateCookies.Contains(userInput))
                {
                    previousGuesses.Add(userInput);
                    chocolateCookies.Remove(userInput);
                }

                else if (previousGuesses.Contains(userInput))
                {
                    Console.WriteLine("That number was already chosen.");
                }

                else
                {
                    throw new CookieException();
                }
            }
        }
        catch (CookieException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

//-----------Challenge Questions-----------

// 1) Did you make a custom exception type or use an existing one, and why did you choose what you did?

// My Answer: I created a custom exception type because as the program grows, different kinds of exceptions can occur.
// With CookieException, my catch block handles only this specific error, and any other bug is not hidden. The name also makes it clear what went wrong.


// 2) You could write this program without exceptions, but the requirements demanded an exception for learning purposes. 
// If you didn't have that requirement, would you have used an exception? Why or why not?

// My Answer: No, I wouldn't use an exception if it weren't required. Picking the bad cookie is not an error. It is a normal,
// expected outcome of the game, so a simple if check and a return would be clearer and simpler. Exceptions are meant for unexpected problems. 
// I used one here on purpose to learn how throw and try/catch work.
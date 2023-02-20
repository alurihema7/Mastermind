using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate the random four-digit secret number
            Random random = new Random();
            int secret = random.Next(1111, 6666);

            // Create an array to hold the digits of the secret number
            int[] secretDigits = new int[4];
            secretDigits[0] = (int)(secret / 1000);
            secretDigits[1] = (int)((secret % 1000) / 100);
            secretDigits[2] = (int)((secret % 100) / 10);
            secretDigits[3] = (int)(secret % 10);

            for (int i = 0; i < 4; i++)
            {
                if (secretDigits[i] < 1 || secretDigits[i] > 6)
                {
                    secretDigits[i] = random.Next(1, 7);
                }
            }
            
            // Set up the loop and the counter
            int counter = 0;
            string guess;
            int guessNum;

            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Guess the four-digit number between 1111 and 6666. " + "For every digit that is correct but in the wrong position," +
                "you'll receive a minus (-) sign, and for every digit that is both correct and in the correct position," + " you'll receive a (+) sign");

            // Loop through the player's guesses
            while (counter < 10)
            {
                // Prompt the player for their guess
                Console.Write("Enter your guess: ");
                guess = Console.ReadLine();
                if (guess.Length != 4)
                {
                    Console.WriteLine("Error: The guess must be four (4) digits in length. Try again.");
                    continue;
                }
                guessNum = int.Parse(guess);

                // Get the digits of the guess
                int[] guessDigits = new int[4];
                guessDigits[0] = (int)(guessNum / 1000);
                guessDigits[1] = (int)((guessNum % 1000) / 100);
                guessDigits[2] = (int)((guessNum % 100) / 10);
                guessDigits[3] = (int)(guessNum % 10);

                // Check the guess against the secret number
                if (guessDigits[0] == secretDigits[0] &&
                 guessDigits[1] == secretDigits[1] &&
                 guessDigits[2] == secretDigits[2] &&
                 guessDigits[3] == secretDigits[3])
                {
                    Console.WriteLine("You win!");
                    break;
                }

                else
                {
                    // Print the plus and minus signs
                    Console.Write("Result: ");

                    for (int i = 0; i < 4; i++)
                    {
                        if (guessDigits[i] == secretDigits[i])
                        {
                            Console.Write("+");
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (secretDigits.Contains(guessDigits[i]))
                        {
                            Console.Write("-");
                        }
                    }
                    Console.WriteLine();
                    counter++;
                }
            }
            if (counter == 10)
            {
                Console.WriteLine("You lose!");
            }
        }
    }
}

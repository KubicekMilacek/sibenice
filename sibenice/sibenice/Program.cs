using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] words = { "programovani", "sibenice", "visualstudio", "maty", "vyvoj softwaru", "software", "prumka" };
        Random random = new Random();
        string wordToGuess = words[random.Next(words.Length)];
        char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
        HashSet<char> guessedLetters = new HashSet<char>();
        int attemptsLeft = 6;

        Console.WriteLine("Vítejte ve hře Šibenice!");
        Console.WriteLine("Hádejte slovo po písmenech.");

        while (attemptsLeft > 0 && new string(guessedWord) != wordToGuess)
        {
            Console.WriteLine($"\nSlovo: {new string(guessedWord)}");
            Console.WriteLine($"Zbývající pokusy: {attemptsLeft}");
            Console.Write("Zadejte písmeno: ");
            char guess = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("Toto písmeno jste již hádali.");
                continue;
            }

            guessedLetters.Add(guess);

            if (wordToGuess.Contains(guess))
            {
                Console.WriteLine("Správně!");
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                    }
                }
            }
            else
            {
                Console.WriteLine("Špatně!");
                attemptsLeft--;
            }
        }

        if (new string(guessedWord) == wordToGuess)
        {
            Console.WriteLine($"\nGratulujeme! Uhodli jste slovo: {wordToGuess}");
        }
        else
        {
            Console.WriteLine($"\nProhráli jste! Hledané slovo bylo: {wordToGuess}");
        }
    }
}
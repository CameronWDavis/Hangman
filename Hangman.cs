using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

public class Hangman
{  

    static string[] wordList = new string[] {
    "apple",
    "mystery",
    "hangman",
    "programming",
    "wizard",
    "galaxy",
    "jigsaw",
    "zodiac",
    "quartz",
    "voyage",
    "guitar",
    "pizza",
    "kangaroo",
    "xylophone"
    };

    static Random rand = new Random();
    static int index = rand.Next(wordList.Length);

    static string chosenWord = wordList[index]; 
    
    public static char[] checkAnswer(char choice, char[] gussedChoice)
    { 
        for(int i = 0; i < chosenWord.Length; i++ )
        {
            if(chosenWord[i].Equals(choice))
            {
                gussedChoice[i] = choice; 
            }
        }

        foreach(char letter in gussedChoice)
        {
            if(letter == null)
            {
                gussedChoice[letter] = '_'; 
            }
        }

        return gussedChoice; 
    }

    public static void printWord(char[] guessedChoice)
    {
        foreach (char element in guessedChoice)
        {
            Console.Write(element + "  ");
        } 
    }

    
    static void Main(string[] args)
    {
        Console.WriteLine(chosenWord); 
        char[] guessedChoice = new char[chosenWord.Length]; //new Array
        int hitMisses = 0;

        while(hitMisses != chosenWord.Length)
        {
        Console.WriteLine(); 
        Console.Write("Guess a letter: ");
        char answerChoice = Console.ReadLine()[0]; 
        
        bool hit = chosenWord.Contains(answerChoice); 

        if(hit == false)
        {
            Console.WriteLine("Sorry " + answerChoice + " is not in the word"); 
            hitMisses++;
            int left = chosenWord.Length - hitMisses;  
            Console.WriteLine("There is " + left + " guesses left"); 
            continue; 
        }

        guessedChoice = checkAnswer(answerChoice, guessedChoice); 

        printWord(guessedChoice); 
        }

        
    }
}

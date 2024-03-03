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

    static List<char> chosenLetters = new List<char>();

    static int hitCorrect = 0; //global to check if player won
    
    public static char[] checkAnswer(char choice, char[] gussedChoice)
    { 
        for(int i = 0; i < chosenWord.Length; i++ )
        {
            if(chosenWord[i].Equals(choice))
            {
                gussedChoice[i] = choice; 
                hitCorrect++; 
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

    public static void printHangMan(int hitMisses)
    {

        string[] stages = new string[] {
        """
           ----
           |  |
           |
           |
           |
           |
        --------
        """,
        """
           ----
           |  |
           |  O
           |
           |
           |
        --------
        """,
        """
           ----
           |  |
           |  O
           |  |
           |
           |
        --------
        """,
        """
           ----
           |  |
           |  O
           | /|
           |
           |
        --------
        """,
        """
           ----
           |  |
           |  O
           | /|\\
           |
           |
        --------
        """,
        """
           ----
           |  |
           |  O
           | /|\\
           | /
           |
        --------
        """,
        """
           ----
           |  |
           |  O
           | /|\\
           | / \\
           |
        --------
        """
    }; //end of  print 

    Console.WriteLine(stages[hitMisses]); 

    }

    public static Boolean inList( char choice)
    {
        if(chosenLetters.Contains(choice))
        {
            return true; 
        }else{
            chosenLetters.Add(choice); 
            return false; 
        }
    }

    
    static void Main(string[] args)
    {
        Console.WriteLine(chosenWord); 
        char[] guessedChoice = new char[chosenWord.Length]; //new Array  
        int hitMisses = 0;

        while(hitMisses != 7)
        {
        Console.WriteLine(); 
        Console.Write("Guess a letter: ");
        char answerChoice = Console.ReadLine()[0]; 

        bool seeInside = inList(answerChoice); 
        while(seeInside != false)
        {

        Console.WriteLine(answerChoice + " is inside of list already cant pick same item more then once"); 
        Console.Write("Guess a letter: ");
        answerChoice = Console.ReadLine()[0]; 
        seeInside = inList(answerChoice);
        }
        
        bool hit = chosenWord.Contains(answerChoice); 

        if(hit == false)
        {
            Console.WriteLine("Sorry " + answerChoice + " is not in the word"); 
            hitMisses++;
            printHangMan(hitMisses); 
            continue; 
        }else{
            Console.WriteLine("Correct! "); 
        }

        guessedChoice = checkAnswer(answerChoice, guessedChoice); 

        printHangMan(hitMisses); 
        printWord(guessedChoice); 

        if(hitCorrect == chosenWord.Length)
        {
            Console.WriteLine("You won congrats "+ chosenWord + " was the word"); 
            Environment.Exit(0); 
        }
        }

        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, what is your name?");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("You have just been arrested for accidentally running over a mans cow in the deep south. According to the law, you have to be hanged unless you can guess a word correctly, using one letter at a time.");
            Console.WriteLine();
            Console.WriteLine();


            SouthernJustice();

            Console.WriteLine("\nPlay again? (Y / N)");
            string response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            {
                Console.WriteLine("You have just been arrested for accidentally running over a mans cow in the deep south. According to the law, you have to be hanged unless you can guess a word correctly, using one letter at a time.");
                Console.Clear();
                SouthernJustice();
            }

            Console.ReadKey();
        }
        /// <summary>
        /// function that runs the hangman game and gives responses based on the characters that have been entered
        /// </summary>
        static void SouthernJustice()
        {
            bool gameOn = true;

            int lives = 7;

            //creating word bank that will be used by the game
            List<string> wordOptions = new List<string>() { "banjo", "shotgun", "moonshine", "cornbread", "supper" };

            //will be the random index that will choose a random word from the list 
            Random rng = new Random();
            int randomWord = rng.Next(0, wordOptions.Count());

            string wordToAnswer = wordOptions[randomWord].ToUpper();

            //letters that have been guessed that were incorrect
            string wrongLetters = string.Empty;

            while (gameOn)
            {
                Console.WriteLine(CoverTheAnswer(wordToAnswer, wrongLetters));

                Console.WriteLine("Only " + lives + " chances left before we have to provide this swift Southern Justice!");

                Console.WriteLine("Better guess if you want to live");

                string input = Console.ReadLine().ToUpper();

                //Checks to make sure only 1 character was entered
                if (input.Length == 1)
                {
                    wrongLetters += input;
                    //checking to make sure that the character is actually in the word that must be guessed
                    if (wordToAnswer.Contains(input))
                    {
                        Console.WriteLine("You got lucky! I'm sure it won't happen again");
                        //checking to see if all the correct characters have been guessed
                        if (EverythingCorrect(CoverTheAnswer(wordToAnswer, wrongLetters)))
                        {
                            gameOn = false;
                            Console.WriteLine("You are free to go. You are one lucky man");
                        }
                    }
                    else
                    {
                        //will display this is character entered was incorrect
                        Console.WriteLine("Hahah wrong answer");
                        lives--;
                    }
                }
                else
                {
                    //cmakes sure you can get the right answer if you enter the entire word
                    if (wordToAnswer == input)
                    {
                        Console.WriteLine("You are one lucky person. You are free to leave");
                        gameOn = false;
                    }
                    else
                    {
                        Console.WriteLine("Haha wrong answer");
                        lives--;
                    }
                }
                //will display when all of the chances have been used
                if (lives == 0)
                {
                    gameOn = false;
                    Console.WriteLine("Seems like all your chances are used up. Get ready for some old school Southern Justice");
                }
            }
        }
        /// <summary>
        /// takes the random word that must be guessed and replaces the characters with underscores that will be filled in when correct character is chosen
        /// </summary>
        /// <param name="wordToAnswer">word that neeeds to be guessed</param>
        /// <param name="wrongLetters">incorrect letters that have been guessed</param>
        /// <returns></returns>
        public static string CoverTheAnswer(string wordToAnswer, string wrongLetters)
        {
            string uncovered = "";

            for (int i = 0; i < wordToAnswer.Length; i++)
            {
                char letter = wordToAnswer[i];

                if (wrongLetters.ToUpper().Contains(Char.ToUpper(letter)))
                {
                    uncovered += letter + " ";
                }
                else
                {
                    uncovered += "_" + " ";
                }
            }
            return uncovered;
        }

        static bool EverythingCorrect(string CoverTheAnswer)
        {
            if (CoverTheAnswer.Contains("_"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

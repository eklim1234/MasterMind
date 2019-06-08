using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        private static Maker _maker; 
        static void Main(string[] args)
        {
            _maker = new Maker();
            StartGame();
        }

        private static void StartGame()
        {
            int maxTries = Convert.ToInt16(ConfigurationManager.AppSettings["maxTries"]);
            bool gotIt = false;
            for (int lp = 0; lp < maxTries; lp++)
            {
                //get user input
                string guess = GetUserInput();
                //check user input
                gotIt = false;
                List<String> result = CheckInput(guess, out gotIt);
                //display resut
                if(gotIt)
                {
                    break;
                }
                else
                {
                    DisplayGuessResult(result);
                }
            }
            if(gotIt)
            {
                DisplaySuccess();
            }
            else
            {
                DisplayFail();
            }

            Console.Read();
        }

        private static void DisplayFail()
        {
            Console.WriteLine();
            Console.WriteLine("I am sorry, but you have not chosen wisely.");
        }

        private static void DisplaySuccess()
        {
            Console.WriteLine();
            Console.WriteLine("You guessed the numbers currectly");
        }

        private static void DisplayGuessResult(List<string> results)
        {
            Console.WriteLine();
            Console.WriteLine("Guess Results:");
            foreach(var result in results)
            {
                Console.Write("   " + result);
            }
        }

        private static List<string> CheckInput(string guess, out bool gotIt)
        {
            return _maker.CheckGuess(guess, out gotIt);
        }

        private static string GetUserInput()
        {
            Console.WriteLine();
            Console.Write("Please enter your 4 numer guess (ex: 1234): ");
            return Console.ReadLine();
        }
    }
}

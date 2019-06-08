using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mastermind.Enums;

namespace Mastermind
{
    public class Maker
    {
        private List<int> _code = new List<int>();
        private int _maxTries = Convert.ToInt16(ConfigurationManager.AppSettings["maxTries"]);
        private int _tryCount;

        public List<int> code
        {
            get { return _code; }
            set { _code = value; }
        }

        public int MaxTries
        {
            get { return _maxTries; }
        }

        public int TryCount
        {
            get { return _tryCount; }
            set { _tryCount = value; }
        }

        public Maker()
        {
            int numberCount = 0;
            while(numberCount  < 4)
            {
                int num = Helpers.GetRandonNumber();
                if(!_code.Contains(num))
                {
                    _code.Add(num);
                    numberCount++;
                }
            }
        }

        public List<String> CheckGuess(string guess, out bool gotIt)
        {
            List<String> resultList = new List<string>();
            char[] guesses = guess.ToCharArray();
            gotIt = false;
            if (guesses != null && guesses.Length > 0)
            {
                int correctCount = 0;
                for(int lp = 0; lp < guesses.Length; lp++)
                {
                    String resString = guesses[lp].ToString() + " ";
                    GuessResult gr = CheckGuess(guesses[lp], lp);
                    if(gr == GuessResult.FoundCorrectPosition)
                    {
                        correctCount++;
                        resString += "+";
                    }
                    else if (gr == GuessResult.FoundIncorrectPosition)
                    {
                        resString += "-";
                    }
                    resultList.Add(resString);
                }
                if(correctCount == 4)
                {
                    gotIt = true;
                }
                else
                {
                    gotIt = false;
                }
            }
            return resultList;
        }

        private GuessResult CheckGuess(char chr, int idx)
        {
            GuessResult result = GuessResult.NotFound;
            int val = Convert.ToInt16(chr) - 48;
            if (code.Contains(val))
            {
                int location = code.IndexOf(val);
                if(location == idx)
                {
                    result = GuessResult.FoundCorrectPosition;
                }
                else
                {
                    result = GuessResult.FoundIncorrectPosition;
                }
            }

            return result;
        }
    }
}

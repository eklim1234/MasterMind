using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Helpers
    {
        public static int GetRandonNumber()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    internal class Player
    {
        public string Name { get; private set; }

        public int Place { get; private set; }

        public bool InPenaltyBox { get; set; }

        public int Purse { get; set; }

        public Player(string n)
        {
            Name = n;
            Place = 0;
            InPenaltyBox = false;
            Purse = 0;
        }

        public void Move(int roll)
        {
            Place += roll;
            if (Place > 11) Place -= 12;
        }

        
    }
}

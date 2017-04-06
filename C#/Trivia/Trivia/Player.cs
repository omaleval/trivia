using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Player
    {

        public Player(string nom)
        {
            Nom = nom;
            Place = 0;
            GoldCoins = 0;
            InPenaltyBox = false;
        }

        public void Move(int roll)
        {
            Place += roll;
            if (Place > 11) Place -= 12;
        }

        public void WinAGoldCoin()
        {
            GoldCoins++;
            Console.WriteLine(Nom + " now has " + GoldCoins + " Gold Coins.");
        }

        public bool IsWinner()
        {
            return GoldCoins == 6;
        }

        public void GoToPenaltyBox()
        {
            InPenaltyBox = true;
        }

        public bool InPenaltyBox { get; set; }

        public int GoldCoins { get; set; }

        public int Place { get; set; }
        public string Nom { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class GameRunner
    {

        private static bool _notAWinner;

        public static void Main(string[] args)
        {
            /*Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");*/

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("-----------------------------------");
                Random rand = new Random(1);
                Game aGame = new Game();

                aGame.Add("Chet");
                aGame.Add("Pat");
                aGame.Add("Sue");

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    _notAWinner = rand.Next(9) == 7 ? aGame.WrongAnswer() : aGame.WasCorrectlyAnswered();

                } while (_notAWinner);
            }

        }


    }

}


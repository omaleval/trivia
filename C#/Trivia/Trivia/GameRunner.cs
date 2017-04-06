using System;

namespace Trivia
{
    public class GameRunner
    {

        private static bool _winner;

        public static void Main(String[] args)
        {

            for (int seed = 0; seed < 100; seed++)
            {
                
                var players = new Players();
                players.Add("Chet");
                players.Add("Pat");
                players.Add("Sue");

                Game aGame = new Game(players);
                Random rand = new Random(seed);

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        _winner = aGame.WrongAnswer();
                    }
                    else
                    {
                        _winner = aGame.WasCorrectlyAnswered();
                    }
                    Console.WriteLine(seed);
                } while (!_winner);

            }
        }


    }

}
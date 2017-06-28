using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _winner;
        public static IDispatchEvent _eventDispatcher;

        public static void Main(String[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                var players = new Players(_eventDispatcher);
                players.Add("Chet");
                players.Add("Pat");
                players.Add("Sue");

                var categories = new[] { "Pop", "Science", "Sports", "Rock" };
                var aGame = new Game(players, new Questions(categories, new GeneratedQuestions(), _eventDispatcher), _eventDispatcher);

                Random rand = new Random(i);

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
                } while (!_winner);
            }
        }
    }
}


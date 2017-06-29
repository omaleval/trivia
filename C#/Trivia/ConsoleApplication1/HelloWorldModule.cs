using System;

namespace Trivia.WebApi
{
    public class HelloWorldModule : Nancy.NancyModule
    {
        private static Game _game;
        private static WebEventDispatcher _eventDispatcher;

        public HelloWorldModule()
        {
            Get["/"] = _ => "Hello World!";
            Post["/startGame"] = StartGame;
            Post["/rollDice"] = RollDice;
        }

      
        private dynamic RollDice(dynamic arg)
        {

            var random = new Random();
            _game.Roll(random.Next(5) + 1);
            return _eventDispatcher.Output;
        }

        private dynamic StartGame(dynamic arg)
        {
            _eventDispatcher = new WebEventDispatcher();
            var players = new Players(_eventDispatcher);
            players.Add("Chet");
            players.Add("Pat");
            players.Add("Sue");

            var categories = new[] { "Pop", "Science", "Sports", "Rock" };
            _game = new Game(players, new Questions(categories, new GeneratedQuestions(), _eventDispatcher), _eventDispatcher);
            return _eventDispatcher.Output;
        }
    }
}

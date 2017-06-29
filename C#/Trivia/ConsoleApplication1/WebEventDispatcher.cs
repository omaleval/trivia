using System;

namespace Trivia.WebApi
{
    internal class WebEventDispatcher : IDispatchEvent
    {
        public void Dispatch<TEvent>(TEvent @event)
        {
            if (@event.GetType() == typeof(PlayerRolledDice))
            {
                var playerRolledDice = @event as PlayerRolledDice;
                Display(playerRolledDice.Name + " is the current player");
                Display("They have rolled a " + playerRolledDice.Roll);
            }
            else if (@event.GetType() == typeof(PlayerGetOutOfPenaltyBox))
            {
                Display((@event as PlayerGetOutOfPenaltyBox).Name + " is getting out of the penalty box");
            }
            else if (@event.GetType() == typeof(PlayerWonAGoldPoint))
            {
                Display("Answer was correct!!!!");
                var playerWonAGoldPoint = @event as PlayerWonAGoldPoint;
                Display(playerWonAGoldPoint.Name + " now has " + playerWonAGoldPoint.GoldCoins + " Gold Coins.");
            }

        }

        public void Display(string message)
        {
            Output += message + "\n";
        }

        public string Output { get; set; }
    }
}
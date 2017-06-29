using System;

namespace Trivia
{
    public class ConsoleDispatchEvent : IDispatchEvent
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void Dispatch<TEvent>(TEvent @event)
        {
            if (@event.GetType() == typeof(PlayerRolledDice))
            {
                var playerRolledDice = @event as PlayerRolledDice;
                Console.WriteLine(playerRolledDice.Name + " is the current player");
                Console.WriteLine("They have rolled a " + playerRolledDice.Roll);
            }
        }
    }
}
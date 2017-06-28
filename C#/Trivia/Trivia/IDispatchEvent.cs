using System;

namespace Trivia
{
    public interface IDispatchEvent
    {
        void Display(String texte);

        void Dispatch<TEvent>(TEvent playerRolledDice);
    }
}
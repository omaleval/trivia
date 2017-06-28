using System;

namespace Trivia
{
    public class Display : IDispatchEvent
    {
        void IDispatchEvent.Display(string text)
        {
            Console.WriteLine(text);
        }
    }
}

using System;

namespace Trivia
{
    class Display : IIDisplay
    {
        void IIDisplay.Display(string text)
        {
            Console.WriteLine(text);
        }
    }
}

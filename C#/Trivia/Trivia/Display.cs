using System;

namespace Trivia
{
    public class Display : IIDisplay
    {
        void IIDisplay.Display(string text)
        {
            Console.WriteLine(text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class Questions
    {

        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() { { 0, "Pop" }, { 1, "Science" }, { 2, "Sports" }, { 3, "Rock" } };

        readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        public void AskQuestion(int currentPlayerPlace)
        {
            if (CurrentCategory(currentPlayerPlace) == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlayerPlace) == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlayerPlace) == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlayerPlace) == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        public String CurrentCategory(int currentPlayerPlace)
        {
            return _categories[currentPlayerPlace % 4];
        }


        public void Generate()
        {
            for (int i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public String CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

    }
}
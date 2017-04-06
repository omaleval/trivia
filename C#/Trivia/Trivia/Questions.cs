using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class Questions
    {

        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() { { 0, "Pop" }, { 1, "Science" }, { 2, "Sports" }, { 3, "Rock" } };


        readonly QuestionStack _popQuestions = new QuestionStack("Pop");
        readonly QuestionStack _scienceQuestions = new QuestionStack("Science");
        readonly QuestionStack _sportsQuestions = new QuestionStack("Sports");
        readonly QuestionStack _rockQuestions = new QuestionStack("Rock");

        public void AskQuestion(int currentPlayerPlace)
        {
            if (CurrentCategory(currentPlayerPlace) == "Pop")
            {
                _popQuestions.AskQuestion();
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlayerPlace) == "Science")
            {
                _scineceQuestions.AskQuestion();
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlayerPlace) == "Sports")
            {
                _sportsQuestions.AskQuestion();
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlayerPlace) == "Rock")
            {
                _rockQuestions.AskQuestion();
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
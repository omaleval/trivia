using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class QuestionsStack
    {
        private readonly LinkedList<string> _questions;
        public string Category { get; private set; }

        public QuestionsStack(string category, Func<string, LinkedList<string>> getQuestions)
        {
            Category = category;
            _questions=getQuestions(Category);
        }

        
        public void AskQuestionAndDiscard()
        {
            Console.WriteLine(_questions.First());
            _questions.RemoveFirst();
        }
    }
}
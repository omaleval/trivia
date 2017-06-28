using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class QuestionsStack
    {
        private readonly LinkedList<string> _questions = new LinkedList<string>();
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IIDisplay _display;

        public QuestionsStack(string category, IQuestionsRepository questionsRepository, IIDisplay display)
        {
            Category = category;
            _questionsRepository = questionsRepository;
            _display = display;
            _questions = _questionsRepository.Get(category);
        }
        
        public string Category { get; private set; }

        public void AskQuestionAndDiscard()
        {
            _display.Display(_questions.First());
            _questions.RemoveFirst();
        }
    }
}
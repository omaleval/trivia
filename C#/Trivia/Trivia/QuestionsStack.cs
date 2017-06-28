using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class QuestionsStack
    {
        private readonly LinkedList<string> _questions = new LinkedList<string>();
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IDispatchEvent _eventDispatcher;

        public QuestionsStack(string category, IQuestionsRepository questionsRepository, IDispatchEvent display)
        {
            Category = category;
            _questionsRepository = questionsRepository;
            _eventDispatcher = display;
            _questions = _questionsRepository.Get(category);
        }
        
        public string Category { get; private set; }

        public void AskQuestionAndDiscard()
        {
            _eventDispatcher.Display(_questions.First());
            _questions.RemoveFirst();
        }
    }
}
using System.Collections.Generic;

namespace Trivia
{
    public class Questions
    {
        private readonly List<QuestionsStack> _categories = new List<QuestionsStack>();
        private readonly IDispatchEvent _eventDispatcher;

        public Questions(IEnumerable<string> categories, IQuestionsRepository questionsRepository, IDispatchEvent display)
        {
            _eventDispatcher = display;
            foreach (var category in categories)
            {
                var questionsStack = new QuestionsStack(category, questionsRepository, display);
                _categories.Add(questionsStack);
            }
        }

        public void AskQuestion(int currentPlayerPlace)
        {
            _eventDispatcher.Display("The category is " + _categories[currentPlayerPlace % _categories.Count].Category);
            _categories[currentPlayerPlace % _categories.Count].AskQuestionAndDiscard();
        }
    }
}
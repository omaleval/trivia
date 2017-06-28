using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Questions
    {
        private readonly List<QuestionsStack> _categories = new List<QuestionsStack>();
        private readonly IIDisplay _display;

        public Questions(IEnumerable<string> categories, IQuestionsRepository questionsRepository, IIDisplay display)
        {
            _display = display;
            foreach (var category in categories)
            {
                var questionsStack = new QuestionsStack(category, questionsRepository, display);
                _categories.Add(questionsStack);
            }
        }

        public void AskQuestion(int currentPlayerPlace)
        {
            _display.Display("The category is " + _categories[currentPlayerPlace % _categories.Count].Category);
            _categories[currentPlayerPlace % _categories.Count].AskQuestionAndDiscard();
        }
    }
}
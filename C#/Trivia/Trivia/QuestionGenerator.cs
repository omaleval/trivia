using System;
using System.Collections.Generic;

namespace Trivia
{
    public class QuestionGenerator : IQuestionRepository
    {

        public LinkedList<string> GetQuestion(String category)
        {
            LinkedList<string> liste = new LinkedList<string>();

            for (var i = 0; i < 50; i++)
            {
                liste.AddLast(category + " Question " + i);
            }

            return liste;
        }
    }
}
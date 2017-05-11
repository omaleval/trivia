using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Trivia
{
    public interface IQuestionRepository
    {
        LinkedList<string> GetQuestion(String category);
    }
}
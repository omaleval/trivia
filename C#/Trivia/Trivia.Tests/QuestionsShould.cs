using System;
using System.IO;
using NFluent;
using NUnit.Framework;

namespace Trivia.Tests
{
    public class QuestionsShould
    {
        [Test]
        public void AllowToPlayWith5Categories()
        {
            var stringWriter = new StringWriter();
            var previousConsoleOut = Console.Out;
            Console.SetOut(stringWriter);
            var questions = new Questions(new [] { "Pop", "Science", "Sports", "Rock", "Cinema" }, new QuestionGenerator().GetQuestion);

            questions.AskQuestion(4);

            Console.SetOut(previousConsoleOut);
            //Assert.That(stringWriter.ToString().Contains("Cinema"), Is.True);
            Check.That(stringWriter.ToString()).Contains("Cinema");
        } 
    }
}

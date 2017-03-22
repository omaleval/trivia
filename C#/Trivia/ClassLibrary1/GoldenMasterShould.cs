using System;
using System.IO;
using System.Runtime.Serialization;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Trivia.Tests
{

    [TestFixture]
    class GoldenMasterShould
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void NotChange()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            GameRunner.Main(null);

            Approvals.Verify(stringWriter);
            //Assert.Test(false, IS.True);
        }
    }
}

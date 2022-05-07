using NUnit.Framework;

namespace DacaSoft.MSBuild.GitHubLogger.Tests
{

    [TestFixture]
    public class TestBuilderGitHubLogger
    {
        [Test]
        public void FormatEvent_FormatsMessageWithoutEndLineAndColumn()
        {
            var message = BuilderGitHubLogger.FormatEvent("test-severity", "test-file", 45, 0, 67, 0, "test-code", "test::message: line,1\r\nline-2");
            var expected = "::test-severity file=test-file,line=45,endLine=45,col=67,endColumn=67,title=[test-code] test%3A%3Amessage%3A line%2C1::test::message: line,1%0Aline-2";
            Assert.AreEqual(message, expected);
        }

        [Test]
        public void FormatEvent_FormatsMessageWithEndLineAndColumn()
        {
            var message = BuilderGitHubLogger.FormatEvent("test-severity", "test-file", 45, 50, 67, 70, "test-code", "test::message: line,1\r\nline-2");
            var expected = "::test-severity file=test-file,line=45,endLine=50,col=67,endColumn=70,title=[test-code] test%3A%3Amessage%3A line%2C1::test::message: line,1%0Aline-2";
            Assert.AreEqual(message, expected);
        }
    }
}
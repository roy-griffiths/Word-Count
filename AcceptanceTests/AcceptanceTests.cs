using NBehave.Fluent.Framework.Extensions;
using NBehave.Narrator.Framework;
using NBehave.Fluent.Framework.NUnit;
using NUnit.Framework;

using Wordcount;
using Application;


namespace AcceptanceTests
{
    [ActionSteps]
    public class TestHelper
    {
        #region Fields

        private Application.Application application;
        private string input;
        private string output;

        #endregion


        #region Action Steps

        [Given(@"the sentence ''")]
        [Given(@"the sentence '$sentence'")]
        protected void Init(string sentence)
        {
            application = new Application.Application(new SentenceAnalyzer(), new OutputRenderer());
            input = sentence ?? "";
        }

        [When(@"the sentence is analyzed")]
        protected void AnalyzeSentence()
        {
            output = application.AnalyzeSentence(input);
        }

        [Then(@"the output should be $result")]
        protected void ValidateResult(string result)
        {
            Assert.AreEqual(result, output);
        }

        #endregion
    }


    [TestFixture]
    public sealed class AcceptanceTests :  ScenarioDrivenSpecBase 
    {
        #region Non-Public Methods

        protected override Feature CreateFeature()
        {
            return new Feature("Count of words in sentence")
                .AddStory()
                .AsA("author")
                .IWant("to know the number of times each word appears in a sentence")
                .SoThat("I can make sure that I'm not repeating myself");
        }

        #endregion


        #region Test Scenarios

        [Test]
        public void CanCountWordsWhereNoDuplicates()
        {
            const string input = "This is a test.";
            const string expected = "Input: This is a test.\r\nOutput:\r\nthis - 1\r\nis - 1\r\na - 1\r\ntest - 1";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }


        [Test]
        public void CanCountWordsWhereSentenceContainsDuplicatesWithSameCase()
        {
            const string input = "This test is an acceptance test.";
            const string expected = "Input: This test is an acceptance test.\r\nOutput:\r\nthis - 1\r\ntest - 2\r\nis - 1\r\nan - 1\r\nacceptance - 1";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }


        [Test]
        public void CanCountWordsWhereSentenceContainsDuplicatesWithDifferingCase()
        {
            const string input = "This is a statement and so is this.";
            const string expected = "Input: This is a statement and so is this.\r\nOutput:\r\nthis - 2\r\nis - 2\r\na - 1\r\nstatement - 1\r\nand - 1\r\nso - 1";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }


        [Test]
        public void CanCountWordsWhereSentenceContainsPunctuation()
        {
            const string input = "This is a statement, and so is this.";
            const string expected = "Input: This is a statement, and so is this.\r\nOutput:\r\nthis - 2\r\nis - 2\r\na - 1\r\nstatement - 1\r\nand - 1\r\nso - 1";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }


        [Test]
        public void CanCountWordsWhereSentenceContainsWhitespace()
        {
            const string input = " This is a  test. ";
            const string expected = "Input:  This is a  test. \r\nOutput:\r\nthis - 1\r\nis - 1\r\na - 1\r\ntest - 1";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }


        [Test]
        public void CanCountWordsWhereSentenceIsBlank()
        {
            const string input = "";
            const string expected = "Input: \r\nOutput:";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }


        [Test]
        public void CanCountWordsWhereSentenceDoesNotContainWords()
        {
            const string input = ".";
            const string expected = "Input: .\r\nOutput:";

            Feature.AddScenario()
                .WithHelperObject<TestHelper>()
                .Given("the sentence '" + input + "'")
                .When("the sentence is analyzed")
                .Then("the output should be " + expected);
        }

        #endregion
    }
}

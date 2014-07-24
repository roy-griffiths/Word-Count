using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using Wordcount;

namespace UnitTests
{
    [TestFixture]
    public sealed class SentenceAnalyzerTests
    {
        #region Test Cases

        [Test]
        public void CanAnalyseSentence()
        {
            const string input = "This is a test.";

            SentenceAnalyzer sentenceAnalyzer = new SentenceAnalyzer();

            SentenceWithWordCounts result = sentenceAnalyzer.AnalyzeSentence(input);

            Assert.AreEqual(input, result.Sentence);

            IDictionary<string, int> counts = result.WordCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
            Assert.AreEqual(1, counts["this"]);
            Assert.AreEqual(1, counts["is"]);
            Assert.AreEqual(1, counts["a"]);
            Assert.AreEqual(1, counts["test"]);
        }


        [Test]
        public void CanAnalyseSentenceWithDuplicateWords()
        {
            const string input = "This is a statement and so is this.";

            SentenceAnalyzer sentenceAnalyzer = new SentenceAnalyzer();

            SentenceWithWordCounts result = sentenceAnalyzer.AnalyzeSentence(input);

            Assert.AreEqual(input, result.Sentence);

            IDictionary<string, int> counts = result.WordCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
            Assert.AreEqual(2, counts["this"]);
            Assert.AreEqual(2, counts["is"]);
            Assert.AreEqual(1, counts["a"]);
            Assert.AreEqual(1, counts["statement"]);
            Assert.AreEqual(1, counts["and"]);
            Assert.AreEqual(1, counts["so"]);
        }


        [Test]
        public void CanAnalyseSentenceWithPunctuation()
        {
            const string input = "This is a statement, and so is this.";

            SentenceAnalyzer sentenceAnalyzer = new SentenceAnalyzer();

            SentenceWithWordCounts result = sentenceAnalyzer.AnalyzeSentence(input);

            Assert.AreEqual(input, result.Sentence);

            IDictionary<string, int> counts = result.WordCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
            Assert.AreEqual(2, counts["this"]);
            Assert.AreEqual(2, counts["is"]);
            Assert.AreEqual(1, counts["a"]);
            Assert.AreEqual(1, counts["statement"]);
            Assert.AreEqual(1, counts["and"]);
            Assert.AreEqual(1, counts["so"]);
        }


        [Test]
        public void CanHAndleEmptyStringWhenAnalyseSentence()
        {
            const string input = "";

            SentenceAnalyzer sentenceAnalyzer = new SentenceAnalyzer();

            SentenceWithWordCounts result = sentenceAnalyzer.AnalyzeSentence(input);

            Assert.AreEqual(input, result.Sentence);

            IDictionary<string, int> counts = result.WordCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
            Assert.AreEqual(0, counts.Count);
        }


        [Test]
        public void CanHAndleNoWordsInStringWhenAnalyseSentence()
        {
            const string input = ".";

            SentenceAnalyzer sentenceAnalyzer = new SentenceAnalyzer();

            SentenceWithWordCounts result = sentenceAnalyzer.AnalyzeSentence(input);

            Assert.AreEqual(input, result.Sentence);

            IDictionary<string, int> counts = result.WordCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
            Assert.AreEqual(0, counts.Count);
        }

        #endregion
    }
}

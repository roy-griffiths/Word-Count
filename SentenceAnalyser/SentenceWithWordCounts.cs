using System.Collections.Generic;

namespace Wordcount
{
    public sealed class SentenceWithWordCounts
    {
        private readonly string sentence;
        private readonly IEnumerable<WordCount> wordCounts;

        public SentenceWithWordCounts(string sentence, IEnumerable<WordCount> wordCounts)
        {
            this.sentence = sentence;
            this.wordCounts = wordCounts;
        }

        public string Sentence
        {
            get { return sentence; }
        }

        public IEnumerable<WordCount> WordCounts
        {
            get { return wordCounts; }
        }
    }
}
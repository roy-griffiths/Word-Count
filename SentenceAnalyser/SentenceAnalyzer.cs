using System;
using System.Collections.Generic;
using System.Linq;


namespace Wordcount
{
    public sealed class SentenceAnalyzer
    {
        private static readonly char[] EndOfSentenceChars = new[] { '.', '?' };
        private static readonly char[] PunctuationChars = new[] {' ', ',', ';', ':'};

        public SentenceWithWordCounts AnalyzeSentence(string sentence)
        {
            string parsedSentence = sentence.Trim().TrimEnd(EndOfSentenceChars);
            IEnumerable<string> words = parsedSentence.Split(PunctuationChars, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());

            IEnumerable<WordCount> wordCounts = words.GroupBy(w => w).Select(group => new WordCount {Word = group.Key, Count = group.Count()});

            SentenceWithWordCounts sentenceWithWordCounts = new SentenceWithWordCounts(sentence, wordCounts);
            return sentenceWithWordCounts;
        }
    }
}

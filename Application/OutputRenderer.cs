using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordcount;

namespace Application
{
    public sealed class OutputRenderer
    {
        public string FormatOutput(SentenceWithWordCounts sentenceWithWordCount)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("Input: {0}\r\nOutput:", sentenceWithWordCount.Sentence));

            foreach (WordCount wordCount in sentenceWithWordCount.WordCounts)
            {
                stringBuilder.AppendFormat("\r\n{0} - {1}", wordCount.Word, wordCount.Count);
            }

            string output = stringBuilder.ToString();
            return output;
        }
    }
}

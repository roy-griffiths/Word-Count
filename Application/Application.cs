using Wordcount;


namespace Application
{
    public sealed class Application
    {
        #region Fields

        private readonly SentenceAnalyzer sentenceAnalyzer;
        private readonly OutputRenderer outputRenderer;

        #endregion


        #region Constructor

        public Application(SentenceAnalyzer sentenceAnalyzer, OutputRenderer outputRenderer)
        {
            this.sentenceAnalyzer = sentenceAnalyzer;
            this.outputRenderer = outputRenderer;
        }

        #endregion


        #region Public Methods

        public string AnalyzeSentence(string sentence)
        {
            SentenceWithWordCounts result = sentenceAnalyzer.AnalyzeSentence(sentence);
            string output = outputRenderer.FormatOutput(result);

            return output;
        }

        #endregion
    }
}

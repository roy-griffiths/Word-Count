using System;

using Wordcount;


namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: {0} <sentence>", AppDomain.CurrentDomain.FriendlyName);
            }
            else
            {
                Application application = new Application(new SentenceAnalyzer(), new OutputRenderer());

                string sentence = args[0];
                string output = application.AnalyzeSentence(sentence);

                Console.WriteLine(output);
            }

            Console.WriteLine("Press return to exit.");
            Console.ReadLine();
        }
    }
}

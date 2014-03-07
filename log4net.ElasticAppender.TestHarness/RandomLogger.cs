using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace log4net.NoSql.TestHarness
{
    public class RandomLogger
    {
        private readonly ILog _logger;

        public int NumberOfEntries { get; set; }

        public RandomLogger(ILog logger)
        {
            _logger = logger;
        }

        public void Debug()
        {
            _logger.Debug(LoremIpsum(5, 8, 1, 1, 1));
        }

        public void Info()
        {
            _logger.Debug(LoremIpsum(5, 8, 1, 1, 1));

        }
        public void Warn()
        {
            _logger.Warn(LoremIpsum(5, 8, 1, 1, 1));
        }

        public void Error()
        {
            Ex();
        }

        public void Fatal()
        {
            Ex();
        }

        public void Ex()
        {
            try
            {
                throw new ApplicationException(LoremIpsum(5, 8, 1, 3, 2));
            }
            catch (Exception ex)
            {
                _logger.Error(LoremIpsum(5, 8, 1, 1, 1), ex);    
            }
        }

        private static string LoremIpsum(int minWords, int maxWords,
            int minSentences, int maxSentences,
            int numParagraphs)
        {

            var words = new[]
            {
                "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"
            };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                               + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            string result = string.Empty;

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0)
                        {
                            result += " ";
                        }
                        result += words[rand.Next(words.Length)];
                    }
                    result += ". ";
                }
            }

            return result;
        }


        public void Start()
        {

            for (var i = 0; i < NumberOfEntries; i++)
            {
                var logLevel = new Random(i).Next(1, 7);
                switch (logLevel)
                {
                    case 1:
                        Debug();
                        break;
                    case 2:
                        Info();
                        break;
                    case 3:
                        Warn();
                        break;
                    case 4:
                        Error();
                        break;
                    case 5:
                        Ex();
                        break;
                    case 6:
                        Fatal();
                        break;
                }
            }


        }
    }
}
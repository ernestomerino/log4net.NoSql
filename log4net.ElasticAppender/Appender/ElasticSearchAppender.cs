using System;
using System.IO;
using System.Text;
using log4net.Appender;
using log4net.Core;
using log4net.ElasticSearch.Util;
using log4net.NoSql.Util;

namespace log4net.NoSql.Appender
{
    public class ElasticSearchAppender : AppenderSkeleton
    {
        private volatile ElasticSearchClient _elasticSearchClient;
        private object _padlock = new object();

        public string Host { get; set; }
        public string Port { get; set; }
        public string Index { get; set; }
        public string DocumentType { get; set; }

        public ElasticSearchAppender()
        {
        }

        private ElasticSearchClient GetClient()
        {
            //we do this here since log4net has not had time to set the configuration properties 
            //at _elasticSearchClient - so we do a double check, single lock on the client
            if (_elasticSearchClient == null)
            {
                lock (_padlock)
                {
                    if (_elasticSearchClient == null)
                        _elasticSearchClient = new ElasticSearchClient(Host, int.Parse(Port));
                }
            }
            return _elasticSearchClient;
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            base.Layout.Format(writer, loggingEvent);
            Console.WriteLine(sb.ToString());

            GetClient().Insert(Index, DocumentType, sb.ToString());
            
            

        }
    }
}

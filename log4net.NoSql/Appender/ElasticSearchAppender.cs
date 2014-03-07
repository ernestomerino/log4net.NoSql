using System;
using System.IO;
using System.Text;
using log4net.Appender;
using log4net.Core;
using log4net.NoSql.Util;

namespace log4net.NoSql.Appender
{
    public class ElasticSearchAppender : AppenderSkeleton
    {
        private volatile ElasticSearchClient _elasticSearchClient;
        private readonly object _padlock = new object();

        public string Host { get; set; }
        public string Port { get; set; }
        public string Index { get; set; }
        public string DocumentType { get; set; }

        public ElasticSearchAppender()
        {
        }

        private ElasticSearchClient Client
        {
            get
            {
                //we do this here since log4net has not had time to set the configuration properties 
                //at constructor - so we do a double check, single lock on the client
                if (_elasticSearchClient != null) return _elasticSearchClient;
                
                lock (_padlock)
                {
                    if (_elasticSearchClient == null)
                        _elasticSearchClient = new ElasticSearchClient(Host, int.Parse(Port));
                }
                return _elasticSearchClient;    
            }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            base.Layout.Format(writer, loggingEvent);
            Console.WriteLine(sb.ToString());
            Client.Insert(Index, DocumentType, sb.ToString());
        }
    }
}

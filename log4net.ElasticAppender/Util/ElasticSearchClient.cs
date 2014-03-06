using System;
using System.Net;
using System.Text;

namespace log4net.NoSql.Util
{
    public class ElasticSearchClient
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _baseUri;
        public ElasticSearchClient(string host, int port)
        {
            _host = host;
            _port = port;
            _baseUri = string.Format("http://{0}:{1}", host, port);

        }

        public void Insert(string index, string type, string log)
        {

            using (var client = new WebClient())
            {
                var url = string.Format("{0}/{1}/{2}", _baseUri, index, type);
                client.UploadData(new Uri(url), Encoding.UTF8.GetBytes(log));
                
            }

        }
        


    }
}

using System;
using System.Net;
using System.Text;
using RestSharp;

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

            var client = new RestClient(_baseUri);
            var request = new RestRequest(index + "/" + type);

            request.AddParameter("application/json; charset=utf-8", log, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            request.AddBody(log);

            try
            {
                client.ExecuteAsync(request, response => { });

                //client.ExecuteAsyncPost(request, null, "POST");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}

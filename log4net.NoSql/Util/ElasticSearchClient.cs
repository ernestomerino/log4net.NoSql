﻿using System;
using System.Net;
using System.Text;
using RestSharp;
using System.Diagnostics;

namespace log4net.NoSql.Util
{
    public class ElasticSearchClient
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _baseUri;
        private readonly RestClient _restClient;
        public ElasticSearchClient(string host, int port)
        {
            _host = host;
            _port = port;
            _baseUri = string.Format("http://{0}:{1}", host, port);

            _restClient = new RestClient(_baseUri);


        }

        public void Insert(string index, string type, string log)
        {
            var request = new RestRequest(index + "/" + type);

            request.AddParameter("application/json; charset=utf-8", log, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            request.AddBody(log);
            
            try
            {
                //dont care about response as if it fails should not throw any exceptions
                _restClient.ExecuteAsync(request, response => { });
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
            }

        }

    }
}

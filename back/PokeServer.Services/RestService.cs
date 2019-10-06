using Microsoft.Extensions.Options;
using PokeServer.Models.Configuration;
using PokeServer.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokeServer.Services
{
    public class RestService<T> : IRestService<T> where T : new()
    {
        private RestClient _client;

        public RestService(IOptions<EnvConfig> config)
        {
            _client = new RestClient(config.Value.PokeApi.Url);
        }

        public T Request(string endPoint, string method, Dictionary<string, object> parameters = null, Dictionary<string, object> headers = null, Dictionary<string, object> queryParameters = null, string body = null)
        {
            
            RestRequest request = new RestRequest(endPoint, Enum.Parse<Method>(method));

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    request.AddHeader(key, headers[key].ToString());
                }
            }

            if (parameters != null)
            {
                foreach (var key in parameters.Keys)
                {
                    request.AddParameter(key, parameters[key]);
                }
            }

            if (queryParameters != null)
            {
                foreach (var key in queryParameters.Keys)
                {
                    request.AddQueryParameter(key, queryParameters[key].ToString());
                }
            }

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
                return default(T);

            return NetJSON.NetJSON.Deserialize<T>(response.Content);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Services.Interfaces
{
    public interface IRestService<T>
    {
        T Request(string endPoint, string method, Dictionary<string, object> parameters = null, Dictionary<string, object> headers = null, Dictionary<string, object> queryParameters = null, string body = null);
    }
}

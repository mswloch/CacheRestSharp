using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CacheRestSharp;

namespace CacheRestSharp
{
    public class CacheRestClient : RestClient
    {
        public CacheRestClient(string resource) : base(resource)
        {

        }

        /// <summary>
        /// Send to server and wait for response
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="request"></param>
        /// <param name="OnComplete">Action on Complete</param>
        /// <param name="OnError">Action on get Error</param>
        public void Send<T>(CacheRestRequest request, Action<T> OnComplete, Action<Exception,string> OnError)
        {
            string value = string.Empty;
            if (!Cache.Get(request.ToCache(), out value))
            {
                this.ExecuteAsync(request, response =>
                {
                    if (response.ErrorException == null)
                    {
                        Cache.Add(request.ToCache(), response.Content);
                        T obj = JsonConvert.DeserializeObject<T>(response.Content);
                        OnComplete(obj);
                    }
                    else
                        OnError(response.ErrorException, response.ErrorMessage);
                });
            }
            else
            {
                T obj = JsonConvert.DeserializeObject<T>(value);
                OnComplete(obj);
            }             
        }
    }
}

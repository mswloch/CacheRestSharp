using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheRestSharp
{
    public class CacheRestRequest: RestRequest
    {
        public CacheRestRequest(string resource, Method method) : base(resource, method)
        {

        }

        /// <summary>
        /// Change object to string
        /// </summary>
        /// <returns></returns>
        public string ToCache()
        {
            string cacheValueKey = string.Empty ;
            this.Parameters.ForEach(x => cacheValueKey += string.Format("{0}:{1}:{2}:{3}", x.Name, x.Value, x.Type, x.ContentType));
            cacheValueKey += this.Resource;
            return cacheValueKey;
        }


    }
}

using CacheRestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheRestSharp;
using RestSharp;
using TestApp.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCache();
            CacheRestClient client = new CacheRestClient("http://swapi.co/api/");
            CacheRestRequest req = new CacheRestRequest("people/1", Method.GET);

            client.Send<PeopleModel>(req, OnComplete, OnError);

            Console.ReadLine();
        }

        private static void OnError(Exception arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        private static void OnComplete(PeopleModel obj)
        {
            Console.WriteLine(obj.name);
            
        }
    }
}

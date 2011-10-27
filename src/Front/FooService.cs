using System;
using System.Net;
using Contracts;
using Newtonsoft.Json;

namespace Front
{
    /// <summary>
    /// This is the frontend implementation of Foo Service
    /// </summary>
    public class FooService : IFooService
    {
        private const string ServiceUrl = "http://localhost:4947/Foo";
     
        /// <summary>
        /// This method retrieves result from server asynchronously and can be moved to the base class of all client-side services
        /// </summary>
        private static FutureResult<T> Get<T>(string queryString)
        {
            var result = new FutureResult<T>(); 

            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (sender, e) =>
            {
                var responseObject = JsonConvert.DeserializeObject<T>(e.Result);                
                result.HandleResult(responseObject);
            };
            webClient.DownloadStringAsync(new Uri(String.Format("{0}/{1}", ServiceUrl, queryString)));

            return result;
        }
                
        public FutureResult<Foo> GetOne(int id)
        {            
            return Get<Foo>(String.Format("GetOne/{0}", id)); // get rid of string literal here
        }
    }
}

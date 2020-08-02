using System.Collections.Generic;

namespace Melon.Net.Http.HttpClientConfiguration
{
    /// <summary>
    /// The configuration for http client request
    /// </summary>
    public class HttpClientConfiguration: IHttpClientConfiguration
    {
      public string BaseUrl { get; set; }

        public IDictionary<string, string> HttpRequestMessageHeaders { get; set; }
    }
}
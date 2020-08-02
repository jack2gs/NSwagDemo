using System.Collections.Generic;

namespace Melon.Net.Http.HttpClientConfiguration
{
    /// <summary>
    /// The client configuration
    /// </summary>
    public interface IHttpClientConfiguration
    {
        string BaseUrl { get; set; }

        IDictionary<string, string> HttpRequestMessageHeaders { get; set; }
    }
}
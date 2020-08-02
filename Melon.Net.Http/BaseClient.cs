using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Melon.Net.Http.HttpClientConfiguration;

namespace Melon.Net.Http
{
    /// <summary>
    /// Base Client
    /// </summary>
    public abstract class BaseClient: IHttpClient
    {
        protected readonly IHttpClientConfiguration ClientConfiguration;

        /// <summary>
        /// The http client configuration, base url can be injected either by HttpClient or the configuration.
        /// </summary>
        /// <param name="clientConfiguration"></param>
        public BaseClient(IHttpClientConfiguration clientConfiguration)
        {
            ClientConfiguration = clientConfiguration;
        }

        protected string BaseUrl => ClientConfiguration.BaseUrl;

        protected  Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            HttpRequestMessage message = new HttpRequestMessage();

            if (ClientConfiguration.HttpRequestMessageHeaders != null)
            {
                foreach (var header in ClientConfiguration.HttpRequestMessageHeaders)
                {
                    message.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return Task.FromResult(message);
        }
    }
}
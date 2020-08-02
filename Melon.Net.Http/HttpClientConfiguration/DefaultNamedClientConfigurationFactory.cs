using System;
using Microsoft.Extensions.Options;

namespace Melon.Net.Http.HttpClientConfiguration
{
    /// <summary>
    /// The default named client configuration factory
    /// </summary>
    public class DefaultNamedClientConfigurationFactory: INamedClientConfigurationFactory
    {
        private readonly IOptionsMonitor<HttpClientConfigurationFactoryOptions> _optionsMonitor;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="optionsMonitor"></param>
        public DefaultNamedClientConfigurationFactory(IOptionsMonitor<HttpClientConfigurationFactoryOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }

        /// <summary>
        /// Create named client configuration
        /// </summary>
        /// <param name="name">the name of configuration</param>
        /// <returns>the client configuration</returns>
        public IHttpClientConfiguration CreateClientConfiguration(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            HttpClientConfiguration httpClientConfiguration = new HttpClientConfiguration();
            HttpClientConfigurationFactoryOptions clientFactoryOptions = this._optionsMonitor.Get(name);
            foreach (var httpClientConfigurationAction in clientFactoryOptions.HttpClientConfigurationActions)
                httpClientConfigurationAction(httpClientConfiguration);

            return httpClientConfiguration;
        }
    }
}

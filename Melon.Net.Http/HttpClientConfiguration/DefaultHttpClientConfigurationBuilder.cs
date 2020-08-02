using Microsoft.Extensions.DependencyInjection;

namespace Melon.Net.Http.HttpClientConfiguration
{
    /// <summary>
    /// the default client configuration builder
    /// </summary>
    public class DefaultHttpClientConfigurationBuilder: IHttpClientConfigurationBuilder
    {
        /// <summary>
        /// the name of the configuration
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The service collection
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">the name of the configuration</param>
        /// <param name="services">the service collection</param>
        public DefaultHttpClientConfigurationBuilder(IServiceCollection services, string name)
        {
            Name = name;
            Services = services;
        }
    }
}

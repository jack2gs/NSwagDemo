using Microsoft.Extensions.DependencyInjection;

namespace Melon.Net.Http.HttpClientConfiguration
{
    /// <summary>
    /// The client configuration builder
    /// </summary>
    public interface IHttpClientConfigurationBuilder
    {
        /// <summary>
        /// Gets the name of the client configured by this builder.
        /// </summary>
        string Name { get; }

        /// <summary>Gets the application service collection.</summary>
        IServiceCollection Services { get; }
    }
}

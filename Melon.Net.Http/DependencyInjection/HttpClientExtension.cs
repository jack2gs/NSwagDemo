using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Melon.Net.Http.HttpClientConfiguration;
using Melon.Net.Http.Resolver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Melon.Net.Http.DependencyInjection
{
    /// <summary>
    /// Add http client services extension
    /// </summary>
    public static class HttpClientExtension
    {
        /// <summary>
        /// Add http client services extension
        /// </summary>
        /// <param name="serviceCollection">the service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddHttpClientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient();
            serviceCollection.TryAddSingleton<INameOfNamedClientsResolver, DefaultNameOfNamedClientsResolver>();
            serviceCollection
                .TryAddSingleton<IClientImplementationClassResolver, DefaultClientImplementationClassResolver>();
            serviceCollection.TryAddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();
            serviceCollection.TryAddSingleton<INamedClientConfigurationFactory, DefaultNamedClientConfigurationFactory>();

            return serviceCollection;
        }

        public static IServiceCollection AddHttpClient(this IServiceCollection serviceCollection, string name, Action<HttpClient> configureHttpClient, Action<IHttpClientConfiguration> configureHttpClientConfiguration)
        {
            serviceCollection.AddHttpClient(name, configureHttpClient);
            serviceCollection.AddHttpClientConfiguration(name, configureHttpClientConfiguration);

            return serviceCollection;
        }
    }
}
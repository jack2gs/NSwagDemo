using System;
using Melon.Net.Http.HttpClientConfiguration;
using Microsoft.Extensions.DependencyInjection;

namespace Melon.Net.Http.DependencyInjection
{
    /// <summary>
    /// Extension for HttpClientConfiguration
    /// </summary>
    public static class HttpClientConfigurationExtension
    {
        /// <summary>
        /// Add named HttpClientConfiguration
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="name">the name of the configuration</param>
        /// <returns>the configuration builder</returns>
        public static IHttpClientConfigurationBuilder AddHttpClientConfiguration(
            this IServiceCollection services,
            string name)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return (IHttpClientConfigurationBuilder)new DefaultHttpClientConfigurationBuilder(services, name);
        }

        /// <summary>
        /// Add named HttpClientConfiguration
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="name">the name of the configuration</param>
        /// <param name="configureHttpClientConfiguration">the configuration</param>
        /// <returns>the configuration builder</returns>
        public static IHttpClientConfigurationBuilder AddHttpClientConfiguration(
            this IServiceCollection services,
            string name,
            Action<IHttpClientConfiguration> configureHttpClientConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            DefaultHttpClientConfigurationBuilder builder = new DefaultHttpClientConfigurationBuilder(services, name);
            builder.ConfigureHttpClientConfiguration(configureHttpClientConfiguration);
            return (IHttpClientConfigurationBuilder)builder;
        }

        /// <summary>
        /// Add named HttpClientConfiguration
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="name">the name of the configuration</param>
        /// <param name="configureHttpClientConfiguration">the configuration</param>
        /// <returns>the configuration builder</returns>
        public static IHttpClientConfigurationBuilder AddHttpClientConfiguration(
            this IServiceCollection services,
            string name,
            Action<IServiceProvider, IHttpClientConfiguration> configureHttpClientConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            DefaultHttpClientConfigurationBuilder builder = new DefaultHttpClientConfigurationBuilder(services, name);
            builder.ConfigureHttpClientConfiguration(configureHttpClientConfiguration);
            return (IHttpClientConfigurationBuilder)builder;
        }
    }
}
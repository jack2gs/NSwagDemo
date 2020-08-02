using System;
using Melon.Net.Http.HttpClientConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Melon.Net.Http.DependencyInjection
{
    /// <summary>
    /// Extension for HttpClientConfiguration
    /// </summary>
    public static class HttpClientConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds a delegate that will be used to configure a named <see cref="T: Melon.Net.Http.HttpClientConfiguration.HttpClientConfiguration" />.
        /// </summary>
        /// <param name="builder">The <see cref="T:Melon.Net.Http.HttpClientConfiguration.IHttpClientConfigurationBuilder" />.</param>
        /// <param name="configureHttpClientConfiguration">A delegate that is used to configure an <see cref="T:Melon.Net.Http.HttpClientConfiguration.HttpClientConfiguration" />.</param>
        /// <returns>An <see cref="T:Melon.Net.Http.HttpClientConfiguration.IHttpClientConfigurationBuilder" /> that can be used to configure the client.</returns>
        public static IHttpClientConfigurationBuilder ConfigureHttpClientConfiguration(
            this IHttpClientConfigurationBuilder builder,
            Action<IHttpClientConfiguration> configureHttpClientConfiguration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configureHttpClientConfiguration == null)
                throw new ArgumentNullException(nameof(configureHttpClientConfiguration));
            builder.Services.Configure<HttpClientConfigurationFactoryOptions>(builder.Name,
                (Action<HttpClientConfigurationFactoryOptions>)(options =>
                   options.HttpClientConfigurationActions.Add(configureHttpClientConfiguration)));
            return builder;
        }

        /// <summary>
        /// Adds a delegate that will be used to configure a named <see cref="T: Melon.Net.Http.HttpClientConfiguration.HttpClientConfiguration" />.
        /// </summary>
        /// <param name="builder">The <see cref="T:Melon.Net.Http.HttpClientConfiguration.IHttpClientConfigurationBuilder" />.</param>
        /// <param name="configureHttpClientConfiguration">A delegate that is used to configure an <see cref="T:Melon.Net.Http.HttpClientConfiguration.HttpClientConfiguration" />.</param>
        /// <returns>An <see cref="T:Melon.Net.Http.HttpClientConfiguration.IHttpClientConfigurationBuilder" /> that can be used to configure the client.</returns>
        public static IHttpClientConfigurationBuilder ConfigureHttpClientConfiguration(
            this IHttpClientConfigurationBuilder builder,
            Action<IServiceProvider, IHttpClientConfiguration> configureHttpClientConfiguration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configureHttpClientConfiguration == null)
                throw new ArgumentNullException(nameof(configureHttpClientConfiguration));

            builder.Services.AddTransient<IConfigureOptions<HttpClientConfigurationFactoryOptions>>(services =>
                new ConfigureNamedOptions<HttpClientConfigurationFactoryOptions>(builder.Name,
                    options => options.HttpClientConfigurationActions.Add(configuration =>
                        configureHttpClientConfiguration(services, configuration))));
          
            return builder;
        }
    }
}

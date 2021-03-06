﻿using System;
using Melon.Net.Http.HttpClientConfiguration;
using Melon.Net.Http.Resolver;

namespace Melon.Net.Http
{
    /// <summary>
    /// The default factory to create the http client which is generated automatically by NSwag.
    /// </summary>
    internal class DefaultHttpClientFactory: IHttpClientFactory
    {
        private readonly System.Net.Http.IHttpClientFactory _httpClientFactory;

        private readonly INameOfNamedClientsResolver _nameOfNamedClientsResolver;

        private readonly IClientImplementationClassResolver _clientImplementationClassResolver;

        private readonly INamedClientConfigurationFactory _namedClientConfigurationFactory;

        /// <summary>
        /// The factory constructor
        /// </summary>
        /// <param name="httpClientFactory">the http client factory</param>
        /// <param name="nameOfNamedClientsResolver">the name for the named clients resolver</param>
        /// <param name="clientImplementationClassResolver">the implementation class resolver</param>
        /// <param name="namedClientConfigurationFactory">the configuration of named clients</param>
        public DefaultHttpClientFactory(System.Net.Http.IHttpClientFactory httpClientFactory, 
            INameOfNamedClientsResolver nameOfNamedClientsResolver, 
            IClientImplementationClassResolver clientImplementationClassResolver, 
            INamedClientConfigurationFactory namedClientConfigurationFactory)
        {
            _httpClientFactory = httpClientFactory;
            _nameOfNamedClientsResolver = nameOfNamedClientsResolver;
            _clientImplementationClassResolver = clientImplementationClassResolver;
            _namedClientConfigurationFactory = namedClientConfigurationFactory;
        }

        /// <summary>
        /// Create the http clients that are generated by NSwag automatically
        /// </summary>
        /// <typeparam name="T">the http client to generate</typeparam>
        /// <returns>the target http client</returns>
        public T Create<T>() where T : IHttpClient
        {
            var name = _nameOfNamedClientsResolver.Resolve<T>();
            var httpClient = _httpClientFactory.CreateClient(name);
            var httpClientType = _clientImplementationClassResolver.Resolve<T>();
            var configuration = _namedClientConfigurationFactory.CreateClientConfiguration(name);

            return (T)Activator.CreateInstance(httpClientType, configuration, httpClient);
        }
    }
}
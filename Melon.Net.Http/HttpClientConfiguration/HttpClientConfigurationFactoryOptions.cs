using System;
using System.Collections.Generic;

namespace Melon.Net.Http.HttpClientConfiguration
{

    /// <summary>
    /// The http client configuration factory options
    /// </summary>
    public class HttpClientConfigurationFactoryOptions
    {
        /// <summary>
        /// The options
        /// </summary>
        public IList<Action<IHttpClientConfiguration>> HttpClientConfigurationActions { get; } = (IList<Action<IHttpClientConfiguration>>)new List<Action<IHttpClientConfiguration>>();
    }
}
namespace Melon.Net.Http.HttpClientConfiguration
{
    /// <summary>
    /// The named client configuration factory
    /// </summary>
    public interface INamedClientConfigurationFactory
    {
        /// <summary>
        /// Create the client configuration
        /// </summary>
        /// <param name="name">the name of the configuration</param>
        /// <returns>the client configuration</returns>
        IHttpClientConfiguration CreateClientConfiguration(string name);
    }
}

namespace Melon.Net.Http
{
    /// <summary>
    /// The http client factory
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Create instance for http client T
        /// </summary>
        /// <typeparam name="T">the http client interface</typeparam>
        /// <returns>the instance created</returns>
        T Create<T>()
            where T: IHttpClient;
    }
}
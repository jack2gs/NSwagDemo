namespace Melon.Net.Http.Resolver
{
    /// <summary>
    /// The name of named clients resolver
    /// </summary>
    public interface INameOfNamedClientsResolver
    {
        /// <summary>
        /// Resolve the name of named clients
        /// </summary>
        /// <typeparam name="T">the http client type</typeparam>
        /// <returns>the name of named clients</returns>
        string Resolve<T>() where T : IHttpClient;
    }
}

namespace Melon.Net.Http.Resolver
{
    /// <summary>
    /// The default implementation fo named client name resolver
    /// </summary>
    internal class DefaultNameOfNamedClientsResolver: INameOfNamedClientsResolver
    {
        /// <summary>
        /// Resolve the client name
        /// </summary>
        /// <typeparam name="T">the client type</typeparam>
        /// <returns>the name of named clients</returns>
        public string Resolve<T>() where T : IHttpClient
        {
            return typeof(T).Assembly.GetName().Name;
        }
    }
}
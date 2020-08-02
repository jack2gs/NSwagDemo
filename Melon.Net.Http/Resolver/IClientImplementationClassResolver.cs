using System;

namespace Melon.Net.Http.Resolver
{
    /// <summary>
    /// The client implementation class resolver
    /// </summary>
    public interface IClientImplementationClassResolver
    {
        /// <summary>
        /// Resolve the implementation class
        /// </summary>
        /// <typeparam name="T">the client interface</typeparam>
        /// <returns>the type of  implementation class</returns>
        Type Resolve<T>() where T:IHttpClient;
    }
}

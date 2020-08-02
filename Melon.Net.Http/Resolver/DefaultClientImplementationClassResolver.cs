using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace Melon.Net.Http.Resolver
{
    /// <summary>
    /// The default implementation of client implementation class resolver
    /// </summary>
    internal class DefaultClientImplementationClassResolver: IClientImplementationClassResolver
    {
        /// <summary>
        /// Resolve the implementation class of the client
        /// </summary>
        /// <typeparam name="T">the client interface</typeparam>
        /// <returns>the type of implementation class</returns>
        public Type Resolve<T>() 
            where T : IHttpClient
        {
            var interfaceType = typeof(T);
            return interfaceType.Assembly.GetTypes().Single(x => interfaceType.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
        }
    }
}
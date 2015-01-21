using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arbitrary.Collections;

namespace Arbitrary
{
    /// <summary>
    /// Wrapp
    /// </summary>
    public class Arbitrary
    {
        /// <summary>
        /// Lists all available Arbitrary collections in the current app domain.
        /// </summary>
        /// <remarks>
        /// Note that this is quite an expensive call, due to it relies heavily on reflection.
        /// </remarks>
        public static IEnumerable<Type> ListAllCollections()
        {
            var type = typeof(IArbitraryEntity);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.IsClass)
                .Where(type.IsAssignableFrom);

            return types;
        }

        public static IEnumerable<T> CollectionOf<T>() where T : IArbitraryEntity<T>
        {
            var factory = new CollectionFactory();
            return factory.List<T>();
        }

    }
}

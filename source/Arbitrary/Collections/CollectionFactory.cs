using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrary.Collections
{
    internal class CollectionFactory
    {
        internal CollectionFactory() { }

        /// <summary>
        /// Lists all items for the specified ArbitraryCollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal IEnumerable<T> List<T>() where T : IArbitraryEntity<T>
        {
            var instance = Activator.CreateInstance<T>();
            return instance.All();
        }
    }
}

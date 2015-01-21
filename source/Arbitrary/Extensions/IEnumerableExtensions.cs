using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrary
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Fetches a single instance from the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>Returns an arbitrary object from the collection, or null if the collection is empty.</returns>
        public static T PickOne<T>(this IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection");

            var rnd = _Randomizer();
            var index = rnd.Next(0, collection.Count());

            return collection.ElementAt(index);
        }

        public static IEnumerable<T> PickSeveral<T>(this IEnumerable<T> collection, int amount)
        {
            var returnValue = new List<T>();

            var rnd = _Randomizer();

            for (int i = 0; i < amount; i++)
            {
                var index = rnd.Next(0, collection.Count());
                returnValue.Add(collection.ElementAt(index));
            }

            return returnValue;
        }

        private static Random _Randomizer()
        {
            // always create a new Random object, with a unique seed
            return new Random(Guid.NewGuid().GetHashCode());
        }
        
    }
}

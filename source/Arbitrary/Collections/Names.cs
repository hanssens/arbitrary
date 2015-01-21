using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrary.Collections
{

    public class Name : IArbitraryEntity<Name>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public IEnumerable<Name> All()
        {
            return new List<Name>()
            {
                new Name(){ FirstName = "Harry", LastName = "Potter"},
                new Name(){ FirstName = "Hermoine", LastName = "Granger"},
            };
        }
    }
}

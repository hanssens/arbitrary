using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrary
{
    public interface IArbitraryEntity
    {
        
    }
    public interface IArbitraryEntity<T> : IArbitraryEntity
    {
        IEnumerable<T> All();
    }
}

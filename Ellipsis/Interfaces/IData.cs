using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.Data;

namespace Ellipsis.Interfaces
{
    public interface IData<T>
    {
        void Add(T item);
        void Delete(T item);
        event DataChangedEventHandler<T> DataChanged;
    }
}

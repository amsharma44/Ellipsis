using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.Data;
using System.Collections.ObjectModel;

namespace Ellipsis.Interfaces
{
    public interface IData<T>
    {
        ObservableCollection<T> GetAll();
        void Add(T item);
        void Delete(T item);
        event DataChangedEventHandler<T> DataChanged;
    }
}

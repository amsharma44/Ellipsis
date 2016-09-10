using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellipsis.Data
{
    public enum DataChangedMode
    {
        New,
        Delete
    }

    public delegate void DataChangedEventHandler<T>(DataChangedEventArgs<T> e);

    public class DataChangedEventArgs<T>
    {
        public T ChangedEntity { get; private set; }
        public DataChangedMode Mode { get; private set; }

        public DataChangedEventArgs(T changedEntity, DataChangedMode mode)
        {
            this.ChangedEntity = changedEntity;
            this.Mode = mode;
        }
    }
}

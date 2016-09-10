using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.Interfaces;
using Ellipsis.Models;

namespace Ellipsis.Data
{
    public class DataRepository<T> : IData<T> where T : DataModel
    {
        private List<T> entityList = new List<T>();

        public event DataChangedEventHandler<T> DataChanged;

        public void Add(T item)
        {
            if (item != null)
            {
                if (entityList.Count != 0)
                {
                    item.Id = entityList.Max(x => x.Id) + 1;
                }
                else
                {
                    item.Id = 1;
                }
                entityList.Add(item);
                RaiseDataChanged(item, DataChangedMode.New);
            }
        }

        public void Delete(T item)
        {
            if (item != null)
            {
                entityList.Remove(item);
                RaiseDataChanged(item, DataChangedMode.Delete);
            }
        }

        private void RaiseDataChanged(T entity, DataChangedMode mode)
        {
            var handler = DataChanged;
            handler?.Invoke(new DataChangedEventArgs<T>(entity, mode));
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess;
using WarehouseManager.Domain.Interfaces;
using WarehouseManager.Service.Interfaces;

namespace WarehouseManager.Service
{
    public abstract class Service<T> : IService<T> where T : class, IEntity
    {
        public Service(WarehouseManagerContext context)
        {
            this.Context = context;
        }

        public WarehouseManagerContext Context { get; set; }

        public abstract Task<T> GetAsync(int id);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        protected abstract T Get(int id);

        public abstract Task<bool> Add(T item);

        public abstract Task<bool> Edit(T item);

        public abstract Task<bool> Delete(int itemId);

        public abstract bool IsValid(T item);

    }
}

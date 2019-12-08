using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess;
using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Service.Interfaces
{
    public interface IService<T> where T : class, IEntity
    {
        WarehouseManagerContext Context { get; }

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> Add(T item);

        Task<bool> Edit(T item);

        Task<bool> Delete(int itemId);

        bool IsValid(T item);
    }
}

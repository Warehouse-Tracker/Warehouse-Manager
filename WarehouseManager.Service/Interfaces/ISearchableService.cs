using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Service.Interfaces
{
    public interface ISearchableService<T> where T : class, IEntity
    {
        Task<T> FindAsync(string search);

        T Find(string search);

        Task<IEnumerable<T>> SearchAsync(string search);

        IEnumerable<T> Search(string search);
    }
}

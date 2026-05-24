using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Iterfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        Task<List<T>> GetAllAsync();

        void Add(T item);

        Task AddAsync(T item);

        void Remove(int id);

        Task RemoveAsync(int id);
    }
}

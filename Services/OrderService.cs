using AsyncDataLibrary.Iterfaces;
using AsyncDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public List<Order> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public void Add(Order order)
        {
            _repository.Add(order);
        }

        public async Task AddAsync(Order order)
        {
            await _repository.AddAsync(order);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}

using AsyncDataLibrary.Iterfaces;
using AsyncDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public void Add(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new Exception("User name is empty");
            }

            _repository.Add(user);
        }

        public async Task AddAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new Exception("User name is empty");
            }

            await _repository.AddAsync(user);
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

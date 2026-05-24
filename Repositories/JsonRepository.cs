using AsyncDataLibrary.Iterfaces;
using AsyncDataLibrary.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Repositories
{
    public class JsonRepository<T> : IRepository<T>
    {
        private readonly string _path;

        private readonly IDataSerializer _serializer;

        private readonly FileStorageProvider _storageProvider;

        public JsonRepository(
            string path,
            IDataSerializer serializer,
            FileStorageProvider storageProvider)
        {
            _path = path;
            _serializer = serializer;
            _storageProvider = storageProvider;

            _storageProvider.EnsureFileExists(_path);
        }

        public List<T> GetAll()
        {
            return _serializer.Deserialize<List<T>>(_path)
                   ?? new List<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _serializer.DeserializeAsync<List<T>>(_path)
                   ?? new List<T>();
        }

        public void Add(T item)
        {
            var items = GetAll();

            items.Add(item);

            _serializer.Serialize(_path, items);
        }

        public async Task AddAsync(T item)
        {
            var items = await GetAllAsync();

            items.Add(item);

            await _serializer.SerializeAsync(_path, items);
        }

        public void Remove(int id)
        {
            var items = GetAll();

            var prop = typeof(T).GetProperty("Id");

            var item = items.FirstOrDefault(x =>
                (int)prop.GetValue(x) == id);

            if (item != null)
            {
                items.Remove(item);
            }

            _serializer.Serialize(_path, items);
        }

        public async Task RemoveAsync(int id)
        {
            var items = await GetAllAsync();

            var prop = typeof(T).GetProperty("Id");

            var item = items.FirstOrDefault(x =>
                (int)prop.GetValue(x) == id);

            if (item != null)
            {
                items.Remove(item);
            }

            await _serializer.SerializeAsync(_path, items);
        }
    }
}

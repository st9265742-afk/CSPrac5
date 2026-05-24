using AsyncDataLibrary.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Infrastructure
{
    public class JsonDataSerializer : IDataSerializer
    {
        public void Serialize<T>(string path, T data)
        {
            string json = JsonSerializer.Serialize(data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(path, json);
        }

        public T Deserialize<T>(string path)
        {
            if (!File.Exists(path))
                return default;

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SerializeAsync<T>(string path, T data)
        {
            using FileStream fs = new(path, FileMode.Create);

            await JsonSerializer.SerializeAsync(fs, data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
        }

        public async Task<T> DeserializeAsync<T>(string path)
        {
            if (!File.Exists(path))
                return default;

            using FileStream fs = new(path, FileMode.Open);

            return await JsonSerializer.DeserializeAsync<T>(fs);
        }
    }
}

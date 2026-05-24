using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Iterfaces
{
    public interface IDataSerializer
    {
        void Serialize<T>(string path, T data);

        T Deserialize<T>(string path);

        Task SerializeAsync<T>(string path, T data);

        Task<T> DeserializeAsync<T>(string path);
    }
}

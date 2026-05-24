using AsyncDataLibrary.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Infrastructure
{
    public class FileStorageProvider
    {
        public void EnsureFileExists(string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }
        }
    }
}

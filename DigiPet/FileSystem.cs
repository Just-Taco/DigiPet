using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace DigiPet
{
    class FileSystem
    {
        private string _path;

        public FileSystem(string path)
        {
            this._path = path;
        }

        public void Save(DigiPet pet)
        {
            var data = JsonSerializer.Serialize(pet);
            File.WriteAllText(_path, data);
            // save logic
        }

        public DigiPet Load(string path)
        {
            this._path = path;
            if (!File.Exists(path)) return null;

            var fileText = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(path)) return null;

            try
            {
                return JsonSerializer.Deserialize<DigiPet>(fileText);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}

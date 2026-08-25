using System.Text.Json;

namespace DigiPet
{
    class FileSystem
    {
        private readonly string _path;

        public FileSystem(string path)
        {
            _path = path;
        }

        public void Save(DigiPet pet)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var data = JsonSerializer.Serialize(pet, options);
            File.WriteAllText(_path, data);
        }

        public DigiPet? Load()
        {
            if (!File.Exists(_path)) return null;

            var fileText = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(fileText)) return null;

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
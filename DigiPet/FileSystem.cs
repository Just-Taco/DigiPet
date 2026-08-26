using System.Text.Json;

namespace DigiPet
{
    class FileSystem
    {
        private const string FileName = "digipet.json";

        private readonly string _folder;
        private readonly string _path;

        public FileSystem(string folder)
        {
            _folder = folder;
            if (File.Exists(folder))
            {
                _path = folder;
            } else
            {
                _path = Path.Combine(folder, FileName);
            }
        }

        static private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        public void Save(DigiPet pet)
        {
            Directory.CreateDirectory(_folder);

            var data = JsonSerializer.Serialize(pet, options);
            File.WriteAllText(_path, data);
        }

        public DigiPet? Load()
        {
            if (!File.Exists(_path)) return null;

            var fileText = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(fileText)) return null;

            return JsonSerializer.Deserialize<DigiPet>(fileText, options);
        }
    }
}
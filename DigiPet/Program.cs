namespace DigiPet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path;
            string name = "DigiPet";

            while (true)
            {
                Console.Write("Path til file save/load: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                path = input;

                if (File.Exists(path) || File.Exists(Path.Combine(path, "digipet.json"))) break;  

                Console.Write("Navn på DigiPet: ");
                string? nameInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nameInput))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                name = nameInput;
                break;
            }

            GameController Game = new(path, name);
            Game.Run();
        }
    }
}

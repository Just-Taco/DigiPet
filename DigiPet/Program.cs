namespace DigiPet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name;
            string? output;
            while (true)
            {
                Console.Write("Path til file save/load: ");
                output = Console.ReadLine();

                Console.Write("Navn på DigiPet: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(output) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                if (File.Exists(output)) break;
                Console.WriteLine("Invalid Path!");
            }

            GameController Game = new(name, output);
            Game.Run();
        }
    }
}

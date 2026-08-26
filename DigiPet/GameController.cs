using System.Reflection.Metadata.Ecma335;

namespace DigiPet
{
    class GameController
    {
        // Default path
        private string path = "C:/Users/temp/Documents";


        private FileSystem fs;
        private DigiPet Pet;
        private BattleManager _battle;

        private ItemController _itemcontroller;

        public GameController(string path, string name = "DigiPet")
        {
            this.path = path;
            this.fs = new(path);
            this.Pet = fs.Load() ?? new(name);
            this._battle = new();
            this._itemcontroller = new();
        }

        private static void DrawScreen(DigiPet pet, string message)
        {
            Console.Clear();
            Console.WriteLine("--------- DIGIPET ---------");
            Console.WriteLine("STATS");
            Console.WriteLine($"Name:      {pet.Name}");
            Console.WriteLine($"Age:       {pet.Born - DateTime.Now}");
            Console.WriteLine($"Health:    {pet.Health}/100");
            Console.WriteLine($"Happiness: {pet.Happiness}/100");
            Console.WriteLine($"Hunger:    {pet.Hunger}/100");
            Console.WriteLine("---------------------------");
            Console.WriteLine("COMMANDS");
            Console.WriteLine("  explore              Explore for 2 min; 50% chance of an enemy and loot");
            Console.WriteLine("  items                List everything in your inventory");
            Console.WriteLine("  use <item>           Use an item");
            Console.WriteLine("  cleanup              Delete all items in your inventory");
            Console.WriteLine("  pet                  Give your digipet a pet");
            Console.WriteLine("  exit                 Save and quit");
            Console.WriteLine("---------------------------");

            if (message.Length > 0)
            {
                Console.WriteLine(message);
                Console.WriteLine("---------------------------");
            }
        }

        public void Run()
        {
            Thread thread = new(Pet.Tick); // starts food and happiness drain
            thread.IsBackground = true;
            thread.Start();
            try
            {
                bool running = true;
                string message = "";
                while (running)
                {
                    DrawScreen(Pet, message);
                    message = "";

                    Console.Write("Command: ");
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        message = "Error: No text found";
                        continue;
                    }
                    string[] parts = input.Split(' ');
                    string command = parts[0];
                    switch (command)
                    {
                        case "explore":
                            // explore function
                        case "use":
                            if (parts.Length > 0)
                            {
                                Item? Item = _itemcontroller.Find(parts[1]);
                                if (Item != null)
                                {
                                    message = Pet.Inventory.UseItem(Item, Pet, _itemcontroller);
                                }
                                
                            } else
                            {
                                message = "Error: No argument";
                                break;
                            }
                            break;
                        case "cleanup":
                            Pet.CleanUp();
                            break;
                        case "pet":
                            message = Pet.Pet();
                            break;
                        case "exit":
                            fs.Save(Pet);
                            running = false;
                            break;
                        default:
                            break;

                    }
                }
            }
            catch (Exception)
            {
                fs.Save(Pet);
                throw;
            }

        }

        public void HandleInput(string cmd)
        {

        }
    }
}
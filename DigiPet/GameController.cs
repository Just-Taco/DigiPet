namespace DigiPet
{
    class GameController
    {
        // Default path
        private string path = "C:/Users/temp/Documents";


        private FileSystem fs;
        private DigiPet Pet;
        private BattleManager _battle;

        public GameController(string name, string path)
        {
            this.path = path;
            this.fs = new(path);
            this.Pet = fs.Load(path) ?? new(name);
            this._battle = new();
        }

        private static void DrawScreen(DigiPet pet, string message)
        {
            Console.Clear();
            Console.WriteLine("--------- DIGIPET ---------");
            Console.WriteLine("STATS");
            Console.WriteLine($"Name:      {pet.Name}");
            Console.WriteLine($"Age:        {pet.Born.}");
            Console.WriteLine($"Health:    {pet.Health}/100");
            Console.WriteLine($"Happiness: {pet.Happiness}/100");
            Console.WriteLine($"Hunger:    {pet.Hunger}/100");
            Console.WriteLine("---------------------------");
            Console.WriteLine("COMMANDS");
            Console.WriteLine("  explore              Explore for 2 min; 50% chance of an enemy and loot");
            Console.WriteLine("  items                List everything in your inventory");
            Console.WriteLine("  use <item> <target>  Use an item on a target");
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
                    string? output = Console.ReadLine();
                    switch (output)
                    {
                        case "explore":
                        // function
                        case "use":
                        //function
                        case "cleanup":
                        //function
                        case "pet":
                        //function
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
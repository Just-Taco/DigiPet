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

        private static void DrawScreen(DigiPet pet, ItemController shop, string message)
        {
            Console.Clear();
            Console.WriteLine("--------- DIGIPET ---------");
            Console.WriteLine("STATS");
            Console.WriteLine($"Name:      {pet.Name}");
            Console.WriteLine($"Age:       {FormatAge(DateTime.Now - pet.Born)}");
            Console.WriteLine($"Health:    {pet.Health}/100");
            Console.WriteLine($"Happiness: {pet.Happiness}/100");
            Console.WriteLine($"Hunger:    {pet.Hunger}/100");
            Console.WriteLine($"Coins:    {pet.Coins}");
            Console.WriteLine("---------------------------");
            Console.WriteLine("COMMANDS");
            Console.WriteLine("  explore              Explore for 2 min; 50% chance of an enemy and loot");
            Console.WriteLine("  items                List everything in your inventory");
            Console.WriteLine("  use <item>           Use an item");
            Console.WriteLine("  buy <item>           Buy an item from sale");
            Console.WriteLine("  cleanup              Delete all items in your inventory");
            Console.WriteLine("  pet                  Give your digipet a pet");
            Console.WriteLine("  exit                 Save and quit");
            Console.WriteLine("---------------------------");
            Console.WriteLine("FOR SALE");
            foreach (IItem item in shop.Items)
            {
                Console.WriteLine($"  {item.Name} {item.Price} coins");
            }
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
            bool running = true;
            string message = "";
            while (running)
            {
                DrawScreen(Pet, _itemcontroller, message);
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
                        if (RNG.randomNumber(1, 101) <= 50)
                        {
                            Enemy enemy = new();
                            message = _battle.Battle(Pet, enemy);
                            if (Pet.IsAlive)
                            {
                                Pet.Coins += RNG.randomNumber(10, 40);
                            }
                        }
                        else
                        {
                            IItem loot = _itemcontroller.RandomItem().Copy();
                            Pet.Inventory.AddItem(loot);
                            message = $"You found a {loot.Name}!";
                        }
                        break;
                    case "items":
                        foreach (IItem item in Pet.Inventory.Items)
                        {
                            Console.WriteLine($"  {item.Name}");
                        }
                        Thread.Sleep(4000);
                        break;
                    case "use":
                        if (parts.Length > 1)
                        {
                            IItem? Item = _itemcontroller.Find(parts[1]);
                            if (Item != null)
                            {
                                message = Pet.Inventory.UseItem(Item, Pet);
                            }

                        }
                        else
                        {
                            message = "Error: No argument";
                            break;
                        }
                        break;
                    case "buy":
                        if (parts.Length < 2)
                        {
                            message = "Error: No argument";
                            break;
                        }

                        IItem? BroughtItem = _itemcontroller.Find(parts[1])?.Copy();
                        if (BroughtItem == null)
                        {
                            message = $"The shop doesnt sell {parts[1]}";
                            break;
                        }

                        if (Pet.Coins < BroughtItem.Price)
                        {
                            message = $"{BroughtItem.Name} costs {BroughtItem.Price}, you have {Pet.Coins}";
                            break;
                        }

                        Pet.Coins -= BroughtItem.Price;
                        Pet.Inventory.AddItem(BroughtItem);
                        message = $"Bought {BroughtItem.Name} for {BroughtItem.Price} coins";
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
                if (!Pet.IsAlive)
                {
                    DrawScreen(Pet, _itemcontroller, $"{Pet.Name} died...");
                    running = false;
                }
            }
        }


        private static string FormatAge(TimeSpan age)
        {
            if (age.TotalDays >= 1)
            {
                return $"{age.Days}d {age.Hours}h {age.Minutes}m";
            }

            if (age.TotalHours >= 1)
            {
                return $"{age.Hours}h {age.Minutes}m";
            }
            if (age.TotalMinutes >= 1)
            {
                return $"{age.Minutes}m {age.Seconds}s";
            }
            return $"{age.Seconds}s";
        }

        public void HandleInput(string cmd)
        {

        }
    }
}
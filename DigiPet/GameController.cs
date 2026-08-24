using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class GameController
    {
        // Default path
        private string path = "C:/Users/temp/Documents";


        private FileSystem fs;
        private DigiPet Pet;
        private BattleManager _battle;

        public GameController(string path, string name)
        {
            this.path = path;
            this.fs = new(path);
            this.Pet = fs.Load(path) ?? new(name);
            this._battle = new();
        }

        public void Run()
        {
            while (true)
            {
                // Game logic
                break;
            }
        }

        public void HandleInput(string cmd)
        {

        }
    }
}
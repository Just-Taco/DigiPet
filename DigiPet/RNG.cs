using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    static class RNG
    {
        static private string[] names = { "Frog", "Bat", "Cat", "Dog" };
        static Random rng = new();



        static public int randomNumber(int x, int y)
        {
            return rng.Next(x, y);
        }

        static public string randomAnimalName()
        {
            return names[rng.Next(0, names.Length)];
        }
    }
}

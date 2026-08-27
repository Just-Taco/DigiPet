using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    interface IFightable
    {
        string Name { get; }
        bool IsAlive { get; }
        int Attack(IFightable target);
        void TakeDamage(int amount);
    }
}

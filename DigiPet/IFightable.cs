using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    interface IFightable
    {
        int Attack(IFightable target);
        void TakeDamage(int amount);
    }
}

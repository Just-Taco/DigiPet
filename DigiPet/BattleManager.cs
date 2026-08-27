using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class BattleManager
    {
        public string Battle(IFightable target_x, IFightable target_y)
        {
            string log = "";

            while (target_x.IsAlive && target_y.IsAlive)
            {
                int dmg = target_x.Attack(target_y);
                target_y.TakeDamage(dmg);

                log += $"{target_x.Name} hits {target_y.Name} for {dmg}";

                if (!target_y.IsAlive) break;

                dmg = target_y.Attack(target_x);
                target_x.TakeDamage(dmg);

                log += $"{target_y.Name} hits {target_x.Name} for {dmg}";
            }
            return log + $"{(target_x.IsAlive ? target_x.Name : target_y.Name)} wins!";
        }
    }
}

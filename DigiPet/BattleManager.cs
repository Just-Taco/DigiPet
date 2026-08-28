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

                if (!target_y.IsAlive) break;

                dmg = target_y.Attack(target_x);
                target_x.TakeDamage(dmg);
            }

            IFightable winner = target_x.IsAlive ? target_x : target_y;
            IFightable loser = target_x.IsAlive ? target_y : target_x;
            return log + $"{(winner.Name)} won against a {loser.Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Weapon : Item
    {
        public int AttackDamage { get; set; }   

        public Weapon(string name, int attackDamage) : base(name, 1, false)
        {
            AttackDamage = attackDamage;
        }
    }

    public class WoodenSword : Weapon
    {
        public int attackModifier = 2;
        public WoodenSword(int attackModifier) : base("Wooden Sword", 5)
        {
            this.attackModifier = attackModifier;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Weapon : Item
    {
        public int AttackDamageModifier { get; set; }   

        public Weapon(string name, int attackDamageModifier) : base(name, 1, false)
        {
            AttackDamageModifier = attackDamageModifier;
        }
        public Weapon() { } 
    }

    public class WoodenSword : Weapon
    {
        public bool isEquipped = false;
       
        public WoodenSword(bool isEquipped) : base("Wooden Sword", 5)
        {
            this.isEquipped = isEquipped;
            if (isEquipped == true) 
            {
                Player player = new Player();
                player.attackDamage += AttackDamageModifier;
            }
            
        }
    }
}

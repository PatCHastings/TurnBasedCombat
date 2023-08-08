using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Weapon 
    {
        internal string weaponName;
        public int AttackDamageModifier { get; set; }   

        public Weapon(string weaponName, int attackDamageModifier) 
        {
            this.weaponName = weaponName;   
            AttackDamageModifier = attackDamageModifier;
        }
        public virtual int GetAttackDamageModifier()
        {
            return AttackDamageModifier;
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
                player.attackDamage = AttackDamageModifier;
            }
            
        }
    }

    public class Dagger : Weapon
    {
        public bool isEquipped = false;

        public Dagger(bool isEquipped) : base("Dagger", 7)
        {
            this.isEquipped = isEquipped;
            if (isEquipped == true)
            {
                Player player = new Player();
                player.attackDamage = AttackDamageModifier;
            }

        }
    }
}

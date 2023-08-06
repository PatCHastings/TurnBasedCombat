using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    internal class Equipment
    {
        protected string name;

        public Equipment(string name)
        {
            this.name = name;  
        }
        public string Name { get; set; }


    }

    internal class WoodenSword : Equipment
    {
        public string WeaponName { get; } 
        public string WeaponType { get; }
        public string WeaponDescription { get; }
        public int AttackMultiplier { get; set; }
        public WoodenSword(string name) : base(name)
        {
            WeaponName = "Wooden Sword";
            WeaponType = "Sword";
            WeaponDescription = "A plain wooden training sword not really suitable for combat..";
            AttackMultiplier = 3;
            
        }
    }
}

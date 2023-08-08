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
        private List<Weapon> weaponList = new List<Weapon>();


        internal void AddWeapon(Weapon weapon)
        {
            weaponList.Add(weapon);
            Console.WriteLine("(" + weapon.weaponName + " added to equipment arsenal)");
        }

    }

    



}

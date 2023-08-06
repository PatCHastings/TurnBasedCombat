using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Armor : Item
    {
        public int ArmorRating { get; set; }

        public Armor(string name, int armorRating) : base(name, 1, false)
        {
            ArmorRating = armorRating;
        }
    }
}

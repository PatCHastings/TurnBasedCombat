using System.ComponentModel;
using System.Numerics;
using System.Reflection.Emit;

namespace TurnBasedCombat
{
    public class Item
    {
        internal string itemName;
        internal int total;
        internal bool singleUse;

        public Item(string itemName, int total, bool singleUse)
        {
            this.itemName = itemName;
            this.total = total;
            this.singleUse = singleUse;
        }   
        public Item()
        {
        }
        public string ItemName { get { return itemName; } }
        public int Total { get { return total; } }

        
    }

    class HealingPotion : Item
    {
        public int healingAmount;
        public HealingPotion(string name, int healingAmount) : base(name, 1, true)
        {
            this.itemName = name;
            this.healingAmount = healingAmount;
        }
        public int HealingAmount { get; set; }

        private int CalculatePlayerHealing()
        {
            Player player = new Player();
            Random random = new Random();
            int baseHealing = random.Next(player.level, player.level * 2);
            return Math.Max(baseHealing - player.armorRating, 2);
        }
        public void Use(Player player)
        {
            int playerHealing = CalculatePlayerHealing();
            player.health += playerHealing;
            Console.WriteLine(player.name + " used a " + itemName + " and gained " + playerHealing + " pts of health!"); ;
        }
        
    }

    public class Firebomb : Item
    {
        public int damageAmount;

        public Firebomb(string name, int damageAmount) : base(name, 1, true)
        {
            this.itemName = name;
            this.damageAmount = damageAmount;
        }
        public int DamageAmount { get; set; }

        public void Use(MonsterType targetMonster)
        {
            
            UseFirebomb(targetMonster);
        }

        public void UseFirebomb(MonsterType monster)
        {
            
            int damageAmount = CalculatePhysDamage();
            monster.health -= damageAmount;
            Console.WriteLine("..." + monster.name + " gets hit by a Firebomb and takes " + damageAmount + " damage!");
        }
        private int CalculatePhysDamage()
        {
          
            Random random = new Random();
            int baseDamage = random.Next(7, 23);
            return Math.Max(baseDamage, 7);
        }
    }


}
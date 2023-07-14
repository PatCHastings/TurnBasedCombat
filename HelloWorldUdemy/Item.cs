using System.Numerics;

namespace TurnBasedCombat
{
    public class Item
    {
        protected string itemName;
        protected int total;
        protected bool singleUse;

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

        public void HealingPotion()
        {
            Player player = new Player();
            var healingAmount = player.level * 2; 
            player.health += healingAmount;
            Console.WriteLine(player.name + " used a Health Potion and gained " + healingAmount + " health.");
        }
    }

    public class HealingPotion : Item
    {
        public int healingAmount;
        public HealingPotion(string name, int healingAmount) : base(name, 1, true)
        {
            this.itemName = name;
            this.healingAmount = healingAmount;
        }
        public int HealingAmount { get; set; }
        public void Use(Player player)
        {
            Console.WriteLine("eureka it worked!");
        }
    }
}
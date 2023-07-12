using System;
using System.Collections.Concurrent;

namespace TurnBasedCombat
{
    class Player
    {
        internal String name;
        internal int level;
        internal int armorRating;
        internal int health;
        

        public Player(string name, int level, int armorRating, int health)
        {
            this.name = name;
            this.level = level;
            this.armorRating = armorRating;
            this.health = health;
        }
        public Player()
        {
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public int ArmorRating { get; set; }
        public int Health { get; set; }

        

        public void UsePhysAttack(Opponent opponent)
        {
            MonsterType monsterType = opponent.MonsterType;
            int physDamage = CalculatePhysDamage();
            monsterType.health -= physDamage;
            Console.WriteLine(name + " swings his sword and strikes! Dealing " + physDamage + " damage to the " + monsterType.name);
        }
        private int CalculatePhysDamage()
        {
            Random random = new Random();
            int baseDamage = random.Next(level, level * 2);
            return Math.Max(baseDamage - armorRating, 2);
        }

        public void UseMagicAttack(Opponent opponent)
        {
            MonsterType monsterType = opponent.MonsterType;
            int magicDamage = CalculateMagicDamage();
            monsterType.health -= magicDamage;
            Console.WriteLine(name + " unleashes a magic spell! Dealing " + magicDamage + " damage to the " + monsterType.name); 
        }
        private int CalculateMagicDamage()
        {
            Random random = new Random();
            int baseDamage = random.Next(level * 2, level * 3);
            return baseDamage; 
        }

        internal void selectItem()
        {
            ItemBag bag = new ItemBag();
            if (bag != null)
            {
                Console.WriteLine("Items: " + bag);
            }
            else
            {
                Console.WriteLine("Your Item bag is empty..");
            }
        }

        internal void playerVitals()
        {
            Console.WriteLine(name + " health: " + health);
        }

        
    }
}


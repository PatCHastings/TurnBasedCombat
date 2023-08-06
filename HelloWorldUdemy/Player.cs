using System;
using System.Collections.Concurrent;

namespace TurnBasedCombat
{
    public class Player
    {
        internal String name;
        internal int level;
        internal int attackDamage;
        internal int armorRating;
        internal int health;
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        

        public Player(string name, int level, int attackDamage, int armorRating, int health)
        {
            this.name = name;
            this.level = level;
            this.attackDamage = attackDamage;
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

        public int CalculateEquippedWeaponAttackDamage()
        {
            if (EquippedWeapon != null)
            {
                return EquippedWeapon.AttackDamage; 
            }
            else
            {
                return attackDamage;
            }
        }

        public void UsePhysAttack(Opponent opponent)
        {
            Opponent opponentGone = new Opponent();
            MonsterType monsterType = opponent.MonsterType;
            int physDamage = CalculatePhysDamage();
            monsterType.health -= physDamage;
            Console.WriteLine(name + " swings his sword and strikes! Dealing " + physDamage + " damage to the " + monsterType.name);
            opponentGone.RemoveDefeatedMonsterAndGenerateNew();
        }
        private int CalculatePhysDamage()
        {
            Random random = new Random();
            if (EquippedWeapon != null)
            {

            }
            int baseDamage = random.Next(attackDamage, attackDamage * 2);
            return Math.Max(baseDamage - armorRating, 2);
        }

        public void UseMagicAttack(Opponent opponent)
        {
            Opponent opponentGone = new Opponent();
            MonsterType monsterType = opponent.MonsterType;
            int magicDamage = CalculateMagicDamage();
            monsterType.health -= magicDamage;
            Console.WriteLine(name + " unleashes a magic spell! Dealing " + magicDamage + " damage to the " + monsterType.name);
            opponentGone.RemoveDefeatedMonsterAndGenerateNew();
        }
        private int CalculateMagicDamage()
        {
            Random random = new Random();
            int baseDamage = random.Next(level * 2, level * 3);
            return baseDamage; 
        }

        internal int CalculatePlayerHealing()
        {
            Random random = new Random();
            int baseHealing = random.Next(Level, level * 2);
            return Math.Max(baseHealing - armorRating, 2);
        }

        internal void playerVitals()
        {
            Console.WriteLine(name + " health: " + health);
        }

        
    }
}


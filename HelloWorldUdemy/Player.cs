using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Numerics;

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
        public List<Weapon> AvailableWeaponList { get; set; }
        

        public Player(string name, int level, int attackDamage, int armorRating, int health)
        {
            this.name = name;
            this.level = level;
            this.attackDamage = attackDamage;
            this.armorRating = armorRating;
            this.health = health;

            AvailableWeaponList = new List<Weapon>();
            EquippedWeapon = WoodenSword; 
            AvailableWeaponList.Add(EquippedWeapon);
        }
        public Player()
        {
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public int AttackDamage { get; set; }   
        public int ArmorRating { get; set; }
        public int Health { get; set; }

        public void ShowAvailableWeapons()
        {
            if (AvailableWeaponList != null)
            {
                Console.WriteLine("Available Weapons:");
                int index = 1;
                foreach (Weapon weapon in AvailableWeaponList)
                {
                    Console.WriteLine(index + ": " + weapon.ItemName);
                }
            }
            else
            {
                Console.WriteLine("You do not have any weapons right now..");
                return;
            }
            
            
        }

        public void EquipWeapon(int weaponIndex)
        {
            if (weaponIndex >= 1 && weaponIndex <= AvailableWeaponList.Count)
            {
                Weapon selectedWeapon = AvailableWeaponList[weaponIndex - 1];

                if (EquippedWeapon != null)
                {
                    
                }
                else
                {
                    return; 
                }
            }
        }

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

        public void StatsManagement()
        {
            Console.WriteLine("After retreating to safety, " + name + " finds himself in the slave quarters.." +
                                "\n1: Manage equipment" +
                                "\n2: Re-enter the Arena..");

            bool leaveQuarters = false;
            while (leaveQuarters != true)
            {
                do
                {
                    ShowAvailableWeapons();
                    int prompt = int.Parse(Console.ReadLine());
                    switch (prompt)
                    {
                        case 1:
                            int weaponIndex = int.Parse(Console.ReadLine());
                            EquipWeapon(weaponIndex);
                            break;

                        case 2:
                            Console.WriteLine(name + "ventures back to the Arena for more action..");
                            leaveQuarters = false;
                            break;
                    }
                } while (true);
            }
        }
    }
}


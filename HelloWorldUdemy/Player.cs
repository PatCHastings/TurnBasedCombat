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

            AvailableWeaponList = new List<Weapon>
            {
                new WoodenSword(true)
                

            };
            EquippedWeapon = AvailableWeaponList[0];

        }
        public Player()
        {
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public int AttackDamage { get; set; }   
        public int ArmorRating { get; set; }
        public int Health { get; set; }



        public void EquipWeapon(int weaponIndex)
        {
            if (weaponIndex >= 1 && weaponIndex <= AvailableWeaponList.Count)
            {
                Weapon selectedWeapon = AvailableWeaponList[weaponIndex - 1];

                if (EquippedWeapon != null)
                {
                    // Remove the currently equipped weapon and adjust the attack damage
                    AttackDamage -= EquippedWeapon.GetAttackDamageModifier();
                    Console.WriteLine(name + " unequipped " + EquippedWeapon.weaponName + ". and went from an attack rating of " + EquippedWeapon.GetAttackDamageModifier());
                }

                EquippedWeapon = selectedWeapon;
                AttackDamage += EquippedWeapon.GetAttackDamageModifier();
                Console.WriteLine(" to " + selectedWeapon.GetAttackDamageModifier() + " when he equipped " + selectedWeapon.weaponName + "!");
            }
            else
            {
                Console.WriteLine("Invalid weapon selection.");
            }
        }

        //public void EquipWeapon(int weaponIndex)
        //{
        //    if (weaponIndex >= 1 && weaponIndex <= AvailableWeaponList.Count)
        //    {
        //        Weapon selectedWeapon = EquippedWeapon;
        //            EquippedWeapon = AvailableWeaponList[weaponIndex - 1];

        //        if (EquippedWeapon != null)
        //        {
                    
        //        }
        //        else
        //        {
        //            return; 
        //        }
        //    }
        //}

        //public Weapon CalculateEquippedWeaponAttackDamage()
        //{
            
        //}

        public void UsePhysAttack(Opponent opponent)
        {
            //Opponent opponentGone = new Opponent();
            MonsterType monsterType = opponent.MonsterType;
            int physDamage = CalculatePhysDamage();
            monsterType.health -= physDamage;
            Console.WriteLine(name + " swings his " + EquippedWeapon.weaponName + " and strikes! Dealing " + physDamage + " damage to the " + monsterType.name);
            if (monsterType.health <= 0) 
            {
                opponent.RemoveDefeatedMonsterAndGenerateNew();
            }
            
        }
        private int CalculatePhysDamage()
        {
            Random random = new Random();
            
            int baseDamage = random.Next(attackDamage, attackDamage * 2);
            int totalDamage = baseDamage + AttackDamage;
            if (EquippedWeapon != null)
            {

                totalDamage += EquippedWeapon.GetAttackDamageModifier();
            }
            return Math.Max(totalDamage, baseDamage);
            
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
            Console.WriteLine(name + " health: " + health + "  weapon: " + EquippedWeapon.weaponName);
        }

        public void StatsManagement()
        {
            Console.WriteLine(name + " steps back to make a quick adjustment.." +
                                "\n1: Manage equipment" +
                                "\n2: Re-engage enemy..");

            bool leaveQuarters = false;
            do
            {
                
                
                
                int prompt = int.Parse(Console.ReadLine());
                switch (prompt)
                {
                    case 1:
                        ShowAvailableWeapons();
                        int weaponIndex = int.Parse(Console.ReadLine());
                        EquipWeapon(weaponIndex);
                        Console.WriteLine("..re-examine equipment or re-engage enemy?" +
                             "\n1: Manage equipment" +
                             "\n2: Re-engage enemy..");
                        break;

                    case 2:
                        Console.WriteLine(name + " resumes a fighting stance..");
                        leaveQuarters = true;
                        break;
                }
                 //while (leaveQuarters == false);
            } while (leaveQuarters == false);
        }

        public void ShowAvailableWeapons()
        {
            if (AvailableWeaponList != null)
            {
                Console.WriteLine("Available Weapons:");
                int index = 1;
                foreach (Weapon weapon in AvailableWeaponList)
                {
                    Console.WriteLine(index + ": " + weapon.weaponName);
                    index++;
                }
            }
            else
            {
                Console.WriteLine("You do not have any weapons right now..");
                return;
            }


        }
    }
}


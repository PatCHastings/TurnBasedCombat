﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Opponent
    {
        private MonsterType[] monsterTypes =
        {
            new MonsterType("Imp", 3, 30, 10),
            new MonsterType("Ogre", 6, 100, 30),
            new MonsterType("Scorpion", 3, 20, 40),
            new MonsterType("Wyrm", 7, 100, 50)
        };

        public Opponent()
        {
            GenerateRandomMonsterType();
        }
        public MonsterType MonsterType { get; private set; }

        private void GenerateRandomMonsterType()
        {
            Random random = new Random();
            int index = random.Next(monsterTypes.Length);
            MonsterType = monsterTypes[index];
        }
    
        public String Name { get; set; }  
        public int Level { get; set; }  
        public int ArmorRating { get; set; }
        public int Health { get; set; }

        public int opponentCalculateDamage()
        {
            Random random = new Random();
            int baseDamage = random.Next(Level, Level * 2);
            return Math.Max(baseDamage - ArmorRating, 0);
        }

       

        internal void opponentVitals()
        {
            Console.WriteLine(MonsterType.name + " Health: " + MonsterType.health);
        }
    }
}

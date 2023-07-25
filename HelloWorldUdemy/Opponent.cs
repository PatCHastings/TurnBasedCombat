using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Opponent
    {
        private List<MonsterType> monsterTypes = new List<MonsterType>
        {
            new MonsterType("Imp", 3, 30, 10),
            new MonsterType("Ogre", 6, 100, 30),
            new MonsterType("Scorpion", 3, 20, 40),
            new MonsterType("Wyrm", 7, 100, 50)
        };

        public Opponent()
        {
            
        }
        public MonsterType MonsterType { get; set; }

        internal MonsterType GenerateRandomMonsterType()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, monsterTypes.Count);
            MonsterType = monsterTypes[randomIndex];
            return MonsterType;
        }
        public void RemoveDefeatedMonsterAndGenerateNew()
        {
            // Find the defeated monster with health <= 0
            //MonsterType defeatedMonster = monsterTypes.Find(monster => monster.health <= 0);\
            for (int i = monsterTypes.Count - 1; i >= 0; i--)
            {
                if (monsterTypes[i].health <= 0)
                {
                    // Remove the defeated monster from the list
                    monsterTypes.RemoveAt(i);
                    Console.WriteLine(MonsterType.name +  " has been defeated! But a new opponent draws near..");
                    // Remove the defeated monster from the list
                    //monsterTypes.Remove(defeatedMonster);

                    // Generate a new random monster and add it to the list
                    MonsterType newMonster = GenerateRandomMonsterType();
                    monsterTypes.Add(newMonster);
                    Console.WriteLine(newMonster + " has now entered the arena!");
                }
            }
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

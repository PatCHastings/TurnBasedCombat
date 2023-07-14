using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class MonsterType
    {
        public string name;
        public int level; 
        public int health;
        public int attackDamage;

        public MonsterType(string name, int level, int health, int attackDamage)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.attackDamage = attackDamage;
        }
        public MonsterType()
        {
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public string AttackDamage { get; set; }
    }
}

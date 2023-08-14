using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TurnBasedCombat;

namespace TurnBasedCombat
{
    class Combat
    {
        private Timer monsterAttackTimer;
        private const int monsterAttackInterval = 5000;
        internal static bool GameOver(bool gameOver)
        {
            Console.WriteLine("You have died in battle..GAME OVER!");
            return gameOver = true;
        }

        public static void Main(string[] args)
        {
            Combat game = new Combat();
            
            game.gameLoop();
        }
        private void StartMonsterAttackTimer(Player player, Opponent opponent)
        {
            monsterAttackTimer = new Timer(PerformMonsterAttackCallback, new object[] { player, opponent }, monsterAttackInterval, Timeout.Infinite);
        }
        private void PerformMonsterAttackCallback(object state)
        {
            object[] stateArray = (object[])state;
            Player player = (Player)stateArray[0];
            Opponent opponent = (Opponent)stateArray[1];

            opponent.PerformMonsterAttack(player);
            StartMonsterAttackTimer(player, opponent); // Restart the timer for the next attack
        }

        public void gameLoop()
        {
            Player player = new Player { name = "pat", level = 5, attackDamage = 3, armorRating = 3, health = 49 };
            ItemBag itemBag = new ItemBag();
            HealingPotion healingPotion = new HealingPotion("healingpotion", 20);
            Firebomb firebomb = new Firebomb("firebomb", 20);
            //Weapon woodenSword = new WoodenSword(true);
            player.AvailableWeaponList = new List<Weapon>
            {
                new WoodenSword(true),
                new Dagger(false)


            };
            player.EquippedWeapon = player.AvailableWeaponList[0];
            itemBag.AddItem(healingPotion);
            itemBag.AddItem(firebomb);
            Opponent opponent = new Opponent();
            opponent.GenerateRandomMonsterType();
            MonsterType monster = opponent.MonsterType;

            Console.WriteLine("Welcome to brutal combat! The fight is about to start...What is your name, stranger?");
            string promptName = Console.ReadLine();
            player.name = promptName;

            Console.WriteLine("Ok then, " + player.name + "...the opponent has entered the arena! A fierce " + monster.name + "!");

            bool gameOver = false;
            while (gameOver == false)
            {
                StartMonsterAttackTimer(player, opponent);
                Console.WriteLine(player.name + " What will you do?" +
                    "\n1: Fight" +
                    "\n2: Magic" +
                    "\n3: use item" +
                    "\n4: switch weapons");
                string retry = "no";
                do
                {
                    int prompt = int.Parse(Console.ReadLine());
                    switch (prompt)
                    {
                        case 1:
                            Console.WriteLine("CraaacK!");
                            player.UsePhysAttack(opponent);
                            player.playerVitals();
                            opponent.opponentVitals();
                            break;
                        case 2:
                            Console.WriteLine("ZAaaaP!");
                            player.UseMagicAttack(opponent);
                            opponent.RemoveDefeatedMonsterAndGenerateNew();
                            player.playerVitals();
                            opponent.opponentVitals();
                            break;
                        case 3:
                            Console.WriteLine(player.name + " reaches into his bag...");
                            itemBag.SelectItem(player, monster);
                            opponent.RemoveDefeatedMonsterAndGenerateNew();
                            player.playerVitals();
                            opponent.opponentVitals();
                            break;
                        case 4:
                            player.StatsManagement();
                            player.playerVitals();
                            opponent.opponentVitals();
                            break;
                        default:
                            Console.WriteLine("thats not an option");
                            Console.WriteLine("would you like to retry?");
                            retry = Console.ReadLine();
                            break;
                    }
                } while (retry != "no");

                // new switch case for statsManagement

            }
        }



    
            
           
        
        
    }
}

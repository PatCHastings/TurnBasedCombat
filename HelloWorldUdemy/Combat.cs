using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    class Combat
    {
        
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

        public void gameLoop()
        {
            Player player = new Player { name = "pat", level = 5, armorRating = 3, health = 49 };
            //MonsterType monster = new MonsterType { name = "test", level = 4, attackDamage = 2, health = 50 };
            Opponent opponent = new Opponent();
            MonsterType monster = opponent.MonsterType;

            Console.WriteLine("Welcome to brutal combat! The fight is about to start...What is your name, stranger?");
            string promptName = Console.ReadLine();
            player.name = promptName;
            
            Console.WriteLine("Ok then, " + player.name + "...the opponent has entered the arena! A fierce " + monster.name + "!");
            Console.WriteLine(player.Name + " What will you do?" +
                "\n1: Fight" +
                "\n2: Magic" +
                "\n3: use item");

            bool gameOver = false; 
            while (gameOver == false)
            {
                

                int prompt = int.Parse(Console.ReadLine());
                switch (prompt)
                {
                    case 1:
                        Console.WriteLine("CraaacK!");
                        player.UsePhysAttack(opponent);
                        opponent.opponentVitals();
                        player.playerVitals();
                        break;
                    case 2:
                        Console.WriteLine("ZAaaaP!");
                        player.UseMagicAttack(opponent);
                        opponent.opponentVitals();
                        player.playerVitals();
                        break;
                    //case 3:
                    //    Console.WriteLine(player.name + " reaches into his bag...");
                    //    player.selectItem();
                }
            }
        }
    }
}

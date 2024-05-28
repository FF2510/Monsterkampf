using System.Diagnostics;
using MonsterKampfSim.monster;
using static System.Net.Mime.MediaTypeNames;

namespace MonsterKampfSim.gameplay
{
    /// <summary>
    /// This class will handle the fight between two monsters.
    /// </summary>
    public class FightManager
    {
        // Private Member -> Monster A
        private readonly Monster? _monsterA;

        // Private Member -> Monster B
        private readonly Monster? _monsterB;



        // Constructor -> Called when the manager is created -> Pass monsters
        public FightManager(Monster monsterA, Monster monsterB)
        {
            // Set private members
            this._monsterA = monsterA;
            this._monsterB = monsterB;
        }

        /// <summary>
        /// Starts the fight.
        /// </summary>
        public void StartFight()
        {
            FightLoop();
        }

        /// <summary>
        /// Calles from outside -> Represents the fight loop.
        /// Will print message with winner after fight is over.
        /// </summary>
        /// <param name="pause"></param>
        private void FightLoop()
        {
            // End function -> Make sure monsters are valid
            if(_monsterA is null || _monsterB is null)
            {
                return;
            }

            // End function -> Make sure monsters are not the same
            if(_monsterA.GetType() == _monsterB.GetType())
            {
                Console.Clear();
                Console.WriteLine("Monsters are of same type!");
                return;
            }




            // Monster class thats on turn
            Monster turnMonster = _monsterA;

            // How often did the monsters fight
            int rounds = 0;



            // Loop as long as all monsters are alive
            while(_monsterA.IsAlive() && _monsterB.IsAlive())
            {
                Monster lastTurn = turnMonster;
                bool effective = false;
                bool specialAttack = false;
                int damage = 0;

                // If monster a is on the move
                if(turnMonster == _monsterA)
                {
                    (effective, specialAttack, damage) = turnMonster.AttackTarget(_monsterB);
                    turnMonster = _monsterB;
                }

                // If monster b is on the move
                else if(turnMonster == _monsterB)
                {
                    (effective, specialAttack, damage) = turnMonster.AttackTarget(_monsterA);
                    turnMonster = _monsterA;
                }


                if(effective)
                {
                    // Update rounds
                    rounds++;

                    //Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Fight Log -> Round:" + rounds + " | " + _monsterA.Name + " vs. " + _monsterB.Name);
                    Console.ResetColor();

                 
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(lastTurn.Name + " Special Attack -> " + specialAttack);
                    Console.ResetColor();
                    

                    Console.WriteLine(lastTurn.Name + " Attacked -> " + turnMonster.Name + " | Damage = " + damage);
                    Console.WriteLine(lastTurn.Name + " Health: " + lastTurn.HealthPoints + " | " + turnMonster.Name + " Health: " + turnMonster.HealthPoints);
                    Console.WriteLine(lastTurn.Name + " Defense: " + lastTurn.DefensePoints + " | " + turnMonster.Name + " Defense: " + turnMonster.DefensePoints);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(turnMonster.Name + " => Attacking ..."); Console.ResetColor();

                    Console.WriteLine("\n \n \n");

                    // Wait for X miliseconds
                    Thread.Sleep(turnMonster.Speed * 1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(lastTurn.Name + " -> Attack failed!");
                    Console.ResetColor();

                    Console.WriteLine("\n \n");

                    Thread.Sleep(1000);
                }
            }




            // set the winner monster
            Monster winner = (_monsterA.IsAlive()) ? _monsterA : _monsterB;

            // Clean the console
            Console.Clear();

            // If one of the monsters is dead
            Console.WriteLine("The winner is: " + winner.Name);
            Console.WriteLine("Played rounds: " + rounds.ToString());


            Console.WriteLine("Press any key to restart ...");
            Console.ReadKey();

            // Restart the game
            Console.Clear();
            GameManager mg = new GameManager();
            mg.Start();
        }
    }
}
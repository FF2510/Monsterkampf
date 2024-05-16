using System.Diagnostics;
using MonsterKampfSim.monster;

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
        /// Calles from outside -> Represents the fight loop.
        /// Will print message with winner after fight is over.
        /// </summary>
        /// <param name="pause"></param>
        public void FightLoop(int pause = 2000)
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
                // If monster a is on the move
                if(turnMonster == _monsterA)
                {
                    turnMonster.AttackTarget(_monsterB);
                    turnMonster = _monsterB;
                }

                // If monster b is on the move
                else if(turnMonster == _monsterB)
                {
                    turnMonster.AttackTarget(_monsterA);
                    turnMonster = _monsterA;
                }

                // Update rounds
                rounds++;

                // Wait for X miliseconds
                Thread.Sleep(pause);
            }




            // set the winner monster
            Monster winner = (_monsterA.IsAlive()) ? _monsterA : _monsterB;

            // Clean the console
            Console.Clear();

            // If one of the monsters is dead
            Console.WriteLine("The winner is: " + winner.ToString());
            Console.WriteLine("Played rounds: " + rounds.ToString());
            return;
        }
    }
}
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using MonsterKampfSim.ui;
using MonsterKampfSim.utility;

namespace MonsterKampfSim.gameplay
{
    public class GameManager
    {
        /// <summary>
        /// Will start the monster fight game.
        /// Intended to be called from outide of the class.
        /// </summary>
        public void Start()
        {
            // Create the menu
            Menu menu = new Menu();
            menu.Start();
        }

    }
}
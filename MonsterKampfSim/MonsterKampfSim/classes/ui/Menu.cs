using System;
using System.Collections.Generic;
using MonsterKampfSim.classes.utility;
using MonsterKampfSim.gameplay;
using MonsterKampfSim.monster;
using MonsterKampfSim.utility;

namespace MonsterKampfSim.ui
{
    public class Menu
    {
        public static FightManager? FightManager;

        private readonly List<Monster> _monsters = new List<Monster>();
        private bool _running = false;
        private int _selectedIndex = 0;
        private int _selection = 0;
        private readonly List<string> _monsterOptions = new List<string> { "Ork", "Goblin", "Troll" };

        private readonly string[] _monsterStats =
        {
            "Tantrum: 20% Chance to deal double damage\nif own health is less than the enemies health!",
            "Sneak Attack: 10% Chance to deal double damage\nif enemies health is below own health.",
            "Stunning Roar: 10% Chance that the opponent is stunned\nand cannot attack for one round. Only if own defense is broken."
        };

        private readonly InputManager _inputManager = new InputManager();

        /// <summary>
        /// Starts the menu to create monsters and initiate the fight.
        /// </summary>
        public void Start()
        {
            if (_running)
                return;

            _running = true;
            CreateMonsters();
        }

        /// <summary>
        /// Creates two monsters by displaying the options menu and handling user input.
        /// </summary>
        private void CreateMonsters()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                DisplayOptionsMenu("Select your monster: ", _monsterOptions, _monsterStats);
                SelectionInput();
            }

            Console.Clear();
            FightManager = new FightManager(_monsters[0], _monsters[1]);
            FightManager.StartFight();
        }

        /// <summary>
        /// Displays the options menu for monster selection.
        /// </summary>
        /// <param name="header">Header text for the menu.</param>
        /// <param name="options">List of monster options.</param>
        /// <param name="stats">Array of monster stats.</param>
        private void DisplayOptionsMenu(string header, List<string> options, string[] stats)
        {
            Console.Clear();
            Console.WriteLine(header);

            for (int i = 0; i < options.Count; i++)
            {
                if (i == _selection)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"[{i}] {options[i]}");
                Console.ResetColor();
            }

            Console.WriteLine("-----------------------------");
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 2);
            Console.Write(stats[_selection]);
        }

        /// <summary>
        /// Handles user input for menu navigation and selection.
        /// </summary>
        private void SelectionInput()
        {
            bool run = true;

            while (run)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            _selection = (_selection <= 0) ? _monsterOptions.Count - 1 : _selection - 1;
                            DisplayOptionsMenu("Select your monster: ", _monsterOptions, _monsterStats);
                            break;

                        case ConsoleKey.DownArrow:
                            _selection = (_selection >= _monsterOptions.Count - 1) ? 0 : _selection + 1;
                            DisplayOptionsMenu("Select your monster: ", _monsterOptions, _monsterStats);
                            break;

                        case ConsoleKey.Enter:
                            Console.Clear();
                            string option = _monsterOptions[_selection];
                            AskStats(option);
                            run = false;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter stats for the selected monster.
        /// </summary>
        /// <param name="option">The selected monster type.</param>
        private void AskStats(string option)
        {
            int health = GetStatInput("HEALTH");
            int attack = GetStatInput("ATTACK");
            int defense = GetStatInput("DEFENSE");
            int speed = GetStatInput("SPEED");

            Monster monster = option switch
            {
                "Ork" => new Ork(health, attack, defense, speed),
                "Troll" => new Troll(health, attack, defense, speed),
                "Goblin" => new Goblin(health, attack, defense, speed),
                _ => throw new ArgumentException("Invalid monster type")
            };

            _monsters.Add(monster);
            _monsterOptions.Remove(option);
        }

        /// <summary>
        /// Prompts the user to enter a valid integer stat within a specified range.
        /// </summary>
        /// <param name="statName">The name of the stat to input.</param>
        /// <returns>The validated stat value.</returns>
        private int GetStatInput(string statName)
        {
            int value = 0;
            while (true)
            {
                Console.WriteLine($"Please enter {statName} value:");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("VALID!");
                    Console.ResetColor();
                    Thread.Sleep(200);
                    return value;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID! Try Again.");
                Console.ResetColor();
                Thread.Sleep(500);
            }
        }
    }
}

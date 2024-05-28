using System;
using MonsterKampfSim.gameplay;

namespace MonsterKampfSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.Start();

            // Verhindert, dass das Programm sofort beendet wird
            Console.ReadLine();
        }
    }
}

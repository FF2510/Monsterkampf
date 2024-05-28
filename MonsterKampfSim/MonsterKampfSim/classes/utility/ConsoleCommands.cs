using System.Numerics;

namespace MonsterKampfSim.utility
{
    public static class ConsoleCommands
    {
        public static void CleanConsoleFromLine(int start)
        {
            // Save original cursor location
            int originalTop = Console.GetCursorPosition().Top;
            int originalLeft = Console.GetCursorPosition().Left;

            // Set console to target location
            Console.SetCursorPosition(0, start);

            // Clear everything
            for(int i = 0; i < Console.WindowHeight; i++)
            {
                for(int ii = 0; ii < Console.WindowWidth; ii++)
                {
                    Console.Write(" ");
                }

                // New Line
                Console.WriteLine();
            }

            // Reset cursor
            Console.SetCursorPosition(originalLeft, originalTop);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSim.classes.utility
{
    public static class Statics
    {
        static public void WriteAnimation(bool NewLine, int InInterval, string InContent)
        {
            // Transform Input string into character array
            char[] chars = InContent.ToCharArray();

            // Stop if there is no content
            if (chars.Length <= 0)
                return;

            // Correct interval if invalid
            if (InInterval <= 0)
                InInterval = 10;

            // Loop
            foreach (char character in chars)
            {
                Console.Write(character);
                Thread.Sleep(InInterval);
            }

            if (NewLine)
                Console.WriteLine();
        }

        static public void ClearLine(bool Displace)
        {
            // Get y pos of cursor
            int pos = Console.CursorTop;

            if (Displace)
                pos--;

            // Set Cursor to be at start of line
            Console.SetCursorPosition(0, pos);
            //Overwrite line with empty string of line length
            Console.Write(new string(' ', 100));
            // Rest the cursor position to start pos
            Console.SetCursorPosition(0, pos);
        }
    }
}

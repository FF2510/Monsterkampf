namespace MonsterKampfSim.gameplay
{
    public enum InputType
    {
        Up,
        Right,
        Down,
        Left
    }


    public class InputManager
    {
        public InputType ReceiveInput()
        {
            while(true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo Input = Console.ReadKey(true);

                    switch (Input.Key)
                    {
                        case ConsoleKey.UpArrow:
                        return InputType.Up;
                            break;

                        case ConsoleKey.RightArrow:
                        return InputType.Right;
                            break;

                        case ConsoleKey.DownArrow:
                        return InputType.Down;
                            break;

                        case ConsoleKey.LeftArrow:
                        return InputType.Left;
                            break;
                    }
                }

                // Pause
                Thread.Sleep(10);
            }
        }
    }
}
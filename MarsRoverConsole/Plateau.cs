using System;

namespace MarsRoverConsole
{
    public class Plateau
    {
        public Location UpperRight { get; set; }

        /// <summary>
        /// parses the input stream of plateau maximum x and y cordinates 
        /// </summary>
        /// <returns></returns>
        public bool ParseInputString()
        {
            if (UpperRight == null)
                UpperRight = new Location();

            bool parsed = false;
            while (!parsed)
            {
                Console.WriteLine("\r\nPlease enter upper-right coordinates (x and y) of the plateau separated by space e.g. 99 78: ");
                string inp = Console.ReadLine();
                if (!string.IsNullOrEmpty(inp))
                {
                    if (inp.Contains(" "))
                    {
                        string[] arr = inp.Split(' ');
                        if (arr.Length == 2)
                        {
                            uint x, y;
                            if (uint.TryParse(arr[0], out x) && uint.TryParse(arr[1], out y))
                            {
                                UpperRight.X = x;
                                UpperRight.Y = y;
                                parsed = true;
                            }
                            else
                                Console.WriteLine("All input values must be positive integers");
                        }
                        else
                        {
                            Console.WriteLine("Please enter 2 values");
                        }
                    }
                    else
                        Console.WriteLine("input values must be separated by space");
                }
                else
                    Console.WriteLine("no input");
            }

            return parsed;
        }
    }
}
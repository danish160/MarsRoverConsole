using System;

namespace MarsRoverConsole
{
    public class Robot
    {
        private string Name { get; set; }
        private uint MaxX { get; set; }
        private uint MaxY { get; set; }
        public Location Loc { get; set; }
        public CardinalDirection CardinalDir { get; set; }

        public Robot(string name, uint maxX, uint maxY)
        {
            Name = name;
            MaxX = maxX;
            MaxY = maxY;
        }

        /// <summary>
        /// parses the input stream of robot cordinates and initial direction
        /// </summary>
        /// <returns></returns>
        public bool ParseInputString()
        {
            if (Loc == null)
                Loc = new Location();

            bool parsed = false;
            while (!parsed)
            {
                Console.WriteLine("\r\nPlease enter coordinates (x and y) and direction (N,E,W,S) of the robot: " + Name);
                string inp = Console.ReadLine();
                if (!string.IsNullOrEmpty(inp))
                {
                    if (inp.Contains(" "))
                    {
                        string[] arr = inp.ToUpper().Split(' ');
                        if (arr.Length == 3)
                        {
                            uint x, y;
                            if (uint.TryParse(arr[0], out x) && uint.TryParse(arr[1], out y))
                            {
                                ///////////////////////////////////////////
                                // Assumption: input values for x or y go out of the bound of the plateau, 
                                // for simplicity, max value is assigned for x and y respectivly
                                ///////////////////////////////////////////
                                
                                if (x > MaxX)
                                    x = MaxX;
                                if (y > MaxY)
                                    y = MaxY;

                                Loc.X = x;
                                Loc.Y = y;

                                switch (arr[2])
                                {
                                    case "N":
                                    case "E":
                                    case "W":
                                    case "S":
                                        CardinalDir = arr[2].ToEnum<CardinalDirection>();
                                        parsed = true;
                                        break;
                                    default:
                                        Console.WriteLine("invalid direction");
                                        break;
                                }
                            }
                            else
                                Console.WriteLine("x and y coordinated must be positive integer values");
                        }
                        else
                        {
                            Console.WriteLine("Please enter 3 values");
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

        /// <summary>
        /// Processes the input stream of directions for robot movement like left right and move-ahead
        /// </summary>
        public void ProcessInputDirection()
        {
            if (Loc == null)
                Loc = new Location();

            bool processed = false;
            while (!processed)
            {
                Console.WriteLine("\r\nPlease enter directions for robot: " + Name);
                string inp = Console.ReadLine();
                if (!string.IsNullOrEmpty(inp))
                {
                    if (!inp.Contains(" "))
                    {
                        char[] chArr = inp.ToUpper().ToCharArray();

                        if (chArr.Length > 0)
                        {
                            foreach (char t in chArr)
                            {
                                if (t == 'L' || t == 'R')
                                {
                                    this.ChangeDirection(t.ToString().ToEnum<Direction>());
                                }
                                else if (t == 'M')
                                {
                                    this.Move();
                                }
                                else
                                {
                                    // invalid direction, skip and continue
                                    continue;
                                }
                            }
                            processed = true;
                        }
                    }
                    else
                        Console.WriteLine("input values must not contain spaces");
                }
                else
                    Console.WriteLine("no input");
            }

            return;
        }

        /// <summary>
        /// Changes the robots cardinal direction i.e. North, East, West or South
        /// </summary>
        /// <param name="dir"></param>
        private void ChangeDirection(Direction dir)
        {
            if (dir == Direction.L)
            {
                switch (CardinalDir)
                {
                    case CardinalDirection.N:
                        CardinalDir = CardinalDirection.W;
                        break;
                    case CardinalDirection.W:
                        CardinalDir = CardinalDirection.S;
                        break;
                    case CardinalDirection.S:
                        CardinalDir = CardinalDirection.E;
                        break;
                    case CardinalDirection.E:
                        CardinalDir = CardinalDirection.N;
                        break;
                }
            }
            else if(dir== Direction.R)
            {
                switch (CardinalDir)
                {
                    case CardinalDirection.N:
                        CardinalDir = CardinalDirection.E;
                        break;
                    case CardinalDirection.W:
                        CardinalDir = CardinalDirection.N;
                        break;
                    case CardinalDirection.S:
                        CardinalDir = CardinalDirection.W;
                        break;
                    case CardinalDirection.E:
                        CardinalDir = CardinalDirection.S;
                        break;
                }
            }
        }

        /// <summary>
        /// Moves the robot one step ahead in the direction where the robot is pointing. 
        /// If the input goe out of the bound, robot will not move.
        /// </summary>
        private void Move()
        {
            switch (CardinalDir)
            {
                case CardinalDirection.N:
                    if (Loc.Y + 1 <= MaxY)
                        Loc.Y++;
                    break;
                case CardinalDirection.W:
                    if ((int)Loc.X - 1 >= 0)
                        Loc.X--;
                    break;
                case CardinalDirection.S:
                    if ((int)Loc.Y - 1 >= 0)
                        Loc.Y--;
                    break;
                case CardinalDirection.E:
                    if (Loc.X + 1 <= MaxX)
                        Loc.X++;
                    break;
            }
        }
    }
}
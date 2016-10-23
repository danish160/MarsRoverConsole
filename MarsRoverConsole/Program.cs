using System;

namespace MarsRoverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************** MARS ROVER ***************");

            Plateau plateau = new Plateau();

            if (plateau.ParseInputString())
            {
                //Console.WriteLine(plateau.UpperRight.ToString());

                Robot robo1 = new Robot("Robot1", plateau.UpperRight.X, plateau.UpperRight.Y);
                Robot robo2 = new Robot("Robot2", plateau.UpperRight.X, plateau.UpperRight.Y);

                if (robo1.ParseInputString() && robo2.ParseInputString())
                {
                    robo1.ProcessInputDirection();
                    robo2.ProcessInputDirection();

                    Console.WriteLine(robo1.Loc + " " + robo1.CardinalDir);
                    Console.WriteLine(robo2.Loc + " " + robo2.CardinalDir);
                }
            }

            Console.Read();
        }
    }
}

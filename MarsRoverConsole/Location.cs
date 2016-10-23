namespace MarsRoverConsole
{
    public class Location
    {
        public uint X { get; set; }
        public uint Y { get; set; }

        public Location()
        {
        }
        public Location(uint pX, uint pY)
        {
            X = pX;
            Y = pY;
        }

        public override string ToString()
        {
            //return string.Format("X: {0}, Y: {1}", X, Y);
            return string.Format("{0} {1}", X, Y);
        }
    }
}
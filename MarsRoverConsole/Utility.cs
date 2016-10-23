using System;

namespace MarsRoverConsole
{
    public static class Utility
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
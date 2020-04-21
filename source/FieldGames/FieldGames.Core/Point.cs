using System;

namespace FieldGames.Core
{
    public struct Point : IEquatable<Point>
    {
        public static Point Zero = new Point(0, 0);

        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) { X = x; Y = y; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
        public override bool Equals(object obj)
        {
            if (obj is Point)
                return this.Equals((Point)obj);
            
            return false;
        }
        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}

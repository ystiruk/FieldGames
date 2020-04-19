using System;

namespace Sandbox
{
    //class Field
    //{
    //    public Field()
    //    {

    //    }
    //}

    public static class PointExtensions
    {
        public enum Direction
        {
            Cross,
            Diag,
            All
        }

        public static Point[] GetNeighbours(this Point point, Direction direction)
        {
            switch (direction)
            {
                case Direction.Cross:
                    return point.GetCrossNeighbours();
                case Direction.Diag:
                    return point.GetDiagonalNeighbours();
                case Direction.All:
                    return point.GetAllNeighbours();
                default:
                    throw new ArgumentException(nameof(direction));
            }
        }
        private static Point[] GetCrossNeighbours(this Point point)
        {
            Point[] neighbours = new Point[4]
            {
                new Point(point.X - 1, point.Y),
                new Point(point.X, point.Y - 1),
                new Point(point.X + 1, point.Y),
                new Point(point.X, point.Y + 1)
            };

            return neighbours;
        }
        private static Point[] GetDiagonalNeighbours(this Point point)
        {
            Point[] neighbours = new Point[4]
            {
                new Point(point.X - 1, point.Y - 1),
                new Point(point.X - 1, point.Y + 1),
                new Point(point.X + 1, point.Y + 1),
                new Point(point.X + 1, point.Y - 1)
            };

            return neighbours;
        }
        private static Point[] GetAllNeighbours(this Point point)
        {
            Point[] neighbours = new Point[8];

            var crossPoints = point.GetCrossNeighbours();
            var diagPoints = point.GetDiagonalNeighbours();

            Array.Copy(crossPoints, 0, neighbours, 0, crossPoints.Length);
            Array.Copy(diagPoints, 0, neighbours, 4, diagPoints.Length);

            return neighbours;
        }
    }
}

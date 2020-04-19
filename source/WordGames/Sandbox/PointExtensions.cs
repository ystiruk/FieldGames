using System;

namespace Sandbox
{
    public static class PointExtensions
    {
        public static Point[] GetNeighbours(this Point point, SearchDirection direction)
        {
            switch (direction)
            {
                case SearchDirection.Cross:
                    return point.GetCrossNeighbours();
                case SearchDirection.Diag:
                    return point.GetDiagonalNeighbours();
                case SearchDirection.All:
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

        public static bool IsInsideField(this Point point, int width, int height)
        {
            return point.X >= 0 && point.X < width && point.Y >= 0 && point.Y < height;
        }
    }
}

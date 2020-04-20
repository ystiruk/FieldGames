using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordGames.Core.Tests
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void DefaultConstructorCreatesEmptyPath()
        {
            Path path = new Path();

            Assert.AreEqual(path.Length, 0);
        }

        [TestMethod]
        public void ConstructorWithParameterCreatesPathOfRightLength()
        {
            var points = Enumerable.Range(0, 3).Select(x => new Point(x, x));
            Path path = new Path(points);

            Assert.AreEqual(path.Length, 3);
        }

        [TestMethod]
        public void PathCanContainEqualPoints()
        {
            Path path = new Path();
            path.Add(new Point());
            path.Add(new Point());

            Assert.AreEqual(path.Length, 2);
        }

        [TestMethod]
        public void LengthOfPathOfOnePointIs1()
        {
            Path path = new Path();
            path.Add(new Point());

            Assert.AreEqual(path.Length, 1);
        }

        [TestMethod]
        public void AddPointToPathIncrementsPathLength()
        {
            Path path = new Path();
            int lengthBefore = path.Length;

            path.Add(new Point());
            int lengthAfter = path.Length;

            Assert.AreEqual(lengthAfter, lengthBefore + 1);
        }

        [TestMethod]
        public void LastOfPathWithOnePointIsThatPoint()
        {
            var singlePoint = new Point(1, 2);

            Path path = new Path();
            path.Add(singlePoint);
            
            Assert.AreEqual(singlePoint, path.Last);
        }

        [TestMethod]
        public void LastOfPathEqualsToLastAddedPoint()
        {
            Path path = new Path();
            path.Add(Point.Zero);
            path.Add(new Point(1, 2));
            
            var lastPoint = new Point(1, 2);
            path.Add(lastPoint);

            Assert.AreEqual(lastPoint, path.Last);
        }

        [TestMethod]
        public void AddSupportsRightOrderAndIndexing()
        {
            Path path = new Path();

            Point point0 = new Point(1, 1);
            Point point1 = new Point(1, 2);
            Point point2 = new Point(1, 3);

            path.Add(point0);
            path.Add(point1);
            path.Add(point2);

            Assert.AreEqual(path[0], point0);
            Assert.AreEqual(path[1], point1);
            Assert.AreEqual(path[2], point2);
        }

        [TestMethod]
        public void PathWithPointX1Y2ContainsThatPoint()
        {
            Path path = new Path();
            path.Add(new Point(1, 2));

            Assert.IsTrue(path.Contains(new Point(1, 2)));
        }

        [TestMethod]
        public void ExtendCreatesNewObject()
        {
            Path path = new Path();
            Path extendedPath = path.Extend(new Point());

            Assert.AreNotSame(path, extendedPath);
        }

        [TestMethod]
        public void ExtendCreatesPathWithIncrementedLength()
        {
            Path path = new Path() { new Point() };
            Path extendedPath = path.Extend(new Point());

            Assert.AreEqual(extendedPath.Length, path.Length + 1);
        }

        [TestMethod]
        public void ExtendAddsPointToEnd()
        {
            Path path = new Path() { new Point() };

            Point newPoint = new Point(1, 5);
            Path extendedPath = path.Extend(newPoint);

            Assert.AreEqual(extendedPath.Last, newPoint);
        }
    }
}

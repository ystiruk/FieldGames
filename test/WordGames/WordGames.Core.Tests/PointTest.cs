using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordGames.Core.Tests
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void PointConstructor()
        {
            int x = 1;
            int y = 2;
            Point point = new Point(x, y);

            Assert.AreEqual(point.X, x);
            Assert.AreEqual(point.Y, y);
        }

        [TestMethod]
        public void PointEquality()
        {
            Point point1 = new Point(1, 2);
            Point point2 = new Point(1, 2);

            Assert.IsTrue(point1.Equals(point2));
        }

        [TestMethod]
        public void PointEqualityAsObjects()
        {
            object point1 = new Point(1, 2);
            object point2 = new Point(1, 2);

            Assert.IsTrue(point1.Equals(point2));
        }

        [TestMethod]
        public void HashCodesEqualForEquivalentPoints()
        {
            Point point1 = new Point(1, 2);
            Point point2 = new Point(1, 2);

            Assert.AreEqual(point1.GetHashCode(), point2.GetHashCode());
        }

        [TestMethod]
        public void HashCodesAreNotEqualForDifferentPoints()
        {
            Point point1 = new Point(1, 2);
            Point point2 = new Point(-1, 2);

            Assert.AreNotEqual(point1.GetHashCode(), point2.GetHashCode());
        }

        [TestMethod]
        public void PointZeroEqualsToPointX0Y0()
        {
            Point point = new Point(0, 0);

            Assert.AreEqual(point, Point.Zero);
        }
    }
}

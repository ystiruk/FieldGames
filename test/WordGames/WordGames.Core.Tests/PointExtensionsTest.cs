using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WordGames.Core.Tests
{
    [TestClass]
    public class PointExtensionsTest
    {
        [TestMethod]
        public void NumberOfNeighboursForCrossDirectionIs4()
        {
            Point point = Point.Zero;

            int neighboursNumber = point.GetNeighbours(SearchDirection.Cross).Length;
            Assert.AreEqual(neighboursNumber, 4);
        }

        [TestMethod]
        public void NumberOfNeighboursForDiagonalDirectionIs4()
        {
            Point point = Point.Zero;

            int neighboursNumber = point.GetNeighbours(SearchDirection.Diagonal).Length;
            Assert.AreEqual(neighboursNumber, 4);
        }

        [TestMethod]
        public void NumberOfNeighboursForAllDirectionIs8()
        {
            Point point = Point.Zero;

            int neighboursNumber = point.GetNeighbours(SearchDirection.All).Length;
            Assert.AreEqual(neighboursNumber, 8);
        }

        [TestMethod]
        public void NeighboursForCrossDirection()
        {
            Point p = Point.Zero;
            Point[] expectedNeighbours = { new Point(p.X - 1, p.Y), new Point(p.X + 1, p.Y), new Point(p.X, p.Y - 1), new Point(p.X, p.Y + 1) };
            
            Point[] actualNeighbours = p.GetNeighbours(SearchDirection.Cross);

            AssertPointSequencesAreEqual(expectedNeighbours, actualNeighbours);
        }

        [TestMethod]
        public void NeighboursForDiagonalDirection()
        {
            Point p = Point.Zero;
            Point[] expectedNeighbours = { new Point(p.X - 1, p.Y - 1), new Point(p.X + 1, p.Y - 1), new Point(p.X - 1, p.Y + 1), new Point(p.X + 1, p.Y + 1) };

            Point[] actualNeighbours = p.GetNeighbours(SearchDirection.Diagonal);

            AssertPointSequencesAreEqual(expectedNeighbours, actualNeighbours);
        }

        [TestMethod]
        public void NeighboursForAllDirection()
        {
            Point p = Point.Zero;
            Point[] expectedNeighbours = {
                new Point(p.X - 1, p.Y), new Point(p.X + 1, p.Y), new Point(p.X, p.Y - 1), new Point(p.X, p.Y + 1),
                new Point(p.X - 1, p.Y - 1), new Point(p.X + 1, p.Y - 1), new Point(p.X - 1, p.Y + 1), new Point(p.X + 1, p.Y + 1)
            };

            Point[] actualNeighbours = p.GetNeighbours(SearchDirection.All);

            AssertPointSequencesAreEqual(expectedNeighbours, actualNeighbours);
        }

        [TestMethod]
        public void PointZeroInsideField3x3()
        {
            Point point = Point.Zero;

            Assert.IsTrue(point.IsInsideField(3, 3));
        }

        [TestMethod]
        public void PointX2Y2InsideField3x3()
        {
            Point point = new Point(2, 2);

            Assert.IsTrue(point.IsInsideField(3, 3));
        }

        [TestMethod]
        public void PointX3Y2InsideField4x3()
        {
            Point point = new Point(3, 2);

            Assert.IsTrue(point.IsInsideField(4, 3));
        }

        [TestMethod]
        public void PointX2Y3InsideField3x4()
        {
            Point point = new Point(2, 3);

            Assert.IsTrue(point.IsInsideField(3, 4));
        }

        private void AssertPointSequencesAreEqual(Point[] points1, Point[] points2)
        {
            var expected = new HashSet<Point>(points1);
            var actual = new HashSet<Point>(points2);

            Assert.IsTrue(expected.SetEquals(actual));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordGames.Core.Tests
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void LengthOfEmptyPathIs0()
        {
            Path path = new Path();

            Assert.AreEqual(path.Length, 0);
        }

        //TODO: move to badways
        //[TestMethod]
        //public void LastOfEmptyPathIsNull()
        //{
        //    Path path = new Path();

        //    Assert.AreEqual(path.Last, null);
        //}

        [TestMethod]
        public void LengthOfPathOfThreePointsIs3()
        {
            var points = Enumerable.Range(0, 3).Select(x => new Point(x, x));
            Path path = new Path(points);

            Assert.AreEqual(path.Length, 3);
        }

        [TestMethod]
        public void AddPointIncrementsLength()
        {
            Path path = new Path();
            int lengthBefore = path.Length;

            path.Add(new Point());
            int lengthAfter = path.Length;

            Assert.AreEqual(lengthAfter, lengthBefore + 1);
        }
    }
}

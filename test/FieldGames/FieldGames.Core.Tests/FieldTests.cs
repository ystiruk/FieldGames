using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGames.Core.Tests
{
    [TestClass]
    public class FieldTests
    {
        class TestIntField : Field<int>
        {
            public TestIntField(int height, int width) : base(height, width) { }
        }

        [TestMethod]
        public void WidthAndHeightIsSetCorrectly()
        {
            int width = 2;
            int height = 3;
            IField<int> field = new TestIntField(height, width);

            Assert.AreEqual(field.Height, height);
            Assert.AreEqual(field.Width, width);
        }

        [TestMethod]
        public void FieldFilledFrom1to6()
        {
            /*
             (0,0) -> [1] [2]
                      [3] [4]
                      [5] [6]
            */

            IField<int> field = new TestIntField(3, 2);

            for (int x = 0; x < field.Height; x++)
                for (int y = 0; y < field.Width; y++)
                    field[x, y] = (x * field.Width + y) + 1;

            Assert.AreEqual(field[0, 0], 1);
            Assert.AreEqual(field[2, 1], 6);
        }
    }
}

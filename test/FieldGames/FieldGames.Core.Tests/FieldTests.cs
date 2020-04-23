using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FieldGames.Core.Tests
{
    [TestClass]
    public class FieldTests
    {
        class TestIntField : Field<int>
        {
            public TestIntField(int height, int width) : base(height, width) { }
        }
        class TestCharField : Field<char>
        {
            protected TestCharField(int height, int width) : base(height, width) { }
            public TestCharField(int height, int width, string content) : this(height, width)
            {
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        field[i, j] = content[i * width + j];
            }
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

        [TestMethod]
        public void MyTestMethod()
        {
            /*
             h o l a , b 
             r o ! a b b 
             a r u l e s 
             */
            string contents = "hola,bro!abbarules";
            TestCharField field = new TestCharField(3, 6, contents);

            Path holaPathV1 = new Path()
            {
                Point.Zero, new Point(0, 1), new Point(0, 2), new Point(0, 3)
            };
            Path holaPathV2 = new Path()
            {
                Point.Zero, new Point(1, 1), new Point(0, 2), new Point(0, 3)
            };

            string sequenceV1 = new string(field.GetElements(holaPathV1).ToArray());
            string sequenceV2 = new string(field.GetElements(holaPathV2).ToArray());

            Assert.AreEqual(sequenceV1, sequenceV2);
        }
    }
}

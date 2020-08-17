using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FieldGames.Core.Tests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void CircleCollectionWithOneItemReturnsThatItem()
        {
            var source = new List<int>() { 1 };
            var expectedSequence = new List<int>() { 1, 1, 1, 1, 1 };

            var switcher = source.Circle();

            var actualSequence = switcher.Take(5);

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void CircleCollectionWithThreeItemsReturnsTheseItemsInRightOrder()
        {
            var source = new List<int>() { 1, 2, 3 };

            var switcher = source.Circle();

            var actualSequence = switcher.Take(3);

            Assert.IsTrue(source.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void CircleSupportsRemoveElementFromCollection()
        {
            var source = new List<int>() { 1, 2, 3 };
            var expectedSequence = new List<int>() {
                1, 2, 3,
                1, 3
            };

            var switcher = source.Circle();

            var actualSequence = new List<int>();
            actualSequence.AddRange(switcher.Take(3));
            source.Remove(2);
            actualSequence.AddRange(switcher.Take(2));

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void CircleSupportsAddElementToCollection()
        {
            var source = new List<int>() { 1, 2, 3 };
            var expectedSequence = new List<int>() {
                1, 2, 3,
                1, 2, 3, 4
            };

            var switcher = source.Circle();

            List<int> actualSequence = new List<int>();
            actualSequence.AddRange(switcher.Take(3));
            source.Add(4);
            actualSequence.AddRange(switcher.Take(4));

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void CircleSupportsInsertElementToCollection()
        {
            var source = new List<int>() { 1, 2, 3 };
            var expectedSequence = new List<int>() {
                1, 2, 3,
                1, 0, 2, 3
            };

            var switcher = source.Circle();

            var actualSequence = new List<int>();
            actualSequence.AddRange(switcher.Take(3));
            source.Insert(1, 0);
            actualSequence.AddRange(switcher.Take(4));

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }
    }
}

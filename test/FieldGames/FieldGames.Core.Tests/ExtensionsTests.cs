using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldGames.Core.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void SwitchCollectionWithOneItemReturnsThatItem()
        {
            IList<int> source = new List<int>() { 1 };
            IList<int> expectedSequence = new List<int>() { 1, 1, 1, 1, 1 };

            var switcher = source.Switch();

            var actualSequence = switcher.Take(5);

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void SwitchCollectionWithThreeItemsReturnsTheseItemsInRightOrder()
        {
            IList<int> source = new List<int>() { 1, 2, 3 };

            var switcher = source.Switch();

            var actualSequence = switcher.Take(3);

            Assert.IsTrue(source.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void SwitchSupportsRemoveElementFromCollection()
        {
            IList<int> source = new List<int>() { 1, 2, 3 };
            IList<int> expectedSequence = new List<int>() {
                1, 2, 3,
                1, 3
            };

            var switcher = source.Switch();

            var actualSequence = new List<int>();
            actualSequence.AddRange(switcher.Take(3));
            source.Remove(2);
            actualSequence.AddRange(switcher.Take(2));

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void SwitchSupportsAddElementToCollection()
        {
            IList<int> source = new List<int>() { 1, 2, 3 };
            IList<int> expectedSequence = new List<int>() {
                1, 2, 3,
                1, 2, 3, 4
            };

            var switcher = source.Switch();

            List<int> actualSequence = new List<int>();
            actualSequence.AddRange(switcher.Take(3));
            source.Add(4);
            actualSequence.AddRange(switcher.Take(4));

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [TestMethod]
        public void SwitchSupportsInsertElementToCollection()
        {
            IList<int> source = new List<int>() { 1, 2, 3 };
            IList<int> expectedSequence = new List<int>() {
                1, 2, 3,
                1, 0, 2, 3
            };

            var switcher = source.Switch();

            var actualSequence = new List<int>();
            actualSequence.AddRange(switcher.Take(3));
            source.Insert(1, 0);
            actualSequence.AddRange(switcher.Take(4));

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }
    }
}

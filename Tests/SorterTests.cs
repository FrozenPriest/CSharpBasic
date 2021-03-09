using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSharpBasic;
using NUnit.Framework;

namespace Tests
{
    public class SorterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSort()
        {
            var init = new[] {5, 3, 1, 6, 5, 2, -1, -64, -5, 5, 7574, 999};
            var init2 = new[] {5, 3, 1, 6, 5, 2, -1, -64, -5, 5, 7574, 999};
            Array.Sort(init);
            Assert.AreEqual(init, Sorter.InsertionSort(init2, (i1, i2) => i1.CompareTo(i2)));
        }

        [Test]
        public void TestSortReverse()
        {
            var init = new[] {5, 3, 1, 6, 5, 2, -1, -64, -5, 5, 7574, 999};
            var init2 = new[] {5, 3, 1, 6, 5, 2, -1, -64, -5, 5, 7574, 999};
            Array.Sort(init);
            Array.Reverse(init);
            Assert.AreEqual(init, Sorter.InsertionSort(init2,
                (i1, i2) => i2.CompareTo(i1)));
        }
    }
}
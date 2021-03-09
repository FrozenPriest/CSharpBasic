using System;
using CSharpBasic;
using NUnit.Framework;

namespace Tests
{
    public class LinkedListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddToEmpty()
        {
            var list = new LinkedList<int>();
            list.InsertLast(2);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list.Size);
        }

        [Test]
        public void TestGetEmpty()
        {
            var list = new LinkedList<int>();
            Assert.Catch<IndexOutOfRangeException>(delegate
            {
                var value = list[0];
            });
        }

        [Test]
        public void TestIndexOutOfBounds()
        {
            var list = GenerateList();
            Assert.Catch<IndexOutOfRangeException>(delegate
            {
                var value = list[-1];
            });
            Assert.Catch<IndexOutOfRangeException>(delegate
            {
                var value = list[list.Size];
            });
            Assert.DoesNotThrow(delegate
            {
                var value = list[list.Size - 1];
            });
            Assert.DoesNotThrow(delegate
            {
                var value = list[0];
            });
        }
        
        [Test]
        public void TestRemoveFirst()
        {
            var list = GenerateList();
            var size = list.Size;
            Assert.DoesNotThrow(delegate
            {
                list.Remove(0);
            });
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(size-1, list.Size);
        }
        
        [Test]
        public void TestRemoveLast()
        {
            var list = GenerateList();
            var size = list.Size;
            Assert.DoesNotThrow(delegate
            {
                list.Remove(size-1);
            });
            Assert.AreEqual(8, list[list.Size-1]);
            Assert.AreEqual(size-1, list.Size);
        }
        
        [Test]
        public void TestInsertBefore()
        {
            var list = GenerateList();
            var size = list.Size;
            Assert.DoesNotThrow(delegate
            {
                list.InsertBefore(size-2, 999);
            });
            Assert.AreEqual(999, list[list.Size-3]);
            Assert.AreEqual(8, list[list.Size-2]);
            Assert.AreEqual(7, list[list.Size-4]);
            Assert.AreEqual(size+1, list.Size);
        }
        
        public void TestInsertAfter()
        {
            var list = GenerateList();
            var size = list.Size;
            Assert.DoesNotThrow(delegate
            {
                list.InsertAfter(size-2, 999);
            });
            Assert.AreEqual(999, list[list.Size-2]);
            Assert.AreEqual(8, list[list.Size-3]);
            Assert.AreEqual(9, list[list.Size-1]);
            Assert.AreEqual(size+1, list.Size);
        }

        [Test]
        public void TestReverse()
        {
            var list = GenerateList();
            Assert.DoesNotThrow(delegate
            {
                list.Reverse();
            });
            for (var i = 0; i < 10; i++)
                Assert.AreEqual(list[list.Size-i-1], i);
        }
        
        [Test]
        public void TestForEach()
        {
            var list = GenerateList();
            var sum = 0;
            foreach (var cur in list)
            {
                sum+=cur;
            }
            Assert.AreEqual(45, sum);
        }


        
        LinkedList<int> GenerateList()
        {
            var list = new LinkedList<int>();
            for (var i = 0; i < 10; i++)
                list.InsertLast(i);
            return list;
        }
    }
}
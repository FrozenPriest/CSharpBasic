using System;
using System.Collections.Generic;
using CSharpBasic;
using NUnit.Framework;

namespace Tests
{
    public class BinaryTreeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInsertEmpty()
        {
            var tree = new BinaryTree<string>();
            tree.Insert(5, "value");
            Assert.AreEqual("value", tree[5]);
        }

        [Test]
        public void TestInsert()
        {
            var tree = GenerateTestTree1();
            var size = tree.Size;
            tree.Insert(5, "value");
            Assert.AreEqual("value", tree[5]);
            Assert.AreEqual(size + 1, tree.Size);
        }

        [Test]
        public void TestInsertReplace()
        {
            var tree = GenerateTestTree1();
            var size = tree.Size;
            tree.Insert(16, "value");
            Assert.AreEqual("value", tree[16]);
            Assert.AreEqual(size, tree.Size);
        }

        [Test]
        public void TestRemove()
        {
            var tree = GenerateTestTree2();
            var size = tree.Size;
            Assert.DoesNotThrow(delegate { tree.Remove(12); });
            Assert.AreEqual(size - 1, tree.Size);
            Assert.AreEqual("(-4, -4)(2, 2)(3, 3)(5, 5)(9, 9)(19, 19)(21, 21)(25, 25)", tree.ToString());
        }

        [Test]
        public void TestRemoveRoot()
        {
            var tree = GenerateTestTree2();
            var size = tree.Size;
            Assert.DoesNotThrow(delegate { tree.Remove(-4); });
            Assert.AreEqual(size - 1, tree.Size);
            Assert.AreEqual("(2, 2)(3, 3)(5, 5)(9, 9)(12, 12)(19, 19)(21, 21)(25, 25)", tree.ToString());
        }

        [Test]
        public void TestRemoveOnlyRoot()
        {
            var tree = new BinaryTree<String>() {[-4] = "-523535325"};
            var size = tree.Size;
            Assert.DoesNotThrow(delegate { tree.Remove(-4); });
            Assert.AreEqual(size - 1, tree.Size);
            Assert.AreEqual("", tree.ToString());
        }
        
        [Test]
        public void TestRemoveNotExist()
        {
            var tree = new BinaryTree<String>() {[-4] = "-523535325"};
            var size = tree.Size;
            Assert.Catch<KeyNotFoundException>(delegate { tree.Remove(-44); });
            Assert.AreEqual(size, tree.Size);
            Assert.AreEqual("(-4, -523535325)", tree.ToString());
        }

        [Test]
        public void TestFind()
        {
            var tree = GenerateTestTree1();
            Assert.AreEqual(null, tree[-55]);
            Assert.AreEqual(null, tree[998]);
            Assert.AreEqual("four", tree[4]);
            Assert.AreEqual("sixteen", tree[16]);
            Assert.AreEqual("one=1", tree[1]);
            Assert.AreEqual("999", tree[999]);

        }

        private static BinaryTree<String> GenerateTestTree1()
        {
            var tree = new BinaryTree<string> {[4] = "four", [16] = "sixteen", [999] = "999", [1] = "one=1"};


            return tree;
        }

        private static BinaryTree<String> GenerateTestTree2()
        {
            var tree = new BinaryTree<string>
            {
                [5] = "5", [2] = "2", [12] = "12", [-4] = "-4", [3] = "3", [9] = "9", [21] = "21", [19] = "19",
                [25] = "25"
            };


            return tree;
        }
    }
}
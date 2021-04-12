using System;

namespace CSharpBasic
{
    public class Treap
    {
        //декартово дерево

        private Node root;
        private Random random = new Random();


        public void Insert(int key)
        {
            if (root == null)
            {
                root = new Node(key, random.Next());
                return;
            }
            Split(key, out Node left, out Node right);
            Node cur = new Node(key, random.Next());
            root = Merge(Merge(left, cur), right);
        }

        public bool Contains(int key)
        {
            if (root == null) return false;
            return Find(root, key) != null;
        }

        private Node Find(Node curRoot, int key)
        {
            Node ans = null;
            if (curRoot==null)
            {
                return null;
            }
            if (key == curRoot.Key) {
                ans = curRoot;
            } else if (key < curRoot.Key) {
                ans = Find(curRoot.Left, key);
            } else if (key > curRoot.Key) {
                ans = Find(curRoot.Right, key);
            }

            return ans;
        }
        
        private Node Merge(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            if (left.Priority > right.Priority)
            {
                var newRight = Merge(left.Right, right);
                return new Node(left.Key, left.Priority, left.Left, newRight);
            }
            else
            {
                var newLeft = Merge(left, right.Left);
                return new Node(right.Key, right.Priority, newLeft, right.Right);
            }
        }

        private void Split(int key, out Node left, out Node right)
        {
            root.Split(key, out left, out right);
        }


        private class Node
        {
            public int Key { get; set; }
            public int Priority { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }

            public void Split(int key, out Node left, out Node right)
            {
                Node newTree = null;
                if (Key <= key)
                {
                    if (Right == null)
                        right = null;
                    else
                        Right.Split(key, out newTree, out right);
                    left = new Node(Key, Priority, Left, newTree);
                }
                else
                {
                    if (Left == null)
                        left = null;
                    else
                        Left.Split(key, out left, out newTree);
                    right = new Node(Key, Priority, newTree, Right);
                }
            }


            public Node(int key, int priority, Node left, Node right)
            {
                Key = key;
                Priority = priority;
                Left = left;
                Right = right;
            }

            public Node(int key, int priority)
            {
                Key = key;
                Priority = priority;
                Left = null;
                Right = null;
            }

            public Node(int key)
            {
                Key = key;
                Priority = 0;
                Left = null;
                Right = null;
            }
        }
    }
}
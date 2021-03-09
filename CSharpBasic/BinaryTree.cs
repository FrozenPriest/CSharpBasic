using System.Collections.Generic;

namespace CSharpBasic
{
    /*
     * Реализовать бинарное дерево: заполнение, поиск, удаление элемента - без использования стандартных деревьев
     */
    public class BinaryTree<T>
    {
        private Node _root;
        public int Size { get; private set; }

        public T this[int key]
        {
            get => Find(key);
            set => Insert(key, value);
        }

        public void Insert(int key, T value)
        {
            if (_root == null)
            {
                _root = new Node(key, value);
                Size++;
            }
            else
            {
                var curNode = _root;
                while (curNode != null)
                {
                    switch (curNode.Key - key)
                    {
                        case > 0:
                            if (curNode.Left != null) curNode = curNode.Left;
                            else
                            {
                                curNode.Left = new Node(key, value);
                                curNode.Left.Parent = curNode;
                                Size++;
                                return;
                            }

                            break;
                        case < 0:
                            if (curNode.Right != null) curNode = curNode.Right;
                            else
                            {
                                curNode.Right = new Node(key, value);
                                curNode.Right.Parent = curNode;
                                Size++;
                                return;
                            }

                            break;
                        case 0:
                            curNode.Value = value;
                            return;
                    }
                }
            }
        }

        public T Find(int key)
        {
            var node = FindNode(key, _root);
            if (node == null)
                return default;
            return node.Value;
        }

        public void Remove(int key)
        {
            RemoveNode(_root, key);
        }

        public override string ToString()
        {
            return GetNodeStringKeyValue(_root);
        }

        private string GetNodeStringKeyValue(Node root)
        {
            if (root == null)
            {
                return "";
            }

            string cur = "(" + root.Key + ", " + root.Value + ")";
            return GetNodeStringKeyValue(root.Left) + cur + GetNodeStringKeyValue(root.Right);
        }

        private void RemoveNode(Node root, int key)
        {
            var node = FindNode(key, root);
            if (node == null) throw new KeyNotFoundException();

            if (node.Left != null && node.Right != null)
            {
                Node minInRightSubTree = node.Right;
                while (minInRightSubTree.Left != null)
                {
                    minInRightSubTree = minInRightSubTree.Left;
                }

                node.Value = minInRightSubTree.Value;
                node.Key = minInRightSubTree.Key;
                RemoveNode(node.Right, minInRightSubTree.Key);
            }
            else if (node.Right != null)
            {
                node.Key = node.Right.Key;
                node.Value = node.Right.Value;
                node.Left = node.Right.Left;
                node.Right = node.Right.Right;
                Size--;
            }
            else if (node.Left != null)
            {
                node.Key = node.Left.Key;
                node.Value = node.Left.Value;
                node.Left = node.Left.Left;
                node.Right = node.Left.Right;
                Size--;
            }
            else
            {
                var parent = node.Parent;
                if (parent == null) _root = null;
                else
                {
                    if (parent.Left == node) parent.Left = null;
                    else parent.Right = null;
                }

                Size--;
            }
        }

        private Node FindNode(int key, Node root)
        {
            var curNode = root;
            while (curNode != null)
            {
                switch (curNode.Key - key)
                {
                    case 0:
                        return curNode;
                    case > 0:
                        curNode = curNode.Left;
                        break;
                    case < 0:
                        curNode = curNode.Right;
                        break;
                }
            }

            return null;
        }

        private class Node
        {
            public Node Left, Right, Parent;
            public int Key;
            public T Value;

            public Node(int key, T value)
            {
                this.Key = key;
                this.Value = value;
            }
        }
    }
}
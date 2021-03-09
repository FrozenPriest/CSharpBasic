using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpBasic
{
    /**
     * Реализовать связный список: создание, удаление, добавление произвольных элементов, реверс списка - без использования стандартных коллекций/LINQ (только IEnumerable)
     */
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node _head;

        public int Size { get; private set; }


        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        public void Reverse()
        {
            var curNode = _head;
            Node prevNode = null;

            while (curNode != null)
            {
                var nextNode = curNode.Next;
                curNode.Next = prevNode;
                prevNode = curNode;
                curNode = nextNode;
            }

            _head = prevNode;
        }

        public void Remove(int key)
        {
            if (key > Size || key < 0) throw new IndexOutOfRangeException();
            if (key == 0)
            {
                _head = _head.Next;
            }
            else
            {
                var prevNode = GetNode(key - 1);
                prevNode.Next = prevNode.Next.Next;
            }

            Size--;
        }

        public void SetValue(int key, T value)
        {
            if (key > Size || key < 0) throw new IndexOutOfRangeException();
            if (key == Size) InsertAfter(key, value);
            else
            {
                GetNode(key).Data = value;
            }
        }

        public void InsertFirst(T value)
        {
            InsertBefore(0, value);
        }

        public void InsertLast(T value)
        {
            InsertAfter(Size - 1, value);
        }

        public void InsertAfter(int key, T value)
        {
            if (key >= Size || key < -1) throw new IndexOutOfRangeException();

            if (key == -1)
            {
                var node = new Node(value);
                node.Next = _head;
                _head = node;
            }
            else
            {
                var lastNode = GetNode(key);
                lastNode.Next = new Node(value);
            }

            Size++;
        }

        public void InsertBefore(int key, T value)
        {
            var node = new Node(value);
            if (key == 0)
            {
                node.Next = _head;
                _head = node;
                Size++;
            }
            else
            {
                InsertAfter(key - 1, value);
            }
        }

        public T GetValue(int key)
        {
            if (key >= Size || key < 0) throw new IndexOutOfRangeException();
            return GetNode(key).Data;
        }

        private Node GetNode(int key)
        {
            var cur = _head;
            for (var i = 0; i < key; i++)
            {
                cur = cur.Next;
            }

            return cur;
        }

        private class Node
        {
            public Node Next;
            public T Data;

            public Node(T data)
            {
                this.Data = data;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var cur = _head; cur != null; cur = cur.Next)
            {
                yield return cur.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
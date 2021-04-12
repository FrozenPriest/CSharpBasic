using System;
using System.Collections.Generic;

namespace CSharpBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var n = int.Parse(input);

            //задача на кучу
            HeapZone(n);
            //Только проверка на вхождение элемента
            //TreapZone(n);
            // ClassicTreeZone(n);
            // TreeZone(n);
        }

        static void HeapZone(int n)
        {
            Heap heap = new Heap(1000000);
            string ans = "";
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if (input == "GET")
                {
                    ans += heap.Pop() + "\n";
                }
                else
                {
                    var cur = int.Parse(input);
                    heap.Add(cur);
                }
            }
            Console.WriteLine(ans);
        }

        static void TreapZone(int n)
        {
            Treap tree = new Treap();
            string ans = "";
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var cur = int.Parse(input);
                bool has = tree.Contains(cur);
                if (!has)
                {
                    tree.Insert(cur);
                }

                ans += has ? "+\n" : "-\n";
            }

            Console.WriteLine(ans);
        }

        static void ClassicTreeZone(int n)
        {
            SortedDictionary<int, int> systemBinaryTree = new SortedDictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var cur = int.Parse(input);
                bool has = systemBinaryTree.ContainsKey(cur);
                if (!has)
                {
                    systemBinaryTree.Add(cur, cur);
                }

                Console.WriteLine(has ? "+" : "-");
            }
        }

        static void TreeZone(int n)
        {
            BinaryTree<int?> tree = new BinaryTree<int?>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var cur = int.Parse(input);
                bool has = tree.Find(cur) != null;
                if (!has)
                {
                    tree.Insert(cur, cur);
                }

                Console.WriteLine(has ? "+" : "-");
            }
        }
    }
}
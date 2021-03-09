using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpBasic
{
    /*
     * Реализовать бинарное дерево: заполнение, поиск, удаление элемента - без использования стандартных деревьев
     */
    public class BinaryTree<T>: IEnumerable
    {
        
        
        
        public IEnumerator<T> GetEnumerator()
        {
            // for (var cur = _head; cur != null; cur = cur.Next)
            // {
            //     yield return cur.Data;
            // }
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
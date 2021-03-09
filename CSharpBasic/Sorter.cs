using System;

namespace CSharpBasic
{
    /*
     * Реализовать сортировку вставками - без .OrderBy() :)
     */
    public class Sorter
    {
        public static int[] InsertionSort(int[] array, Comparison<int> comparator)
        {
            
            var result = new int[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && comparator.Invoke(result[j - 1],array[i]) > 0)
                {
                    result[j] = result[j - 1];
                    j--;
                }
                result[j] = array[i];
            }
            return result;
        }
    }
}
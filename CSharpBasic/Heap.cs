using System.Collections;

namespace CSharpBasic
{
    public class Heap : IEnumerable
    {
        private int _count;
        private int[] items;

        public int Count => _count;

        public Heap(int n)
        {
            items = new int[n];
        }

        public IEnumerator GetEnumerator()
        {
            while (_count > 0)
            {
                yield return Pop();
            }
        }

        public int? Peek()
        {
            if (_count > 0)
            {
                return items[0];
            }

            return null;
        }

        public void Add(int item)
        {
            items[_count++] = item;

            var currentIndex = _count - 1;
            var parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && items[parentIndex] < items[currentIndex])
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public int Pop()
        {
            var result = items[0];
            items[0] = items[_count - 1];
            Sort(0);
            _count--;
            return result;
        }

        private int GetParentIndex(int current)
        {
            return (current - 1) / 2;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        private void Sort(int index)
        {
            var maxIndex = index;

            while (index < _count)
            {
                var leftIndex = 2 * index + 1;
                var rightIndex = 2 * index + 2;

                if (leftIndex < _count && items[leftIndex] > items[maxIndex])
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < _count && items[rightIndex] > items[maxIndex])
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == index)
                {
                    break;
                }

                Swap(index, maxIndex);
                index = maxIndex;
            }
        }
    }
}
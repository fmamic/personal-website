using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfPpijProgrami.WpfService
{
    public class ParallelMergeSort<T>
    {
        private int _taskCount;
        private int _elementCountPerTask;
        private int _comparisonCount;
        protected IComparer<T> _comparer;

        public void Sort(T[] list)
        {
            Sort(list, Comparer<T>.Default);
        }

        public void Sort(T[] list, Comparison<T> comparison)
        {
            Sort(list, new ComparerFromComparison<T>(comparison));
        }
        public void Sort(T[] list, IComparer<T> comparer)
        {
            _comparisonCount = 0;
            _comparer = comparer;
            _taskCount = Environment.ProcessorCount;
            _elementCountPerTask = (list.Length - 1) / _taskCount + 1;

            var tempList = new T[list.Length];

            if (_taskCount > 1)
            {
                Task[] tasks = new Task[_taskCount];
                for (int taskIndex = 0; taskIndex < _taskCount; taskIndex++)
                {
                    int bottom = taskIndex * _elementCountPerTask;
                    int top = Math.Min(list.Length - 1, bottom + _elementCountPerTask - 1);

                    tasks[taskIndex] = Task.Factory.StartNew(
                      delegate()
                      {
                          SortPartOfList(list, tempList, bottom, top, 1);
                      });
                }
                Task.WaitAll(tasks);

                SortPartOfList(list, tempList, 0, list.Length - 1, _elementCountPerTask);
            }
            else
            {
                SortPartOfList(list, tempList, 0, list.Length - 1, 1);
            }
        }

        private void SortPartOfList(
          T[] list, T[] tempList, int bottom, int top, int blockSize)
        {
            while (blockSize < (top - bottom + 1))
            {
                MergeToTarget(tempList, list, bottom, top, blockSize);
                blockSize = blockSize * 2;

                if (blockSize < (top - bottom + 1))
                    MergeToTarget(list, tempList, bottom, top, blockSize);
                else
                    Array.Copy(tempList, bottom, list, bottom, top - bottom + 1);
                blockSize = blockSize * 2;
            }
        }

        private void MergeToTarget(
          T[] targetList, T[] sourceList, int bottom, int top, int blockSize)
        {
            int beginBlock1 = bottom;
            int beginBlock2 = Math.Min(bottom + blockSize, top);
            for (int i = 1; i <= ((top - bottom + 1) / (blockSize * 2)) + 1; i++)
            {
                int endBlock2 = Math.Min(beginBlock2 + blockSize - 1, top);
                MergeTwoBlocks(targetList, sourceList, beginBlock1, beginBlock2 - 1, beginBlock2, endBlock2);
                beginBlock1 = endBlock2 + 1;
                beginBlock2 = Math.Min(beginBlock1 + blockSize, top);
            }
        }

        private void MergeTwoBlocks(
          T[] targetList, T[] sourceList, int beginBlock1, int endBlock1, int beginBlock2, int endBlock2)
        {
            int targetIndex = beginBlock1;
            for (; targetIndex <= endBlock2; targetIndex++)
            {
                if (beginBlock1 > endBlock1)
                    targetList[targetIndex] = sourceList[beginBlock2++];
                else if (beginBlock2 > endBlock2)
                    targetList[targetIndex] = sourceList[beginBlock1++];
                else
                {
                    _comparisonCount++;
                    if (_comparer.Compare(sourceList[beginBlock1], sourceList[beginBlock2]) <= 0)
                        targetList[targetIndex] = sourceList[beginBlock1++];
                    else
                        targetList[targetIndex] = sourceList[beginBlock2++];
                }
            }
        }

        private class ComparerFromComparison<TU> : IComparer<TU>
        {
            private readonly Comparison<TU> _comparison;

            public ComparerFromComparison(Comparison<TU> comparison)
            {
                _comparison = comparison;
            }

            public int Compare(TU x, TU y)
            {
                return _comparison(x, y);
            }
        }
    }
}


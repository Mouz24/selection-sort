using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace SelectionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{array}");
            }

            for (int tmp_min_index = 0; tmp_min_index < array.Length; tmp_min_index++)
            {
                for (int k = tmp_min_index + 1; k < array.Length; k++)
                {
                    if (array[k] < array[tmp_min_index])
                    {
                        int min_value = array[k];
                        array[k] = array[tmp_min_index];
                        array[tmp_min_index] = min_value;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[] array)
        {
            SelectionSort1(array, 0);
        }

        public static int FindMin(int[] array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{array}");
            }

            int min = index - 1;
            if (index < array.Length - 1)
            {
                min = FindMin(array, index + 1);
            }

            if (array[index] < array[min])
            {
                min = index;
            }

            return min;
        }

        public static void SelectionSort1(int[] array, int left)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{array}");
            }

            if (left < array.Length - 1)
            {
                Swap(array, left, FindMin(array, left));
                SelectionSort1(array, left + 1);
            }
        }

        public static void Swap(int[] array, int index1, int index2)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{array}");
            }

            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapSortingAlgorithms;

namespace HeapSortingAlgorithms
{
    public static class HeapSort
    {

        public static void Sorting(int[] input)
        {
            int inputLength = input.Length;
            int count = 0;
            Console.WriteLine($"\n ------------------------ Part 1 - Building the heap (rearranging the array) ------------------------");

            // Построение кучи (перегруппируем массив)
            for (int i = (inputLength / 2 - 1); i >= 0; i--)
            {
                count = Heapify(input, inputLength, i, count);
            }

            Console.WriteLine($"\n ++++++++++++++++++++++++ Part 2 - Fetch elements from the heap one by one ++++++++++++++++++++++++");

            // Один за другим извлекаем элементы из кучи
            for (int i = inputLength - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                Console.WriteLine($"\nMove the current root from [{0}] to the end - [{i}]");
                Console.WriteLine($"Start = {input[0]}, End = {input[i]}");
                (input[0], input[i]) = (input[i], input[0]);
                Console.WriteLine($"Start = {input[0]}, End = {input[i]}\n");

                count = Heapify(input, i, 0, count);
            }

            Console.WriteLine($"\n Sorting was finished, iterations count = {count}, input array length = {inputLength}, length * log(ltngth) = {inputLength * MathF.Log(inputLength)}");

        }

        // Метод для преобразования в двоичную кучу поддерева с корневым узлом i, что является индексом в input[] (inputLength - размер кучи)
        static int Heapify(int[] input, int inputLength, int i, int count)
        {
            count++;
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            Console.WriteLine($"input largest[{largest}] = {input[largest]}");
            AuxiliaryTools.PrintArrayWithRoot(input, largest);

            bool leftMoreRoot = left.IsOutOfIndexIn(inputLength) && input[left] > input[largest]; // left < inputLength 
            if (leftMoreRoot)
            {
                largest = left;
                Console.WriteLine($"input left[{left}] = {input[left]}");
                AuxiliaryTools.PrintArrayWithRoot(input, largest);
            }

            bool rightMoreLargest = right.IsOutOfIndexIn(inputLength) && input[right] > input[largest];
            if (rightMoreLargest)
            {
                largest = right;
                Console.WriteLine($"input right[{right}] = {input[right]}");
                AuxiliaryTools.PrintArrayWithRoot(input, largest);
            }

            if (largest != i)
            {
                (input[i], input[largest]) = (input[largest], input[i]);

                AuxiliaryTools.PrintArrayWithRoot(input, largest);
                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                count = Heapify(input, inputLength, largest, count);
            }
            return count;
        }
    }
}

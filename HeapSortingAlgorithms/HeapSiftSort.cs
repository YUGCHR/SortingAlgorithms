using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions.Library;


namespace HeapSortingAlgorithms
{
    public static class HeapSiftSoft
    {

        public static void HeapSort(int[] input)
        {
            int inputLength = input.Length;
            int count = 0;

            Console.WriteLine($"\n ------------------------ Part 1 - Building the heap (rearranging the array) ------------------------");

            // Формируем первоначальное сортирующее дерево
            // Для этого справа-налево перебираем элементы массива (у которых есть потомки) и делаем для каждого из них просейку            
            for (int start = (inputLength / 2 - 1); start >= 0; start--)
            {
                count = HeapSift(input, inputLength - 1, start, count);
            }

            Console.WriteLine($"\n ++++++++++++++++++++++++ Part 2 - Fetch elements from the heap one by one ++++++++++++++++++++++++");

            // Первый элемент массива всегда соответствует корню сортирующего дерева и поэтому является максимумом для неотсортированной части массива
            for (int end = inputLength - 1; end > 0; end--)
            {
                // Меняем этот максимум местами с последним элементом неотсортированной части массива
                //Console.WriteLine($"\nMove the current root from [{0}] to the end - [{end}]");
                //Console.WriteLine($"Start = {input[0]}, End = {input[end]}");
                (input[end], input[0]) = (input[0], input[end]);
                //Console.WriteLine($"Start = {input[0]}, End = {input[end]}\n");

                // После обмена в корне сортирующего дерева немаксимальный элемент, восстанавливаем сортирующее дерево
                // Просейка для неотсортированной части массива
                count = HeapSift(input, end - 1, 0, count);
            }

            Console.WriteLine($"\n Sorting was finished, iterations count = {count}, input array length = {inputLength}, length * log(length) = {inputLength * MathF.Log(inputLength)}");

        }

        // Просейка сверху вниз, в результате которой восстанавливается сортирующее дерево
        static int HeapSift(int[] input, int heap_size, int root_index, int count)
        {
            // Начало подмассива - узел, с которого начинаем просейку вниз
            int largest = root_index;

            // Цикл просейки продолжается до тех пор, пока встречаются потомки, большие чем их родитель

            // Левый потомок
            int left_child = 2 * root_index + 1;
            // Правый потомок
            int right_child = 2 * root_index + 2;

            // Если левый потомок корня — допустимый индекс, а элемент больше, чем текущий наибольший, обновляем наибольший элемент
            bool isLargest = left_child < heap_size && input[left_child] < input[largest];
            if (isLargest)
            {
                largest = left_child;
            }

            // То же самое для правого потомка корня
            isLargest = right_child < heap_size && input[right_child] < input[largest];
            if (isLargest)
            {
                largest = right_child;
            }

            // Если наибольший элемент больше не корневой, они меняются местами
            bool largestNotRoot = largest != root_index;
            if (largestNotRoot)
            {
                (input[root_index], input[largest]) = (input[largest], input[root_index]);

                count = HeapSift(input, heap_size, largest, count);

            }

            AuxiliaryTools.PrintArrayWithRoot(input, largest);
            count++;
            return count;
        }
    }
}

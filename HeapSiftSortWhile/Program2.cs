﻿using System;
using System.Linq;

namespace HeapSiftSortWhile
{
    class Program2
    {
        static void Main(string[] args)
        {
            //int[] input = new int[15] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4 };
            int[] input = new int[60] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4, 21, 35, 34, 33, 31, 30, 32, 25, 29, 22, 26, 23, 28, 27, 24, 41, 55, 54, 53, 51, 50, 52, 45, 49, 42, 46, 43, 48, 47, 44, 61, 75, 74, 73, 71, 70, 72, 65, 69, 62, 66, 63, 68, 67, 64 };

            //SiftingIsCarriedOut(input);
            SiftingIsCarriedOut.BasePrintArray(input);
            SiftingIsCarriedOut.HeapSort(input);
            //SiftingIsCarriedOut.BasePrintArray(input);
        }
    }


    public static class SiftingIsCarriedOut
    {

        public static void HeapSort(int[] input)
        {
            int inputLength = input.Length;
            int count = 0;
            int countTemp = 0;

            Console.WriteLine($"\n ------------------------ Part 1 - Building the heap (rearranging the array) ------------------------");

            // Формируем первоначальное сортирующее дерево
            // Для этого справа-налево перебираем элементы массива (у которых есть потомки) и делаем для каждого из них просейку            
            for (int start = (inputLength / 2 - 1); start > -1; start--)
            {
                countTemp = count;
                Console.WriteLine($"\nIterate over the element[{start}] = {input[start]}, count = {count}");
                count = HeapSift(input, start, inputLength - 1, count);
                Console.WriteLine($"\nAfter HeapSift the element[{start}] = {input[start]}, count = {count}");
                if(count == countTemp)
                {
                    count++;
                }
            }

            Console.WriteLine($"\n ++++++++++++++++++++++++ Part 2 - Fetch elements from the heap one by one ++++++++++++++++++++++++");

            // Первый элемент массива всегда соответствует корню сортирующего дерева и поэтому является максимумом для неотсортированной части массива
            for (int end = inputLength - 1; end > 0; end--)
            {
                // Меняем этот максимум местами с последним элементом неотсортированной части массива
                Console.WriteLine($"\nMove the current root from [{0}] to the end - [{end}]");
                Console.WriteLine($"Start[0] = {input[0]}, End[{end}] = {input[end]}");
                (input[end], input[0]) = (input[0], input[end]);
                PrintArrayWithRoot(input, end);
                Console.WriteLine($"Start[0] = {input[0]}, End[{end}] = {input[end]}\n");

                // После обмена в корне сортирующего дерева немаксимальный элемент, восстанавливаем сортирующее дерево
                // Просейка для неотсортированной части массива
                count = HeapSift(input, 0, end - 1, count);
            }

            Console.WriteLine($"\n Sorting was finished, iterations count = {count}, input array length = {inputLength}, length * log(length) = {inputLength * MathF.Log(inputLength)}\n");

        }

        // Просейка сверху вниз, в результате которой восстанавливается сортирующее дерево
        static int HeapSift(int[] input, int start, int end, int count)
        {
            // Начало подмассива - узел, с которого начинаем просейку вниз
            int root = start;

            // Цикл просейки продолжается до тех пор, пока встречаются потомки, большие чем их родитель
            while (true)
            {
                // Левый потомок
                int child = 2 * root + 1;

                // (Если левый потомок корня — допустимый индекс, а элемент больше, чем текущий наибольший, обновляем наибольший элемент)
                // Левый потомок за пределами подмассива - завершаем просейку
                //bool isLargest = left_child < heap_size && input[left_child] < input[largest];
                if (child > end)
                {
                    break;
                }

                // Если правый потомок тоже в пределах подмассива, то среди обоих потомков выбираем наибольший
                bool isLargest = child + 1 <= end && input[child] < input[child + 1];
                if (isLargest)
                {
                    child += 1;
                }

                // (Если наибольший элемент больше не корневой, они меняются местами)
                // Если больший потомок больше корня, то меняем местами, при этом больший потомок сам становится корнем, от которого дальше опускаемся вниз по дереву
                bool largestNotRoot = input[root] < input[child];
                if (largestNotRoot)
                {
                    (input[root], input[child]) = (input[child], input[root]);
                    root = child;
                    //count = HeapSift(input, heap_size, largest, count);

                }
                else
                {
                    break;
                }
                PrintArrayWithRoot(input, root);
                count++;
            }
            return count;
        }

        public static void PrintArrayWithRoot(int[] input, int root)
        {
            BasePrintArray(input, $" root = {root}");
        }

        public static void BasePrintArray(int[] input, string additions = "")
        {
            int inputLength = input.Length;

            string currentIsCurrent = String.Equals(additions, "") ? "" : $" / {additions}";

            string lengthName = String.Equals(additions, "") ? $"Length = {inputLength}, Array = " : "";
            string indexesName = String.Equals(additions, "") ? $"   Array indexes are " : "";

            Console.WriteLine($"{indexesName}[{Enumerable.Range(0, inputLength).ToArray().AddBlankIfOneDigitInNumberToString()}]");
            Console.Write($"{lengthName}[{input.AddBlankIfOneDigitInNumberToString()}]{currentIsCurrent}\n");
            //Console.Read();
        }

        static string AddBlankIfOneDigitInNumberToString(this int[] input, string separ = " ")
        {
            return String.Join(separ, input.Select(x => { return x < 10 ? $" {x}" : $"{x}"; }).ToArray());
        }

        static bool IsOutOfIndexIn(this int whoIs, int border)
        {
            return whoIs < border;
        }

    }
}

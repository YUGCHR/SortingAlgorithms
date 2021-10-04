using System;
using System.Linq;

namespace HeapSiftSort
{
    class Program1
    {
        static void Main(string[] args)
        {
            //int[] input = new int[15] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4 };
            int[] input = new int[60] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4, 21, 35, 34, 33, 31, 30, 32, 25, 29, 22, 26, 23, 28, 27, 24, 41, 55, 54, 53, 51, 50, 52, 45, 49, 42, 46, 43, 48, 47, 44, 61, 75, 74, 73, 71, 70, 72, 65, 69, 62, 66, 63, 68, 67, 64 };

            //SiftingIsCarriedOut(input);
            SiftingIsCarriedOut.BasePrintArray(input);
            SiftingIsCarriedOut.HeapSort(input);
            SiftingIsCarriedOut.BasePrintArray(input);
        }
    }


    public static class SiftingIsCarriedOut
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

        // Просейка свеху вниз, в результате которой восстанавливается сортирующее дерево
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

            PrintArrayWithRoot(input, largest);
            count++;
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

            //Console.WriteLine($"{indexesName}[{Enumerable.Range(0, inputLength).ToArray().AddBlankIfOneDigitInNumberToString()}]");
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

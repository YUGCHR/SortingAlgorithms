using System;
using System.Linq;

namespace TreeViewSort
{
    class Program0
    {
        static void Main(string[] args)
        {
            int[] input = new int[60] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4, 21, 35, 34, 33, 31, 30, 32, 25, 29, 22, 26, 23, 28, 27, 24, 41, 55, 54, 53, 51, 50, 52, 45, 49, 42, 46, 43, 48, 47, 44, 61, 75, 74, 73, 71, 70, 72, 65, 69, 62, 66, 63, 68, 67, 64 };

            //SiftingIsCarriedOut(input);
            HeapSort.BasePrintArray(input);
            HeapSort.Sorting(input);
            //HeapSort.BasePrintArray(input);
        }
    }


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

            Console.WriteLine($"\n Sorting was finished, iterations count = {count}, input array length = {inputLength}, length * log(ltngth) = {inputLength*MathF.Log(inputLength)}");

        }

        // Метод для преобразования в двоичную кучу поддерева с корневым узлом i, что является индексом в input[] (inputLength - размер кучи)
        static int Heapify(int[] input, int inputLength, int i, int count)
        {
            count++;
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            Console.WriteLine($"input largest[{largest}] = {input[largest]}");
            HeapSort.PrintArrayWithRoot(input, largest);

            bool leftMoreRoot = left.IsOutOfIndexIn(inputLength) && input[left] > input[largest]; // left < inputLength 
            if (leftMoreRoot)
            {
                largest = left;
                Console.WriteLine($"input left[{left}] = {input[left]}");
                HeapSort.PrintArrayWithRoot(input, largest);
            }

            bool rightMoreLargest = right.IsOutOfIndexIn(inputLength) && input[right] > input[largest];
            if (rightMoreLargest)
            {
                largest = right;
                Console.WriteLine($"input right[{right}] = {input[right]}");
                HeapSort.PrintArrayWithRoot(input, largest);
            }

            if (largest != i)
            {
                (input[i], input[largest]) = (input[largest], input[i]);

                HeapSort.PrintArrayWithRoot(input, largest);
                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                count = Heapify(input, inputLength, largest, count);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions.Library;


namespace HeapSortingAlgorithms
{
    public static class HeapSiftSortBottomUp
    {

        public static void HeapSortBottomUp(int[] input)
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
                count = HeapSortBottomUp_Sift(input, start, inputLength - 1, count);
                Console.WriteLine($"\nAfter HeapSift the element[{start}] = {input[start]}, count = {count}");
                if (count == countTemp)
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
                AuxiliaryTools.PrintArrayWithRoot(input, end);
                Console.WriteLine($"Start[0] = {input[0]}, End[{end}] = {input[end]}\n");

                // После обмена в корне сортирующего дерева немаксимальный элемент, восстанавливаем сортирующее дерево
                // Просейка для неотсортированной части массива
                count = HeapSortBottomUp_Sift(input, 0, end - 1, count);
            }

            Console.WriteLine($"\n Sorting was finished, iterations count = {count}, input array length = {inputLength}, length * log(length) = {inputLength * MathF.Log(inputLength)}\n");

        }

        // Просейка, сначала идущая вниз, затем выныривающая наверх
        // Восходящая просейка
        static int HeapSortBottomUp_Sift(int[] input, int start, int end, int count)
        {
            int current;
            // По бОльшим потомкам спускаемся до самого нижнего уровня
            (current, count) = HeapSortBottomUp_LeafSearch(input, start, end, count);

            // Поднимаемся вверх, пока не встретим узел больший или равный корню поддерева
            while (input[start] > input[current])
            {
                current = (current - 1) / 2;

                AuxiliaryTools.PrintArrayWithRoot(input, current);
                count++;
            }

            // Найденный узел запоминаем и в этот узел кладём корень поддерева

            int temp = input[current];
            input[current] = input[start];

            // всё что выше по ветке вплоть до корня - сдвигаем на один уровень вверх
            while (current > start)
            {
                current = (current - 1) / 2;

                (temp, input[current]) = (input[current], temp);

                AuxiliaryTools.PrintArrayWithRoot(input, current);
                count++;
            }

            return count;
        }

        // Спуск вниз до самого нижнего листа - выбираем бОльших потомков
        static (int, int) HeapSortBottomUp_LeafSearch(int[] input, int start, int end, int count)
        {
            int child;
            int current = start;

            // Спускаемся вниз, определяя какой потомок (левый или правый) больше
            while (true)
            {
                // Левый потомок
                child = current * 2 + 1;

                // Прерываем цикл, если правый вне массива                
                if (child + 1 > end)
                {
                    count++;
                    break;
                }

                // Идём туда, где потомок больше
                bool isLarger = input[child + 1] > input[child];
                if (isLarger)
                {
                    count++;
                    current = child + 1;
                }
                else
                {
                    count++;
                    current = child;
                }

                AuxiliaryTools.PrintArrayWithRoot(input, current);
            }

            // Возможна ситуация, если левый потомок единственный
            // Левый потомок
            child = current * 2 + 1;

            if (child <= end)
            {
                current = child;
                AuxiliaryTools.PrintArrayWithRoot(input, current);
                count++;
            }

            return (current, count);
        }
    }
}

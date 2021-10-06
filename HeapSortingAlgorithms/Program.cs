using System;
using System.Linq;

namespace HeapSortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] input = new int[15] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4 };
            int[] input = new int[60] { 1, 15, 14, 13, 11, 10, 12, 5, 9, 2, 6, 3, 8, 7, 4, 21, 35, 34, 33, 31, 30, 32, 25, 29, 22, 26, 23, 28, 27, 24, 41, 55, 54, 53, 51, 50, 52, 45, 49, 42, 46, 43, 48, 47, 44, 61, 75, 74, 73, 71, 70, 72, 65, 69, 62, 66, 63, 68, 67, 64 };

            //SiftingIsCarriedOut(input);
            AuxiliaryTools.BasePrintArray(input);
            HeapSiftSortBottomUp.HeapSortBottomUp(input);
            //AuxiliaryTools.BasePrintArray(input);

            AuxiliaryTools.BasePrintArray(input);
            HeapSort.Sorting(input);

            AuxiliaryTools.BasePrintArray(input);
            HeapSiftSoft.HeapSort(input);

            AuxiliaryTools.BasePrintArray(input);
            HeapSiftSortWhile.HeapSort(input);



        }
    }


    
}

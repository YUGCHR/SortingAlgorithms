using System;
using System.Linq;

namespace Extensions.Library
{
    public static class AuxiliaryTools
    {
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

        public static string AddBlankIfOneDigitInNumberToString(this int[] input, string separ = " ")
        {
            return String.Join(separ, input.Select(x => { return x < 10 ? $" {x}" : $"{x}"; }).ToArray());
        }

        public static bool IsOutOfIndexIn(this int whoIs, int border)
        {
            return whoIs < border;
        }
    }
}

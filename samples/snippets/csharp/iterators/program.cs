using System;
using System.Collections.Generic;

namespace Iterators
{
    public class Program
    {
        public static void Main()
        {
            ForeachExamples.ExampleOne();

            foreach (var item in IteratorMethods.GetSingleDigitNumbers())
                Console.WriteLine(item);

            foreach (var item in IteratorMethods.GetSingleDigitNumbersV2())
                Console.WriteLine(item);

            foreach (var item in IteratorMethods.GetSingleDigitNumbersAndNumbersOver100())
                Console.WriteLine(item);
        }
    }
}

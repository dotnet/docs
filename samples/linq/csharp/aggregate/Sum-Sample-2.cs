using System;
using System.Linq;

namespace Aggregate
{
    public static class SumSample2
    {
        //This sample uses Sum to get the total number of characters of all words in the array.
        // 
        // Output: 
        // There are a total of 20 characters in these words.
        public static void Example()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine($"There are a total of {totalChars} characters in these words.");
        }
    }
}
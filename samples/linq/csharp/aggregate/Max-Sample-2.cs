using System;
using System.Linq;

namespace Aggregate
{
    public static class MaxSample2
    {

        //This sample uses Max to get the length of the longest word in an array.
        //
        //Output:
        // The longest word is 9 characters long.
        public static void Example()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            int longestLength = words.Max(w => w.Length);

            Console.WriteLine($"The longest word is {longestLength} characters long.");
        }
    }
}
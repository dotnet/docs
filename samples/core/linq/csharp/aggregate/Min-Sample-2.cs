using System;
using System.Linq;

namespace Aggregate
{
    public static class MinSample2
    {
        //This sample uses Min to get the length of the shortest word in an array.
        // 
        //Output: 
        // The shortest word is 5 characters long.
        public static void Example()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int shortestWord = words.Min(w => w.Length);

            Console.WriteLine($"The shortest word is {shortestWord} characters long.");
        }
    }
}
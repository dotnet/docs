using System;
using System.Linq;

namespace Element
{
    public static class FirstSample2
    {
        //This sample uses First to find the first element in the array that starts with 'o'.
        //
        //Output: 
        // A string starting with 'o': one
        public static void Example()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string startsWithO = strings.First(s => s[0] == 'o');

            Console.WriteLine("A string starting with 'o': {0}", startsWithO);
        }
    }
}
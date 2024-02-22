using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class SplitStringOnChar
    {
        public static void Run()
        {
            // <SnippetExample>
            string inputString = "🐂, 🐄, 🐆";
            string[] splitOnSpace = inputString.Split(' ');
            string[] splitOnComma = inputString.Split(',');
            // </SnippetExample>

            Console.WriteLine($"Splitting string {inputString} on space");
            Array.ForEach(splitOnSpace, s => Console.WriteLine(s));

            Console.WriteLine($"Splitting string {inputString} on comma");
            Array.ForEach(splitOnComma, s => Console.WriteLine(s));
        }
    }
}

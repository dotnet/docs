using System;
using System.Linq;

namespace Conversion
{
    public static class ToListSample1
    {
        //This sample uses ToList and query syntax to immediately evaluate a sequence into a List<T>.
        //
        //Output:
        // The sorted word list:
        // apple
        // blueberry
        // cherry
        public static void QuerySyntaxExample()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w
                select w;
            var wordList = sortedWords.ToList();

            Console.WriteLine("The sorted word list:");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
        }

        //This sample uses ToList and method syntax to immediately evaluate a sequence into a List<T>.
        //
        //Output:
        // The sorted word list:
        // apple
        // blueberry
        // cherry
        public static void MethodSyntaxExample()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                words.OrderBy(w => w);
            var wordList = sortedWords.ToList();

            Console.WriteLine("The sorted word list:");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
        }
    }
}
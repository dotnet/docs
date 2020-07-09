using System;
using System.Linq;

namespace HowToStrings
{
    public static class ParseStringsUsingSplit
    {
        public static void Examples()
        {
            Console.WriteLine("Example one");
            Console.WriteLine();
            SplitWords();

            Console.WriteLine("Example two");
            Console.WriteLine();
            SplitWordsWithRepeatedSeparators();

            Console.WriteLine("Example three");
            Console.WriteLine();
            SplitOnMultipleChars();

            Console.WriteLine("Example four");
            Console.WriteLine();
            SplitOnMultipleCharsWithGaps();

            Console.WriteLine("Example five");
            Console.WriteLine();
            SplitUsingStrings();
        }

        private static void SplitWords()
        {
            // <Snippet1>
            string phrase = "The quick brown fox jumps over the lazy dog.";
            string[] words = phrase.Split(' ');

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            // </Snippet1>
        }

        private static void SplitWordsWithRepeatedSeparators()
        {
            // <Snippet2>
            string phrase = "The quick brown    fox     jumps over the lazy dog.";
            string[] words = phrase.Split(' ');

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            // </Snippet2>
        }

        private static void SplitOnMultipleChars()
        {
            // <Snippet3>
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string text = "one\ttwo three:four,five six seven";
            System.Console.WriteLine($"Original text: '{text}'");

            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            // </Snippet3>
        }

        private static void SplitOnMultipleCharsWithGaps()
        {
            // <Snippet4>
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string text = "one\ttwo :,five six seven";
            System.Console.WriteLine($"Original text: '{text}'");

            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            // </Snippet4>
        }

        private static void SplitUsingStrings()
        {
            // <Snippet5>
            string[] separatingStrings = { "<<", "..." };

            string text = "one<<two......three<four";
            System.Console.WriteLine($"Original text: '{text}'");

            string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine($"{words.Length} substrings in text:");

            foreach (var word in words)
            {
                System.Console.WriteLine(word);
            }
            // </Snippet5>
        }
    }
}

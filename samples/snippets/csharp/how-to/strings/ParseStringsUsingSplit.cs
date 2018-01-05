using System;

namespace HowToStrings
{
    public static class ParseStringsUsingSplit
    {
        public static void Examples()
        {
            SplitWords();
        }

        private static void SplitWords()
        {
            /// <Snippet1>
            string phrase = "The quick brown fox jumped over the lazy dog.";
            string[] words = phrase.Split(' ');

            foreach(var word in words)
                Console.WriteLine(word);
            /// </Snippet1>
        }
    }
}
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RuneSamples
{
    public static class InsertNewlines
    {
        public static void Run()
        {
            // <SnippetFullExample>
            Console.WriteLine("Original string:");
            string testString = "Here's a 🦊. And a 🐕.";
            PrintChars(testString);

            string wellFormed = InsertNewlinesEveryTenTextElements(testString);
            Console.WriteLine("Well-formed string after split:");
            PrintChars(wellFormed);

            Console.WriteLine("Not well-formed string after split:");
            string notWellFormed = InsertNewlinesEveryTencharsBadExample(testString);
            PrintChars(notWellFormed);

            // <SnippetGoodExample>
            static string InsertNewlinesEveryTenTextElements(string input)
            {
                StringBuilder builder = new StringBuilder();

                // Append chunks in multiples of 10 chars

                TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(input);

                int textElementCount = 1;
                while (enumerator.MoveNext())
                {
                    builder.Append(enumerator.Current);
                    if (textElementCount % 10 == 0 && textElementCount > 0)
                    {
                        builder.AppendLine(); // newline
                    }
                    textElementCount++;
                }

                // Add a final newline.
                builder.AppendLine(); // newline
                return builder.ToString();

            }
            // </SnippetGoodExample>

            // <SnippetBadExample>
            // THE FOLLOWING METHOD SHOWS INCORRECT CODE.
            // DO NOT DO THIS IN A PRODUCTION APPLICATION.
            static string InsertNewlinesEveryTencharsBadExample(string input)
            {
                StringBuilder builder = new StringBuilder();

                // First, append chunks in multiples of 10 chars
                // followed by a newline.
                int i = 0;
                for (; i < input.Length - 10; i += 10)
                {
                    builder.Append(input, i, 10);
                    builder.AppendLine(); // newline
                }

                // Then append any leftover data followed by
                // a final newline.
                builder.Append(input, i, input.Length - i);
                builder.AppendLine(); // newline

                return builder.ToString();
            }
            // </SnippetBadExample>
            static void PrintChars(string s)
            {
                Console.WriteLine($"\"{s}\"\nLength = {s.Length}");
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine((int)s[i] switch
                    {
                        10 => "LF",
                        13 => "CR",
                        _ => $"s[{i}] = '{s[i]}' ('\\u{(int)s[i]:x4}')"
                    });
                }
                Console.WriteLine();
            }
            // </SnippetFullExample>
        }
    }
}

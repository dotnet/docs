using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class ConvertToUpper
    {
        public static void Run()
        {

            // <SnippetConvertToUpper>
            string testString = "abc𐑉";
            Console.WriteLine($"String to be converted to uppercase: {testString}");
            PrintChars(testString);

            string testStringUppercase = ConvertToUpper(testString);
            Console.WriteLine($"String converted to uppercase using correct code: {testStringUppercase}");
            PrintChars(testStringUppercase);

            testStringUppercase = ConvertToUpperBadExample(testString);
            Console.WriteLine($"String converted to uppercase using incorrect code: {testStringUppercase}");
            PrintChars(testStringUppercase);

            // <SnippetGoodExample>
            static string ConvertToUpper(string input)
            {
                StringBuilder builder = new StringBuilder(input.Length);
                foreach (Rune rune in input.EnumerateRunes())
                {
                    builder.Append(Rune.ToUpperInvariant(rune));
                }
                return builder.ToString();
            }
            // </SnippetGoodExample>

            // <SnippetBadExample>
            // THE FOLLOWING METHOD SHOWS INCORRECT CODE.
            // DO NOT DO THIS IN A PRODUCTION APPLICATION.
            static string ConvertToUpperBadExample(string input)
            {
                StringBuilder builder = new StringBuilder(input.Length);
                for (int i = 0; i < input.Length; i++) /* or 'foreach' */
                {
                    builder.Append(char.ToUpperInvariant(input[i]));
                }
                return builder.ToString();
            }
            // </SnippetBadExample>

            static void PrintChars(string s)
            {
                Console.WriteLine($"\"{s}\".Length = {s.Length}");
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine($"s[{i}] = '{s[i]}' ('\\u{(int)s[i]:x4}')");
                }
                Console.WriteLine();
            }
            // <SnippetConvertToUpper>
        }
    }
}

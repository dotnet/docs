using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RuneSamples
{
    public static class CountLettersInSpan
    {
        public static void Run()
        {
            Console.WriteLine($"Incorrect code: { CountLettersBadExample(new Span<char>("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟".ToCharArray()))} letters in 𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");
            Console.WriteLine($"  Correct code: { CountLetters(new Span<char>("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟".ToCharArray()))} letters in 𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");

            // <SnippetBadExample>
            // THE FOLLOWING METHOD SHOWS INCORRECT CODE.
            // DO NOT DO THIS IN A PRODUCTION APPLICATION.
            static int CountLettersBadExample(ReadOnlySpan<char> span)
            {
                int letterCount = 0;

                foreach (char ch in span)
                {
                    if (char.IsLetter(ch))
                    { letterCount++; }
                }

                return letterCount;
            }
            // </SnippetBadExample>

            // <SnippetGoodExample>
            static int CountLetters(ReadOnlySpan<char> span)
            {
                int letterCount = 0;

                foreach (Rune rune in span.EnumerateRunes())
                {
                    if (Rune.IsLetter(rune))
                    { letterCount++; }
                }

                return letterCount;
            }
            // </SnippetGoodExample>
        }
    }
}

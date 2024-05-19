using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class CountLettersInString
    {
        public static void Run()
        {
            Console.WriteLine($"Incorrect code: { CountLettersBadExample("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟")} letters in 𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");
            Console.WriteLine($"  Correct code: { CountLetters("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟")} letters in 𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");
            //Console.WriteLine($"String '𐓏𐓘𐓻𐓘𐓻𐓟𐒻𐓟' consists entirely of letters: { StringConsistsEntirelyOfLetters("𐓏𐓘𐓻𐓘𐓻𐓟𐒻𐓟")}");

            // <SnippetBadExample>
            // THE FOLLOWING METHOD SHOWS INCORRECT CODE.
            // DO NOT DO THIS IN A PRODUCTION APPLICATION.
            int CountLettersBadExample(string s)
            {
                int letterCount = 0;

                foreach (char ch in s)
                {
                    if (char.IsLetter(ch))
                    { letterCount++; }
                }

                return letterCount;
            }
            // </SnippetBadExample>

            // <SnippetGoodExample>
            int CountLetters(string s)
            {
                int letterCount = 0;

                foreach (Rune rune in s.EnumerateRunes())
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

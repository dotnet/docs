using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class WorkWithSurrogates
    {
        public static void Run()
        {
            ProcessStringUseChar("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");
            ProcessStringUseRune("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");

            // <SnippetUseChar>
            static void ProcessStringUseChar(string s)
            {
                Console.WriteLine("Using char");

                for (int i = 0; i < s.Length; i++)
                {
                    if (!char.IsSurrogate(s[i]))
                    {
                        Console.WriteLine($"Code point: {(int)(s[i])}");
                    }
                    else if (i + 1 < s.Length && char.IsSurrogatePair(s[i], s[i + 1]))
                    {
                        int codePoint = char.ConvertToUtf32(s[i], s[i + 1]);
                        Console.WriteLine($"Code point: {codePoint}");
                        i++; // so that when the loop iterates it's actually +2
                    }
                    else
                    {
                        throw new Exception("String was not well-formed UTF-16.");
                    }
                }
            }
            // </SnippetUseChar>

            // <SnippetUseRune>
            static void ProcessStringUseRune(string s)
            {
                Console.WriteLine("Using Rune");

                for (int i = 0; i < s.Length;)
                {
                    if (!Rune.TryGetRuneAt(s, i, out Rune rune))
                    {
                        throw new Exception("String was not well-formed UTF-16.");
                    }

                    Console.WriteLine($"Code point: {rune.Value}");
                    i += rune.Utf16SequenceLength; // increment the iterator by the number of chars in this Rune
                }
            }
            // </SnippetUseRune>

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class EncodeRune
    {
        public static void Run()
        {
            Console.WriteLine("Converting ox emoji to UTF-16 and UTF-8");
            Rune rune = Rune.GetRuneAt("🐂", 0);
            Console.WriteLine($"Rune value: {rune.Value}");

            // <SnippetUtf16CharArray>
            char[] chars = new char[rune.Utf16SequenceLength];
            int numCharsWritten = rune.EncodeToUtf16(chars);
            // </SnippetUtf16CharArray>

            Console.WriteLine($"Number of chars: {numCharsWritten}");

            // <SnippetUtf16String>
            string theString = rune.ToString();
            // </SnippetUtf16String>

            // <SnippetUtf8ByteArray>
            byte[] bytes = new byte[rune.Utf8SequenceLength];
            int numBytesWritten = rune.EncodeToUtf8(bytes);
            // </SnippetUtf8ByteArray>

            Console.WriteLine($"Number of UTF-8 bytes: {numBytesWritten}");
        }
    }
}

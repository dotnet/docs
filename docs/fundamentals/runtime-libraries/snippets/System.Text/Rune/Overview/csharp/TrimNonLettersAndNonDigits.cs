using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    class TrimNonLettersAndNonDigits
    {
        public static void Run()
        {
            char[] s = "!Hello!".ToCharArray();
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(s);
            Console.WriteLine(span.ToString());
            ReadOnlySpan<char> newSpan = TrimNonLettersAndNonDigits(span);
            Console.WriteLine(newSpan.ToString());

            // <SnippetExample>
            static ReadOnlySpan<char> TrimNonLettersAndNonDigits(ReadOnlySpan<char> span)
            {
                // First, trim from the front.
                // If any Rune can't be decoded
                // (return value is anything other than "Done"),
                // or if the Rune is a letter or digit,
                // stop trimming from the front and
                // instead work from the end.
                while (Rune.DecodeFromUtf16(span, out Rune rune, out int charsConsumed) == OperationStatus.Done)
                {
                    if (Rune.IsLetterOrDigit(rune))
                    { break; }
                    span = span[charsConsumed..];
                }

                // Next, trim from the end.
                // If any Rune can't be decoded,
                // or if the Rune is a letter or digit,
                // break from the loop, and we're finished.
                while (Rune.DecodeLastFromUtf16(span, out Rune rune, out int charsConsumed) == OperationStatus.Done)
                {
                    if (Rune.IsLetterOrDigit(rune))
                    { break; }
                    span = span[..^charsConsumed];
                }

                return span;
            }
            // </SnippetExample>
        }
    }
}

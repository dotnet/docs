using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public class InstantiateRunes
    {
        public static void Run()
        {
            // <SnippetCodePoint>
            Rune a = new Rune(0x0061); // LATIN SMALL LETTER A
            Rune b = new Rune(0x10421); // DESERET CAPITAL LETTER ER
            // </SnippetCodePoint>

            // <SnippetChar>
            Rune c = new Rune('a');
            // </SnippetChar>

            // <SnippetSurrogate>
            Rune d = new Rune('\ud83d', '\udd2e'); // U+1F52E CRYSTAL BALL
            // </SnippetSurrogate>

            Console.WriteLine($"Rune a: {a}");
            Console.WriteLine($"Rune b: {b}");
            Console.WriteLine($"Rune c: {c}");
            Console.WriteLine($"Rune d: {d}");
            Console.WriteLine($"Rune d code point: {d.Value}");

            // <SnippetValue>
            Rune rune = new Rune('\ud83d', '\udd2e'); // U+1F52E CRYSTAL BALL
            int codePoint = rune.Value; // = 128302 decimal (= 0x1F52E)
            // </SnippetValue>

        }
    }
}

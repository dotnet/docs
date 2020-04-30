using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public class InstantiateRunes
    {
        public static void Run()
        {
            // <SnippetValid>
            Rune a = new Rune('a');
            Rune b = new Rune(0x0061);
            Rune c = new Rune('\u0061');
            Rune d = new Rune(0x10421);
            Rune e = new Rune('\ud801', '\udc21');
            // </SnippetValid>

            Console.WriteLine($"Rune a: {a}");
            Console.WriteLine($"Rune b: {b}");
            Console.WriteLine($"Rune c: {c}");
            Console.WriteLine($"Rune d: {d}");
            Console.WriteLine($"Rune e: {e}");

            try
            {
                // <SnippetInvalidSurrogate>
                Rune f = new Rune('\ud801');
                // </SnippetInvalidSurrogate>
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rune f: Exception: {ex.Message}");
            }

            try
            {
                // <SnippetInvalidHigh>
                Rune g = new Rune(0x12345678);
                // </SnippetInvalidHigh>
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rune g: Exception: {ex.Message}");
            }
        }
    }
}

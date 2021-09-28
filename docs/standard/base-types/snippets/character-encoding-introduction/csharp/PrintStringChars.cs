using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class PrintStringChars
    {
        public static void Run()
        {
            // <SnippetPrintStringChars>
            PrintChars("Hello");
            PrintChars("你好");
            //PrintChars("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟");
            //PrintChars("🐂");

            // <SnippetPrintChars>
            void PrintChars(string s)
            {
                Console.WriteLine($"\"{s}\".Length = {s.Length}");
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine($"s[{i}] = '{s[i]}' ('\\u{(int)s[i]:x4}')");
                }
                Console.WriteLine();
            }
            // </SnippetPrintChars>
            // </SnippetPrintStringChars>
        }
    }
}

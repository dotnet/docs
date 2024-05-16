using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSamples
{
    public static class FindFirstLetter
    {
        public static void Run()
        {
            Console.WriteLine($"Index of first capital letter of Latin alphabet in \"𐓏𐓘𐓻𐓘𐓻𐓟F𐒻𐓟\": { GetIndexOfFirstAToZ("𐓏𐓘𐓻𐓘𐓻𐓟F𐒻𐓟")}");

            // <SnippetExample>
            int GetIndexOfFirstAToZ(string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    char thisChar = s[i];
                    if ('A' <= thisChar && thisChar <= 'Z')
                    {
                        return i; // found a match
                    }
                }

                return -1; // didn't find 'A' - 'Z' in the input string
            }
            // </SnippetExample>
        }
    }
}

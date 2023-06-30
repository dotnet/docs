using System;
using System.Buffers;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RuneSamples
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n----- Print string chars");
            PrintStringChars.Run();

            Console.WriteLine("\n----- Instantiate Runes");
            InstantiateRunes.Run();

            Console.WriteLine("\n----- Convert string to uppercase");
            ConvertToUpper.Run();

            Console.WriteLine("\n----- Count text elements");
            CountTextElements.Run();

            Console.WriteLine("\n----- Split string on character count");
            InsertNewlines.Run();

            //Console.WriteLine("\n----- Get value of a Rune");
            //GetValueOfRune.Run();

            //Console.WriteLine("\n----- Trim letters and nondigits");
            //TrimLettersAndNondigits.Run();

            //Console.WriteLine("\n----- Count letters in string");
            //CountLettersInString.Run();

            //Console.WriteLine("\n----- Count letters in span");
            //CountLettersInSpan.Run();

            //Console.WriteLine("\n----- Encode a Rune");
            //EncodeRune.Run();

            //Console.WriteLine("\n----- Valid uses of char");
            //UseChar.Run();

            //Console.WriteLine("\n----- Handle surrogates");
            //WorkWithSurrogates.Run();
        }
    }
}

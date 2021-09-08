using System;
using System.Threading.Tasks;

namespace UnsafeCodePointers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=================    Fixed Memory Examples ======================");
            FixedKeywordExamples.Examples();

            Console.WriteLine("=================    Conversion Examples   ======================");
            ClassConvert.Conversions();

            Console.WriteLine("===================   Function pointers   =======================");
            FunctionPointers.PointerExamples();
        }
    }
}

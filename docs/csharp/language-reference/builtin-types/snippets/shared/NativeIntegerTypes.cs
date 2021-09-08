using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace builtin_types
{
    public static class NativeIntegerTypes
    {
        public static void Examples()
        {
            nativeintegerminmax.Example.Main();
        }
    }

    namespace nativeintegerminmax
    {
        public static class Example
        {

            public unsafe static void Main()
            {
                // <MinMax>
                Console.WriteLine($"nint.MinValue = {nint.MinValue}");
                Console.WriteLine($"nint.MaxValue = {nint.MaxValue}");
                Console.WriteLine($"nuint.MinValue = {nuint.MinValue}");
                Console.WriteLine($"nuint.MaxValue = {nuint.MaxValue}");

                // output when run in a 64-bit process
                //nint.MinValue = -9223372036854775808
                //nint.MaxValue = 9223372036854775807
                //nuint.MinValue = 0
                //nuint.MaxValue = 18446744073709551615

                // output when run in a 32-bit process
                //nint.MinValue = -2147483648
                //nint.MaxValue = 2147483647
                //nuint.MinValue = 0
                //nuint.MaxValue = 4294967295
                // </MinMax>

                // <SizeOf>
                Console.WriteLine($"size of nint = {sizeof(nint)}");
                Console.WriteLine($"size of nuint = {sizeof(nuint)}");

                // output when run in a 64-bit process
                //size of nint = 8
                //size of nuint = 8

                // output when run in a 32-bit process
                //size of nint = 4
                //size of nuint = 4
                // </SizeOf>
            }
        }
    }
}

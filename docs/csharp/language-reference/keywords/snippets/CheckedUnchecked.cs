using System;

namespace keywords;

public static class CheckedAndUnchecked
{
    public static void Examples()
    {
        // <CheckedAndUnchecked>
        Console.WriteLine(int.MaxValue);           // 2147483647
        Console.WriteLine($"0x{int.MaxValue:X}");  // 0x7FFFFFFF
        
        Console.WriteLine(unchecked (int.MaxValue+1));          // -2147483648
        Console.WriteLine($"0x{unchecked (int.MaxValue+1):X}"); // 0x80000000
        Console.WriteLine(int.MinValue);                        // -2147483648
        Console.WriteLine($"0x{int.MinValue:X}");               // 0x80000000
        
        // Create overflow using compile-time constants:
        // CS0220: The operation overflows at compile time in checked mode
        // Console.WriteLine(checked (int.MaxValue+1));

        try {
            checked 
            {
                var number = 1 + int.MaxValue / 2;
                number += number;
            }
        } catch (OverflowException e)
        {
            Console.WriteLine("This operation overflows at runtime in checked mode.");
        }
        // </CheckedAndUnchecked>

   }
}
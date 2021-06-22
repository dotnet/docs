using System;
using System.Runtime.CompilerServices;

internal class SkipLocalsInitExample
{
    public static void Main()
    {
        ReadUninitializedMemory();
    }

    // <ReadUninitializedMemory>
    [SkipLocalsInit]
    static void ReadUninitializedMemory()
    {
        Span<int> numbers = stackalloc int[120];
        for (int i = 0; i < 120; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
    // output depends on initial contents of memory, for example:
    //0
    //0
    //0
    //168
    //0
    //-1271631451
    //32767
    //38
    //0
    //0
    //0
    //38
    // Remaining rows omitted for brevity.
    // </ReadUninitializedMemory>
}


// <Snippet1>
using System;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;


// Class to test for the ExplicitLayout property.
[StructLayout(LayoutKind.Explicit, Size=16, CharSet=CharSet.Ansi)]
public class MySystemTime
{
   [FieldOffset(0)]public ushort wYear;
   [FieldOffset(2)]public ushort wMonth;
   [FieldOffset(4)]public ushort wDayOfWeek;
   [FieldOffset(6)]public ushort wDay;
   [FieldOffset(8)]public ushort wHour;
   [FieldOffset(10)]public ushort wMinute;
   [FieldOffset(12)]public ushort wSecond;
   [FieldOffset(14)]public ushort wMilliseconds;
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of the type using the GetType method.
        Type  t = typeof(MySystemTime);
        // Get and display the IsExplicitLayout property.
        Console.WriteLine("\nIsExplicitLayout for MySystemTime is {0}.",
            t.IsExplicitLayout);
    }
}
// </Snippet1>
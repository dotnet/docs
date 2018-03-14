// <Snippet1>
using System;
using System.Reflection;

class Example
{
    public static String val = "test";
    
    public static void Main()
    {
        FieldInfo fld = typeof(Example).GetField("val");
        Console.WriteLine(fld.GetValue(null));
        val = "hi";
        Console.WriteLine(fld.GetValue(null));
    }
}
// The example displays the following output:
//     test
//     hi
// </Snippet1>
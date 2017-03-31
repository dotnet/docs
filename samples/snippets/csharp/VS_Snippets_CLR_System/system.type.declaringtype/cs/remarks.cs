using System;
using System.Collections.Generic;

class ProgStubClass
{
    public static void Main()
    {
// <Snippet1>
        Type t = typeof(List<string>).GetMethod("ConvertAll").GetGenericArguments()[0].DeclaringType;
// </Snippet1>
        Console.WriteLine("Declaring type: {0:s}", t.FullName);
    }
}
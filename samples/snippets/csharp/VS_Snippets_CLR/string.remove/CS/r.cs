//<snippet1>
// This example demonstrates the String.Remove() method.
using System;

class Sample 
{
    public static void Main() 
    {
    string s = "abc---def"; 
//
    Console.WriteLine("Index: 012345678");
    Console.WriteLine("1)     {0}", s);
    Console.WriteLine("2)     {0}", s.Remove(3)); 
    Console.WriteLine("3)     {0}", s.Remove(3, 3));
    }
}
/*
This example produces the following results:

Index: 012345678
1)     abc---def
2)     abc
3)     abcdef

*/
//</snippet1>
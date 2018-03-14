// This example demonstrates StringBuilder.Remove()
//<snippet1>
using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {
    string rule1 = "0----+----1----+----2----+----3----+----4---";
    string rule2 = "01234567890123456789012345678901234567890123";
    string str =   "The quick brown fox jumps over the lazy dog.";
    StringBuilder sb = new StringBuilder(str);

    Console.WriteLine();
    Console.WriteLine("StringBuilder.Remove method");
    Console.WriteLine();
    Console.WriteLine("Original value:");
    Console.WriteLine(rule1);
    Console.WriteLine(rule2);
    Console.WriteLine("{0}", sb.ToString());
    Console.WriteLine();

    sb.Remove(10, 6); // Remove "brown "

    Console.WriteLine("New value:");
    Console.WriteLine(rule1);
    Console.WriteLine(rule2);
    Console.WriteLine("{0}", sb.ToString());
    }
}
/*
This example produces the following results:

StringBuilder.Remove method

Original value:
0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick brown fox jumps over the lazy dog.

New value:
0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick fox jumps over the lazy dog.

*/
//</snippet1>
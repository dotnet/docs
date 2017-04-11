// This example demonstrates StringBuilder.Replace()
//<snippet1>
using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {
//                0----+----1----+----2----+----3----+----4---
//                01234567890123456789012345678901234567890123
    string str = "The quick br!wn d#g jumps #ver the lazy cat.";
    StringBuilder sb = new StringBuilder(str);

    Console.WriteLine();
    Console.WriteLine("StringBuilder.Replace method");
    Console.WriteLine();

    Console.WriteLine("Original value:");
    Show(sb);

    sb.Replace('#', '!', 15, 29);        // Some '#' -> '!'
    Show(sb);
    sb.Replace('!', 'o');                // All '!' -> 'o'
    Show(sb);
    sb.Replace("cat", "dog");            // All "cat" -> "dog"
    Show(sb);
    sb.Replace("dog", "fox", 15, 20);    // Some "dog" -> "fox"

    Console.WriteLine("Final value:");
    Show(sb);
    }

    public static void Show(StringBuilder sbs)
    {
    string rule1 = "0----+----1----+----2----+----3----+----4---";
    string rule2 = "01234567890123456789012345678901234567890123";

    Console.WriteLine(rule1);
    Console.WriteLine(rule2);
    Console.WriteLine("{0}", sbs.ToString());
    Console.WriteLine();
    }
}
/*
This example produces the following results:

StringBuilder.Replace method

Original value:
0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick br!wn d#g jumps #ver the lazy cat.

0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick br!wn d!g jumps !ver the lazy cat.

0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick brown dog jumps over the lazy cat.

0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick brown dog jumps over the lazy dog.

Final value:
0----+----1----+----2----+----3----+----4---
01234567890123456789012345678901234567890123
The quick brown fox jumps over the lazy dog.

*/
//</snippet1>
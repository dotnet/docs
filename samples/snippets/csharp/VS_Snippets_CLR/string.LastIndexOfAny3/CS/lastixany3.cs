//<snippet1>
// Sample for String.LastIndexOfAny(Char[], Int32, Int32)
using System;

class Sample {
    public static void Main() {

    string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
    string br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
    string str = "Now is the time for all good men to come to the aid of their party.";
    int start;
    int at;
    int count;
    string target = "aid";
    char[] anyOf = target.ToCharArray();

    start = ((str.Length-1)*2)/3;
    count = (str.Length-1)/3;
    Console.WriteLine("The last character occurrence from position {0} for {1} characters.", start, count);
    Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str);
    Console.Write("A character in '{0}' occurs at position: ", target);

    at = str.LastIndexOfAny(anyOf, start, count);
    if (at > -1) 
        Console.Write(at);
    else
        Console.Write("(not found)");
    Console.Write("{0}{0}{0}", Environment.NewLine);
    }
}
/*
This example produces the following results:
The last character occurrence from position 44 for 22 characters.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'aid' occurs at position: 27
*/
//</snippet1>
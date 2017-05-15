// <Snippet1>
using System;

public class Example 
{
    public static void Main() 
    {
        Random rnd = new Random();
        Byte[] b = new Byte[10];
        rnd.NextBytes(b);
        Console.WriteLine("The Random bytes are: ");
        for (int i = 0; i <= b.GetUpperBound(0); i++) 
            Console.WriteLine("{0}: {1}", i, b[i]);  
    }
}
// The example displays output similar to the following:
//       The Random bytes are:
//       0: 131
//       1: 96
//       2: 226
//       3: 213
//       4: 176
//       5: 208
//       6: 99
//       7: 89
//       8: 226
//       9: 194
// </Snippet1>

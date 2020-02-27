using System;

public class Example
{
    public static void Main()
    {
        // <Snippet2>
        var g = new Guid(0xA, 0xB, 0xC, 
                          new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7 } );
        Console.WriteLine($"{g:B}");

        // The example displays the following output:
        //        {0000000a-000b-000c-0001-020304050607}
        // </Snippet2>
    }
}

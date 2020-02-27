using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        // Create a GUID and determine whether it consists of all zeros.
        Guid guid1 = Guid.NewGuid();
        Console.WriteLine(guid1);
        Console.WriteLine($"Empty: {guid1 == Guid.Empty}\n");
      
        // Create a GUID with all zeros and compare it to Empty.
        var bytes = new Byte[16];
        var guid2 = new Guid(bytes);
        Console.WriteLine(guid2);
        Console.WriteLine($"Empty: {guid2 == Guid.Empty}");

        // The example displays output like the following:
        //       11c43ee8-b9d3-4e51-b73f-bd9dda66e29c
        //       Empty: False
        //       
        //       00000000-0000-0000-0000-000000000000
        //       Empty: True
        // </Snippet1>
    }
}

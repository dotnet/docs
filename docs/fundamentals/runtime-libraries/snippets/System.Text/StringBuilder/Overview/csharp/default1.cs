// <Snippet3>
using System;
using System.Reflection;
using System.Text;

public class Example4
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder();
        ShowSBInfo(sb);
        sb.Append("This is a sentence.");
        ShowSBInfo(sb);
        for (int ctr = 0; ctr <= 10; ctr++)
        {
            sb.Append("This is an additional sentence.");
            ShowSBInfo(sb);
        }
    }

    private static void ShowSBInfo(StringBuilder sb)
    {
        foreach (var prop in sb.GetType().GetProperties())
        {
            if (prop.GetIndexParameters().Length == 0)
                Console.Write("{0}: {1:N0}    ", prop.Name, prop.GetValue(sb));
        }
        Console.WriteLine();
    }
}
// The example displays the following output:
//    Capacity: 16    MaxCapacity: 2,147,483,647    Length: 0
//    Capacity: 32    MaxCapacity: 2,147,483,647    Length: 19
//    Capacity: 64    MaxCapacity: 2,147,483,647    Length: 50
//    Capacity: 128    MaxCapacity: 2,147,483,647    Length: 81
//    Capacity: 128    MaxCapacity: 2,147,483,647    Length: 112
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 143
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 174
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 205
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 236
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 267
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 298
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 329
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 360
// </Snippet3>

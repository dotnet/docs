// <Snippet6>
using System;
using System.Text;

public class Example8
{
    public static void Main()
    {
        string value = "An ordinary string";
        int index = value.IndexOf("An ") + 3;
        int capacity = 0xFFFF;

        // Instantiate a StringBuilder from a string.
        StringBuilder sb1 = new StringBuilder(value);
        ShowSBInfo(sb1);

        // Instantiate a StringBuilder from string and define a capacity.  
        StringBuilder sb2 = new StringBuilder(value, capacity);
        ShowSBInfo(sb2);

        // Instantiate a StringBuilder from substring and define a capacity.  
        StringBuilder sb3 = new StringBuilder(value, index,
                                              value.Length - index,
                                              capacity);
        ShowSBInfo(sb3);
    }

    public static void ShowSBInfo(StringBuilder sb)
    {
        Console.WriteLine($"\nValue: {sb.ToString()}");
        foreach (var prop in sb.GetType().GetProperties())
        {
            if (prop.GetIndexParameters().Length == 0)
                Console.Write("{0}: {1:N0}    ", prop.Name, prop.GetValue(sb));
        }
        Console.WriteLine();
    }
}
// The example displays the following output:
//    Value: An ordinary string
//    Capacity: 18    MaxCapacity: 2,147,483,647    Length: 18
//    
//    Value: An ordinary string
//    Capacity: 65,535    MaxCapacity: 2,147,483,647    Length: 18
//    
//    Value: ordinary string
//    Capacity: 65,535    MaxCapacity: 2,147,483,647    Length: 15
// </Snippet6>

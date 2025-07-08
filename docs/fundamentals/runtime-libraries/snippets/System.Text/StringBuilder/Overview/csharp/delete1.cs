// <Snippet10>
using System;
using System.Text;

public class Example5
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder("A StringBuilder object");
        ShowSBInfo(sb);
        // Remove "object" from the text.
        string textToRemove = "object";
        int pos = sb.ToString().IndexOf(textToRemove);
        if (pos >= 0)
        {
            sb.Remove(pos, textToRemove.Length);
            ShowSBInfo(sb);
        }
        // Clear the StringBuilder contents.
        sb.Clear();
        ShowSBInfo(sb);
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
//    Value: A StringBuilder object
//    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 22
//    
//    Value: A StringBuilder
//    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 16
//    
//    Value:
//    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 0
// </Snippet10>

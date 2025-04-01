// <Snippet1>
using System;

public class CompareSample
{
    public static void Main()
    {
        string string1 = "file";
        string string2 = "FILE";
        int compareResult = 0;

        compareResult = String.Compare(string1, string2,
                                       StringComparison.Ordinal);
        Console.WriteLine($"{StringComparison.Ordinal} comparison of '{string1}' and '{string2}': {compareResult}");

        compareResult = String.Compare(string1, string2,
                                       StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"{StringComparison.OrdinalIgnoreCase} comparison of '{string1}' and '{string2}': {compareResult}");
    }
}
// The example displays the following output:
//    Ordinal comparison of 'file' and 'FILE': 32
//    OrdinalIgnoreCase comparison of 'file' and 'FILE': 0
// </Snippet1>

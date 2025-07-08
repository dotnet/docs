// <Snippet3>
using System;

public class PropertiesEx2
{
    public static void Main()
    {
        Decimal[] values = { 1345.6538m, 1921651.16m };

        foreach (var value in values)
        {
            string resultString = value.ToString();
            Console.WriteLine(resultString);
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       1345.6538
//
//       1921651.16
// </Snippet3>

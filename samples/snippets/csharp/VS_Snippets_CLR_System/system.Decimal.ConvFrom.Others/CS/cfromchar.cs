//<Snippet1>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of Char values.
        Char[] values = { '\0', ' ', '*', 'A', 'a', '{', 'Æ' };

        // Convert each Char value to a Decimal.
        foreach (var value in values) {
           decimal decValue = value;
           Console.WriteLine("'{0}' ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name);         
        }
    }
}
// The example displays the following output:
//       ' ' (Char) --> 0 (Decimal)
//       ' ' (Char) --> 32 (Decimal)
//       '*' (Char) --> 42 (Decimal)
//       'A' (Char) --> 65 (Decimal)
//       'a' (Char) --> 97 (Decimal)
//       '{' (Char) --> 123 (Decimal)
//       'Æ' (Char) --> 198 (Decimal)
//</Snippet1>

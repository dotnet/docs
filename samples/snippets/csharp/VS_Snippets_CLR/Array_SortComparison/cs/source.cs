// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    private static int CompareDinosByLength(string x, string y)
    {
        if (x == null)
        {
            if (y == null)
            {
                // If x is null and y is null, they're
                // equal. 
                return 0;
            }
            else
            {
                // If x is null and y is not null, y
                // is greater. 
                return -1;
            }
        }
        else
        {
            // If x is not null...
            //
            if (y == null)
                // ...and y is null, x is greater.
            {
                return 1;
            }
            else
            {
                // ...and y is not null, compare the 
                // lengths of the two strings.
                //
                int retval = x.Length.CompareTo(y.Length);

                if (retval != 0)
                {
                    // If the strings are not of equal length,
                    // the longer string is greater.
                    //
                    return retval;
                }
                else
                {
                    // If the strings are of equal length,
                    // sort them with ordinary string comparison.
                    //
                    return x.CompareTo(y);
                }
            }
        }
    }

    public static void Main()
    {
        string[] dinosaurs = {
            "Pachycephalosaurus",
            "Amargasaurus",
            "",
            null,
            "Mamenchisaurus",
            "Deinonychus" };
        Display(dinosaurs);

        Console.WriteLine("\nSort with generic Comparison<string> delegate:");
        Array.Sort(dinosaurs, CompareDinosByLength);
        Display(dinosaurs);

    }

    private static void Display(string[] arr)
    {
        Console.WriteLine();
        foreach( string s in arr )
        {
            if (s == null)
                Console.WriteLine("(null)");
            else
                Console.WriteLine("\"{0}\"", s);
        }
    }
}

/* This code example produces the following output:

"Pachycephalosaurus"
"Amargasaurus"
""
(null)
"Mamenchisaurus"
"Deinonychus"

Sort with generic Comparison<string> delegate:

(null)
""
"Deinonychus"
"Amargasaurus"
"Mamenchisaurus"
"Pachycephalosaurus"
 */
// </Snippet1>



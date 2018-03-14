//<snippet01>
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<String> names = new List<String>();
        names.Add("Bruce");
        names.Add("Alfred");
        names.Add("Tim");
        names.Add("Richard");

        // Display the contents of the list using the Print method.
        names.ForEach(Print);

        // The following demonstrates the anonymous method feature of C#
        // to display the contents of the list to the console.
        names.ForEach(delegate(String name)
        {
            Console.WriteLine(name);
        });
    }

    private static void Print(string s)
    {
        Console.WriteLine(s);
    }
}
/* This code will produce output similar to the following:
 * Bruce
 * Alfred
 * Tim
 * Richard
 * Bruce
 * Alfred
 * Tim
 * Richard
 */
//</snippet01>

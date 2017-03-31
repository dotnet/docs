//<snippet1>
// This example demonstrates the System.Globalization.Culture-
// AndRegionInfoBuilder Unregister method.
// Compile this example with a reference to sysglobl.dll.

/*
   Notes:
   This example deletes the custom culture x-en-US-sample.nlp 
   file, but not the %winnt%\Globalization directory that contains the file.
*/

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    try 
        {
        Console.Clear();
        Console.WriteLine("Unregister the \"x-en-US-sample\" " +
                          "custom culture if it already exists...");
        CultureAndRegionInfoBuilder.Unregister("x-en-US-sample");
        Console.WriteLine("The custom culture was unregistered successfully.");
        }
    catch (Exception e)
        {
        Console.WriteLine("Error while unregistering...");
        Console.WriteLine(e);
        }
    }
}
/*
This code example produces the following results:

Unregister the "x-en-US-sample" custom culture if it already exists...
The custom culture was unregistered successfully.

*/
//</snippet1>
//<snippet1>
// This example demonstrates the Console.Title property.
using System;

class Sample 
{
    public static void Main() 
    {
    Console.WriteLine("The current console title is: \"{0}\"",
                      Console.Title);
    Console.WriteLine("  (Press any key to change the console title.)");
    Console.ReadKey(true);
    Console.Title = "The title has changed!";
    Console.WriteLine("Note that the new console title is \"{0}\"\n" +
                      "  (Press any key to quit.)", Console.Title);
    Console.ReadKey(true);
    }
}
/*
This example produces the following results:

>myTitle
The current console title is: "Command Prompt - myTitle"
  (Press any key to change the console title.)
Note that the new console title is "The title has changed!"
  (Press any key to quit.)

*/
//</snippet1>
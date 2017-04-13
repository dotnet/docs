//<snippet1>
// Sample for the Environment.GetEnvironmentVariables method
using System;
using System.Collections;

class Sample 
{
    public static void Main() 
    {
       Console.WriteLine();
       Console.WriteLine("GetEnvironmentVariables: ");
       foreach (DictionaryEntry de in Environment.GetEnvironmentVariables()) 
           Console.WriteLine("  {0} = {1}", de.Key, de.Value);
    }
}
// Output from the example is not shown, since it is:
//    Lengthy.
//    Specific to the machine on which the example is run.
//    May reveal information that should remain secure.
//</snippet1>
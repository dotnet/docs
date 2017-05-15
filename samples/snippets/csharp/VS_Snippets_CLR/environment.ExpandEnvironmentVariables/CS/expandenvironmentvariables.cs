//<snippet1>
// Sample for the Environment.ExpandEnvironmentVariables method
using System;

class Sample 
{
    public static void Main() 
    {
    String str;
    String nl = Environment.NewLine;

    Console.WriteLine();
//  <-- Keep this information secure! -->
    String query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";
    str = Environment.ExpandEnvironmentVariables(query);
    Console.WriteLine("ExpandEnvironmentVariables: {0}  {1}", nl, str);
    }
}
/*
This example produces the following results:

ExpandEnvironmentVariables:
  My system drive is C: and my system root is C:\WINNT
*/
//</snippet1>
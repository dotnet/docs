//<snippet1>
// Sample for the Environment.StackTrace property
using System;

class Sample 
{
    public static void Main() 
    {
    Console.WriteLine();
    Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);
    }
}
/*
This example produces the following results:

StackTrace: '   at System.Environment.GetStackTrace(Exception e)
   at System.Environment.GetStackTrace(Exception e)
   at System.Environment.get_StackTrace()
   at Sample.Main()'
*/
//</snippet1>
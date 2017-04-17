//<snippet1>
using System;

class Example
{
    public static void Main() 
    {
       string causeOfFailure = "A catastrophic failure has occured.";

       // Assume your application has failed catastrophically and must
       // terminate immediately. The try-finally block is not executed
       // and is included only to demonstrate that instructions within
       // try-catch blocks and finalizers are not performed.
       try {
           Environment.FailFast(causeOfFailure);
       }
       finally {
           Console.WriteLine("This finally block will not be executed.");
       }
   }
}
/*
The example produces no output because the application is terminated.
However, an entry is made in the Windows Application event log, and
the log entry contains the text from the causeOfFailure variable.
*/
//</snippet1>

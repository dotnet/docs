// System.Diagnostics.EventLog.Exists(String)

/*
   The following sample demonstrates the 'Exists(String)'method of 
   'EventLog' class. It checks for the existence of a log and displays 
   the result accordingly.
*/

using System;
using System.Diagnostics;              
class EventLog_Exists_1
{
   public static void Main()
   {
      try
      {
// <Snippet1>
         string myLog = "myNewLog";
         if (EventLog.Exists(myLog))
         {
            Console.WriteLine("Log '"+myLog+"' exists.");
         }
         else
         {
            Console.WriteLine("Log '"+myLog+"' does not exist.");
         }
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception:"+ e.Message);
      }
   }
}

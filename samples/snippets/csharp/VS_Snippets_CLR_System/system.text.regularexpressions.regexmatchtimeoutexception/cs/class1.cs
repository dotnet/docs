// <Snippet1>
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

public class Example
{
   const int MaxTimeoutInSeconds = 2;
   
   public static void Main()
   {
      TimeSpan timeout = new TimeSpan(0, 0, 1);
      string input = "aaaaaaaaaaaaaaaaaaaaaa>";
      if (ValidateInput(input, timeout))
         // Perform some operation with valid input string.
         Console.WriteLine("'{0}' is a valid string.", input); 
   } 

   private static bool ValidateInput(string input, TimeSpan timeout)
   {
      string pattern = "(a+)+$";      
      try {
         return Regex.IsMatch(input, pattern, 
                              RegexOptions.IgnoreCase, timeout);
      }
      catch (RegexMatchTimeoutException e) {
         // Increase the timeout interval and retry.
         timeout = timeout.Add(new TimeSpan(0, 0, 1));
         Console.WriteLine("Changing the timeout interval to {0}", 
                           timeout); 
         if (timeout.TotalSeconds <= MaxTimeoutInSeconds) {
            // Pause for a short period.
            Thread.Sleep(250);
            return ValidateInput(input, timeout);
         }   
         else {
            Console.WriteLine("Timeout interval of {0} exceeded.", 
                              timeout);
            // Write to event log named RegexTimeouts
            try {
               if (! EventLog.SourceExists("RegexTimeouts"))
                  EventLog.CreateEventSource("RegexTimeouts", "RegexTimeouts");

               EventLog log = new EventLog("RegexTimeouts");
               log.Source = "RegexTimeouts";
               string msg = String.Format("Timeout after {0} matching '{1}' with '{2}.",
                                          e.MatchTimeout, e.Input, e.Pattern);
               log.WriteEntry(msg, EventLogEntryType.Error);
            }
            // Do nothing to handle the exceptions.
            catch (SecurityException) { }
            catch (InvalidOperationException) { }
            catch (Win32Exception) { }
            return false;
         }   
      }
   }
}
// The example writes to the event log and also displays the following output:
//       Changing the timeout interval to 00:00:02
//       Changing the timeout interval to 00:00:03
//       Timeout interval of 00:00:03 exceeded.
// </Snippet1>

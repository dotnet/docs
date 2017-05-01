//<snippet1>
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

#endregion

namespace CreateEventSource
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Create the source, if it does not already exist.
                if (!EventLog.SourceExists("MySamplesSite"))
                {
                    EventLog.CreateEventSource("MySamplesSite", "Application");
                    Console.WriteLine("Creating Event Source");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "MySamplesSite";

                // Write an informational entry to the event log.    
                myLog.WriteEntry("Testing writing to event log.");

                Console.WriteLine("Message written to event log.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine("{0}", e.ToString());
            }
        }
    }
}
//</snippet1>
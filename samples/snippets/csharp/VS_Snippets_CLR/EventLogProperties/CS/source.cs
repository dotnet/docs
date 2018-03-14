//<Snippet1>

using System;
using System.IO;
using System.Globalization;
using System.Data;
using System.Diagnostics;
using Microsoft.Win32;

namespace EventLogSamples
{
    class EventLogProperties
    {
        /// The main entry point for the sample application.
        [STAThread]
        static void Main(string[] args)
        {
            DisplayEventLogProperties();

            Console.WriteLine();
            Console.WriteLine("Enter the name of an event log to change the");
            Console.WriteLine("overflow policy (or press Enter to exit): ");
            String input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                ChangeEventLogOverflowAction(input);
            }
        }


        // Prompt the user for the overflow policy setting.
        static void GetNewOverflowSetting(ref OverflowAction newOverflow,
            ref Int32 numDays)
        {

            Console.Write("Enter the new overflow policy setting [");
            Console.Write(" OverwriteOlder,");
            Console.Write(" DoNotOverwrite,");
            Console.Write(" OverwriteAsNeeded");
            Console.WriteLine("] : ");
    
            String input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                switch (input.Trim().ToUpper(CultureInfo.InvariantCulture))
                {
                    case "OVERWRITEOLDER":
                        newOverflow = OverflowAction.OverwriteOlder;
                        Console.WriteLine("Enter the number of days to retain events: ");
                        input = Console.ReadLine();
                        if ((!Int32.TryParse(input, out numDays)) ||
                            (numDays == 0))
                        {
                            Console.WriteLine("  Invalid input, defaulting to 7 days.");
                            numDays = 7;
                        }
                        break;
                    case "DONOTOVERWRITE":
                        newOverflow = OverflowAction.DoNotOverwrite;
                        break;
                    case "OVERWRITEASNEEDED":
                        newOverflow = OverflowAction.OverwriteAsNeeded;
                        break;
                    default:
                        Console.WriteLine("Unrecognized overflow policy value.");
                        break;
                }

            }
            Console.WriteLine();
        }


        // <Snippet2>
        static void DisplayEventLogProperties()
        {
            // Iterate through the current set of event log files,
            // displaying the property settings for each file.

            EventLog[] eventLogs = EventLog.GetEventLogs();
            foreach (EventLog e in eventLogs)
            {
                Int64 sizeKB = 0;

                Console.WriteLine();
                Console.WriteLine("{0}:", e.LogDisplayName);
                Console.WriteLine("  Log name = \t\t {0}", e.Log); 

                Console.WriteLine("  Number of event log entries = {0}", e.Entries.Count.ToString());
                            
                // Determine if there is an event log file for this event log.
                RegistryKey regEventLog = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\EventLog\\" + e.Log);
                if (regEventLog != null)
                {
                    Object temp = regEventLog.GetValue("File");
                    if (temp != null)
                    {
                        Console.WriteLine("  Log file path = \t {0}", temp.ToString());
                        FileInfo file = new FileInfo(temp.ToString());

                        // Get the current size of the event log file.
                        if (file.Exists)
                        {
                            sizeKB = file.Length / 1024;
                            if ((file.Length % 1024) != 0)
                            {
                                sizeKB++;
                            }
                            Console.WriteLine("  Current size = \t {0} kilobytes", sizeKB.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Log file path = \t <not set>");
                    }
                }
                            
                // Display the maximum size and overflow settings.

                sizeKB = e.MaximumKilobytes;
                Console.WriteLine("  Maximum size = \t {0} kilobytes", sizeKB.ToString());
                Console.WriteLine("  Overflow setting = \t {0}", e.OverflowAction.ToString());

                switch (e.OverflowAction)
                {
                    case OverflowAction.OverwriteOlder:
                        Console.WriteLine("\t Entries are retained a minimum of {0} days.", 
                            e.MinimumRetentionDays);
                        break;
                    case OverflowAction.DoNotOverwrite:
                        Console.WriteLine("\t Older entries are not overwritten.");
                        break;
                    case OverflowAction.OverwriteAsNeeded:
                        Console.WriteLine("\t If number of entries equals max size limit, a new event log entry overwrites the oldest entry.");
                        break;
                    default:
                        break;
                }
            }
        }
        // </Snippet2>

        // <Snippet3>
        // Display the current event log overflow settings, and 
        // prompt the user to input a new overflow setting.
        public static void ChangeEventLogOverflowAction(String logName)
        {
            if (EventLog.Exists(logName))
            {
                // Display the current overflow setting of the 
                // specified event log.
                EventLog inputLog = new EventLog(logName);
                Console.WriteLine("  Event log {0}", inputLog.Log);

                OverflowAction logOverflow = inputLog.OverflowAction;
                Int32 numDays = inputLog.MinimumRetentionDays;

                Console.WriteLine("  Current overflow setting = {0}",
                    logOverflow.ToString());
                if (logOverflow == OverflowAction.OverwriteOlder)
                {
                    Console.WriteLine("\t Entries are retained a minimum of {0} days.", 
                        numDays.ToString());
                }

                // Prompt user for a new overflow setting.
                GetNewOverflowSetting(ref logOverflow, ref numDays);

                // Change the overflow setting on the event log.
                if (logOverflow != inputLog.OverflowAction)
                {
                    inputLog.ModifyOverflowPolicy(logOverflow, numDays);
                    Console.WriteLine("Event log overflow policy was modified successfully!");
                }
                else 
                {
                    Console.WriteLine("Event log overflow policy was not modified.");
                }
            }
            else 
            {
                Console.WriteLine("Event log {0} was not found.", logName);
            }
        }
        // </Snippet3>
    }
}
//</Snippet1>

//<Snippet1>
using System;
using System.Globalization;
using System.Diagnostics;

namespace EventLogSamples
{
    class CreateSourceSample
    {
        [STAThread]
        static void Main(string[] args)
        {
            //<Snippet2>
            EventSourceCreationData mySourceData = new EventSourceCreationData("", "");
            bool registerSource = true;

            // Process input parameters.
            if (args.Length > 0)
            {
                // Require at least the source name.

                mySourceData.Source = args[0];

                if (args.Length > 1)
                {
                    mySourceData.LogName = args[1];
                }

                if (args.Length > 2)
                {
                    mySourceData.MachineName = args[2];
                }
                if ((args.Length > 3) && (args[3].Length > 0))
                {
                    mySourceData.MessageResourceFile = args[3];
                }
            }
            else 
            {
                // Display a syntax help message.
                Console.WriteLine("Input:");
                Console.WriteLine(" source [event log] [machine name] [resource file]");

                registerSource = false;
            }

            // Set defaults for parameters missing input.
            if (mySourceData.MachineName.Length == 0)
            {
                // Default to the local computer.
                mySourceData.MachineName = ".";
            }
            if (mySourceData.LogName.Length == 0)
            {
                // Default to the Application log.
                mySourceData.LogName = "Application";
            }
            //</Snippet2>

            // Determine if the source exists on the specified computer.
            if (!EventLog.SourceExists(mySourceData.Source, 
                                       mySourceData.MachineName))
            {
                // The source does not exist.  

                // Verify that the message file exists
                // and the event log is local.

                if ((mySourceData.MessageResourceFile != null) &&
                    (mySourceData.MessageResourceFile.Length > 0))
                {
                    if (mySourceData.MachineName == ".") 
                    {
                        if (!System.IO.File.Exists(mySourceData.MessageResourceFile))
                        {
                            Console.WriteLine("File {0} not found - message file not set for source.",
                                mySourceData.MessageResourceFile);
                            registerSource = false;
                        }
                    }
                    else 
                    {
                        // For simplicity, do not allow setting the message
                        // file for a remote event log.  To set the message
                        // for a remote event log, and for source registration,
                        // the file path should be specified with system-wide
                        // environment variables that are valid on the remote
                        // computer, such as
                        // "%SystemRoot%\system32\myresource.dll".

                        Console.WriteLine("Message resource file ignored for remote event log.");
                        registerSource = false;
                    }
                }
            }
            else
            {
                // Do not register the source, it already exists.
                registerSource = false;

                // Get the event log corresponding to the existing source.
                string sourceLog;
                sourceLog = EventLog.LogNameFromSourceName(mySourceData.Source,
                                mySourceData.MachineName);

                // Determine if the event source is registered for the 
                // specified log.

                if (sourceLog.ToUpper(CultureInfo.InvariantCulture) != mySourceData.LogName.ToUpper(CultureInfo.InvariantCulture)) 
                {
                    // An existing source is registered 
                    // to write to a different event log.
                    Console.WriteLine("Warning: source {0} is already registered to write to event log {1}",
                        mySourceData.Source, sourceLog);
                }
                else 
                {
                    // The source is already registered 
                    // to write to the specified event log.

                    Console.WriteLine("Source {0} already registered to write to event log {1}",
                        mySourceData.Source, sourceLog);
                }
            }
        

            if (registerSource)
            {
                // Register the new event source for the specified event log.

                Console.WriteLine("Registering new source {0} for event log {1}.",
                    mySourceData.Source, mySourceData.LogName);
                EventLog.CreateEventSource(mySourceData);
                Console.WriteLine("Event source was registered successfully!");
            }
        }
    }
}
//</Snippet1>
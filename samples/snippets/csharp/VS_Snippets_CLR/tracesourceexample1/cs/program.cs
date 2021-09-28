//<Snippet1>
using System;
using System.Diagnostics;

class TraceTest
{

    private static TraceSource mySource =
            new TraceSource("TraceSourceApp");
        static void Main(string[] args)
        {
           // Issue an error and a warning message. Only the error message
            // should be logged.
            Activity1();

            // Save the original settings from the configuration file.
            EventTypeFilter configFilter =
                (EventTypeFilter)mySource.Listeners["console"].Filter;

            // Create a new event type filter that ensures
            // warning messages will be written.
            mySource.Listeners["console"].Filter =
                new EventTypeFilter(SourceLevels.Warning);

            // Allow the trace source to send messages to listeners
            // for all event types. This statement will override
            // any settings in the configuration file.
            // If you do not change the switch level, the event filter
            // changes have no effect.
            mySource.Switch.Level = SourceLevels.All;

            // Issue a warning and a critical message. Both should be logged.
            Activity2();

            // Restore the original filter settings.
            mySource.Listeners["console"].Filter = configFilter;
            Activity3();
            mySource.Close();
            return;
        }
        static void Activity1()
        {
            mySource.TraceEvent(TraceEventType.Error, 1,
                "Error message.");
            mySource.TraceEvent(TraceEventType.Warning, 2,
                "Warning message.");
        }
        static void Activity2()
        {
            mySource.TraceEvent(TraceEventType.Critical, 3,
                "Critical message.");
            mySource.TraceEvent(TraceEventType.Warning, 2,
                "Warning message.");
        }
        static void Activity3()
        {
            mySource.TraceEvent(TraceEventType.Error, 4,
                "Error message.");
            mySource.TraceInformation("Informational message.");
        }
    }
//</Snippet1>
//<Snippet1>
#define TRACE

using System;
using System.Diagnostics;

namespace TestingTracing
{
    class TraceTest
    {
        static void Main()
        {
            TraceSource ts = new TraceSource("TraceTest");
            SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch", "Verbose");
            ts.Switch = sourceSwitch;
            ConsoleTraceListener ctl = new ConsoleTraceListener();
            ctl.Name = "console";
            ctl.TraceOutputOptions = TraceOptions.DateTime;
            ctl.Filter = new ErrorFilter();
            ts.Listeners.Add(ctl);

            ts.TraceEvent(TraceEventType.Warning, 1, "*** This event will be filtered out ***");
            // this event will be get displayed
            ts.TraceEvent(TraceEventType.Error, 2, "*** This event will be be displayed ***");

            ts.Flush();
            ts.Close();
        }
    }

    //<Snippet2>
    public class ErrorFilter : TraceFilter
    {
        override public bool ShouldTrace(TraceEventCache cache, string source,
            TraceEventType eventType, int id, string formatOrMessage,
            object[] args, object data, object[] dataArray)
        {
            return eventType == TraceEventType.Error;
        }
    }
    //</Snippet2>
}
//</Snippet1>

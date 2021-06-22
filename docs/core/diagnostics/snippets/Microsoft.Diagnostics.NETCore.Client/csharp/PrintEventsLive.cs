using Microsoft.Diagnostics.NETCore.Client;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.EventPipe;
using Microsoft.Diagnostics.Tracing.Parsers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

public partial class Tracer
{
    public static void PrintEventsLive(int processId)
    {
        var providers = new List<EventPipeProvider>()
        {
            new EventPipeProvider("Microsoft-Windows-DotNETRuntime",
                EventLevel.Informational, (long)ClrTraceEventParser.Keywords.Default)
        };
        var client = new DiagnosticsClient(processId);
        using (var session = client.StartEventPipeSession(providers, false))
        {

            Task streamTask = Task.Run(() =>
            {
                var source = new EventPipeEventSource(session.EventStream);
                source.Clr.All += (TraceEvent obj) => Console.WriteLine(obj.EventName);
                try
                {
                    source.Process();
                }
                // NOTE: This exception does not currently exist. It is something that needs to be added to TraceEvent.
                catch (Exception e)
                {
                    Console.WriteLine("Error encountered while processing events");
                    Console.WriteLine(e.ToString());
                }
            });

            Task inputTask = Task.Run(() =>
            {
                Console.WriteLine("Press Enter to exit");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Task.Delay(TimeSpan.FromMilliseconds(100));
                }
                session.Stop();
            });

            Task.WaitAny(streamTask, inputTask);
        }
    }
}

using Microsoft.Diagnostics.NETCore.Client;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.EventPipe;
using Microsoft.Diagnostics.Tracing.Parsers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public partial class Dumper
{
    public static void TriggerDumpOnCpuUsage(int processId, int threshold)
    {
        var providers = new List<EventPipeProvider>()
        {
            new EventPipeProvider(
                "System.Runtime",
                EventLevel.Informational,
                (long)ClrTraceEventParser.Keywords.None,
                new Dictionary<string, string>
                {
                    ["EventCounterIntervalSec"] = "1"
                }
            )
        };
        var client = new DiagnosticsClient(processId);
        using (var session = client.StartEventPipeSession(providers))
        {
            var source = new EventPipeEventSource(session.EventStream);
            source.Dynamic.All += (TraceEvent obj) =>
            {
                if (obj.EventName.Equals("EventCounters"))
                {
                    var payloadVal = (IDictionary<string, object>)(obj.PayloadValue(0));
                    var payloadFields = (IDictionary<string, object>)(payloadVal["Payload"]);
                    if (payloadFields["Name"].ToString().Equals("cpu-usage"))
                    {
                        double cpuUsage = Double.Parse(payloadFields["Mean"].ToString());
                        if (cpuUsage > (double)threshold)
                        {
                            client.WriteDump(DumpType.Normal, "/tmp/minidump.dmp");
                        }
                    }
                }
            };
            try
            {
                source.Process();
            }
            catch (Exception) {}
        }
    }
}

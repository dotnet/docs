using System;
using Microsoft.Diagnostics.NETCore.Client;

public class Profiler
{
    public static void AttachProfiler(int processId, Guid profilerGuid, string profilerPath)
    {
        var client = new DiagnosticsClient(processId);
        client.AttachProfiler(TimeSpan.FromSeconds(10), profilerGuid, profilerPath);
    }
}

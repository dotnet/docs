using Microsoft.Diagnostics.NETCore.Client;
using System;
using System.Diagnostics;
using System.Linq;

public class ProcessTracker
{
    public static void PrintProcessStatus()
    {
        var processes = DiagnosticsClient.GetPublishedProcesses()
            .Select(Process.GetProcessById)
            .Where(process => process != null);

        foreach (var process in processes)
        {
            Console.WriteLine($"{process.ProcessName}");
        }
    }
}

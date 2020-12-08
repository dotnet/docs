using Microsoft.Diagnostics.NETCore.Client;

public class Dumper
{
    public static void TriggerCoreDump(int processId)
    {
        var client = new DiagnosticsClient(processId);
        client.WriteDump(DumpType.Normal, "/tmp/minidump.dmp");
    }
}

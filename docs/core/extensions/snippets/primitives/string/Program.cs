using System.Diagnostics;
using BenchmarkDotNet.Running;

bool runBenchmark = false;
if (args.Length == 1 && bool.TryParse(args[0], out bool result))
{
    runBenchmark = result;
}

if (runBenchmark && !Debugger.IsAttached)
{
    _ = BenchmarkRunner.Run<Example>();
}
else
{
    var example = new Example();

    example.RunTokenizer();
    example.RunSegments();
    example.ShowStringValues();
}

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
    var example = new Example { WriteOutput = true };

    example.Tokenizer();
    example.Split();
    example.RunSegments();
}

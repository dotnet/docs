using System.Runtime.CompilerServices;

internal sealed class LoggingStopwatch
{
    internal static IDisposable WriteDurationToConsole(
        [CallerMemberName] string? operation = null) =>
        new StopwatchDisposable(operation);

    private sealed class StopwatchDisposable : IDisposable
    {
        private readonly string? _operation;
        private readonly Stopwatch _stopwatch;

        internal StopwatchDisposable(string? operation) =>
            (_operation, _stopwatch) = (operation, Stopwatch.StartNew());

        void IDisposable.Dispose()
        {
            _stopwatch.Stop();

            Console.WriteLine($"Finished {_operation} in: {_stopwatch.Elapsed}");
        }
    }
}

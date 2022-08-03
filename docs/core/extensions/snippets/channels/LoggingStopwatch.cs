using System.Runtime.CompilerServices;

internal class LoggingStopwatch
{
    internal static IDisposable WriteDurationToConsole(
        [CallerMemberName] string? operation = null) =>
        new StopWatchDisposable(operation);

    private sealed class StopWatchDisposable : IDisposable
    {
        private readonly string? _operation;
        private readonly Stopwatch _stopwatch;

        internal StopWatchDisposable(string? operation) =>
            (_operation, _stopwatch) = (operation, Stopwatch.StartNew());

        void IDisposable.Dispose()
        {
            _stopwatch.Stop();

            Console.WriteLine($"Finished {_operation} in: {_stopwatch.Elapsed}");
        }
    }
}

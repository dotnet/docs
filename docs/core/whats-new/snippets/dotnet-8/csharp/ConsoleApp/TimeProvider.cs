using System;
using System.Threading;
using System.Threading.Tasks.Sources;

namespace WhatsNew
{
    internal class MyTimer(TimeProvider timeProvider)
    {
        TimeProvider _timeProvider { get; set; } = timeProvider;

        public void Start()
        {
            // <GetElapsedTime>
            // Get system time.
            DateTimeOffset utcNow = TimeProvider.System.GetUtcNow();
            DateTimeOffset localNow = TimeProvider.System.GetLocalNow();

            TimerCallback callback = s => ((State)s!).Signal();

            // Create a timer using the time provider.
            ITimer timer = _timeProvider.CreateTimer(
                callback, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);

            // Measure a period using the system time provider.
            long providerTimestamp1 = TimeProvider.System.GetTimestamp();
            long providerTimestamp2 = TimeProvider.System.GetTimestamp();

            TimeSpan period = _timeProvider.GetElapsedTime(providerTimestamp1, providerTimestamp2);
            // </GetElapsedTime>
        }

        private sealed class State : IValueTaskSource<bool>
        {
            public bool GetResult(short token) => throw new NotImplementedException();
            public ValueTaskSourceStatus GetStatus(short token) => throw new NotImplementedException();
            public void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags) => throw new NotImplementedException();

            public void Signal(bool stopping = false, CancellationToken cancellationToken = default)
            {
                // ...
            }
        }
    }

    class RunIt
    {
        public static void Main()
        {
            var timeProvider = new ZonedTimeProvider(TimeZoneInfo.Local);
            MyTimer timer = new(timeProvider);
            timer.Start();
        }

        // <TimeProvider>
        // Create a time provider that works with a
        // time zone that's different than the local time zone.
        private class ZonedTimeProvider(TimeZoneInfo zoneInfo) : TimeProvider()
        {
            private readonly TimeZoneInfo _zoneInfo = zoneInfo ?? TimeZoneInfo.Local;

            public override TimeZoneInfo LocalTimeZone => _zoneInfo;

            public static TimeProvider FromLocalTimeZone(TimeZoneInfo zoneInfo) =>
                new ZonedTimeProvider(zoneInfo);
        }
        // </TimeProvider>
    }
}

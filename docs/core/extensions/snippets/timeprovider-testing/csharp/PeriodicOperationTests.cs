using Microsoft.Extensions.Time.Testing;
using Xunit;

// <PeriodicOperationTests>
public class PeriodicOperationTests
{
    [Fact]
    public void PeriodicOperation_ExecutesAtIntervals()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var counter = new PeriodicCounter(fakeTimeProvider);
        counter.Start(TimeSpan.FromSeconds(10));

        // Act & Assert
        Assert.Equal(0, counter.Count);

        // Advance by 10 seconds
        fakeTimeProvider.Advance(TimeSpan.FromSeconds(10));
        Assert.Equal(1, counter.Count);

        // Advance by 20 more seconds
        fakeTimeProvider.Advance(TimeSpan.FromSeconds(20));
        Assert.Equal(3, counter.Count);

        // Clean up
        counter.Stop();
    }
}

public class PeriodicCounter(TimeProvider timeProvider)
{
    private ITimer? _timer;

    public int Count { get; private set; }

    public void Start(TimeSpan interval)
    {
        _timer = timeProvider.CreateTimer(
            callback: _ => Count++,
            state: null,
            dueTime: interval,
            period: interval);
    }

    public void Stop()
    {
        _timer?.Dispose();
    }
}
// </PeriodicOperationTests>

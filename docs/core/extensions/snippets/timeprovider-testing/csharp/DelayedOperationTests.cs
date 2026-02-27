using Microsoft.Extensions.Time.Testing;
using Xunit;

// <DelayedOperationTests>
public class DelayedOperationTests
{
    [Fact]
    public async Task DelayedOperation_CompletesAfterDelay()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var operation = new DelayedOperation(fakeTimeProvider);

        // Act
        Task task = operation.ExecuteAsync(TimeSpan.FromMinutes(5));

        // Assert - operation should not be complete yet
        Assert.False(task.IsCompleted);

        // Advance time by 5 minutes
        fakeTimeProvider.Advance(TimeSpan.FromMinutes(5));

        // Wait for the task to complete
        await task;

        // Operation should now be complete
        Assert.True(task.IsCompleted);
    }
}

public class DelayedOperation(TimeProvider timeProvider)
{
    public async Task ExecuteAsync(TimeSpan delay)
    {
        await Task.Delay(delay, timeProvider);
    }
}
// </DelayedOperationTests>

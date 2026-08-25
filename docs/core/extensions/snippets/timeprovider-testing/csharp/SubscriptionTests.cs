using Microsoft.Extensions.Time.Testing;
using Xunit;

// <SubscriptionTests>
public class SubscriptionTests
{
    [Fact]
    public void Subscription_ExpiresAfterOneYear()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var startDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);
        fakeTimeProvider.SetUtcNow(startDate);

        var subscription = new Subscription(fakeTimeProvider);
        subscription.Activate();

        // Assert - subscription is active
        Assert.True(subscription.IsActive);

        // Act - advance time by 11 months
        fakeTimeProvider.Advance(TimeSpan.FromDays(30 * 11));
        Assert.True(subscription.IsActive);

        // Advance time by 2 more months
        fakeTimeProvider.Advance(TimeSpan.FromDays(60));
        Assert.False(subscription.IsActive);
    }
}

public class Subscription(TimeProvider timeProvider)
{
    private DateTimeOffset _activationDate;

    public void Activate()
    {
        _activationDate = timeProvider.GetUtcNow();
    }

    public bool IsActive
    {
        get
        {
            DateTimeOffset currentTime = timeProvider.GetUtcNow();
            DateTimeOffset expirationDate = _activationDate.AddYears(1);
            return currentTime < expirationDate;
        }
    }
}
// </SubscriptionTests>

internal sealed class ClientConnectRetryFilter : IClientConnectionRetryFilter
{
    public Task<bool> ShouldRetryConnectionAttempt(
        Exception exception,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}

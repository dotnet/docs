using Orleans.Runtime;

internal sealed class ClientConnectRetryFilter : IClientConnectionRetryFilter
{
    private int _retryCount = 0;
    private readonly int _maxRetry = 5;
    private readonly int _delay = 1_000;

    public async Task<bool> ShouldRetryConnectionAttempt(
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (_retryCount >= _retryCount)
        {
            return false;
        }

        if (exception is SiloUnavailableException siloUnavailableException)
        {
            await Task.Delay(++ _retryCount * _delay, cancellationToken);
            return true;
        }

        return false;
    }
}

using Microsoft.Extensions.Hosting;

internal class HostedService : IHostedService
{
    private readonly HttpClient _httpClient;

    public HostedService(HttpClient client)
    {
        _httpClient = client;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "https://www.bing.com");

        try
        {
            using var _ = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            System.Diagnostics.Debug.WriteLine($"Exception occured while sending the request. Exception message: '{e.Message}'");
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken) => await Task.CompletedTask;
}

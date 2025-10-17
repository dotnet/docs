namespace GeneratedHttp.Example;


public sealed class HttpLatencyExportHandler : DelegatingHandler
{
    // ILatencyContextAccessor is just an example of some accessor that is able to read latency context
    private readonly ILatencyContextAccessor _latency;

    public HttpLatencyExportHandler(ILatencyContextAccessor latency) => _latency = latency;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var rsp = await base.SendAsync(request, ct).ConfigureAwait(false);

        var ctx = _latency.Current;
        if (ctx != null)
        {
            var data = ctx.LatencyData;
            // Record/export gc and conn with version as a dimension here.
        }
        return rsp;
    }
}

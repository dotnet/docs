using Microsoft.Extensions.Diagnostics.Enrichment;
using Microsoft.Extensions.Http.Logging;

public class CustomHttpClientLogEnricher : IHttpClientLogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector, HttpRequestMessage request,
        HttpResponseMessage? response, Exception? exception)
    {
        // Add custom tags based on the request
        collector.Add("request_method", request.Method.ToString());

        // Add tags based on the response (if available)
        if (response is not null)
        {
            collector.Add("response_status_code", (int)response.StatusCode);
        }

        // Add tags based on the exception (if available)
        if (exception is not null)
        {
            collector.Add("error_type", exception.GetType().Name);
        }
    }
}

using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

internal partial class Program
{
    private static void RemoveHandlers(IHttpClientBuilder httpClientBuilder)
    {
        // <remove-handlers>
        var services = new ServiceCollection();
        services.ConfigureHttpClientDefaults(builder => builder.AddStandardResilienceHandler());
       // For a named HttpClient "custom" we want to remove the StandardResilienceHandler and add the StandardHedgingHandler instead.
        services.AddHttpClient("custom")
            .RemoveAllResilienceHandlers()
            .AddStandardHedgingHandler();
        // </remove-handlers>
    }
}

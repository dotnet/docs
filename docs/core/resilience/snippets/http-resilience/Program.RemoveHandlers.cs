using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;

internal partial class Program
{
    private static void RemoveHandlers()
    {
        #pragma warning disable EXTEXP0001
        // <remove-handlers>
        var services = new ServiceCollection();
		// By default, we want all HttpClient instances to include the StandardResilienceHandler.
        services.ConfigureHttpClientDefaults(builder => builder.AddStandardResilienceHandler());
        // For a named HttpClient "custom" we want to remove the StandardResilienceHandler and add the StandardHedgingHandler instead.
		services.AddHttpClient("custom")
            .RemoveAllResilienceHandlers()
            .AddStandardHedgingHandler();
        // </remove-handlers>
        #pragma warning restore EXTEXP0001
    }
}

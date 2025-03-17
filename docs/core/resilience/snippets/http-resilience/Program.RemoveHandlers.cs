using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

internal partial class Program
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Resilience", "EXTEXP0001:Experimental API")]
    private static void RemoveHandlers()
    {
        // <remove-handlers>
        var services = new ServiceCollection();
		// By default, we want all HttpClient instances to include the StandardResilienceHandler.
        services.ConfigureHttpClientDefaults(builder => builder.AddStandardResilienceHandler());
        // For a named HttpClient "custom" we want to remove the StandardResilienceHandler and add the StandardHedgingHandler instead.
		services.AddHttpClient("custom")
            .RemoveAllResilienceHandlers()
            .AddStandardHedgingHandler();
        // </remove-handlers>
    }
}

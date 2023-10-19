using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;

internal partial class Program
{
    private static void WithStandardHedgingHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <standard-hedging>
        httpClientBuilder.AddStandardHedgingHandler();
        // </standard-hedging>
    }

    private static void WithConfiguredStandardHedgingHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <configure-standard-hedging>
        httpClientBuilder.AddStandardHedgingHandler(static (IRoutingStrategyBuilder builder) =>
        {
            // Hedging allows sending multiple concurrent requests
            builder.ConfigureOrderedGroups(static options =>
            {
                options.Groups.Add(new UriEndpointGroup()
                {
                    Endpoints =
                    {
                        // Imagine a scenario where 3% of the requests are 
                        // sent to the experimental endpoint.
                        new() { Uri = new("https://example.net/api/experimental"), Weight = 3 },
                        new() { Uri = new("https://example.net/api/stable"), Weight = 97 }
                    }
                });
            });
        });
        // </configure-standard-hedging-ordered>

        // <configure-standard-hedging-weighted>
        httpClientBuilder.AddStandardHedgingHandler(static (IRoutingStrategyBuilder builder) =>
        {
            // Hedging allows sending multiple concurrent requests
            builder.ConfigureWeightedGroups(static options =>
            {
                options.SelectionMode = WeightedGroupSelectionMode.EveryAttempt;

                options.Groups.Add(new WeightedUriEndpointGroup()
                {
                    Endpoints =
                    {
                        // Imagine a/b testing
                        new() { Uri = new("https://example.net/api/a"), Weight = 33 },
                        new() { Uri = new("https://example.net/api/b"), Weight = 33 },
                        new() { Uri = new("https://example.net/api/c"), Weight = 33 }
                    }
                });
            });
        });        
        // </configure-standard-hedging-weighted>
    }
}


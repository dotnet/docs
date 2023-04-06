using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;

// Overrides default IHttpClientFactory registration as a transient
// service with access to the current scope.
public class ScopeAwareHttpClientFactory : IHttpClientFactory
{
    private readonly IServiceProvider _scopeServiceProvider;
    private readonly IHttpMessageHandlerFactory _httpMessageHandlerFactory; // using IHttpMessageHandlerFactory to get access to HttpClientFactory's cached handlers
    private readonly IOptionsMonitor<HttpClientFactoryOptions> _hcfOptionsMonitor;
    private readonly IOptionsMonitor<ScopeAwareHttpClientFactoryOptions> _scopeAwareOptionsMonitor;

    public ScopeAwareHttpClientFactory(
        IServiceProvider scopeServiceProvider,
        IHttpMessageHandlerFactory httpMessageHandlerFactory,
        IOptionsMonitor<HttpClientFactoryOptions> hcfOptionsMonitor,
        IOptionsMonitor<ScopeAwareHttpClientFactoryOptions> scopeAwareOptionsMonitor)
    {
        _scopeServiceProvider = scopeServiceProvider;
        _httpMessageHandlerFactory = httpMessageHandlerFactory;
        _hcfOptionsMonitor = hcfOptionsMonitor;
        _scopeAwareOptionsMonitor = scopeAwareOptionsMonitor;
    }

    public HttpClient CreateClient(string name)
    {
        DelegatingHandler? scopeAwareHandler = null;

        // get custom options to get scope aware handler information
        ScopeAwareHttpClientFactoryOptions scopeAwareOptions = _scopeAwareOptionsMonitor.Get(name);
        Type? scopeAwareHandlerType = scopeAwareOptions.HttpHandlerType;

        // <CreateClient>
        if (scopeAwareHandlerType != null)
        {
            if (!typeof(DelegatingHandler).IsAssignableFrom(scopeAwareHandlerType))
            {
                throw new ArgumentException($"""
                    Scope aware HttpHandler {scopeAwareHandlerType.Name} should 
                    be assignable to DelegatingHandler
                    """);
            }

            // Create top-most delegating handler with scoped dependencies
            scopeAwareHandler = (DelegatingHandler)_scopeServiceProvider.GetRequiredService(scopeAwareHandlerType); // should be transient
            if (scopeAwareHandler.InnerHandler != null)
            {
                throw new ArgumentException($"""
                    Inner handler of a delegating handler {scopeAwareHandlerType.Name} should be null. 
                    Scope aware HttpHandler should be registered as Transient.
                    """);
            }
        }

        // Get or create HttpMessageHandler from HttpClientFactory
        HttpMessageHandler handler = _httpMessageHandlerFactory.CreateHandler(name);

        if (scopeAwareHandler != null)
        {
            scopeAwareHandler.InnerHandler = handler;
            handler = scopeAwareHandler;
        }

        HttpClient client = new(handler);
        // </CreateClient>

        // configure HttpClient in the same way HttpClientFactory would do
        HttpClientFactoryOptions hcfOptions = _hcfOptionsMonitor.Get(name);
        for (int i = 0; i < hcfOptions.HttpClientActions.Count; i++)
        {
            hcfOptions.HttpClientActions[i](client);
        }
        return client;
    }
}

public class ScopeAwareHttpClientFactoryOptions
{
    public Type? HttpHandlerType { get; set; }
}

public static class ScopeAwareHttpClientBuilderExtensions
{
    // <AddScopeAwareHttpHandler>
    public static IHttpClientBuilder AddScopeAwareHttpHandler<THandler>(
        this IHttpClientBuilder builder) where THandler : DelegatingHandler
    {
        builder.Services.TryAddTransient<THandler>();
        if (!builder.Services.Any(sd => sd.ImplementationType == typeof(ScopeAwareHttpClientFactory)))
        {
            // Override default IHttpClientFactory registration
            builder.Services.AddTransient<IHttpClientFactory, ScopeAwareHttpClientFactory>();
        }

        builder.Services.Configure<ScopeAwareHttpClientFactoryOptions>(
            builder.Name, options => options.HttpHandlerType = typeof(THandler));

        return builder;
    }
    // </AddScopeAwareHttpHandler>
}

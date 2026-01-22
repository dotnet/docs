using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans.Hosting;
using Orleans.Runtime;

namespace Orleans.Docs.Snippets.Interceptors;

// <logging_outgoing_filter>
public class OutgoingLoggingCallFilter : IOutgoingGrainCallFilter
{
    private readonly ILogger<OutgoingLoggingCallFilter> _logger;

    public OutgoingLoggingCallFilter(ILogger<OutgoingLoggingCallFilter> logger)
    {
        _logger = logger;
    }

    public async Task Invoke(IOutgoingGrainCallContext context)
    {
        try
        {
            await context.Invoke();

            _logger.LogInformation(
                "{GrainType}.{MethodName} returned value {Result}",
                context.Grain.GetType(),
                context.MethodName,
                context.Result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "{GrainType}.{MethodName} threw an exception",
                context.Grain.GetType(),
                context.MethodName);

            // If this exception is not re-thrown, it is considered to be
            // handled by this filter.
            throw;
        }
    }
}
// </logging_outgoing_filter>

public static class OutgoingFilterRegistration
{
    public static void ConfigureDelegateFilter(ISiloBuilder builder)
    {
        // <outgoing_delegate_filter>
        builder.AddOutgoingGrainCallFilter(async context =>
        {
            // If the method being called is 'MyInterceptedMethod', then set a value
            // on the RequestContext which can then be read by other filters or the grain.
            if (string.Equals(
                context.InterfaceMethod.Name,
                nameof(IMyGrain.MyInterceptedMethod)))
            {
                RequestContext.Set(
                    "intercepted value", "this value was added by the filter");
            }

            await context.Invoke();

            // If the grain method returned an int, set the result to double that value.
            if (context.Result is int resultValue)
            {
                context.Result = resultValue * 2;
            }
        });
        // </outgoing_delegate_filter>
    }

    public static void RegisterLoggingFilter(ISiloBuilder builder)
    {
        // <register_outgoing_logging_filter>
        builder.AddOutgoingGrainCallFilter<OutgoingLoggingCallFilter>();
        // </register_outgoing_logging_filter>
    }

    public static void RegisterFilterWithDI(ISiloBuilder builder)
    {
        // <register_outgoing_filter_di>
        builder.ConfigureServices(
            services => services.AddSingleton<IOutgoingGrainCallFilter, OutgoingLoggingCallFilter>());
        // </register_outgoing_filter_di>
    }
}

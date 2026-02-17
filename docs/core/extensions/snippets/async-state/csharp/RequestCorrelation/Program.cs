using System;
using System.Threading.Tasks;
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAsyncState();
builder.Services.AddSingleton<RequestProcessor>();

var host = builder.Build();

var processor = host.Services.GetRequiredService<RequestProcessor>();
await processor.ProcessRequestAsync("ABC-123");

// <RequestProcessor>
public class RequestProcessor
{
    private readonly IAsyncContext<CorrelationContext> _asyncContext;

    public RequestProcessor(IAsyncContext<CorrelationContext> asyncContext)
    {
        _asyncContext = asyncContext;
    }

    public async Task ProcessRequestAsync(string correlationId)
    {
        // Set correlation context at the beginning of request processing
        _asyncContext.Set(new CorrelationContext { CorrelationId = correlationId });

        // The correlation ID flows through all async operations
        await Step1Async();
        await Step2Async();
    }

    private async Task Step1Async()
    {
        await Task.Delay(100);
        
        if (_asyncContext.TryGet(out var context))
        {
            Console.WriteLine($"Step 1 - Correlation ID: {context.CorrelationId}");
        }
    }

    private async Task Step2Async()
    {
        await Task.Delay(100);
        
        if (_asyncContext.TryGet(out var context))
        {
            Console.WriteLine($"Step 2 - Correlation ID: {context.CorrelationId}");
        }
    }
}
// </RequestProcessor>

// <CorrelationContext>
public class CorrelationContext
{
    public string CorrelationId { get; set; } = string.Empty;
}
// </CorrelationContext>

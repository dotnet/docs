using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAsyncState();
builder.Services.AddScoped<RequestHandler>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var asyncContext = context.RequestServices.GetRequiredService<IAsyncContext<RequestMetadata>>();
    
    // Set request metadata at the beginning of the pipeline
    asyncContext.Set(new RequestMetadata
    {
        RequestId = context.TraceIdentifier,
        RequestPath = context.Request.Path,
        StartTime = DateTimeOffset.UtcNow
    });

    await next();
});

app.MapGet("/api/data", async (RequestHandler handler) =>
{
    return await handler.GetDataAsync();
});

app.Run();

// <RequestHandler>
public class RequestHandler
{
    private readonly IAsyncContext<RequestMetadata> _asyncContext;

    public RequestHandler(IAsyncContext<RequestMetadata> asyncContext)
    {
        _asyncContext = asyncContext;
    }

    public async Task<object> GetDataAsync()
    {
        await Task.Yield();
        
        if (_asyncContext.TryGet(out var metadata))
        {
            var duration = DateTimeOffset.UtcNow - metadata.StartTime;
            return new
            {
                RequestId = metadata.RequestId,
                RequestPath = metadata.RequestPath,
                Duration = duration.TotalMilliseconds
            };
        }

        return new { Error = "No request metadata available" };
    }
}
// </RequestHandler>

// <RequestMetadata>
public class RequestMetadata
{
    public required string RequestId { get; set; }
    public required string RequestPath { get; set; }
    public DateTimeOffset StartTime { get; set; }
}
// </RequestMetadata>

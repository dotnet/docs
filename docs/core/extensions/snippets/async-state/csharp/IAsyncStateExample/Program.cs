using System;
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddAsyncState();

var provider = services.BuildServiceProvider();
// <snippet>
var asyncState = provider.GetRequiredService<IAsyncState>();

// Initialize the state
asyncState.Initialize();

// Set a value
asyncState.Value = new RequestInfo 
{ 
    RequestId = Guid.NewGuid().ToString(),
    Timestamp = DateTimeOffset.UtcNow
};

// Access the value
Console.WriteLine($"Request ID: {asyncState.Value.RequestId}");

// Reset the state
asyncState.Reset();
// </snippet>

// <RequestInfo>
public class RequestInfo
{
    public required string RequestId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}
// </RequestInfo>

---
title: Request context
description: Learn about request context in .NET Orleans.
ms.date: 07/03/2024
ms.topic: how-to
---

# Request context

The <xref:Orleans.Runtime.RequestContext> is an Orleans feature that allows application metadata, such as a trace ID, to flow with requests. Application metadata may be added on the client; it will flow with Orleans requests to the receiving grain. The feature is implemented by a public static class, `RequestContext`, in the Orleans namespace. This class exposes two simple methods:

```csharp
void Set(string key, object value)
```

The preceding API is used to store a value in the request context. The value can be any serializable type.

```csharp
object Get(string key)
```

The preceding API is used to retrieve a value from the current request context.

The backing storage for `RequestContext` is async-local. When a caller (whether client-side or within Orleans) sends a request, the contents of the caller's `RequestContext` are included with the Orleans message for the request; when the grain code receives the request, that metadata is accessible from the local `RequestContext`. If the grain code does not modify the `RequestContext`, then any grain it requests to will receive the same metadata, and so on.

Application metadata also is maintained when you schedule a future computation using <xref:System.Threading.Tasks.TaskFactory.StartNew%2A> or <xref:System.Threading.Tasks.Task.ContinueWith%2A>; in both cases, the continuation will execute with the same metadata as the scheduling code had at the moment the computation was scheduled (that is, the system makes a copy of the current metadata and passes it to the continuation, so changes after the call to `StartNew` or `ContinueWith` will not be seen by the continuation).

> [!IMPORTANT]
> The application metadata does not flow back with responses; that is, code that runs as a result of a response being received, either within a `ContinueWith` continuation or after a call to <xref:System.Threading.Tasks.Task.Wait?displayProperty=nameWithType> or `GetValue`, will still run within the current context that was set by the original request.

For example, to set a trace id in the client to a new `Guid`, you call:

```csharp
RequestContext.Set("TraceId", Guid.NewGuid());
```

Within grain code (or other code that runs within Orleans on a scheduler thread), the trace id of the original client request could be used, for instance, when writing a log:

```csharp
Logger.LogInformation(
    "Currently processing external request {TraceId}",
    RequestContext.Get("TraceId"));
```

While any serializable `object` may be sent as application metadata, it's worth mentioning that large or complex objects may add noticeable overhead to message serialization time. For this reason, the use of simple types (strings, GUIDs, or numeric types) is recommended.

## Example grain code

To help illustrate the use of a request context, consider the following example grain code:

```csharp
using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains;

public class HelloGrain(ILogger<HelloGrain> logger) : Grain, IHelloGrain
{
    ValueTask<string> IHelloGrain.SayHello(string greeting)
    {
        _logger.LogInformation("""
            SayHello message received: greeting = "{Greeting}"
            """,
            greeting);
        
        var traceId = RequestContext.Get("TraceId") as string 
            ?? "No trace ID";

        return ValueTask.FromResult($"""
            TraceID: {traceId}
            Client said: "{greeting}", so HelloGrain says: Hello!
            """);
    }
}

public interface IHelloGrain : IGrainWithStringKey
{
    ValueTask<string> SayHello(string greeting);
}
```

The `SayHello` method logs the incoming `greeting` parameter and then retrieves the trace id from the request context. If no trace id is found, the grain logs "No trace ID".

## Example client code

The client is able to set the trace id in the request context before calling the `SayHello` method on the `HelloGrain`. The following client code demonstrates how to set a trace id in the request context and call the `SayHello` method on the `HelloGrain`:

```csharp
﻿using GrainInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.UseLocalhostClustering())
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();

var grain = client.GetGrain<IHelloGrain>("friend");

var id = "example-id-set-by-client";

RequestContext.Set("TraceId", id);

var message = await friend.SayHello("Good morning!");

Console.WriteLine(message);
// Output:
//   TraceID: example-id-set-by-client
//   Client said: "Good morning!", so HelloGrain says: Hello!
```

In this example, the client sets the trace id to "example-id-set-by-client" before calling the `SayHello` method on the `HelloGrain`. The grain retrieves the trace id from the request context and logs it.

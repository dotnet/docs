---
title: Types of RPC - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Types of RPC

As a WCF developer you are probably used to dealing with the following types of RPC:

- Request/Reply
- Duplex:
  - One way duplex with session
  - Full duplex with session
- One-way

It is possible to map these RPC types fairly naturally to existing gRPC concepts and this chapter will look at each of these areas in turn. Similar examples will be explored in much greater depth in [Chapter 5](migrating-wcf-to-grpc.md).

| WCF | gRPC |
| --- | ---- |
| Regular request/reply | Unary |
| Duplex service with session using a client callback interface | Server streaming |
| Full duplex service with session | Bi-directional streaming |
| One-way operations | Client streaming |

## Request/reply

For simple request/reply methods that take and return small amounts of data, use the simplest gRPC pattern, the unary RPC.

```protobuf
service Things {
    rpc Get(GetThingRequest) returns (GetThingResponse);
}
```

```csharp
public class ThingService : Things.ThingsBase
{
    public override async Task<GetThingResponse> Get(GetThingRequest request, ServerCallContext context)
    {
        // Get thing from database
        return new GetThingResponse { Thing = thing };
    }
}
```

```csharp
public async Task ShowThing(int thingId)
{
    var thing = await _thingsClient.GetAsync(new GetThingRequest { ThingId = thingId });
    Console.WriteLine($"{thing.Name}");
}
```

As you can see, implementing a gRPC unary RPC service method is very similar to implementing a WCF operation, except that with gRPC you override a base class method instead of implementing an interface. Note that on the server, gRPC base methods always return a `Task<T>`, although the client provides both async and blocking methods to call the service.

## WCF duplex, one-way to client

WCF applications (with certain bindings) can create a persistent connection between client and server, and the server can asynchronously send data to the client until the connection is closed, using a *callback interface*.

gRPC services can work with streams of messages, in either or both directions. This does not map exactly to WCF Duplex, but the same result can be achieved.

Here is an example of a server streaming RPC.

```protobuf
service ThingStreamer {
    rpc Subscribe(SubscribeRequest) returns (stream Thing);
}
```

```csharp
{
    public class ThingStreamerService : ThingStreamer.ThingStreamerBase
    {
        public override async Task Subscribe(SubscribeRequest request,
            IServerStreamWriter<Thing> responseStream,
            ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var thing = await _things.GetNext();
                await responseStream.WriteAsync(new Thing { name = thing.Name});
            }
        }
    }
}
```

```csharp
public async Task GetThingsAsync(CancellationToken token)
{
    var request = new SubscribeRequest();
    var response = _thingsClient.Subscribe(request);

    while (await response.ResponseStream.MoveNext(token))
    {
        var update = response.ResponseStream.Current;
        UpdateThingDisplay(update.Name);
    }
}
```

> [!NOTE]
> Server streaming RPCs are useful for subscription-style services, and also for sending very large datasets when it would be inefficient or impossible to build the entire dataset in memory. However, streaming responses is not as fast as sending `repeated` fields in a single message, so as a rule streaming should not be used for small datasets.

### Differences to WCF

A WCF duplex service uses a client callback interface that can have multiple methods. A gRPC server streaming service can only send messages over a single stream. If you need multiple methods, use a message type with either [an Any field or a oneof field](protobuf-any-oneof.md) to send different messages, and write code in the client to handle them.

In WCF, the one-way method called from the client returns immediately, but the `ServiceContract` class with the session is kept alive until the connection is terminated. In gRPC, the Task returned by the implementation method should not complete until the connection is closed.

## WCF one-way operations and gRPC client streaming

WCF provides One-Way operations (marked with `[OperationContract(IsOneWay = true)]`) that the client can call without waiting for a response. gRPC service methods always return a response, even if it is empty, and the client should always `await` that response. For "fire-and-forget" style messaging in gRPC, you can create a Client Streaming service.

### thing_log.proto

```protobuf
service ThingLog {
  rpc OpenConnection(stream Thing) returns (ConnectionClosedResponse);
}
```

### ThingLogService.cs

```csharp
public class ThingLogService : Protos.ThingLog.ThingLogBase
{
    private readonly ILogger<ThingLogService> _logger;
    public ThingLogService(ILogger<ThingLogService> logger)
    {
        _logger = logger;
    }

    public override async Task<CompletedResponse> OpenConnection(IAsyncStreamReader<Thing> requestStream, ServerCallContext context)
    {
        while (await requestStream.MoveNext(context.CancellationToken))
        {
            _logger.LogInformation(requestStream.Current.Description);
        }
        return new ConnectionClosedResponse();
    }
}
```

### ThingLog client example

```csharp
public class ThingLogger : IAsyncDisposable
{
    private readonly ThingLog.ThingLogClient _client;
    private readonly AsyncClientStreamingCall<ThingLogRequest, CompletedResponse> _stream;

    public ThingLogger(ThingLog.ThingLogClient client)
    {
        _client = client;
        _stream = client.OpenConnection();
    }

    public async Task WriteAsync(string description)
    {
        await _stream.RequestStream.WriteAsync(new Thing
        {
            Description = description,
            Time = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
        });
    }

    public async ValueTask DisposeAsync()
    {
        await _stream.RequestStream.CompleteAsync();
        _stream.Dispose();
    }
}
```

Again, client streaming RPCs can be used for fire-and-forget messaging as shown above, but also for sending very large datasets to the server. The same caveat regarding performance applies: you should used `repeated` fields in regular messages for smaller datasets.

## WCF full duplex services

WCF duplex binding supports multiple one-way operations on both the service interface and the client callback interface, allowing ongoing conversations between client and server. gRPC supports something similar with Bi-directional Streaming RPCs, where both parameters are marked with the `stream` modifier.

### chat.proto

```protobuf
service Chatter {
    rpc Connect(stream IncomingMessage) returns (stream OutgoingMessage);
}
```

### ChatterService.cs

```csharp
public class ChatterService : Chatter.ChatterBase
{
    private readonly IChatHub _hub;

    public ChatterService(IChatHub hub)
    {
        _hub = hub;
    }

    public override async Task Connect(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        _hub.MessageReceived += async (sender, args) =>
            await responseStream.WriteAsync(new MessageResponse {Text = args.Message});

        while (await requestStream.MoveNext(context.CancellationToken))
        {
            await _hub.SendAsync(requestStream.Current.Text);
        }
    }
}
```

Here you can see that the implementation method receives both a request stream (`IAsyncStreamReader<MessageRequest>`) and a response stream (`IServerStreamWriter<MessageResponse>`), and can read and write messages until the connection is closed.

### Chatter client

```csharp
public class Chat : IAsyncDisposable
{
    private readonly Chatter.ChatterClient _client;
    private readonly AsyncDuplexStreamingCall<MessageRequest, MessageResponse> _stream;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Task _readTask;

    public Chat(Chatter.ChatterClient client)
    {
        _client = client;
        _stream = _client.Connect();
        _cancellationTokenSource = new CancellationTokenSource();
        _readTask = ReadAsync(_cancellationTokenSource.Token);
    }

    public async Task SendAsync(string message)
    {
        await _stream.RequestStream.WriteAsync(new MessageRequest {Text = message});
    }

    private async Task ReadAsync(CancellationToken token)
    {
        while (await _stream.ResponseStream.MoveNext(token))
        {
            Console.WriteLine(_stream.ResponseStream.Current.Text);
        }
    }

    public async ValueTask DisposeAsync()
    {
        _cancellationTokenSource.Cancel();
        await _readTask;
        await _stream.RequestStream.CompleteAsync();
        _stream.Dispose();
    }
}
```

>[!div class="step-by-step"]
<!-->[Next](metadata.md)-->

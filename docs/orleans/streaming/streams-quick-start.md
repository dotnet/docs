---
title: Orleans streaming quickstart
description: Learn from the streaming quickstart in .NET Orleans.
ms.date: 03/30/2025
ms.topic: quickstart
ms.service: orleans
zone_pivot_groups: orleans-version
---

# Orleans streaming quickstart

This guide shows you a quick way to set up and use Orleans Streams. To learn more about the details of streaming features, read other parts of this documentation.

## Required configurations

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

In this guide, you use a memory-based stream that uses grain messaging to send stream data to subscribers. You use the in-memory storage provider to store lists of subscriptions. Using memory-based mechanisms for streaming and storage is intended only for local development and testing, not for production environments.

On the silo, where `silo` is an <xref:Orleans.Hosting.ISiloBuilder>, call <xref:Orleans.Hosting.SiloBuilderExtensions.AddMemoryStreams%2A>:

```csharp
silo.AddMemoryStreams("StreamProvider")
    .AddMemoryGrainStorage("PubSubStore");
```

On the cluster client, where `client` is an <xref:Orleans.Hosting.IClientBuilder>, call <xref:Orleans.Hosting.ClientBuilderStreamingExtensions.AddMemoryStreams%2A>.

```csharp
client.AddMemoryStreams("StreamProvider");

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

In this guide, use a simple message-based stream that uses grain messaging to send stream data to subscribers. Use the in-memory storage provider to store lists of subscriptions; this isn't a wise choice for real production applications.

On the silo, where `hostBuilder` is an `ISiloHostBuilder`, call <xref:Orleans.Hosting.StreamHostingExtensions.AddSimpleMessageStreamProvider%2A>:

```csharp
hostBuilder.AddSimpleMessageStreamProvider("SMSProvider")
           .AddMemoryGrainStorage("PubSubStore");
```

On the cluster client, where `clientBuilder` is an `IClientBuilder`, call <xref:Orleans.Hosting.ClientStreamExtensions.AddSimpleMessageStreamProvider%2A>.

```csharp
clientBuilder.AddSimpleMessageStreamProvider("SMSProvider");
```

> [!NOTE]
> By default, messages passed over the Simple Message Stream are considered immutable and might be passed by reference to other grains. To turn off this behavior, configure the SMS provider to turn off <xref:Orleans.Configuration.SimpleMessageStreamProviderOptions.OptimizeForImmutableData?displayProperty=nameWithType>.

```csharp
siloBuilder
    .AddSimpleMessageStreamProvider(
        "SMSProvider",
        options => options.OptimizeForImmutableData = false);
```

:::zone-end

You can create streams, send data using them as producers, and receive data as subscribers.

## Produce events

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

It's relatively easy to produce events for streams. First, get access to the stream provider defined in the config previously (`"StreamProvider"`), then choose a stream and push data to it.

```csharp
// Pick a GUID for a chat room grain and chat room stream
var guid = new Guid("some guid identifying the chat room");
// Get one of the providers which we defined in our config
var streamProvider = GetStreamProvider("StreamProvider");
// Get the reference to a stream
var streamId = StreamId.Create("RANDOMDATA", guid);
var stream = streamProvider.GetStream<int>(streamId);
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

It's relatively easy to produce events for streams. First, get access to the stream provider defined in the config previously (`"SMSProvider"`), then choose a stream and push data to it.

```csharp
// Pick a GUID for a chat room grain and chat room stream
var guid = new Guid("some guid identifying the chat room");
// Get one of the providers which we defined in our config
var streamProvider = GetStreamProvider("SMSProvider");
// Get the reference to a stream
var stream = streamProvider.GetStream<int>(guid, "RANDOMDATA");
```

:::zone-end

As you can see, the stream has a GUID and a namespace. This makes it easy to identify unique streams. For example, the namespace for a chat room could be "Rooms", and the GUID could be the owning `RoomGrain`'s GUID.

Here, use the GUID of a known chat room. Using the `OnNextAsync` method of the stream, push data to it. Let's do this inside a timer using random numbers. You could use any other data type for the stream as well.

```csharp
RegisterTimer(_ =>
{
    return stream.OnNextAsync(Random.Shared.Next());
},
null,
TimeSpan.FromMilliseconds(1_000),
TimeSpan.FromMilliseconds(1_000));
```

## Subscribe to and receive streaming data

For receiving data, you can use implicit and explicit subscriptions, described in more detail at [Explicit and implicit subscriptions](streams-programming-apis.md#explicit-and-implicit-subscriptions). This example uses implicit subscriptions, which are easier. When a grain type wants to implicitly subscribe to a stream, it uses the attribute `[ImplicitStreamSubscription(namespace)]`.

For your case, define a `ReceiverGrain` like this:

```csharp
[ImplicitStreamSubscription("RANDOMDATA")]
public class ReceiverGrain : Grain, IRandomReceiver
```

Whenever data is pushed to streams in the `RANDOMDATA` namespace (as in the timer example), a grain of type `ReceiverGrain` with the same `Guid` as the stream receives the message. Even if no activations of the grain currently exist, the runtime automatically creates a new one and sends the message to it.

For this to work, complete the subscription process by setting the `OnNextAsync` method for receiving data. To do so, the `ReceiverGrain` should call something like this in its `OnActivateAsync`:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
// Create a GUID based on our GUID as a grain
var guid = this.GetPrimaryKey();

// Get one of the providers which we defined in config
var streamProvider = GetStreamProvider("StreamProvider");

// Get the reference to a stream
var streamId = StreamId.Create("RANDOMDATA", guid);
var stream = streamProvider.GetStream<int>(streamId);

// Set our OnNext method to the lambda which simply prints the data.
// This doesn't make new subscriptions, because we are using implicit
// subscriptions via [ImplicitStreamSubscription].
await stream.SubscribeAsync<int>(
    async (data, token) =>
    {
        Console.WriteLine(data);
        await Task.CompletedTask;
    });
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
// Create a GUID based on our GUID as a grain
var guid = this.GetPrimaryKey();

// Get one of the providers which we defined in config
var streamProvider = GetStreamProvider("SMSProvider");

// Get the reference to a stream
var stream = streamProvider.GetStream<int>(guid, "RANDOMDATA");

// Set our OnNext method to the lambda which simply prints the data.
// This doesn't make new subscriptions, because we are using implicit
// subscriptions via [ImplicitStreamSubscription].
await stream.SubscribeAsync<int>(
    async (data, token) =>
    {
        Console.WriteLine(data);
        await Task.CompletedTask;
    });
```

:::zone-end

You're all set! Now, the only requirement is that something triggers the producer grain's creation. Then, it registers the timer and starts sending random integers to all interested parties.

Again, this guide skips many details and only provides a high-level overview. Read other parts of this manual and other resources on Rx to gain a good understanding of what's available and how it works.

Reactive programming can be a powerful approach to solving many problems. For example, you could use LINQ in the subscriber to filter numbers and perform various interesting operations.

## See also

[Orleans Streams Programming APIs](streams-programming-apis.md)

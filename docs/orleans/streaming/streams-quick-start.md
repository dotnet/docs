---
title: Orleans streaming quickstart
description: Learn from the streaming quickstart in .NET Orleans.
ms.date: 12/06/2022
zone_pivot_groups: orleans-version
---

# Orleans streaming quickstart

This guide will show you a quick way to set up and use Orleans Streams.
To learn more about the details of the streaming features, read other parts of this documentation.

## Required configurations

In this guide, we'll use a simple message-based stream that uses grain messaging to send stream data to subscribers. We will use the in-memory storage provider to store lists of subscriptions, so it is not a wise choice for real production applications.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

On the silo, where `hostBuilder` is an `ISiloHostBuilder`:

```csharp
hostBuilder.AddMemoryStreams("StreamProvider")
           .AddMemoryGrainStorage("PubSubStore");
```

On the cluster client, where `clientBuilder` is an `IClientBuilder`.

```csharp
clientBuilder.AddMemoryStreams("StreamProvider");

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

On the silo, where `hostBuilder` is an `ISiloHostBuilder`:

```csharp
hostBuilder.AddSimpleMessageStreamProvider("SMSProvider")
           .AddMemoryGrainStorage("PubSubStore");
```

On the cluster client, where `clientBuilder` is an `IClientBuilder`.

```csharp
clientBuilder.AddSimpleMessageStreamProvider("SMSProvider");
```

> [!NOTE]
> By default, messages that are passed over the Simple Message Stream are considered immutable, and may be passed by reference to other grains.  To turn off this behavior, you must config the SMS provider to turn off <xref:Orleans.Configuration.SimpleMessageStreamProviderOptions.OptimizeForImmutableData?displayProperty=nameWithType>

```csharp
siloBuilder
    .AddSimpleMessageStreamProvider(
        "SMSProvider",
        options => options.OptimizeForImmutableData = false);
```

:::zone-end

You can create streams, send data using them as producers and also receive data as subscribers.

## Producing events

Producing events for streams is relatively easy. You should first get access to the stream provider which you defined in the config above (`"SMSProvider"`) and then choose a stream and push data to it.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
// Pick a GUID for a chat room grain and chat room stream
var guid = new Guid("some guid identifying the chat room");
// Get one of the providers which we defined in our config
var streamProvider = GetStreamProvider("SMSProvider");
// Get the reference to a stream
var streamId = StreamId.Create("RANDOMDATA", guid);
var stream = streamProvider.GetStream<int>(streamId);
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
// Pick a GUID for a chat room grain and chat room stream
var guid = new Guid("some guid identifying the chat room");
// Get one of the providers which we defined in our config
var streamProvider = GetStreamProvider("SMSProvider");
// Get the reference to a stream
var stream = streamProvider.GetStream<int>(guid, "RANDOMDATA");
```

:::zone-end

As you can see, our stream has a GUID and a namespace. This will make it easy to identify unique streams. For example, the namespace for a chat room can be "Rooms" and the GUID can be the owning RoomGrain's GUID.

Here we use the GUID of some known chat room. Using the `OnNextAsync` method of the stream we can push data to it. Let's do it inside a timer, using random numbers. You could use any other data type for the stream as well.

```csharp
RegisterTimer(_ =>
{
    return stream.OnNextAsync(Random.Shared.Next());
},
null,
TimeSpan.FromMilliseconds(1_000),
TimeSpan.FromMilliseconds(1_000));
```

## Subscribing and receiving streaming data

For receiving data, we can use implicit/explicit subscriptions, which are fully described in other pages of the manual. Here we use implicit subscriptions, which are easier. When a grain type wants to implicitly subscribe to a stream, it uses the attribute [[ImplicitStreamSubscription (namespace)]](xref:Orleans.ImplicitStreamSubscriptionAttribute).

For our case we'll define a `ReceiverGrain` like this:

```csharp
[ImplicitStreamSubscription("RANDOMDATA")]
public class ReceiverGrain : Grain, IRandomReceiver
```

Whenever data is pushed to the streams of the namespace `RANDOMDATA`, as we have in the timer, a grain of type `ReceiverGrain` with the same `Guid` of the stream will receive the message. Even if no activations of the grain currently exist, the runtime will automatically create a new one and send the message to it.

For this to work, we need to complete the subscription process by setting our `OnNextAsync` method for receiving data. To do so, our `ReceiverGrain` should call something like this in its `OnActivateAsync`

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
// Create a GUID based on our GUID as a grain
var guid = this.GetPrimaryKey();

// Get one of the providers which we defined in config
var streamProvider = GetStreamProvider("SMSProvider");

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

You're all set! Now the only requirement is that something triggers the producer grain's creation, and then it will register the timer and start sending random ints to all interested parties.

Again, this guide skips lots of details and is only good for showing the big picture. Read other parts of this manual and other resources on RX to gain a good understanding of what is available and how.

Reactive programming can be a very powerful approach to solving many problems. You could for example use LINQ in the subscriber to filter numbers and do all sorts of interesting stuff.

## See also

[Orleans Streams Programming APIs](streams-programming-apis.md)

---
title: Orleans streaming APIs
description: Learn about the available streaming APIs for .NET Orleans.
ms.date: 12/06/2022
zone_pivot_groups: orleans-version
---

# Orleans streaming APIs

Applications interact with streams via APIs that are very similar to the well-known [Reactive Extensions (Rx) in .NET](/previous-versions/dotnet/reactive-extensions/hh242985(v=vs.103)). The main difference is that Orleans stream extensions are **asynchronous**, to make processing more efficient in Orleans' distributed and scalable compute fabric.

### Async stream

An application starts by using a *stream provider* to get a handle to a stream. You can read more about stream providers [here](stream-providers.md), but for now, you can think of it as a stream factory that allows implementers to customize streams behavior and semantics:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
IStreamProvider streamProvider = base.GetStreamProvider("SimpleStreamProvider");
StreamId streamId = StreamId.Create("MyStreamNamespace", Guid);
IAsyncStream<T> stream = streamProvider.GetStream<T>(streamId);
```

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
IStreamProvider streamProvider = base.GetStreamProvider("SimpleStreamProvider");
IAsyncStream<T> stream = streamProvider.GetStream<T>(Guid, "MyStreamNamespace");
```

:::zone-end

An application can get a reference to the stream provider either by calling the <xref:Orleans.Grain.GetStreamProvider%2A?displayProperty=nameWithType> method when inside a grain, or by calling the <xref:Orleans.GrainClient.GetStreamProvider%2A?displayProperty=nameWithType> method when on the client.

<xref:Orleans.Streams.IAsyncStream%601?displayProperty=nameWithType> is a logical, strongly typed handle to a virtual stream. It's similar in spirit to Orleans Grain Reference. Calls to `GetStreamProvider` and `GetStream` are purely local. The arguments to `GetStream` are a GUID and an additional string that we call a stream namespace (which can be null). Together the GUID and the namespace string comprise the stream identity (similar in spirit to the arguments to <xref:Orleans.IGrainFactory.GetGrain%2A?displayProperty=nameWithType>). The combination of GUID and namespace string provide extra flexibility in determining stream identities. Just like grain 7 may exist within the Grain type `PlayerGrain` and a different grain 7 may exist within the grain type `ChatRoomGrain`, Stream 123 may exist with the stream namespace `PlayerEventsStream` and a different stream 123 may exist within the stream namespace `ChatRoomMessagesStream`.

### Producing and consuming

<xref:Orleans.Streams.IAsyncStream%601> implements both the <xref:Orleans.Streams.IAsyncObserver%601> and <xref:Orleans.Streams.IAsyncObservable%601> interfaces. That way an application can use the stream either to produce new events into the stream by using `Orleans.Streams.IAsyncObserver<T>` or to subscribe to and consume events from a stream by using `Orleans.Streams.IAsyncObservable<T>`.

```csharp
public interface IAsyncObserver<in T>
{
    Task OnNextAsync(T item, StreamSequenceToken token = null);
    Task OnCompletedAsync();
    Task OnErrorAsync(Exception ex);
}

public interface IAsyncObservable<T>
{
    Task<StreamSubscriptionHandle<T>> SubscribeAsync(IAsyncObserver<T> observer);
}
```

To produce events into the stream, an application just calls

```csharp
await stream.OnNextAsync<T>(event)
```

To subscribe to a stream, an application calls

```csharp
StreamSubscriptionHandle<T> subscriptionHandle = await stream.SubscribeAsync(IAsyncObserver)
```

The argument to <xref:Orleans.Streams.AsyncObservableExtensions.SubscribeAsync%2A> can either be an object that implements the <xref:Orleans.Streams.IAsyncObserver%601> interface or a combination of lambda functions to process incoming events. More options for `SubscribeAsync` are available via <xref:Orleans.Streams.AsyncObservableExtensions> class. `SubscribeAsync` returns a <xref:Orleans.Streams.StreamSubscriptionHandle%601>, which is an opaque handle that can be used to unsubscribe from the stream (similar in spirit to an asynchronous version of <xref:System.IDisposable>).

```csharp
await subscriptionHandle.UnsubscribeAsync()
```

It is important to note that the subscription is for a grain, not for activation. Once the grain code is subscribed to the stream, this subscription surpasses the life of this activation and stays durable forever, until the grain code (potentially in a different activation) explicitly unsubscribes. This is the heart of a virtual stream abstraction: not only do all streams always exist, logically, but also a stream subscription is durable and lives beyond a particular physical activation that created the subscription.

### Multiplicity

An Orleans stream may have multiple producers and multiple consumers. A message published by a producer will be delivered to all consumers that were subscribed to the stream before the message was published.

In addition, the consumer can subscribe to the same stream multiple times. Each time it subscribes it gets back a unique <xref:Orleans.Streams.StreamSubscriptionHandle%601>. If a grain (or client) is subscribed X times to the same stream, it will receive the same event X times, once for each subscription. The consumer can also unsubscribe from an individual subscription. It can find all its current subscriptions by calling:

```csharp
IList<StreamSubscriptionHandle<T>> allMyHandles =
    await IAsyncStream<T>.GetAllSubscriptionHandles();
```

### Recovering from failures

If the producer of a stream dies (or its grain is deactivated), there is nothing it needs to do. The next time this grain wants to produce more events it can get the stream handle again and produce new events in the same way.

Consumer logic is a little bit more involved. As we said before, once a consumer grain is subscribed to a stream, this subscription is valid until the grain explicitly unsubscribes. If the consumer of the stream dies (or its grain is deactivated) and a new event is generated on the stream, the consumer grain will be automatically re-activated (just like any regular Orleans grain is automatically activated when a message is sent to it). The only thing that the grain code needs to do now is to provide an <xref:Orleans.Streams.IAsyncObserver%601> to process the data. The consumer needs to re-attach processing logic as part of the <xref:Orleans.Grain.OnActivateAsync> method. To do that it can call:

```csharp
StreamSubscriptionHandle<int> newHandle =
    await subscriptionHandle.ResumeAsync(IAsyncObserver);
```

The consumer uses the previous handle it got when it first subscribed to "resume processing". Notice that <xref:Orleans.Streams.StreamSubscriptionHandle%601.ResumeAsync%2A> merely updates an existing subscription with the new instance of `IAsyncObserver` logic and does not change the fact that this consumer is already subscribed to this stream.

How does the consumer get an old `subscriptionHandle`? There are 2 options. The consumer may have persisted the handle it was given back from the original `SubscribeAsync` operation and can use it now. Alternatively, if the consumer does not have the handle, it can ask the `IAsyncStream<T>` for all its active subscription handles, by calling:

```csharp
IList<StreamSubscriptionHandle<T>> allMyHandles =
    await IAsyncStream<T>.GetAllSubscriptionHandles();
```

The consumer can now resume all of them or unsubscribe from some if it wishes to.

> [!TIP]
> If the consumer grain implements the <xref:Orleans.Streams.IAsyncObserver%601> interface directly (`public class MyGrain<T> : Grain, IAsyncObserver<T>`), it should in theory not be required to re-attach the `IAsyncObserver` and thus will not need to call `ResumeAsync`. The streaming runtime should be able to automatically figure out that the grain already implements `IAsyncObserver` and will just invoke those `IAsyncObserver` methods. However, the streaming runtime currently does not support this and the grain code still needs to explicitly call `ResumeAsync`, even if the grain implements `IAsyncObserver` directly.

### Explicit and implicit subscriptions

By default, a stream consumer has to explicitly subscribe to the stream. This subscription would usually be triggered by some external message that the grain (or client) receives that instructs it to subscribe. For example, in a chat service when a user joins a chat room his grain receives a `JoinChatGroup` message with the chat name, which will cause the user grain to subscribe to this chat stream.

In addition, Orleans streams also support *implicit subscriptions*. In this model, the grain does not explicitly subscribe to the stream. This grain is subscribed automatically, implicitly, just based on its grain identity and an <xref:Orleans.ImplicitStreamSubscriptionAttribute>. Implicit subscriptions' main value is allowing the stream activity to trigger the grain activation (hence triggering the subscription) automatically. For example, using SMS streams, if one grain wanted to produce a stream and another grain process this stream, the producer would need to know the identity of the consumer grain and make a grain call to it telling it to subscribe to the stream. Only after that can it start sending events. Instead, using implicit subscriptions, the producer can just start producing events to a stream, and the consumer grain will automatically be activated and subscribe to the stream. In that case, the producer doesn't care at all who is reading the events

The grain implementation `MyGrainType` can declare an attribute `[ImplicitStreamSubscription("MyStreamNamespace")]`. This tells the streaming runtime that when an event is generated on a stream whose identity is GUID XXX and `"MyStreamNamespace"` namespace, it should be delivered to the grain whose identity is XXX of type `MyGrainType`. That is, the runtime maps stream `<XXX, MyStreamNamespace>` to consumer grain `<XXX, MyGrainType>`.

The presence of `ImplicitStreamSubscription`causes the streaming runtime to automatically subscribe this grain to a stream and deliver the stream events to it. However, the grain code still needs to tell the runtime how it wants events to be processed. Essentially, it needs to attach the `IAsyncObserver`. Therefore, when the grain is activated, the grain code inside `OnActivateAsync` needs to call:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
IStreamProvider streamProvider =
    base.GetStreamProvider("SimpleStreamProvider");

StreamId streamId =
    StreamId.Create("MyStreamNamespace", this.GetPrimaryKey());
IAsyncStream<T> stream =
    streamProvider.GetStream<T>(streamId);

StreamSubscriptionHandle<T> subscription =
    await stream.SubscribeAsync(IAsyncObserver<T>);
```

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
IStreamProvider streamProvider =
    base.GetStreamProvider("SimpleStreamProvider");

IAsyncStream<T> stream =
    streamProvider.GetStream<T>(this.GetPrimaryKey(), "MyStreamNamespace");

StreamSubscriptionHandle<T> subscription =
    await stream.SubscribeAsync(IAsyncObserver<T>);
```

:::zone-end

### Writing subscription logic

Below are the guidelines on how to write the subscription logic for various cases: explicit and implicit subscriptions, rewindable and non-rewindable streams. The main difference between explicit and implicit subscriptions is that for implicit the grain always has exactly one implicit subscription for every stream namespace; there is no way to create multiple subscriptions (there is no subscription multiplicity), there is no way to unsubscribe, and the grain logic always only needs to attach the processing logic. That also means that for implicit subscriptions there is never a need to resume a subscription. On the other hand, for explicit subscriptions, one needs to Resume the subscription, otherwise, if the grain subscribes again it will result in the grain being subscribed multiple times.

**Implicit subscriptions:**

For implicit subscriptions, the grain needs to subscribe to attach the processing logic. This should be done in the grain's `OnActivateAsync` method. The grain should simply execute `await stream.SubscribeAsync(OnNext ...)` in its `OnActivateAsync` method. That will cause this particular activation to attach the `OnNext` function to process that stream. The grain can optionally specify the `StreamSequenceToken` as an argument to `SubscribeAsync`, which will cause this implicit subscription to start consuming from that token. There is never a need for an implicit subscription to call `ResumeAsync`.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
public override async Task OnActivateAsync(CancellationToken cancellationToken)
{
    var streamProvider = GetStreamProvider(PROVIDER_NAME);
    var streamId = StreamId.Create("MyStreamNamespace", GetPrimaryKey());
    var stream = streamProvider.GetStream<string>(streamId);

    await stream.SubscribeAsync(OnNextAsync)
}
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
public override async Task OnActivateAsync()
{
    var streamProvider = GetStreamProvider(PROVIDER_NAME);
    var stream =
        streamProvider.GetStream<string>(
            GetPrimaryKey(), "MyStreamNamespace");

    await stream.SubscribeAsync(OnNextAsync)
}
```

:::zone-end

**Explicit subscriptions:**

For explicit subscriptions, a grain must call `SubscribeAsync` to subscribe to the stream.  This creates a subscription, as well as attaches the processing logic. The explicit subscription will exist until the grain unsubscribes, so if a grain gets deactivated and reactivated, the grain is still explicitly subscribed, but no processing logic will be attached. In this case, the grain needs to re-attach the processing logic. To do that, in its `OnActivateAsync`, the grain first needs to find out what subscriptions it has, by calling <xref:Orleans.Streams.IAsyncStream%601.GetAllSubscriptionHandles?displayProperty=nameWithType>. The grain must execute `ResumeAsync` on each handle it wishes to continue processing or UnsubscribeAsync on any handles it is done with. The grain can also optionally specify the `StreamSequenceToken` as an argument to the `ResumeAsync` calls, which will cause this explicit subscription to start consuming from that token.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
public async override Task OnActivateAsync(CancellationToken cancellationToken)
{
    var streamProvider = GetStreamProvider(PROVIDER_NAME);
    var streamId = StreamId.Create("MyStreamNamespace", GetPrimaryKey());
    var stream = streamProvider.GetStream<string>(streamId);

    var subscriptionHandles = await stream.GetAllSubscriptionHandles();
    if (!subscriptionHandles.IsNullOrEmpty())
    {
        subscriptionHandles.ForEach(
            async x => await x.ResumeAsync(OnNextAsync));
    }
}
```

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
public async override Task OnActivateAsync()
{
    var streamProvider = GetStreamProvider(PROVIDER_NAME);
    var stream =
        streamProvider.GetStream<string>(GetPrimaryKey(), "MyStreamNamespace");

    var subscriptionHandles = await stream.GetAllSubscriptionHandles();
    if (!subscriptionHandles.IsNullOrEmpty())
    {
        subscriptionHandles.ForEach(
            async x => await x.ResumeAsync(OnNextAsync));
    }
}
```

:::zone-end

### Stream order and sequence tokens

The order of event delivery between an individual producer and an individual consumer depends on the stream provider.

With SMS the producer explicitly controls the order of events seen by the consumer by controlling the way the producer publishes them. By default (if the <xref:Orleans.Configuration.SimpleMessageStreamProviderOptions.FireAndForgetDelivery?displayProperty=nameWithType> option for SMS provider is set to false) and if the producer awaits every `OnNextAsync` call, the events arrive in FIFO order. In SMS it is up to the producer to decide how to handle delivery failures that will be indicated by a broken `Task` returned by the `OnNextAsync` call.

Azure Queue streams do not guarantee FIFO order, since the underlying Azure Queues do not guarantee the order in failure cases. (They do guarantee FIFO order in failure-free executions.) When a producer produces the event into Azure Queue, if the queue operation fails, it is up to the producer to attempt another queue and later on deal with potential duplicate messages. On the delivery side, the Orleans Streaming runtime dequeues the event from the queue and attempts to deliver it for processing to consumers. The Orleans Streaming runtime deletes the event from the queue only upon successful processing. If the delivery or processing fails, the event is not deleted from the queue and will automatically re-appear in the queue later. The Streaming runtime will try to deliver it again, thus potentially breaking the FIFO order. The above behavior matches the normal semantics of Azure Queues.

**Application Defined Order**: To deal with the above ordering issues, an application can optionally specify its ordering. This is achieved via a <xref:Orleans.Streams.StreamSequenceToken>, which is an opaque <xref:System.IComparable> object that can be used to order events. A producer can pass an optional `StreamSequenceToken` to the `OnNext` call. This `StreamSequenceToken` will be passed to the consumer and will be delivered together with the event. That way, an application can reason and reconstruct its order independently of the streaming runtime.

### Rewindable streams

Some streams only allow an application to subscribe to them starting at the latest point in time, while other streams allow "going back in time". The latter capability is dependent on the underlying queuing technology and the particular stream provider. For example, Azure Queues only allow consuming the latest enqueued events, while EventHub allows replaying events from an arbitrary point in time (up to some expiration time). Streams that support going back in time are called *rewindable streams*.

The consumer of a rewindable stream can pass a `StreamSequenceToken` to the `SubscribeAsync` call. The runtime will deliver events to it starting from that `StreamSequenceToken`. A null token means the consumer wants to receive events starting from the latest.

The ability to rewind a stream is very useful in recovery scenarios. For example, consider a grain that subscribes to a stream and periodically checkpoints its state together with the latest sequence token. When recovering from a failure, the grain can re-subscribe to the same stream from the latest checkpointed sequence token, thereby recovering without losing any events that were generated since the last checkpoint.

[Event Hubs provider](https://www.nuget.org/packages/Microsoft.Orleans.OrleansServiceBus/) is rewindable. You can find its code on [GitHub: Orleans/Azure/Orleans.Streaming.EventHubs](https://github.com/dotnet/orleans/tree/main/src/Azure/Orleans.Streaming.EventHubs). [SMS](https://www.nuget.org/packages/Microsoft.Orleans.OrleansProviders/) and [Azure Queue](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AzureStorage/) providers are _not_ rewindable.

### Stateless automatically scaled-out processing

By default, Orleans Streaming is targeted to support a large number of relatively small streams, each processed by one or more stateful grains. Collectively, the processing of all the streams together is sharded among a large number of regular (stateful) grains. The application code controls this sharding by assigning stream ids and grain ids and by explicitly subscribing. The goal is sharded stateful processing.

However, there is also an interesting scenario of automatically scaled-out stateless processing. In this scenario, an application has a small number of streams (or even one large stream) and the goal is stateless processing. An example is a global stream of events, where the processing involves decoding each event and potentially forwarding it to other streams for further stateful processing. The stateless scaled-out stream processing can be supported in Orleans via <xref:Orleans.Concurrency.StatelessWorkerAttribute> grains.

**Current Status of Stateless Automatically Scaled-Out Processing:**
This is not yet implemented. An attempt to subscribe to a stream from a `StatelessWorker` grain will result in undefined behavior. [We are considering to support this option](https://github.com/dotnet/orleans/issues/433).

### Grains and Orleans clients

Orleans streams work uniformly across grains and Orleans clients. That is, the same APIs can be used inside a grain and in an Orleans client to produce and consume events. This greatly simplifies the application logic, making special client-side APIs, such as Grain Observers, redundant.

### Fully managed and reliable streaming pub-sub

To track stream subscriptions, Orleans uses a runtime component called **Streaming Pub-Sub** which serves as a rendezvous point for stream consumers and stream producers. Pub-sub tracks all stream subscriptions and persists them, and matches stream consumers with stream producers.

Applications can choose where and how the Pub-Sub data is stored. The Pub-Sub component itself is implemented as grains (called `PubSubRendezvousGrain`), which use Orleans declarative persistence. `PubSubRendezvousGrain` uses the storage provider named `PubSubStore`. As with any grain, you can designate an implementation for a storage provider.  For Streaming Pub-Sub you can change the implementation of the `PubSubStore` at silo construction time using the silo host builder:

The following configures the Pub-Sub to store its state in Azure tables.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
hostBuilder.AddAzureTableGrainStorage("PubSubStore",
    options => options.ConfigureTableServiceClient("<Secret>"));
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
hostBuilder.AddAzureTableGrainStorage("PubSubStore",
    options => options.ConnectionString = "<Secret>");
```

:::zone-end

That way Pub-Sub data will be durably stored in Azure Table. For initial development, you can use memory storage as well. In addition to Pub-Sub, the Orleans Streaming Runtime delivers events from producers to consumers, manages all runtime resources allocated to actively used streams, and transparently garbage collects runtime resources from unused streams.

### Configuration

To use streams you need to enable stream providers via the silo host or cluster client builders. You can read more about stream providers [here](stream-providers.md). Sample stream provider setup:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
hostBuilder.AddMemoryStreams("StreamProvider")
    .AddAzureQueueStreams<AzureQueueDataAdapterV2>("AzureQueueProvider",
        optionsBuilder => optionsBuilder.Configure(
            options => options.ConfigureTableServiceClient("<Secret>")))
    .AddAzureTableGrainStorage("PubSubStore",
        options => options.ConfigureTableServiceClient("<Secret>"));
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
hostBuilder.AddSimpleMessageStreamProvider("SMSProvider")
    .AddAzureQueueStreams<AzureQueueDataAdapterV2>("AzureQueueProvider",
        optionsBuilder => optionsBuilder.Configure(
            options => options.ConnectionString = "<Secret>"))
    .AddAzureTableGrainStorage("PubSubStore",
        options => options.ConnectionString = "<Secret>");
```

:::zone-end

## See also

[Orleans Stream Providers](stream-providers.md)

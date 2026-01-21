---
title: Orleans stream providers
description: Learn about the available stream providers for .NET Orleans.
ms.date: 05/23/2025
ms.topic: article
zone_pivot_groups: orleans-version
---

# Orleans stream providers

Streams can come in different shapes and forms. Some streams might deliver events over direct TCP links, while others deliver events via durable queues. Different stream types might use different batching strategies, caching algorithms, or backpressure procedures. Stream providers are extensibility points in the Orleans Streaming Runtime that allow you to implement any type of stream, avoiding constraints on streaming applications to only a subset of those behavioral choices. This extensibility point is similar in spirit to Orleans storage providers.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0"

## NATS JetStream stream provider

[!INCLUDE [orleans-10-alpha](../includes/orleans-10-alpha.md)]

[NATS](https://nats.io/) is a high-performance, cloud-native messaging system designed for simplicity and speed. [JetStream](https://docs.nats.io/nats-concepts/jetstream) is the built-in distributed persistence system in NATS that provides at-least-once delivery guarantees, stream replay, and durable subscriptions.

The Orleans NATS JetStream stream provider integrates NATS JetStream as a durable streaming backend for Orleans. It uses deterministic subject partitioning to distribute stream messages across multiple partitions, enabling scalable and reliable event processing.

### Installation

Install the [Microsoft.Orleans.Streaming.NATS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.NATS) NuGet package:

```dotnetcli
dotnet add package Microsoft.Orleans.Streaming.NATS
```

### Silo configuration

Configure the NATS stream provider on your Orleans silo using the `AddNatsStreams` extension method:

```csharp
using Orleans.Hosting;
using Orleans.Streaming.NATS;

var builder = Host.CreateApplicationBuilder(args);

builder.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    
    // Add NATS JetStream streaming provider
    siloBuilder.AddNatsStreams("NatsProvider", options =>
    {
        options.StreamName = "orleans-events";
        options.NatsClientOptions = new NatsOpts
        {
            Url = "nats://localhost:4222"
        };
    });
});

var host = builder.Build();
await host.RunAsync();
```

### Client configuration

Configure the NATS stream provider on Orleans clients to enable stream producers:

```csharp
using Orleans.Hosting;
using Orleans.Streaming.NATS;

var builder = Host.CreateApplicationBuilder(args);

builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.UseLocalhostClustering();
    
    // Add NATS JetStream streaming provider
    clientBuilder.AddNatsStreams("NatsProvider", options =>
    {
        options.StreamName = "orleans-events";
        options.NatsClientOptions = new NatsOpts
        {
            Url = "nats://localhost:4222"
        };
    });
});

var host = builder.Build();
await host.RunAsync();
```

### Configuration options

The `NatsOptions` class provides the following configuration options:

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `StreamName` | `string` | (required) | The NATS JetStream stream name. This is required and must be set. |
| `NatsClientOptions` | `NatsOpts` | `null` | NATS client configuration options. If not provided, a default client connects to `localhost:4222`. |
| `BatchSize` | `int` | `100` | Maximum number of messages to fetch in a single batch from NATS. |
| `PartitionCount` | `int` | `8` | Number of partitions for the stream. Maps to NATS deterministic subject partitioning. Increase for more parallelism. |
| `ProducerCount` | `int` | `8` | Number of connections used to send stream messages to NATS JetStream. |
| `JsonSerializerOptions` | `JsonSerializerOptions` | `null` | Custom JSON serialization options for message serialization. |

### Advanced configuration

For more control over the stream provider, use the configurator pattern:

```csharp
siloBuilder.AddNatsStreams("NatsProvider", configurator =>
{
    // Configure NATS connection
    configurator.ConfigureNats(ob => ob.Configure(options =>
    {
        options.StreamName = "orleans-events";
        options.NatsClientOptions = new NatsOpts
        {
            Url = "nats://nats-server:4222",
            Name = "Orleans-Silo"
        };
        options.PartitionCount = 16;
        options.BatchSize = 200;
    }));
    
    // Configure cache size for consuming messages
    configurator.ConfigureCache(cacheSize: 4096);
    
    // Configure partitioning (number of queue mappers)
    configurator.ConfigurePartitioning(numOfparitions: 16);
});
```

### Partitioning

The NATS provider uses deterministic subject token partitioning to distribute messages across partitions. When the provider initializes, it creates a JetStream stream with a subject mapping pattern:

- **Source pattern**: `[Provider-Name].*.*`
- **Target pattern**: `[Provider-Name].{partition([PartitionCount],1,2)}.{wildcard(1)}.{wildcard(2)}`

This ensures that messages with the same stream namespace and key are always routed to the same partition, maintaining ordering guarantees.

> [!IMPORTANT]
> The partition count is set when the JetStream stream is first created. If you need to change the partition count later, you must manually update the stream definition on the NATS server, as the provider won't modify existing streams.

### Producing events

Use the standard Orleans streaming API to produce events:

```csharp
public class ProducerGrain : Grain, IProducerGrain
{
    public async Task SendEventAsync(string message)
    {
        var streamProvider = this.GetStreamProvider("NatsProvider");
        var stream = streamProvider.GetStream<string>("events", "my-stream");
        await stream.OnNextAsync(message);
    }
}
```

### Consuming events

Grains consume events using implicit or explicit subscriptions:

```csharp
[ImplicitStreamSubscription("events")]
public class ConsumerGrain : Grain, IConsumerGrain, IAsyncObserver<string>
{
    public override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
        var streamProvider = this.GetStreamProvider("NatsProvider");
        var stream = streamProvider.GetStream<string>("events", this.GetPrimaryKeyString());
        await stream.SubscribeAsync(this);
    }

    public Task OnNextAsync(string item, StreamSequenceToken? token = null)
    {
        Console.WriteLine($"Received: {item}");
        return Task.CompletedTask;
    }

    public Task OnCompletedAsync() => Task.CompletedTask;

    public Task OnErrorAsync(Exception ex) => Task.CompletedTask;
}
```

### Stream provider comparison

| Feature | NATS JetStream | Azure Event Hub | Azure Queue |
|---------|----------------|-----------------|-------------|
| Delivery guarantee | At-least-once | At-least-once | At-least-once |
| Message ordering | Per-partition | Per-partition | Per-queue |
| Replay capability | Yes | Yes (time-based) | No |
| Cloud provider | Any (self-hosted) | Azure only | Azure only |
| Partitioning | Deterministic subject | Partition key | Multiple queues |
| Throughput | Very high | High | Moderate |
| Latency | Very low | Low | Moderate |
| Persistence | JetStream streams | Event Hub capture | Queue storage |

### NATS server requirements

The NATS stream provider requires:

- **NATS Server 2.2+** with JetStream enabled
- **JetStream storage** configured (file or memory)

To enable JetStream on a NATS server, start it with the `-js` flag:

```bash
nats-server -js
```

Or configure it in the server configuration file:

```text
jetstream {
    store_dir: /data/jetstream
    max_mem: 1G
    max_file: 10G
}
```

:::zone-end
<!-- markdownlint-enable MD044 -->

## Azure Event Hub stream provider

[Azure Event Hubs](/azure/event-hubs) is a fully managed, real-time data ingestion service capable of receiving and processing millions of events per second. It's designed to handle high-throughput, low-latency data ingestion from multiple sources and subsequent processing of that data by multiple consumers.

Event Hubs is often used as the foundation of a larger event-processing architecture, serving as the "front door" for an event pipeline. You can use it to ingest data from various sources, including social media feeds, IoT devices, and log files. One of the key benefits of Event Hubs is the ability to scale out horizontally to meet the needs of even the largest event-processing workloads. It's also highly available and fault-tolerant, with multiple data replicas distributed across multiple Azure regions to ensure high availability.

The [Microsoft.Orleans.Streaming.EventHubs](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.EventHubs) NuGet package contains the Event Hubs stream provider.

## Azure Queue (AQ) stream provider

The Azure Queue (AQ) stream provider delivers events over Azure Queues. On the producer side, the AQ stream provider enqueues events directly into Azure Queue. On the consumer side, the AQ stream provider manages a set of **pulling agents** that pull events from a set of Azure Queues and deliver them to the application code that consumes them. You can think of the pulling agents as a distributed "microservice"—a partitioned, highly available, and elastic distributed component. The pulling agents run inside the same silos hosting application grains. Thus, there's no need to run separate Azure worker roles to pull from the queues. The Orleans Streaming Runtime fully manages the existence of pulling agents, their management, backpressure, balancing the queues between them, and handing off queues from a failed agent to another agent. This is all transparent to application code using streams.

The [Microsoft.Orleans.Streaming.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AzureStorage) NuGet package contains the [Azure Queue storage](https://azure.microsoft.com/products/storage/queues) stream provider.

## Queue adapters

Different stream providers delivering events over durable queues exhibit similar behavior and are subject to similar implementations. Therefore, we provide a generic extensible <xref:Orleans.Providers.Streams.Common.PersistentStreamProvider> that allows you to plug in different types of queues without writing a completely new stream provider from scratch. `PersistentStreamProvider` uses an <xref:Orleans.Streams.IQueueAdapter> component, which abstracts specific queue implementation details and provides means to enqueue and dequeue events. The logic inside `PersistentStreamProvider` handles everything else. The Azure Queue Provider mentioned above is also implemented this way: it's an instance of `PersistentStreamProvider` that uses an `AzureQueueAdapter`.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

## Simple message stream provider

The simple message stream provider, also known as the SMS provider, delivers events over TCP using regular Orleans grain messaging. Since SMS events are delivered over unreliable TCP links, SMS does _not_ guarantee reliable event delivery and doesn't automatically resend failed messages for SMS streams. By default, the producer's call to <xref:Orleans.Streams.IAsyncObserver%601.OnNextAsync%2A> returns a `Task` representing the stream consumer's processing status. This tells the producer whether the consumer successfully received and processed the event. If this task fails, the producer can decide to send the same event again, achieving reliability at the application level. Although stream message delivery is best-effort, SMS streams themselves are reliable. That is, the subscriber-to-producer binding performed by Pub-Sub is fully reliable.

:::zone-end

## See also

- [Orleans streams implementation details](../implementation/streams-implementation/index.md)

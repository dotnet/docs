---
title: Orleans stream providers
description: Learn about the available stream providers for .NET Orleans.
ms.date: 01/04/2023
zone_pivot_groups: orleans-version
---

# Orleans stream providers

Streams can come in different shapes and forms. Some streams may deliver events over direct TCP links, while others deliver events via durable queues. Different stream types may use different batching strategies, different caching algorithms, or different backpressure procedures. To avoid constraining streaming applications to only a subset of those behavioral choices, stream providers are extensibility points to Orleans Streaming Runtime that allow users to implement any type of stream. This extensibility point is similar in spirit to Orleans Storage providers.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

## Simple message stream provider

The simple message stream provider, also known as the SMS provider, delivers events over TCP by utilizing regular Orleans grain messaging. Since events in SMS are delivered over unreliable TCP links, SMS does _not_ guarantee reliable event delivery and does not automatically resend failed messages for SMS streams. By default, the producer's call to <xref:Orleans.Streams.IAsyncObserver%601.OnNextAsync%2A> returns a `Task` that represents the processing status of the stream consumer, which tells the producer whether the consumer successfully received and processed the event. If this task fails, the producer can decide to send the same event again, thus achieving reliability on the application level. Although stream message delivery is the best effort, SMS streams themselves are reliable. That is, the subscriber-to-producer binding performed by Pub-Sub is fully reliable.

:::zone-end

## Azure Queue (AQ) stream provider

Azure Queue (AQ) stream provider delivers events over Azure Queues. On the producer side, AQ stream provider enqueues events directly into Azure Queue. On the consumer side, the AQ stream provider manages a set of **pulling agents** that pull events from a set of Azure Queues and deliver them to the application code that consumes them. One can think of the pulling agents as a distributed "micro-service" &mdash; a partitioned, highly available, and elastic distributed component. The pulling agents run inside the same silos that host application grains. Thus, there is no need to run separate Azure worker roles to pull from the queues. The existence of pulling agents, their management, backpressure, balancing the queues between them, and handing off queues from a failed agent to another agent are fully managed by Orleans Streaming Runtime and are transparent to application code that uses streams.

## Queue adapters

Different stream providers that deliver events over durable queues exhibit similar behavior and are subject to a similar implementation. Therefore, we provide a generic extensible <xref:Orleans.Providers.Streams.Common.PersistentStreamProvider> that allows developers to plug in different types of queues without writing a completely new stream provider from scratch. `PersistentStreamProvider` uses an <xref:Orleans.Streams.IQueueAdapter> component, which abstracts specific queue implementation details and provides means to enqueue and dequeue events. All the rest is handled by the logic inside the `PersistentStreamProvider`. Azure Queue Provider mentioned above is also implemented this way: it is an instance of `PersistentStreamProvider` that uses an `AzureQueueAdapter`.

## See also

[Orleans Streams Implementation Details](../implementation/streams-implementation/index.md)

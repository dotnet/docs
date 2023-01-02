---
title: Broadcast channels
description: Learn how to work with Orleans broadcast channels.
ms.date: 01/02/2023
---

# Broadcast channels in Orleans

Broadcast channels are a special type of broadcasting mechanism that can be used to send messages to all subscribers. Unlike streaming providers, broadcast channels are not persistent and do not store messages, and they're not a replacement for persistent streams. With broadcast channels, a grain subscribes to the broadcast channel and receives broadcast messages from a producer. This decouples the sender and receiver of the message, which is useful for scenarios where the sender and receiver are not known in advance.

## Example scenario

Consider a scenario where you have a grain that needs to receive stock price updates from a stock price provider. The stock price provider is a background service that publishes stock price updates to a broadcast channel. The grain subscribes to the broadcast channel and receives updated stock prices. The following diagram shows the scenario:

:::image type="content" source="snippets/media/broadcastchannel-diagram.png" lightbox="snippets/media/broadcastchannel-diagram.png" alt-text="Stock prices diagram depicting a silo, a stock grain and consuming client in a simple broadcast channel architecture.":::

In the preceding diagram:

- The silo publishes stock price updates to the broadcast channel.
- The grain subscribes to the broadcast channel and receives stock price updates.
- The client consumes the stock price updates from the stock grain.

The broadcast channel decouples the producer and consumer of the stock price updates. The producer publishes stock price updates to the broadcast channel, and the consumer subscribes to the broadcast channel and receives stock price updates.

## Define a consumer grain

To consume broadcast channel messages, your grain needs to implement the <xref:Orleans.BroadcastChannel.IOnBroadcastChannelSubscribed> interface. Your implementation will use the <xref:Orleans.BroadcastChannel.IBroadcastChannelSubscription.Attach%2A?displayProperty=nameWithType> method to attach to the broadcast channel. The `Attach` method takes a generic-type parameter for the message type you're going to receive. The following example shows a grain that subscribes to a broadcast channel of type `Stock`:

:::code source="./snippets/broadcastchannel/BroadcastChannel.Silo/LiveStockGrain.cs":::

In the preceding code:

- The `LiveStockGrain` grain implements the `IOnBroadcastChannelSubscribed` interface.
- The `OnSubscribed` method is called when the grain subscribes to the broadcast channel.
- The `subscription` parameter is used to call the `Attach` method to attach to the broadcast channel.
  - The `OnStockUpdated` method is passed to `Attach` as a callback that fires when the `Stock` message is received.
  - The `OnError` method is passed to `Attach` as a callback that fires when an error occurs.

This example grain will contain the latest stock prices as published on the broadcast channel. Any client that asks this grain for the latest stock price will get the latest price from the broadcast channel.

## Publish messages to a broadcast channel

To publish messages to the broadcast channel, you need to get a reference to the broadcast channel. To do this, you need to get the <xref:Orleans.BroadcastChannel.IBroadcastChannelProvider> from the <xref:Orleans.IClusterClient>. With the provider, you can call the <xref:Orleans.BroadcastChannel.IBroadcastChannelProvider.GetChannelWriter%2A?displayProperty=nameWithType> method to get an instance of <xref:Orleans.BroadcastChannel.IBroadcastChannelWriter%601>. The writer is used to publish messages to the broadcast channel. The following example shows how to publish messages to the broadcast channel:

:::code source="./snippets/broadcastchannel/BroadcastChannel.Silo/Services/StockWorker.cs":::

In the preceding code:

- The `StockWorker` class is a background service that publishes messages to the broadcast channel.
- The constructor takes an `IStockClient` and <xref:Orleans.IClusterClient> as parameters.
- From the cluster client instance, the <xref:Orleans.Hosting.ChannelHostingExtensions.GetBroadcastChannelProvider%2A> method is used to get the broadcast channel provider.
- Using the `IStockClient`, the `StockWorker` class gets the latest stock price for a stock symbol.
- Every 15 seconds, the `StockWorker` class publishes a `Stock` message to the broadcast channel.

The publishing of messages to a broadcast channel is decoupled from the consumer grain. The consumer grain subscribes to the broadcast channel and receives messages from the broadcast channel. The producer lives in a silo and is responsible for publishing messages to the broadcast channel and doesn't know anything about consuming grains.

## See also

- [Streaming with Orleans](index.md)

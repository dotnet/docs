---
title: The Publish/Subscribe building block
description: A description of the Publish/Subscribe building-block and how to apply it
author: edwinvw
ms.date: 09/25/2020
---

# The Publish/Subscribe building block

The Publish/Subscribe pattern is a well known messaging pattern that has been around for some time and has been applied in many distributed applications. Obviously, Dapr also offers a building block for implementing this pattern.

## What it solves

The main advantage of the Publish/Subscribe pattern, is that the services that send messages (the **producers**) are decoupled from the services that receive the messages (the **consumers**). The producers do not need to know which consumers will consume their messages or where they run. In some implementations it is not even necessary for the consumers to be online when the message is sent by a producer. Once the consumer comes back online, the message is delivered to it and handled by the consumer. Whether or not this is possible has a lot to do with how you transport the messages from the producer to the consumer. We often use something called a **message-broker** as middleware that takes care of transporting the messages. If the message-broker used also supports queuing of messages, then you get this temporal decoupling of producers and consumers as a benefit.

[pub/sub diagram]

There are several message-broker products available - either commercial software as well as open-source software. Each one has its own advantages and drawbacks which you as an application developer have to match with the requirements you have for the system you're building. To make sure the application being built is not tied to a specific message-broker product, often an abstraction layer is created. Although this is a wise decision, it contains a fair amount of code you have to write and maintain. And often this code is also not very trivial and error-prone. This is exactly where Dapr can come to the rescue.

The Dapr Publish/Subscribe building block is an abstraction of the Publish/Subscribe messaging pattern. Because Dapr offers this abstraction, you as an application developer don't need to create and maintain your own abstraction-layer anymore. This offers a productivity boost and gives you more time to actually write software that is valuable for the business.

## How it works

The Dapr Publish/Subscribe building block offers a standard API you can use in your application code to send or receive messages. It is possible to use this API directly over HTTP or gRPC. In order to publish a message using Dapr, you can use the following end-point on the Dapr sidecar:

`http://localhost:<daprPort>/v1.0/publish/<pubsubname>/<topic>`

- You must fill `<daprPort>` with the port the Dapr sidecar is listening on.
- You must fill `<pubsubname>` with the name of the Publish/Subscribe component that must be used (we will come back to components later on).
- You must fill `<topic>` with the name of the topic the message must be published to.

This is a simple example where the command-line tool *curl* is used to publish a message over the Dapr Publish/Subscribe API:

```
curl -X POST http://localhost:3500/v1.0/publish/pubsub/newOrder \
  -H "Content-Type: application/json" \
  -d '{ "orderId": "1234", "productId": "5678", "amount": 2 }'
```

Subscribing to a topic works a bit differently. Upon startup, the Dapr runtime will query your application (using a GET request) on a well-known end-point to ask for the subscriptions you want to create. This is the end-point that will be called:

`http://localhost:<appPort>/dapr/subscribe`

The `<appPort>` part will be filled with the port that your application is listening on. You specify this when starting your application with Dapr.

The application needs to return a response containing the list of topics it wants to subscribe to. With each topic, it also needs to specify the end-point on the application that must be called when a message comes in on that topic. This is what the expected structure of the response is:

```json
[
  {
    "pubsubname": "pubsub",
    "topic": "newOrder",
    "route": "/orders"
  },
  {
    "pubsubname": "pubsub",
    "topic": "newProduct",
    "route": "/productCatalog/products"
  }
]
```

### Using the Dapr .NET SDK

Obviously, using the Dapr APIs over HTTP is fine, but you need to handle serialization, HTTP response codes and things like that yourself. But there is a more convenient way of doing Publish/Subscribe when you use one of the available SDKs. The .NET SDK offers a Dapr client that offers a method for publishing a message using Dapr:

```csharp
public Task PublishEventAsync<TData>(
    string pubsubName,
    string topicName,
    TData data,
    CancellationToken cancellationToken = default);
```

This method can be used to publish a message. The `pubsubName` argument is used to specify the component to use for transporting messages. We will dive into Publish/Subscribe components in more detail later. Messages are always sent to a certain **topic**. The topic can be specified using the `topicName` argument of the method. Receiving messages is possible by subscribing to a certain topic. We will get back to how that exactly works later on.

### Messaging characteristics

Dapr guarantees At-Least-Once semantics for message delivery. That means that when an application publishes a message to a topic using the Publish/Subscribe API, it can assume the message is delivered at least once to any subscriber when the response status code from that endpoint is 200, or returns no error if using the gRPC client.

### Pub/sub components

The actual transport of the messages is handled by Publish/Subscribe components. Several Publish/Subscribe components are available that each abstract a certain message-broker product. At the time of writing, the following Publish/Subscribe components were available:

- Hazelcast
- Redis Streams
- NATS
- Kafka
- Azure Service Bus
- RabbitMQ
- Azure Event Hubs
- GCP Pub/Sub
- MQTT

These components are created by the community in a [component-contrib repository on Github](https://github.com/dapr/components-contrib/tree/master/pubsub). So it is possible to write your own Dapr Publish/Subscribe component for a message-broker that is not yet supported.

### Configuring Publish/Subscribe

You can configure Dapr to use a certain Publish/Subscribe component. The configuration contains several fields, including a **name** field. This name is important because you can configure multiple Publish/Subscribe components for Dapr to use. When you want to send or receive a message, you must specify this name to specify which message-broker to use (as we saw in the `PublishEventAsync` method signature shown above). In the configuration you can also specify any message-broker specific configuration through metadata.

Below you see an example of a Dapr configuration file for configuring a RabbitMQ message-broker component:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub-rq
spec:
  type: pubsub.rabbitmq
  metadata:
  - name: host
    value: "amqp://localhost:5672"
  - name: consumerID
    value: "myCoolService"
  - name: durable
    value: true
```

You can see in this example that you can configure RabbitMQ to create a durable queue for holding messages. Each of the components' configuration will have its own set of possible fields. Which fields are available can be found in the documentation of each Publish/Subscribe component.

## Reference case: eShopOnDapr

[Really quick intro on specific pub/sub stuff in eShop]

### Pub/sub in eShopOnDapr
...


### Benefits compared to eShopOnContainers

....

- Benefit
[TODO Nice integration with ASP.NET Controllers. Doesn't matter how your code called (HTTP request, message), server side is the same.]

## Summary

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
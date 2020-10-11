---
title: The Publish/Subscribe building block
description: A description of the Publish/Subscribe building-block and how to apply it
author: edwinvw
ms.date: 09/25/2020
---

# The Publish/Subscribe building block

The Publish/Subscribe pattern is a well known messaging pattern that has been around for some time and has been applied in many distributed applications. Obviously, Dapr also offers a building block for implementing this pattern.

## What it solves

The main advantage of the Publish/Subscribe pattern, is that the services that send messages (the **producers**) are decoupled from the services that receive the messages (the **consumers**). The producers do not need to know which consumers will consume their messages or where they run. This is possible because with the Publish/Subscribe pattern a central **message-broker** is used to distribute the messages.

![](media/pubsub-pattern.png)

1. Subscribers create a subscription on the message-broker.
2. Publishers send messages to the message-broker.
3. The message-broker forwards a copy of the message to all subscribers.

Some message-brokers offer a queueing mechanism and can persist messages once received. In this case, it is not even necessary for the consumers to be online when the message is sent by a producer. Once the consumer comes back online, the message is delivered to it and can be handled. This offers you temporal decoupling of producers and consumers and helps to decrease coupling between services.

There are several message-broker products available - either commercial software as well as open-source software. Each one has its own advantages and drawbacks which you as an application developer have to match with the requirements you have for the system you're building. To make sure the application being built is not tied to a specific message-broker product, often an abstraction layer is created. Although this is a wise decision, it contains a fair amount of code you have to write and maintain. And often this code is also not very trivial and error-prone. This is exactly where Dapr can come to the rescue.

The Dapr Publish/Subscribe building block is an abstraction of the Publish/Subscribe messaging pattern. Because Dapr offers this abstraction, you as an application developer don't need to create and maintain your own abstraction-layer anymore. This offers a productivity boost and gives you more time to actually write software that is valuable for the business.

Dapr guarantees At-Least-Once semantics for message delivery. That means that when an application publishes a message to a topic using the Publish/Subscribe API, it can assume the message is delivered at least once to any subscriber.

## How it works

The Dapr Publish/Subscribe building block offers a standard API you can use in your application code to send or receive messages. Messages are published to a named **topic** and consumers can subscribe to topics in order to receive the messages sent to them.

Dapr also offers a way to configure the message-broker you want to use for actually transporting messages. This is called the Publish/Subscribe **component**. We will come back to components in more detail later on.

It is possible to use the Publish/Subscribe building block directly over HTTP or gRPC using the Dapr API. In order to publish a message using Dapr, you can use the following API call on the Dapr sidecar of your application:

`http://localhost:<daprPort>/v1.0/publish/<pubsubname>/<topic>`

> In the examples in this chapter, we will assume everything is running locally on a single host so we can use `localhost` as hostname.

- You must fill `<daprPort>` with the port the Dapr sidecar is listening on.
- You must fill `<pubsubname>` with the name of the Publish/Subscribe component that must be used.
- You must fill `<topic>` with the name of the topic the message must be published to.

This is a simple example where the command-line tool *curl* is used to publish a message over the Dapr Publish/Subscribe API:

```
curl -X POST http://localhost:3500/v1.0/publish/pubsub/newOrder \
  -H "Content-Type: application/json" \
  -d '{ "orderId": "1234", "productId": "5678", "amount": 2 }'
```
Receiving messages is possible by subscribing to a topic. Upon startup, the Dapr runtime will query your application on a well-known end-point to ask for the subscriptions you want to create. This is the end-point that will be called:

`http://localhost:<appPort>/dapr/subscribe`

The `<appPort>` part will be filled with the port that your application is listening on. You can specify this when starting your application with Dapr.

The application needs to handle requests on the `/dapr/subscribe` endpoint and return a response containing the list of topics it wants to subscribe to. With each topic, it also needs to specify the end-point on the application that must be called when a message comes in on that topic. This is an example of a response:

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

In this example, you see the application wants to subscribe to two topics `newOrder` and `newProduct` and register the end-points `/orders` and `/productCatalog/products` with these topics. For both subscriptions, the application wants to use the Publish/Subscribe component named `pubsub`.

In he following diagram you can see the entire flow of the example:

![](media/pubsub-dapr-pattern.png)

1. The Dapr sidecar of Service B (consumer) calls the `/dapr/subscribe` endpoint on the service. The service responses with the subscriptions it wants to create.
2. The Dapr sidecar of Service B creates the requested subscriptions on the message-broker.
3. Service A (producer) calls the `/v1.0/publish/<pubsubname>/<topic>` endpoint on its sidecar.
4. The Service A sidecar publishes the message to the message-broker.
5. The message-broker sends a copy of the message to the Service B sidecar.
6. The Service B sidecar calls the endpoint corresponding to the subscription (in this case `/orders`) on Service B.

Obviously, using the Dapr APIs directly over HTTP is fine, but you need to handle serialization, HTTP response codes and things like that yourself. But there is a more convenient way of doing Publish/Subscribe when you use one of the available SDKs.

### Using the Dapr .NET SDK

The .NET SDK offers a more convenient way of working with the Publish/Subscribe building block. It offers a **Dapr client** that can be used to invoke several Dapr building blocks. One of the methods it offers is the `PublishEventAsync` method for publishing a message. This is an example of how to use it:

```csharp
var data = new OrderData
{
  id = "123456",
  productId = "67890",
  amount = 2
}

await PublishEventAsync<OrderData>("pubsub", "newOrder", data);
```

The first argument is used to specify the name of the component to use for transporting messages. The second argument is used to specify the topic that the message must be sent. The third argument is obviously the payload of the message. You can specify the .NET type of the message using the generic type parameter of the method. If you want to know more about the method and its overloads, check out the [.NET SDK documentation](https://github.com/dapr/dotnet-sdk).

Receiving messages is possible by subscribing to a certain topic. You specify which endpoint on your application Dapr needs to call when a message comes in on that topic. For the following examples, we will assume that we have an existing ASP.NET WebAPI application that offers an operation that you want to be called, for example:

```csharp
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

So how can you specify that this method must be called when a message comes in on a certain Topic? Well, the Dapr .NET SDK offers a nice integration with ASP.NET Core. You can link a WebAPI operation to a Publish/Subscribe topic by decorating it with the `Topic` attribute:

```csharp
[Topic("pubsub", "newOrder")]
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

> You must add a reference the NuGet package `Dapr.AspNetCore` in your project in order to use this.

You have to specify 2 things with this attribute:

- The Dapr Publish/Subscribe component you want to use (in this case `pubsub`).
- The name of the topic to subscribe to (in this case `newOrder`).

Now you need to tell ASP.NET Core to use Dapr for the incoming requests. For this, the .NET SDK offers some extension methods that you can use in your `Startup` class during registration of services for dependency injection and during the configuration of your ASP.NET Core application:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...

    services.AddControllers().AddDapr();
}
```

Dapr offers an `AddDapr` extension-method on the `IMvcBuilder` returned from `AddControllers` that you can use in the `ConfigureServices` method. It will register the necessary services to integrate Dapr into the MVC pipeline that is being created.

In the `Configure` method, you must add the following parts in order to enable Dapr:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...

    app.UseCloudEvents();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapSubscribeHandler();

        ...
    });
}
```

The call to `UseCloudEvents` makes sure that **CloudEvents** middleware is added to the ASP.NET Core middleware pipeline. This middleware will unwrap requests that use the CloudEvents structured format, allowing the event payload to be read directly.

> CloudEvents is a standardized messaging format used by Dapr. See the [cloudevents specification](https://github.com/cloudevents/spec/tree/v1.0) for more information.

The call to `MapSubscribeHandler` in the endpoint routing configuration will add a Dapr subscribe endpoint to the application. This endpoint will respond to requests on `/dapr/subscribe`. When this endpoint is called, it will automatically find all WebAPI operations that are decorated with the `Topic` attribute and return a response with all the subscriptions.

### Pub/sub components

The actual transport of the messages is handled by Publish/Subscribe components. Several Publish/Subscribe components are available that each use a certain message-broker product to implement the Publish/Subscribe building block. At the time of writing, the following Publish/Subscribe components were available:

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

You can configure Dapr to use a certain Publish/Subscribe component. The configuration contains several fields, including a **name** field. This name is important because you can configure multiple Publish/Subscribe components for Dapr to use. When you want to send or receive a message, you must specify this name to specify which message-broker to use (as we saw in the `PublishEventAsync` method signature shown earlier).

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

You can see in this example that you can specify any message-broker specific configuration in the `metadata` block. In this case, RabbitMQ is configured to create durable queues. Each of the components' configuration will have its own set of possible fields. Which fields are available can be found in the documentation of each Publish/Subscribe component.

## Reference case: eShopOnDapr

[Really quick intro on specific pub/sub stuff in eShop]

Within the eShopOnDapr sample application, the Publish/Subscribe pattern is used in several areas:

- Example 1
- Example 2

First, let's look at which Publish/Subscribe components are configured for eShopOnDapr.

[Component(s)]

[Code samples]

### Pub/sub in eShopOnDapr
...

[Benefits interleaved with the description]

[Benefit: Nice integration with ASP.NET Controllers. Doesn't matter how your code called (HTTP request, message), server side is the same.]

## Summary

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
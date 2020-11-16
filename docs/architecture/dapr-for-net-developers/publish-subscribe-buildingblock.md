---
title: The Publish/Subscribe building block
description: A description of the Publish/Subscribe building-block and how to apply it
author: edwinvw
ms.date: 11/14/2020
---

# The Publish/Subscribe building block

The [Publish-Subscribe pattern](https://docs.microsoft.com/azure/architecture/patterns/publisher-subscriber) is a well-known and widely used messaging pattern. Architects commonly embrace it in distributed applications. However, the plumbing to implement it can be complex. Dapr offers a building block that significantly simplifies implementing publish/subscribe functionality.

## What it solves

The primary advantage of the Publish-Subscribe pattern is `loose coupling`, sometimes referred to as [temporal decoupling](https://docs.microsoft.com/azure/architecture/guide/technology-choices/messaging#decoupling). Specifically, the pattern decouples services that send messages (the **publishers**) from services that consume messages (the **subscribers**). Both publishers and subscribers are unaware of each other - both are dependent on a centralized **message broker** that distributes the messages. 

Figure 4-x shows the high-level architecture of the publish/subscribe pattern.

![The Publish/Subscribe pattern](./media/pubsub-pattern.png)

**Figure 4-x**. The publish/subscrive pattern.

From the previous figure, note the steps of the pattern:

1. Subscribers create a subscription on the message broker.
2. Publisher sends messages to the message broker.
3. The message broker forwards a copy of the message to all or select subscriptions.
4. Subscribers consume messages from their subscriptions.

Most message brokers encapsulate a queueing mechanism that can persist messages once received. With it, the subscribers don't have to be immediately available or even online when a publisher sends a message. The message broker guarantees `durablity` by storing the message. Once available, the subscriber receives and processes the message.  Dapr guarantees `At-Least-Once` semantics for message delivery. Once a message is published, it will be delivered at least once to any subscriber.

 > If your application can only process a message once, you'll need to provide an idempotency check to ensure that the same message is not processed twice. While such logic can coded, keep in mind that some message brokers, such as Azure Service Bus, provide built-in `duplicate detection` message capabilities. 

There are several message broker products available - both commercially and open-source. Each has advantages and drawbacks. Your job is to match your system requirements to the appropriate broker. Once selected, it's a best practice to decouple your application from message broker plumbing. You do this by wrapping the broker inside an `abstraction`. The abstraction encapsulates the message plumbing and exposes generic publish and subscribe operations to your code. Your code communicates with the abstraction, not the actual message broker. While a wise decision, you'll have to write and maintain the abstraction and its underlying implementation. This approach requires custom code that can be complex, repetitive, and error-prone. 

This scenario is where Dapr comes to the rescue. The Dapr Publish/Subscribe building block provides the messaging abstraction and implementation out-of-the-box. The custom code you would have had to write is prebuilt and encapsulated inside the Dapr building block. You bind to it and consume it. The Dapr building block architecture offers a significant productivity increase. It enables you and your team to create business functionality, not plumbing code.

## How it works

The Dapr Publish/Subscribe building block provides a platform agnostic API framework to send and receive messages. Your services can publish messages to a named [topic](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-queues-topics-subscriptions#topics-and-subscriptions). Your services can subscribe to a topic to consume messages.

Underneath the hood, your service makes HTTP/gRPC calls to a Dapr pub/sub building block, which is exposed within a sidecar architecture. Based upon your configuration, the building block makes calls into a pre-defined Dapr component. The component encapsulates a specific message broker product. Figure 4-x shows the Dapr pub/sub messaging stack.

![The Publish/Subscribe stack](./media/dapr-pub-sub-stack.png)

**Figure 4-x**. The Dapr Publish/Subscribe stack.

The Dapr publish-subscribe building block can be invoked in a number of ways.

At a lower level, any programming platform can directly invoke the building block over HTTP or gRPC using the **Dapr native API**. To publish a message, you can make the following API call:

``` http
http://localhost:<daprPort>/v1.0/publish/<pubsubname>/<topic>
```

- The `<daprPort>` URL segment provides the port number upon which the Dapr sidecar is listening.
- The `<pubsubname>`, the name of the selected Dapr publish-subscribe component.
- The `<topic>`, the name of the topic to which the message is published.

Using the *curl* command-line tool to publish a message, you can try it out:

``` curl
curl -X POST http://localhost:3500/v1.0/publish/pubsub/newOrder \
  -H "Content-Type: application/json" \
  -d '{ "orderId": "1234", "productId": "5678", "amount": 2 }'
```

You receive messages by subscribing to a topic. Upon startup, the Dapr runtime will query your application on a well-known endpoint to ask for the subscriptions you want to create. Here is the endpoint that will be called:

``` http
http://localhost:<appPort>/dapr/subscribe
```

- The `<appPort>` URL segment informs the Dapr sidecar of the port upon which your application is listening.

The application handles the request on the `/dapr/subscribe` endpoint by returning a response containing the list of topics to which it wants to subscribe. For each topic, it also specifies the endpoint that must be called when a message comes in on that topic. Here is an example of a response:

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

In this example, you can see the application wants to subscribe to topics `newOrder` and `newProduct` and register the endpoints `/orders` and `/productCatalog/products`for them, respectively. For both subscriptions, the application wants to use the Dapr component named `pubsub`.

Figure 4-x presents the flow of the example.

![Example Publish/Subscribe flow with Dapr](media/pubsub-dapr-pattern.png)

**Figure 4-x**. Publish/subscribe flow with Dapr.

From the previous figure, note the flow:

1. The Dapr sidecar for Service B calls the `/dapr/subscribe` endpoint from Service B (consumer). The service responds with the subscriptions it wants to create.
2. The Dapr sidecar for Service B creates the requested subscriptions on the message broker.
3. Service A (publisher) calls the `/v1.0/publish/<pubsubname>/<topic>` endpoint on the Dapr sidecar for Service A.
4. The Service A sidecar publishes the message to the message broker.
5. The message broker sends a copy of the message to the Service B sidecar.
6. The Service B sidecar calls the endpoint corresponding to the subscription (in this case `/orders`) on Service B.

Making HTTP calls against the native Dapr APIs is workable, but not as productive. Your calls are crafted at the HTTP level, and you'll need to handle plumbing concerns such as serialization and HTTP response codes. Fortunately, there's a more intuitive way. Dapr provides several language-specific SDKs for popular development platforms. At the time of this writing, Go, Node.js, Python, .NET, Java, and JavaScript are available.

### Using the Dapr .NET SDK

For .NET Developers, the Dapr .NET SDK provides a more productive way of working with Dapr. The SDK exposes a `Daprclient` class through which you can directly invoke Dapr functionality. It's intuitive and easy to use.

To publish a message, the `Daprclient` exposes a `PublishEventAsync` method. It's straightforward to use:

```csharp
var data = new OrderData
{
  id = "123456",
  productId = "67890",
  amount = 2
}

await PublishEventAsync<OrderData>("pubsub", "newOrder", data);
```

- The first argument `pubsub` is the name of the Dapr component that provides the message broker implementation. We'll address components later in this section.
- The second argument `neworder` provides the name of the topic on which to send the message.
- The third argument is the payload of the message.
- You can specify the .NET type of the message using the generic type parameter of the method.

To receive messages, you bind an endpoint to a subscription from a registered topic. The AspNetCore library for Dapr makes this trivial. Assume, for example, that you have an existing ASP.NET WebAPI action method entitled `CreateOrder`:

```csharp
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

 > You must add a reference to the NuGet package `Dapr.AspNetCore` in your project to consume the AspNetCore integration.

To bind this action method to a Topic, you decorate it with the `Topic` attribute:

```csharp
[Topic("pubsub", "newOrder")]
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

You specify two key elements with this attribute:

- The Dapr Publish/Subscribe component to target (in this case `pubsub`).
- The topic to subscribe (in this case `newOrder`).

Dapr then invokes that action method as it receives messages for that topic.

You also need to configure ASP.NET Core to use Dapr for the incoming requests. For this, the .NET SDK provides extension methods that can be invoked in the `Startup` class

In the `ConfigureServices` method, you must add the following extension method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...

    services.AddControllers().AddDapr();
}
```

Append the `AddDapr` extension-method to the `AddControllers` extension. It registers the necessary services to integrate Dapr into the MVC pipeline. It also registers a `DaprClient` instance into the dependency injection container, which then can be injected anywhere into your service.

In the `Configure` method, you must add the following middleware components to enable Dapr:

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

The call to `UseCloudEvents` adds **CloudEvents** middleware is to the ASP.NET Core middleware pipeline. This middleware will unwrap requests that use the CloudEvents structured format, so the receiving method receives the event payload directly.

> [CloudEvents](https://cloudevents.io/) is a standardized messaging format, providing a common way to describe event information across platforms. Dapr embraces CloudEvents. For more about CloudEvents, see the [cloudevents specification](https://github.com/cloudevents/spec/tree/v1.0).

The call to `MapSubscribeHandler` in the endpoint routing configuration will add a Dapr subscribe endpoint to the application. This endpoint will respond to requests on `/dapr/subscribe`. When this endpoint is called, it will automatically find all WebAPI operations decorated with the `Topic` attribute and return a response with all the subscriptions.

### Pub/sub components

Dapr Publish/Subscribe components handle the actual transport of the messages. Several are available. Each uses a specific message broker product to implement the Publish/Subscribe building block. At the time of writing, the following Publish/Subscribe components were available:

- Hazelcast
- Redis Streams
- NATS
- Kafka
- Azure Service Bus
- RabbitMQ
- Azure Event Hubs
- GCP Pub/Sub
- MQTT

 > Note for the Azure cloud stack how both messaging functionality (Azure Service Bus) and event streaming (Azure Event Hub) are available.

These components are created by the community in a [component-contrib repository on GitHub](https://github.com/dapr/components-contrib/tree/master/pubsub). It's possible to write your own Dapr component for a message broker that isn't yet supported.

### Configuring Publish/Subscribe components

You can configure Dapr to use a particular Publish/Subscribe component. The configuration contains several fields, including a **name** field. This name is important because you can configure multiple Publish/Subscribe components for Dapr to use. When you want to send or receive a message, you must include the name of the message broker to use (as we saw in the `PublishEventAsync` method signature shown earlier).

Below you see an example of a Dapr configuration file for configuring a RabbitMQ message broker component:

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

In this example, you can see that you can specify any message broker-specific configuration in the `metadata` block. In this case, RabbitMQ is configured to create durable queues. Each of the components' configuration will have its own set of possible fields. You can read which fields are available in the documentation of each Publish/Subscribe component.

## Reference case: eShopOnDapr

The eShop sample application uses the Publish/Subscribe pattern in several places for communicating integration events, for example:

- When a user checks-out a shopping basket.
- When a payment for an order has succeeded.
- When the grace-period of a purchase has expired.

In eShopOnContainers, the Publish/Subscribe pattern is implemented using an *IEventBus* abstraction:

```csharp
public interface IEventBus
{
    void Publish(IntegrationEvent @event);

    void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>;
}
```

Multiple implementations exist for this abstraction, each for a different message broker (RabbitMQ and Azure Service Bus). Each implementation implements both the publish and subscribe part of the abstraction.

### Publishing events

In eShopOnDapr, we replaced the entire Publish/Subscribe implementation with Dapr. This refactoring was straightforward. We reduced the existing `IEventBus` abstraction, so it only contains a method for publishing events:

```csharp
public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}
```

To implement the `IEventBus` abstraction, a `DaprEventBus` implementation was created. This implementation uses the Dapr client to publish an event:

```csharp
public class DaprEventBus : IEventBus
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    private readonly DaprClient _dapr;
    private readonly ILogger<DaprEventBus> _logger;

    public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
    {
        _dapr = dapr;
        _logger = logger;
    }

    public async Task PublishAsync<TIntegrationEvent>(TIntegrationEvent @event)
        where TIntegrationEvent : IntegrationEvent
    {
        var topicName = @event.GetType().Name;

        _logger.LogInformation("Publishing event {@Event} to {PubsubName}.{TopicName}", @event, DAPR_PUBSUB_NAME, topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        await _dapr.PublishEventAsync(DAPR_PUBSUB_NAME, topicName, (dynamic)@event);
    }
}
```

As you can see in the code snippet, the event type's name is used as the topic to send the event to. Because all services use the `IEventBus` abstraction, nothing needed to be changed to publish events.

As you can see in the implementation, we cast the event to a `dynamic` when passing it as an argument. This is a workaround for an issue with the `System.Text.Json` serializer that the SDK uses to serialize and deserialize messages. In the eShop code that calls this method, sometimes an event is explicitly declared as the base-class for events `IntegrationEvent` (because the specific event-type is determined dynamically based on business-logic). As a result, the event isn't serialized correctly and the message payload won't contain all the fields of the event. Our workaround fixes this and all fields are correctly serialized.

One of the benefits of using Dapr, is that the infrastructure code is reduced heavily and is now straightforward. It doesn't need to distinguish between the different message brokers being used anymore. Dapr abstracts this for you. And you can configure to use different message broker components. We'll get back to how that works in eShopOnDapr later on.

### Subscribing to events

eShopOnContainers contains *SubscriptionManagers* that handle subscriptions. Each specific message broker for which an implementation of the `IEventBus` abstraction exists, contains a fair amount of message broker-specific code for handling subscriptions. Each service that wants to receive events needs to explicitly register a handler for each event-type upon startup.

We replaced this in eShopOnDapr with the nice ASP.NET Core integration that Dapr offers, as described earlier. We created a controller in each service with a method for each event to handle. We decorated each controller-method with the corresponding `Topic` attribute the message is published to. Here's a code snippet taken from the `PaymentService`:

```csharp
[Route("api/v1/[controller]")]
[ApiController]
public class IntegrationEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    private readonly IServiceProvider _serviceProvider;

    public IntegrationEventController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpPost("OrderStatusChangedToValidated")]
    [Topic(DAPR_PUBSUB_NAME, "OrderStatusChangedToValidatedIntegrationEvent")]
    public async Task OrderStarted(OrderStatusChangedToValidatedIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToValidatedIntegrationEventHandler>();
        await handler.Handle(@event);
    }
}
```

As you can see in the code snippet, the event type's name is used as the topic to subscribe to. The `OrderStatusChangedToValidatedIntegrationEventHandler` being used in the code-snippet is an event-handler that already existed in eShopOnContainers. Because Dapr now handles everything around subscriptions and the differences between message brokers, this means lots of code became obsolete, which we removed from the code-base.

### Using Publish/Subscribe components

Within the eShopOnDapr repository, a `deployment` folder contains files for deploying the application using different deployment methods (for now: `Docker Compose` and `k8s`). A `dapr` folder exists within each of these folders that holds a `components` folder. This folder holds a file `eshop-pubsub.yaml` containing the configuration of the Publish/Subscribe component that Dapr must use for Publish/Subscribe. As you saw in the code snippets shown earlier, the name of the Publish/Subscribe component used is `pubsub`. Here's the content of the `eshop-pubsub.yaml` file in the `deployment/compose/dapr/components` folder:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: default
spec:
  type: pubsub.nats
  metadata:
  - name: natsURL
    value: nats://demo.nats.io:4222
```

As you can see, the NATS message broker is configured in this example. If you want to use a different message broker for eShopOnDapr, you only need to change this file and configure a different message broker (for example, the RabbitMQ broker). Because you're using Dapr, you don't need any code-changes whatsoever when switching message broker.

You might ask yourself: "Why would I need multiple implementations of a message broker in my application?". Well, a system often handles multiple workloads with different characteristics. Some events occur 10 times a day, whereas another event occurs 5000 times per second. In that situation, you need the ability to partition your messaging traffic and use a specific message broker for each workload. With Dapr this is as straightforward as adding multiple Publish/Subscribe component configurations with each a different name and specifying the name of the component you want to use in your application code.

## Summary

The Publish/Subscribe pattern can help with decoupling services in a distributed application. Dapr offers the Publish/Subscribe building block for implementing this pattern in your applications.

The Dapr sidecar offers an API you can use to publish a message. Each message is published to a certain *topic*.

Each service's Dapr sidecar will query the service to determine which topic(s) the service wants to subscribe to.

You can use the Publish/Subscribe building block directly over HTTP or by using one of the available language-specific SDKs.

You can use the .NET SDK for Dapr by adding a reference to the `Dapr.Client` NuGet package. It offers a `DaprClient` class that can be used to publish messages. Dapr also provides a straightforward way of integrating the Publish/Subscribe building block in an ASP.NET Core WebAPI application. For this, you need a reference to the `Dapr.AspNetCore` NuGet package. WebAPI controller methods can be decorated with the `Topic` attribute from this package to specify to Dapr that the decorated method must be invoked when a message comes in on the specified topic.

Using the Dapr components mechanism, you can configure the actual message broker used by Dapr to distribute the messages.

When using the Dapr Publish/Subscribe building block, it becomes straightforward to switch to another message broker for your application without any code changes.

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
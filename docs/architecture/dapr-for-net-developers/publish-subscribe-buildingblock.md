---
title: The Publish/Subscribe building block
description: A description of the Publish/Subscribe building-block and how to apply it
author: edwinvw
ms.date: 09/25/2020
---

# The Publish/Subscribe building block

The [Publish-Subscribe pattern](https://docs.microsoft.com/azure/architecture/patterns/publisher-subscriber) is a well-known and widely used messaging pattern. Architects commonly implement it across distributed services. However, the required plumbing can be complex and repetitive - both to create and maintain. Dapr offers a building block that significantly streamlines and simplifies implementing publish/subscribe functionality.

## What it solves

The primary advantage of the Publish-Subscribe pattern is `loose coupling`. The pattern decouples services that send messages (the **publishers**) from services that consume messages (the **subscribers**). Publishers and subscribers are unaware of each other - both are dependent on a centralized **message broker** that distributes the messages. 

Figure 4-x shows the high-level architecture of the publish/subscribe pattern.

![The Publish/Subscribe pattern](./media/pubsub-pattern.png)

**Figure 4-x**. The publish/subscrive pattern.

From the previous figure, note the steps of the pattern:

1. Subscribers create a subscription on the message broker.
2. Publisher sends messages to the message broker.
3. The message broker forwards a copy of the message to all subscribers.

Some message brokers offer a queueing mechanism that can persist messages once received. In this case, the subscribers don't have to be online when a publisher sends the message. Once back online, the subscriber receives and processes the message. The message broker provides `durablity` by storing the message. This feature offers you [temporal decoupling](https://docs.microsoft.com/azure/architecture/guide/technology-choices/messaging#decoupling) of publishers and consumers and helps reduce coupling between services.

There are several message broker products available - both commercially and open-source. Each has advantages and drawbacks. Your job is to match your system requirements to the appropriate broker. To keep your application decoupled from a specific message broker, it's a best practice to wrap the broker in an abstraction. While a wise decision, you'll have to write and maintain the abstraction. This type of custom code can become complex, repetitive, and error-prone. This is exactly where Dapr comes to the rescue.

The Dapr Publish/Subscribe building block is an abstraction of the Publish/Subscribe messaging pattern. Because Dapr provides the abstraction layer, you no longer create or maintain it. The building block provides a significant productivity boost enabling you to focus on business functionality as opposed to plumbing code.

Dapr guarantees At-Least-Once semantics for message delivery. Once a message is published, it will be delivered at least once to any subscriber.

## How it works

The Dapr Publish/Subscribe building block offers a standard API you can use to send or receive messages. Producers send messages to a named [topic](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-queues-topics-subscriptions#topics-and-subscriptions). Consuming services subscribe to a topic to receive the messages sent to them.

Dapr also allows you to select and configure a specific message broker product, which is known as a Dapr **component**.  We'll cover components in detail later in this section.

 It's possible to use the Publish/Subscribe building block directly over HTTP or gRPC using the Dapr API. To publish a message using Dapr, you can invoke the following API call on the Dapr sidecar of your application:

``` http
http://localhost:<daprPort>/v1.0/publish/<pubsubname>/<topic>
```

- You must fill `<daprPort>` with the port the Dapr sidecar is listening on.
- You must fill `<pubsubname>` with the name of the Publish/Subscribe component that must be used.
- You must fill `<topic>` with the name of the topic the message must be published to.

Using the command-line tool *curl*, you can easily publish a message over the Dapr Publish/Subscribe API to try it out:

``` curl
curl -X POST http://localhost:3500/v1.0/publish/pubsub/newOrder \
  -H "Content-Type: application/json" \
  -d '{ "orderId": "1234", "productId": "5678", "amount": 2 }'
```

You receive messages by subscribing to a topic. Upon startup, the Dapr runtime will query your application on a well-known endpoint to ask for the subscriptions you want to create. Here is the endpoint that will be called:

``` http
http://localhost:<appPort>/dapr/subscribe
```

The Dapr sidecar will use the `<appPort>` that your application is listening on.

The application needs to handle requests on the `/dapr/subscribe` endpoint and return a response containing the list of topics it wants to subscribe to. With each topic, it also needs to specify the endpoint on the application that must be called when a message comes in on that topic. Here is an example of a response:

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

In this example, you can see the application wants to subscribe to topics `newOrder` and `newProduct` and register the endpoints `/orders` and `/productCatalog/products` with these topics. For both subscriptions, the application wants to use the Publish/Subscribe component named `pubsub`.

Figure 4-x presents the entire flow of the example.

![Example Publish/Subscribe flow with Dapr](media/pubsub-dapr-pattern.png)

**Figure 4-x**. Publish/subscrive flow with Dapr.

From the previous figure, note the flow:

1. The Dapr sidecar for Service B (consumer) calls the `/dapr/subscribe` endpoint on the service. The service responds with the subscriptions it wants to create.
2. The Dapr sidecar for Service B creates the requested subscriptions on the message broker.
3. Service A (publisher) calls the `/v1.0/publish/<pubsubname>/<topic>` endpoint on its sidecar.
4. The Service A sidecar publishes the message to the message broker.
5. The message broker sends a copy of the message to the Service B sidecar.
6. The Service B sidecar calls the endpoint corresponding to the subscription (in this case `/orders`) on Service B.

Using the Dapr APIs directly over HTTP is fine, but you'll need to handle plumbing concerns such as serialization and HTTP response codes. Fortunately, there is a more convenient way of implementing Publish/Subscribe when you use one of the available SDKs.

### Using the Dapr .NET SDK

The .NET SDK offers a more convenient way of working with the Publish/Subscribe building block. It provides a `Daprclient` class that you can use to invoke several Dapr building blocks.

One of the methods the Dapr client offers is the `PublishEventAsync` method for publishing a message. This is an example of how to use it:

```csharp
var data = new OrderData
{
  id = "123456",
  productId = "67890",
  amount = 2
}

await PublishEventAsync<OrderData>("pubsub", "newOrder", data);
```

You need to provide the name of the component to use for transporting messages as the first argument. As second argument, you must provide the name of the topic to which you want to send the message. The third argument is obviously the payload of the message. You can specify the .NET type of the message using the generic type parameter of the method. If you want to know more about the method and its overloads, check out the [.NET SDK documentation](https://github.com/dapr/dotnet-sdk).

You receiving messages by subscribing to a specific topic. You specify which endpoint on your application Dapr needs to call when a message comes in on that topic. For the following examples, we will assume that we have an existing ASP.NET WebAPI application that offers an operation that you want to be called, for example:

```csharp
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

How can you specify that this method must be called when a message comes in on a certain Topic? Well, the Dapr .NET SDK offers a nice integration with ASP.NET Core. You can link a WebAPI operation to a Publish/Subscribe topic by decorating it with the `Topic` attribute:

```csharp
[Topic("pubsub", "newOrder")]
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

> You must add a reference to the NuGet package `Dapr.AspNetCore` in your project to use this.

You have to specify two things with this attribute:

- The Dapr Publish/Subscribe component you want to use (in this case `pubsub`).
- The name of the topic to subscribe to (in this case `newOrder`).

Now you need to tell ASP.NET Core to use Dapr for the incoming requests. For this, the .NET SDK offers some extension methods that you can use in your `Startup` class during the registration of services for dependency injection and during the configuration of your ASP.NET Core application:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...

    services.AddControllers().AddDapr();
}
```

Dapr offers an `AddDapr` extension-method on the `IMvcBuilder` returned from `AddControllers` that you can use in the `ConfigureServices` method. It will register the necessary services to integrate Dapr into the MVC pipeline. It also automatically registers a `DaprClient` instance for dependency injection, so you don't have to do that explicitly yourself.

In the `Configure` method, you must add the following parts to enable Dapr:

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

> CloudEvents is a standardized messaging format used by Dapr. See the [cloudevents specification](https://github.com/cloudevents/spec/tree/v1.0) for more information.

The call to `MapSubscribeHandler` in the endpoint routing configuration will add a Dapr subscribe endpoint to the application. This endpoint will respond to requests on `/dapr/subscribe`. When this endpoint is called, it will automatically find all WebAPI operations decorated with the `Topic` attribute and return a response with all the subscriptions.

### Pub/sub components

Publish/Subscribe components handle the actual transport of the messages. Several Publish/Subscribe components are available that each use a specific message broker product to implement the Publish/Subscribe building block. At the time of writing, the following Publish/Subscribe components were available:

- Hazelcast
- Redis Streams
- NATS
- Kafka
- Azure Service Bus
- RabbitMQ
- Azure Event Hubs
- GCP Pub/Sub
- MQTT

These components are created by the community in a [component-contrib repository on Github](https://github.com/dapr/components-contrib/tree/master/pubsub). So it is possible to write your own Dapr Publish/Subscribe component for a message broker that is not yet supported.

### Configuring Publish/Subscribe

You can configure Dapr to use a particular Publish/Subscribe component. The configuration contains several fields, including a **name** field. This name is important because you can configure multiple Publish/Subscribe components for Dapr to use. When you want to send or receive a message, you must specify this name to specify which message broker to use (as we saw in the `PublishEventAsync` method signature shown earlier).

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

In this example, you can see that you can specify any message broker specific configuration in the `metadata` block. In this case, RabbitMQ is configured to create durable queues. Each of the components' configuration will have its own set of possible fields. You can read which fields are available in the documentation of each Publish/Subscribe component.

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

Multiple implementations exist for this abstraction, each for a different message broker (RabbitMQ and Azure Service Bus). Each implementation implements both the publish as well as the subscribe part of the abstraction.

### Publishing events

In eShopOnDapr, we replaced the entire Publish/Subscribe implementation with Dapr. This refactoring was pretty straightforward. We reduced the existing `IEventBus` abstraction, so it only contains a method for publishing events:

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

As you can see in the implementation, we cast the event to a `dynamic` when passing it as an argument. This is a workaround for an issue with the `System.Text.Json` serializer that the SDK uses to serialize and deserialize messages. In the eShop code that calls this method, sometimes an event is explicitly declared as the base-class for events `IntegrationEvent` (because the specific event-type is determined dynamically based on business-logic). As a result, the event is not serialized correctly and the message payload will not contain all the fields of the event. Our workaround fixes this and all fields are correctly serialized.

One of the benefits of using Dapr, is that the infrastructure code is reduced heavily and is now pretty straightforward. It does not need to distinguish between the different message brokers being used anymore. Dapr abstracts this for you. And you can configure to use different message broker components. We will get back to how that works in eShopOnDapr later on.

### Subscribing to events

eShopOnContainers contains *SubscriptionManagers* that handle subscriptions. Each specific message broker for which an implementation of the `IEventBus` abstraction exists, contains a fair amount of message broker specific code for handling subscriptions. Each service that wants to receive events needs to explicitly register a handler for each event-type upon startup.

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

As you can see, the NATS message broker is configured in this example. If you want to use a different message broker for eShopOnDapr, you only need to change this file and configure a different message broker (e.g., the RabbitMQ broker). Because you're using Dapr, you don't need any code-changes whatsoever when switching message broker.

You might ask yourself: "Why would I need multiple implementations of a message broker in my application?". Well, a system often handles multiple workloads with different characteristics. Some events occur ten times a day, whereas another event occurs 5000 times per second. In that situation, you need the ability to partition your messaging traffic and use a specific message broker for each workload. With Dapr this is as straightforward as adding multiple Publish/Subscribe component configurations with each a different name and specifying the name of the component you want to use in your application code.

## Summary

The Publish/Subscribe pattern can help with decoupling services in a distributed application. Dapr offers the Publish/Subscribe building block for implementing this pattern in your applications.

The Dapr sidecar offers an API you can use to publish a message. Each message is published to a certain *topic*.

Each service's Dapr sidecar will query the service to determine which topic(s) the service wants to subscribe to.

You can use the Publish/Subscribe building block directly over HTTP or by using one of the available language specific SDKs.

You can use the .NET SDK for Dapr by adding a reference to the `Dapr.Client` NuGet package. It offers a `DaprClient` class that can be used to publish messages. Dapr also provides a very straightforward way of integrating the Publish/Subscribe building block in an ASP.NET Core WebAPI application. For this, you need a reference to the `Dapr.AspNetCore` NuGet package. WebAPI controller methods can be decorated with the `Topic` attribute from this package to specify to Dapr that the decorated method must be invoked when a message comes in on the specified topic.

Using the Dapr components mechanism, you can configure the actual message broker used by Dapr to distribute the messages.

When using the Dapr Publish/Subscribe building block, it becomes very straightforward to switch to another message broker for your application without any code changes.

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
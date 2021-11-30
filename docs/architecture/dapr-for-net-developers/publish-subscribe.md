---
title: The Dapr publish & subscribe building block
description: A description of the Dapr publish & subscribe building-block and how to apply it
author: edwinvw
ms.date: 11/17/2021
---

# The Dapr publish & subscribe building block

The [Publish-Subscribe pattern](/azure/architecture/patterns/publisher-subscriber) (often referred to as "pub/sub") is a well-known and widely used messaging pattern. Architects commonly embrace it in distributed applications. However, the plumbing to implement it can be complex. There are often subtle feature differences across different messaging products. Dapr offers a building block that significantly simplifies implementing pub/sub functionality.

## What it solves

The primary advantage of the Publish-Subscribe pattern is **loose coupling**, sometimes referred to as [temporal decoupling](/azure/architecture/guide/technology-choices/messaging#decoupling). The pattern decouples services that send messages (the **publishers**) from services that consume messages (the **subscribers**). Both publishers and subscribers are unaware of each other - both are dependent on a centralized **message broker** that distributes the messages.

Figure 7-1 shows the high-level architecture of the pub/sub pattern.

:::image type="content" source="./media/publish-subscribe/pub-sub-pattern.png" alt-text="The pub/sub pattern.":::

**Figure 7-1**. The pub/sub pattern.

From the previous figure, note the steps of the pattern:

1. Publishers send messages to the message broker.
1. Subscribers bind to a subscription on the message broker.
1. The message broker forwards a copy of the message to interested subscriptions.
1. Subscribers consume messages from their subscriptions.

Most message brokers encapsulate a queueing mechanism that can persist messages once received. With it, the message broker guarantees **durability** by storing the message. Subscribers don't need to be immediately available or even online when a publisher sends a message. Once available, the subscriber receives and processes the message.  Dapr guarantees **At-Least-Once** semantics for message delivery. Once a message is published, it will be delivered at least once to any interested subscriber.

> [!TIP]
> If your service can only process a message once, you'll need to provide an [idempotency check](/azure/architecture/microservices/design/api-design#idempotent-operations) to ensure that the same message is not processed multiple times. While such logic can be coded, some message brokers, such as Azure Service Bus, provide built-in *duplicate detection* messaging capabilities.

There are several message broker products available - both commercially and open-source. Each has advantages and drawbacks. Your job is to match your system requirements to the appropriate broker. Once selected, it's a best practice to decouple your application from message broker plumbing. You achieve this functionality by wrapping the broker inside an *abstraction*. The abstraction encapsulates the message plumbing and exposes generic pub/sub operations to your code. Your code communicates with the abstraction, not the actual message broker. While a wise decision, you'll have to write and maintain the abstraction and its underlying implementation. This approach requires custom code that can be complex, repetitive, and error-prone.

The Dapr publish & subscribe building block provides the messaging abstraction and implementation out-of-the-box. The custom code you would have had to write is prebuilt and encapsulated inside the Dapr building block. You bind to it and consume it. Instead of writing messaging plumbing code, you and your team focus on creating business functionality that adds value to your customers.

## How it works

The Dapr publish & subscribe building block provides a platform-agnostic API framework to send and receive messages. Your services publish messages to a named [topic](/azure/service-bus-messaging/service-bus-queues-topics-subscriptions#topics-and-subscriptions). Your services subscribe to a topic to consume messages.

The service calls the pub/sub API on the Dapr sidecar. The sidecar then makes calls into a pre-defined Dapr pub/sub component that encapsulates a specific message broker product. Figure 7-2 shows the Dapr pub/sub messaging stack.

:::image type="content" source="./media/publish-subscribe/pub-sub-buildingblock.png" alt-text="The Dapr pub/sub stack.":::

**Figure 7-2**. The Dapr pub/sub stack.

The Dapr publish & subscribe building block can be invoked in many ways.

At the lowest level, any programming platform can invoke the building block over HTTP or gRPC using the **Dapr native API**. To publish a message, you make the following API call:

``` http
http://localhost:<dapr-port>/v1.0/publish/<pub-sub-name>/<topic>
```

There are several Dapr specific URL segments in the above call:

- `<dapr-port>` provides the port number upon which the Dapr sidecar is listening.
- `<pub-sub-name>` provides the name of the selected Dapr pub/sub component.
- `<topic>` provides the name of the topic to which the message is published.

Using the *curl* command-line tool to publish a message, you can try it out:

``` curl
curl -X POST http://localhost:3500/v1.0/publish/pubsub/newOrder \
  -H "Content-Type: application/json" \
  -d '{ "orderId": "1234", "productId": "5678", "amount": 2 }'
```

You receive messages by subscribing to a topic. At startup, the Dapr runtime will call the application on a well-known endpoint to identify and create the required subscriptions:

``` http
http://localhost:<appPort>/dapr/subscribe
```

- `<appPort>` informs the Dapr sidecar of the port upon which the application is listening.

You can implement this endpoint yourself. But Dapr provides more intuitive ways of implementing it. We'll address this functionality later in this chapter.

The response from the call contains a list of topics to which the applications will subscribe. Each includes an endpoint to call when the topic receives a message. Here's an example of a response:

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

In the JSON response, you can see the application wants to subscribe to topics `newOrder` and `newProduct`. It registers the endpoints `/orders` and `/productCatalog/products` for each, respectively. For both subscriptions, the application is binding to the Dapr component named `pubsub`.

Figure 7-3 presents the flow of the example.

:::image type="content" source="./media/publish-subscribe/pub-sub-flow.png" alt-text="Pub/sub flow with Dapr.":::

**Figure 7-3**. Pub/sub flow with Dapr.

From the previous figure, note the flow:

1. The Dapr sidecar for Service B calls the `/dapr/subscribe` endpoint from Service B (the consumer). The service responds with the subscriptions it wants to create.
1. The Dapr sidecar for Service B creates the requested subscriptions on the message broker.
1. Service A publishes a message at the `/v1.0/publish/<pub-sub-name>/<topic>` endpoint on the Dapr Service A sidecar.
1. The Service A sidecar publishes the message to the message broker.
1. The message broker sends a copy of the message to the Service B sidecar.
1. The Service B sidecar calls the endpoint corresponding to the subscription (in this case `/orders`) on Service B. The service responds with an HTTP status-code `200 OK` so the sidecar will consider the message as being handled successfully.

In the example, the message is handled successfully. But if something goes wrong while Service B is handling the request, it can use the response to specify what needs to happen with the message. When it returns an HTTP status-code `404`, an error is logged and the message is dropped. With any other status-code than `200` or `404`, a warning is logged and the message is retried. Alternatively, Service B can explicitly specify what needs to happen with the message by including a JSON payload in the body of the response:

```json
{
  "status": "<status>"
}
```

The following table shows the available `status` values:

| Status           | Action                                                       |
| ---------------- | ------------------------------------------------------------ |
| SUCCESS          | The message is considered as processed successfully and dropped. |
| RETRY            | The message is retried.                                      |
| DROP             | A warning is logged and the message is dropped.              |
| Any other status | The message is retried.                                      |

### Competing consumers

When scaling out an application that subscribes to a topic, you have to deal with competing consumers. Only one application instance should handle a message sent to the topic. Luckily, Dapr handles that problem. When multiple instances of a service with the same application-id subscribe to a topic, Dapr delivers each message to only one of them.

## Use the Dapr .NET SDK

For .NET Developers, the [Dapr .NET SDK](https://www.nuget.org/packages/Dapr.Client) provides a more productive way of working with Dapr. The SDK exposes a `DaprClient` class through which you can directly invoke Dapr functionality. It's intuitive and easy to use.

To publish a message, the `DaprClient` exposes a `PublishEventAsync` method.

```csharp
var data = new OrderData
{
  orderId = "123456",
  productId = "67890",
  amount = 2
};

var daprClient = new DaprClientBuilder().Build();

await daprClient.PublishEventAsync<OrderData>("pubsub", "newOrder", data);
```

- The first argument `pubsub` is the name of the Dapr component that provides the message broker implementation. We'll address components later in this chapter.
- The second argument `neworder` provides the name of the topic to send the message to.
- The third argument is the payload of the message.
- You can specify the .NET type of the message using the generic type parameter of the method.

To receive messages, you bind an endpoint to a subscription for a registered topic. The AspNetCore library for Dapr makes this trivial. Assume, for example, that you have an existing ASP.NET WebAPI action method entitled `CreateOrder`:

```csharp
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

> [!IMPORTANT]
> You must add a reference to the [Dapr.AspNetCore](https://www.nuget.org/packages/Dapr.AspNetCore) NuGet package in your project to consume the Dapr ASP.NET Core integration.

To bind this action method to a topic, you decorate it with the `Topic` attribute:

```csharp
[Topic("pubsub", "newOrder")]
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```

You specify two key elements with this attribute:

- The Dapr pub/sub component to target (in this case `pubsub`).
- The topic to subscribe to (in this case `newOrder`).

Dapr then invokes that action method as it receives messages for that topic.

You'll also need to enable ASP.NET Core to use Dapr. The Dapr .NET SDK provides several extension methods that can be used to do this.

In the `Program.cs` file, you must call the following extension method on the `WebApplication` builder to register Dapr:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddDapr();
```

Appending the `AddDapr` extension method to the `AddControllers` extension method registers the necessary services to integrate Dapr into the MVC pipeline. It also registers a `DaprClient` instance into the dependency injection container, which then can be injected anywhere into your service.

After the `WebApplication` has been created, you must add the following middleware components to enable Dapr:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseCloudEvents();
app.MapControllers();
app.MapSubscribeHandler();
```

The call to `UseCloudEvents` adds **CloudEvents** middleware into to the ASP.NET Core middleware pipeline. This middleware will unwrap requests that use the CloudEvents structured format, so the receiving method can read the event payload directly.

> [!NOTE]
> [CloudEvents](https://cloudevents.io/) is a standardized messaging format, providing a common way to describe event information across platforms. Dapr embraces CloudEvents. For more information about CloudEvents, see the [cloudevents specification](https://github.com/cloudevents/spec/tree/v1.0).

The call to `MapSubscribeHandler` in the endpoint routing configuration will add a Dapr subscribe endpoint to the application. This endpoint will respond to requests on `/dapr/subscribe`. When this endpoint is called, it will automatically find all WebAPI action methods decorated with the `Topic` attribute and instruct Dapr to create subscriptions for them.

## Pub/sub components

Dapr [pub/sub components](https://github.com/dapr/components-contrib/tree/master/pubsub) handle the actual transport of the messages. Several are available. Each encapsulates a specific message broker product to implement the pub/sub functionality. At the time of writing, the following pub/sub components were available:

- Apache Kafka
- Azure Event Hubs
- Azure Service Bus
- AWS SNS/SQS
- GCP Pub/Sub
- Hazelcast
- MQTT
- NATS
- Pulsar
- RabbitMQ
- Redis Streams

> [!NOTE]
> The Azure cloud stack has both messaging functionality (Azure Service Bus) and event streaming (Azure Event Hub) availability.

These components are created by the community in a [component-contrib repository on GitHub](https://github.com/dapr/components-contrib/tree/master/pubsub). You're encouraged to write your own Dapr component for a message broker that isn't yet supported.

### Configuration

Using a Dapr configuration file, you can specify the pub/sub component(s) to use. This configuration contains several fields. The `name` field specifies the pub/sub component that you want to use. When sending or receiving a message, you need to specify this name (as you saw earlier in the `PublishEventAsync` method signature).

Below you see an example of a Dapr configuration file for configuring a RabbitMQ message broker component:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub-rq
spec:
  type: pubsub.rabbitmq
  version: v1
  metadata:
  - name: host
    value: "amqp://localhost:5672"
  - name: durable
    value: true
```

In this example, you can see that you can specify any message broker-specific configuration in the `metadata` block. In this case, RabbitMQ is configured to create durable queues. But the RabbitMQ component has more configuration options. Each of the components' configuration will have its own set of possible fields. You can read which fields are available in the documentation of each [pub/sub component](https://docs.dapr.io/operations/components/setup-pubsub/supported-pubsub/).

Next to the programmatic way of subscribing to a topic from code, Dapr pub/sub also provides a declarative way of subscribing to a topic. This approach removes the Dapr dependency from the application code. Therefore, it also enables an existing application to subscribe to topics without any changes to the code. The following example shows a Dapr configuration file for configuring a subscription:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Subscription
metadata:
  name: newOrder-subscription
spec:
  pubsubname: pubsub
  topic: newOrder
  route: /orders
scopes:
- ServiceB
- ServiceC
```

You have to specify several elements with every subscription:

- The name of the Dapr pub/sub component you want to use (in this case `pubsub`).
- The name of the topic to subscribe to (in this case `newOrder`).
- The API operation that needs to be called for this topic (in this case `/orders`).
- The [scope](https://docs.dapr.io/developing-applications/building-blocks/pubsub/pubsub-scopes/) can specify which services can publish and subscribe to a topic.

## Sample application: Dapr Traffic Control

In Dapr Traffic Control sample app, the TrafficControl service uses the Dapr pub/sub building block to send speeding violations to the FineCollection service. Figure 7-4 shows the conceptual architecture of the Dapr Traffic Control sample application. The Dapr pub/sub building block is used in flows marked with number 2 in the diagram:

:::image type="content" source="./media/publish-subscribe/dapr-solution-pub-sub.png" alt-text="Conceptual architecture of the Dapr Traffic Control sample application.":::

**Figure 7-4**. Conceptual architecture of the Dapr Traffic Control sample application.

Speeding violations are handled by the `CollectionController`, an ordinary ASP.NET Core Controller. The `CollectionController.CollectFine` method subscribes to and handles `SpeedingViolation` event messages:

```csharp
[Topic("pubsub", "speedingviolations")]
[Route("collectfine")]
[HttpPost]
public async Task<ActionResult> CollectFine(
    SpeedingViolation speedingViolation, [FromServices] DaprClient daprClient)
{
    // ...
}
```

The method is decorated with the Dapr `Topic` attribute. It specifies that the pub/sub component named `pubsub` should be used to subscribe to messages sent to the `speedingviolations` topic.

The TrafficControl service sends speeding violations. Near the end of the `VehicleExit` method in the `TrafficController` class, the `DaprClient` object is used to publish `SpeedingViolation` messages using the pub/sub building block:

```csharp
/// ...

var speedingViolation = new SpeedingViolation
{
    VehicleId = msg.LicenseNumber,
    RoadId = _roadId,
    ViolationInKmh = violation,
    Timestamp = msg.Timestamp
};

// publish speedingviolation (Dapr publish / subscribe)
await daprClient.PublishEventAsync("pubsub", "speedingviolations", speedingViolation);

/// ...
```

Note how the `DaprClient` object reduces the call to a single line of code, again, binding to the `speedingviolations` topic and the Dapr `pubsub` component.

While the Traffic Control app uses RabbitMQ as the message broker, it never directly references RabbitMQ. Instead, the accompanying Dapr component configuration file named `pubsub.yaml` in the `/dapr/components` folder specifies the message broker:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: dapr-trafficcontrol
spec:
  type: pubsub.rabbitmq
  version: v1
  metadata:
  - name: host
    value: "amqp://localhost:5672"
  - name: durable
    value: "false"
  - name: deletedWhenUnused
    value: "false"
  - name: autoAck
    value: "false"
  - name: reconnectWait
    value: "0"
  - name: concurrency
    value: parallel
scopes:
  - trafficcontrolservice
  - finecollectionservice
```

The `type` element in the configuration, `pubsub.rabbitmq` instructs the building block to use the Dapr RabbitMQ component.

The `scopes` element in the configuration *constrains* application access to the RabbitMQ component. Only the TrafficControl and FineCollection services can consume it.

Using Dapr pub/sub in the Traffic Control sample application offers the following benefits:

1. No infrastructural abstraction of a message broker to maintain.
1. Services are temporally decoupled, which increases robustness.
1. Publisher and subscribers are unaware of each other. This means that additional services could be introduced that will react to speeding violations in the future, without the need to change the TrafficControl service.

## Summary

The pub/sub pattern helps you decouple services in a distributed application. The Dapr publish & subscribe building block simplifies implementing this behavior in your application.

Through Dapr pub/sub, you can publish messages to a specific *topic*. As well, the building block will query your service to determine which topic(s) to subscribe to.

You can use Dapr pub/sub natively over HTTP or by using one of the language-specific SDKs, such as the .NET SDK for Dapr. The .NET SDK tightly integrates with the ASP.NET core platform.

With Dapr, you can plug a supported message broker product into your application. You can then swap message brokers without requiring code changes to your application.

> [!div class="step-by-step"]
> [Previous](service-invocation.md)
> [Next](bindings.md)

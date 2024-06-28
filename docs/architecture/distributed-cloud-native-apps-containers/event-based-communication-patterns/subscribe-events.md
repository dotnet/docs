---
title: Subscribing to events
description: .NET Microservices Architecture for Containerized .NET Applications | Understand the details of publishing and subscription to integration events.
ms.date: 06/23/2021
---

# Subscribing to events

[!INCLUDE [download-alert](../includes/download-alert.md)]

The first step for using the event bus is to subscribe the microservices to the events they want to receive. That functionality should be done in the receiver microservices.

The following simple code shows what each receiver microservice needs to implement when starting the service (that is, in the `Startup` class) so it subscribes to the events it needs. In this case, the `basket-api` microservice needs to subscribe to `ProductPriceChangedIntegrationEvent` and the `OrderStartedIntegrationEvent` messages.

For instance, when subscribing to the `ProductPriceChangedIntegrationEvent` event, that makes the basket microservice aware of any changes to the product price and lets it warn the user about the change if that product is in the user's basket.

```csharp
var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

eventBus.Subscribe<ProductPriceChangedIntegrationEvent,
                   ProductPriceChangedIntegrationEventHandler>();

eventBus.Subscribe<OrderStartedIntegrationEvent,
                   OrderStartedIntegrationEventHandler>();
```

After this code runs, the subscriber microservice will be listening through RabbitMQ channels. When any message of type ProductPriceChangedIntegrationEvent arrives, the code invokes the event handler that is passed to it and processes the event.

## Publishing events through the event bus

Finally, the message sender (origin microservice) publishes the integration events with code similar to the following example. (This approach is a simplified example that does not take atomicity into account.) You would implement similar code whenever an event must be propagated across multiple microservices, usually right after committing data or transactions from the origin microservice.

First, the event bus implementation object (based on RabbitMQ or based on a service bus) would be injected at the controller constructor, as in the following code:

```csharp
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogContext _context;
    private readonly IOptionsSnapshot<Settings> _settings;
    private readonly IEventBus _eventBus;

    public CatalogController(CatalogContext context,
        IOptionsSnapshot<Settings> settings,
        IEventBus eventBus)
    {
        _context = context;
        _settings = settings;
        _eventBus = eventBus;
    }
    // ...
}
```

Then you use it from your controller's methods, like in the UpdateProduct method:

```csharp
[Route("items")]
[HttpPost]
public async Task<IActionResult> UpdateProduct([FromBody]CatalogItem product)
{
    var item = await _context.CatalogItems.SingleOrDefaultAsync(
        i => i.Id == product.Id);
    // ...
    if (item.Price != product.Price)
    {
        var oldPrice = item.Price;
        item.Price = product.Price;
        _context.CatalogItems.Update(item);
        var @event = new ProductPriceChangedIntegrationEvent(item.Id,
            item.Price,
            oldPrice);
        // Commit changes in original transaction
        await _context.SaveChangesAsync();
        // Publish integration event to the event bus
        // (RabbitMQ or a service bus underneath)
        _eventBus.Publish(@event);
        // ...
    }
    // ...
}
```

In this case, since the origin microservice is a simple CRUD microservice, that code is placed right into a Web API controller.

In more advanced microservices, like when using CQRS approaches, it can be implemented in the `CommandHandler` class, within the `Handle()` method.

### Designing atomicity and resiliency when publishing to the event bus

!TODO - need to add how the event bus Rabbit and the basket service works

![Screenshot of a browser showing the price change notification on the user cart.](media/display-item-price-change.png)

**Figure 7-24**. Displaying the item being added to the cart

## Idempotency in update message events

An important aspect of update message events is that a failure at any point in the communication should cause the message to be retried. Otherwise a background task might try to publish an event that has already been published, creating a race condition. Make sure that the updates are either idempotent or that they provide enough information to ensure that you can detect a duplicate, discard it, and send back only one response.

As noted earlier, idempotency means that an operation can be performed multiple times without changing the result. In a messaging environment, as when communicating events, an event is idempotent if it can be delivered multiple times without changing the result for the receiver microservice. This may be necessary because of the nature of the event itself, or because of the way the system handles the event. Message idempotency is important in any application that uses messaging, not just in applications that implement the event bus pattern.

An example of an idempotent operation is a SQL statement that inserts data into a table only if that data is not already in the table. It does not matter how many times you run that insert SQL statement; the result will be the same—the table will contain that data. Idempotency like this can also be necessary when dealing with messages if the messages could potentially be sent and therefore processed more than once. For instance, if retry logic causes a sender to send exactly the same message more than once, you need to make sure that it is idempotent.

It is possible to design idempotent messages. For example, you can create an event that says "set the product price to $25" instead of "add $5 to the product price." You could safely process the first message any number of times and the result will be the same. That is not true for the second message. But even in the first case, you might not want to process the first event, because the system could also have sent a newer price-change event and you would be overwriting the new price.

Another example might be an order-completed event that's propagated to multiple subscribers. The app has to make sure that order information is updated in other systems only once, even if there are duplicated message events for the same order-completed event.

It is convenient to have some kind of identity per event so that you can create logic that enforces that each event is processed only once per receiver.

Some message processing is inherently idempotent. For example, if a system generates image thumbnails, it might not matter how many times the message about the generated thumbnail is processed; the outcome is that the thumbnails are generated and they are the same every time. On the other hand, operations such as calling a payment gateway to charge a credit card may not be idempotent at all. In these cases, you need to ensure that processing a message multiple times has the effect that you expect.

## Deduplicating integration event messages

You can make sure that message events are sent and processed only once per subscriber at different levels. One way is to use a deduplication feature offered by the messaging infrastructure you are using. Another is to implement custom logic in your destination microservice. Having validations at both the transport level and the application level is your best bet.

### Deduplicating message events at the EventHandler level

One way to make sure that an event is processed only once by any receiver is by implementing certain logic when processing the message events in event handlers. For example, by wrapping one command within another.

### Deduplicating messages when using RabbitMQ

When intermittent network failures happen, messages can be duplicated, and the message receiver must be ready to handle these duplicated messages. If possible, receivers should handle messages in an idempotent way, which is better than explicitly handling them with deduplication.

According to the [RabbitMQ documentation](https://www.rabbitmq.com/reliability.html#consumer), "If a message is delivered to a consumer and then requeued (because it was not acknowledged before the consumer connection dropped, for example) then RabbitMQ will set the redelivered flag on it when it is delivered again (whether to the same consumer or a different one).

If the "redelivered" flag is set, the receiver must take that into account, because the message might already have been processed. But that is not guaranteed; the message might never have reached the receiver after it left the message broker, perhaps because of network issues. On the other hand, if the "redelivered" flag is not set, it is guaranteed that the message has not been sent more than once. Therefore, the receiver needs to deduplicate messages or process messages in an idempotent way only if the "redelivered" flag is set in the message.

## Implementing the .NET Aspire Azure Service Bus Component

In the realm of cloud-native applications, the need for robust and scalable messaging services is paramount. The Azure Service Bus, a fully managed enterprise integration message broker, is a critical component in facilitating this communication. It provides reliable message queues and publish-subscribe capabilities that enable complex messaging scenarios. The .NET Aspire Azure Service Bus component simplifies the integration of these services into your .NET applications.

### Prerequisites

Before diving into the implementation, ensure you have the following prerequisites in place:

- An active Azure subscription. You can create one for free if you don't already have one.
- A Service Bus namespace within Azure. This is essential for establishing the messaging infrastructure.

### Getting Started

To begin, install the `Aspire.Azure.Messaging.ServiceBus` NuGet package in your project. This package is the cornerstone of the .NET Aspire Azure Service Bus component, providing the necessary classes and methods for connecting to the Azure Service Bus.

```shell
dotnet add package Aspire.Azure.Messaging.ServiceBus
```

### Configuration

Configuration plays a vital role in the implementation of the Service Bus component. You can apply configurations either through code or via configuration files. The component supports `Microsoft.Extensions.Configuration`, allowing you to load settings from `appsettings.json` or other configuration sources.

Here's an example of how you might configure the Service Bus client in your `appsettings.json`:

```json
{
  "Aspire": {
    "Azure": {
      "Messaging": {
        "ServiceBus": {
          "DisableHealthChecks": true
        }
      }
    }
  }
}
```

### Example Usage

With the package installed and the configuration set, you can now register a `ServiceBusClient` in the dependency injection (DI) container of your application. In the `Program.cs` file, call the `AddAzureServiceBusClient` extension method:

```csharp
builder.AddAzureServiceBusClient("messaging");
```

To retrieve the configured `ServiceBusClient` instance, simply require it as a constructor parameter in your services:

```csharp
public class ExampleService
{
    private readonly ServiceBusClient _client;

    public ExampleService(ServiceBusClient client)
    {
        _client = client;
    }

    // ...
}
```

### App Host Usage

For applications using an app host, you can add Azure Service Bus hosting support by installing the `Aspire.Hosting.Azure.ServiceBus` NuGet package and registering the Service Bus component accordingly.

```shell
dotnet add package Aspire.Hosting.Azure.ServiceBus
```

In your app host project, you would then consume the service using the following pattern:

```csharp
var builder = DistributedApplication.CreateBuilder(args);
var serviceBus = builder.ExecutionContext.IsPublishMode
    ? builder.AddAzureServiceBus("messaging")
    : builder.AddConnectionString("messaging");

builder.AddProject<Projects.ExampleProject>()
       .WithReference(serviceBus);
```

### Additional resources

- **Eventual Consistency** \
    <https://en.wikipedia.org/wiki/Eventual_consistency>

- **The CAP Theorem** \
    <https://en.wikipedia.org/wiki/CAP_theorem>

- **Reliability Guide** (RabbitMQ documentation) \
    <https://www.rabbitmq.com/reliability.html#consumer>

> [!div class="step-by-step"]
> [Previous](background-tasks-with-ihostedservice.md)
> [Next](---To DO---)
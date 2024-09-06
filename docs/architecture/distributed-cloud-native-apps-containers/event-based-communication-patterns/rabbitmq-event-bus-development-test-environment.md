---
title: Implementing an event bus with RabbitMQ for the development or test environment
description: .NET Microservices Architecture for Containerized .NET Applications | Use RabbitMQ to implement event bus messaging for integration events in development or test environments.
ms.date: 01/13/2021
---
# Implementing an event bus with RabbitMQ for the development or test environment

[!INCLUDE [download-alert](../includes/download-alert.md)]

We should start by saying that if you create your custom event bus based on [RabbitMQ](https://www.rabbitmq.com/) running in a container, it should be used only for your development and test environments. Don't use it for your production environment, unless you're building it as a part of a production-ready service bus as described in the [Additional resources section below](rabbitmq-event-bus-development-test-environment.md#additional-resources). A simple custom event bus might be missing many production-ready critical features that a commercial service bus has.

The event bus implementation with RabbitMQ lets microservices subscribe to events, publish events, and receive events, as shown in Figure 7-21.

![Diagram showing RabbitMQ between message sender and message receiver.](./media/rabbitmq-implementation.png)

**Figure 7-21.** RabbitMQ implementation of an event bus

RabbitMQ functions as an intermediary between a message publisher and subscribers, to handle distribution. In the code, the `EventBusRabbitMQ` class implements the generic `IEventBus` interface. This implementation is based on dependency injection so that you can swap from this development and test version to a production version.

```csharp
public class EventBusRabbitMQ : IEventBus, IDisposable
{
    // Implementation using RabbitMQ API
    //...
}
```

The RabbitMQ implementation of a sample dev/test event bus is boilerplate code. It has to handle the connection to the RabbitMQ server and publish a message event to the queues. It also has to implement a collection of integration event handlers for each event type. These event types can have a different instantiation and different subscriptions for each receiver microservice, as shown in Figure 7-21.

## Implementing a simple publish method with RabbitMQ

The following code is a **simplified** version of an event bus implementation for RabbitMQ, to showcase the whole scenario. You don't really handle the connection this way. To see the full implementation, see the actual code in the [eShop Reference Architecture](https://github.com/dotnet/eShop/blob/main/src/EventBusRabbitMQ/RabbitMQEventBus.cs) repository.

```csharp
public class EventBusRabbitMQ : IEventBus, IDisposable
{
    // Member objects and other methods ...
    // ...

    public void Publish(IntegrationEvent @event)
    {
        var eventName = @event.GetType().Name;
        var factory = new ConnectionFactory() { HostName = _connectionString };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: _brokerName,
                type: "direct");
            string message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: _brokerName,
                routingKey: eventName,
                basicProperties: null,
                body: body);
       }
    }
}
```

As mentioned earlier, there are many possible configurations in RabbitMQ, so this code should be used only for dev/test environments. For example, you could improve a RabbitMQ implementation by using a [Polly](https://github.com/App-vNext/Polly) retry policy, which retries the task some times in case the RabbitMQ container is not ready. This scenario can occur when docker-compose is starting the containers. For example, the RabbitMQ container might start more slowly than the other containers.

## Implementing the subscription code with the RabbitMQ API

As with the publish code, the following code is a simplification of part of the event bus implementation for RabbitMQ. Again, you usually don't need to change it unless you are improving it.

```csharp
public class EventBusRabbitMQ : IEventBus, IDisposable
{
    // Member objects and other methods ...
    // ...

    public void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        var eventName = _subsManager.GetEventKey<T>();

        var containsKey = _subsManager.HasSubscriptionsForEvent(eventName);
        if (!containsKey)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {
                channel.QueueBind(queue: _queueName,
                                    exchange: BROKER_NAME,
                                    routingKey: eventName);
            }
        }

        _subsManager.AddSubscription<T, TH>();
    }
}
```

Each event type has a related channel to get events from RabbitMQ. You can then have as many event handlers per channel and event type as needed.

The `Subscribe` method accepts an `IIntegrationEventHandler` object, which is like a callback method in the current microservice, plus its related `IntegrationEvent` object. The code then adds that event handler to the list of event handlers that each integration event type can have per client microservice. If the client code has not already been subscribed to the event, the code creates a channel for the event type so it can receive events in a push style from RabbitMQ when that event is published from any other service.

## Implementing RabitMQ with .NET Aspire

When using .NET Aspire you can implement and configure RabbitMQ with much less custom code. Initially, you need to install the [Aspire.RabbitMQ.Client](https://www.nuget.org/packages/Aspire.RabbitMQ.Client) NuGet package. In the app host, install the [Aspire.Hosting.RabbitMQ](https://www.nuget.org/packages/Aspire.Hosting.RabbitMQ) NuGet package.

In the _Program.cs_ file of your microservice project, call the `AddRabbitMQClient` extension method to register an `IConnection` in the dependency injection container. The method takes a connection name parameter.

```csharp
Copy
builder.AddRabbitMQClient("messaging");
```

You can then retrieve the `IConnection` instance using dependency injection:

```csharp
copy
public class ExampleService(IConnection connection)
{
    // Use connection...
}
```

In your app host project, register a RabbitMQ server and consume the connection using the following methods, such as AddRabbitMQ:

```csharp
Copy
var builder = DistributedApplication.CreateBuilder(args);

var messaging = builder.AddRabbitMQ("messaging");

builder.AddProject<Projects.ExampleProject>()
       .WithReference(messaging);
```

The `WithReference` method configures a connection in the `ExampleProject` project named "messaging".

You can choose to provide the username and password explicitly for authenticating with RabbitMQ:

```csharp
Copy
var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);

var messaging = builder.AddRabbitMQ("messaging", username, password);

// Service consumption
builder.AddProject<Projects.ExampleProject>()
       .WithReference(messaging);
```

For more information, see [.NET Aspire RabbitMQ component](https://learn.microsoft.com/dotnet/aspire/messaging/rabbitmq-client-component)

## Additional resources

- **Peregrine Connect** - Simplify your integration with efficient design, deployment, and management of apps, APIs, and workflows \
  <https://www.peregrineconnect.com/why-peregrine/rabbitmq-integration>

- **NServiceBus** - Fully-supported commercial service bus with advanced management and monitoring tooling for .NET \
  <https://particular.net/>

- **EasyNetQ** - Open Source .NET API client for RabbitMQ \
  <https://easynetq.com/>

- **MassTransit** - Free, open-source distributed application framework for .NET \
  <https://masstransit-project.com/>
  
- **Rebus** - Open source .NET Service Bus \
  <https://github.com/rebus-org/Rebus>

> [!div class="step-by-step"]
> [Previous](integration-event-based-microservice-communications.md)
> [Next](background-tasks-with-ihostedservice.md)

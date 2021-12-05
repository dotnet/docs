---
title: The Dapr actors building block
description: A deep dive into the Dapr actors building block and how to apply it
author: amolenk
ms.date: 11/17/2021
---

# The Dapr actors building block

The actor model originated in 1973. It was proposed by Carl Hewitt as a conceptual model of concurrent computation, a form of computing in which several computations are executed at the same time. Highly parallel computers weren't yet available at that time, but the more recent advancements of multi-core CPUs and distributed systems have made the actor model popular.

In the actor model, the *actor* is an independent unit of compute and state. Actors are completely isolated from each other and they will never share memory. Actors communicate with each other using messages. When an actor receives a message, it can change its internal state, and send messages to other (possibly new) actors.

The reason why the actor model makes writing concurrent systems easier is that it provides a turn-based (or single-threaded) access model. Multiple actors can run at the same time, but each actor will process received messages one at a time. This means that you can be sure that at most one thread is active inside an actor at any time. That makes writing correct concurrent and parallel systems much easier.

## What it solves

Actor model implementations are usually tied to a specific language or platform. With the Dapr actors building block however, you can leverage the actor model from any language or platform.

Dapr's implementation is based on the [virtual actor pattern introduced by Project "Orleans"](https://www.microsoft.com/research/project/orleans-virtual-actors/). With the virtual actor pattern, you don't need to explicitly create actors. Actors are activated implicitly and placed on a node in the cluster the first time a message is sent to the actor. When not executing operations, actors are silently unloaded from memory. If a node fails, Dapr automatically moves activated actors to healthy nodes. Besides sending messages between actors, the Dapr actor model also support scheduling future work using timers and reminders.

While the actor model can provide great benefits, it's important to carefully consider the actor design. For example, having many clients call the same actor will result in poor performance because the actor operations execute serially. Here are some criteria to check if a scenario is a good fit for Dapr actors:

- Your problem space involves concurrency. Without actors, you'd have to introduce explicit locking mechanisms in your code.
- Your problem space can be partitioned into small, independent, and isolated units of state and logic.
- You don't need low-latency reads of the actor state. Low-latency reads cannot be guaranteed because actor operations execute serially.
- You don't need to query state across a set of actors. Querying across actors is inefficient because each actor's state needs to be read individually and can introduce unpredictable latencies.

One design pattern that fits these criteria quite well is the [orchestration-based saga](/azure/architecture/reference-architectures/saga/saga) or *process manager* design pattern. A saga manages a sequence of steps that must be taken to reach some outcome. The saga (or process manager) maintains the current state of the sequence and triggers the next step. If a step fails, the saga can execute compensating actions. Actors make it easy to deal with concurrency in the saga and to keep track of the current state. The [eShopOnDapr reference application](reference-application.md) uses the saga pattern and Dapr actors to implement the Ordering process.

## How it works

The Dapr sidecar provides the HTTP/gRPC API to invoke actors. This is the base URL of the HTTP API:

```http
http://localhost:<daprPort>/v1.0/actors/<actorType>/<actorId>/
```

- `<daprPort>`: the HTTP port that Dapr listens on.
- `<actorType>`: the actor type.
- `<actorId>`: the ID of the specific actor to call.

The sidecar manages how, when and where each actor runs, and also routes messages between actors. When an actor hasn't been used for a period of time, the runtime deactivates the actor and removes it from memory. Any state managed by the actor is persisted and will be available when the actor re-activates. Dapr uses an idle timer to determine when an actor can be deactivated. When an operation is called on the actor (either by a method call or a reminder firing), the idle timer is reset and the actor instance will remain activated.

The sidecar API is only one part of the equation. The service itself also needs to implement an API specification, because the actual code that you write for the actor will run inside the service itself. Figure 11-1 shows the various API calls between the service and its sidecar:

:::image type="content" source="./media/actors/sidecar-communication.png" alt-text="Diagram of API calls between actor service and Dapr sidecar.":::

**Figure 11-1**. API calls between actor service and Dapr sidecar.

To provide scalability and reliability, actors are partitioned across all the instances of the actor service. The Dapr placement service is responsible for keeping track of the partitioning information. When a new instance of an actor service is started, the sidecar registers the supported actor types with the placement service. The placement service calculates the updated partitioning information for the given actor type and broadcasts it to all instances. Figure 11-2 shows what happens when a service is scaled out to a second replica:

:::image type="content" source="./media/actors/placement.png" alt-text="Diagram of the actor placement service.":::

**Figure 11-2**. Actor placement service.

1. On startup, the sidecar makes a call to the actor service to get the registered actor types as well as actor configuration settings.
2. The sidecar sends the list of registered actor types to the placement service.
3. The placement service broadcasts the updated partitioning information to all actor service instances. Each instance will keep a cached copy of the partitioning information and use it to invoke actors.

> [!IMPORTANT]
> Because actors are randomly distributed across service instances, it should be expected that an actor operation always requires a call to a different node in the network.

The next figure shows an ordering service instance running in Pod 1 call the `ship` method of an `OrderActor` instance with ID `3`. Because the actor with ID `3` is placed in a different instance, this results in a call to a different node in the cluster:

:::image type="content" source="./media/actors/invoke-actor-method.png" alt-text="Diagram of calling an actor method.":::

**Figure 11-3**. Calling an actor method.

1. The service calls the actor API on the sidecar. The JSON payload in the request body contains the data to send to the actor.
2. The sidecar uses the locally cached partitioning information from the placement service to determine which actor service instance (partition) is responsible for hosting the actor with ID `3`. In this example, it's the service instance in pod 2. The call is forwarded to the appropriate sidecar.
3. The sidecar instance in pod 2 calls the service instance to invoke the actor. The service instance activates the actor (if it hasn't already) and executes the actor method.

### Turn-based access model

The turn-based access model ensures that at any time there's at most one thread active inside an actor instance. To understand why this is useful, consider the following example of a method that increments a counter value:

```csharp
public int Increment()
{
    var currentValue = GetValue();
    var newValue = currentValue + 1;

    SaveValue(newValue);

    return newValue;
}
```

Let's assume that the current value returned by the `GetValue` method is `1`. When two threads call the `Increment` method at the same time, there's a risk of both of them calling the `GetValue` method before one of them calls `SaveValue`. This results in both threads starting with the same initial value (`1`). The threads then increment the value to `2` and return it to the caller. The resulting value after the two calls is now `2` instead of `3` which it should be. This is a simple example to illustrate the kind of issues that can slip into your code when working with multiple threads, and is easy to solve. In real world applications however, concurrent and parallel scenarios can become very complex.

In traditional programming models, you can solve this problem by introducing locking mechanisms. For example:

```csharp
public int Increment()
{
    int newValue;

    lock (_lockObject)
    {
        var currentValue = GetValue();
        newValue = currentValue + 1;

        SaveValue(newValue);
    }

    return newValue;
}
```

Unfortunately, using explicit locking mechanisms is error-prone. They can easily lead to deadlocks and can have serious impact on performance.

Thanks to the turn-based access model, you don't need to worry about multiple threads with actors, making it much easier to write concurrent systems. The following actor example closely mirrors the code from the previous sample, but doesn't require any locking mechanisms to be correct:

```csharp
public async Task<int> IncrementAsync()
{
    var counterValue = await StateManager.TryGetStateAsync<int>("counter");

    var currentValue = counterValue.HasValue ? counterValue.Value : 0;
    var newValue = currentValue + 1;

    await StateManager.SetStateAsync("counter", newValue);

    return newValue;
}
```

### Timers and reminders

Actors can use timers and reminders to schedule calls to themselves. Both concepts support the configuration of a due time. The difference lies in the lifetime of the callback registrations:

- Timers will only stay active as long as the the actor is activated. Timers *will not* reset the idle-timer, so they cannot keep an actor active on their own.
- Reminders outlive actor activations. If an actor is deactivated, a reminder will re-activate the actor. Reminders *will* reset the idle-timer.

Timers are registered by making a call to the actor API. In the following example, a timer is registered with a due time of 0 and a period of 10 seconds.

```bash
curl -X POST http://localhost:3500/v1.0/actors/<actorType>/<actorId>/timers/<name> \
  -H "Content-Type: application/json" \
  -d '{
        "dueTime": "0h0m0s0ms",
        "period": "0h0m10s0ms"
      }'
```

Because the due time is 0, the timer will fire immediately. After a timer callback has finished, the timer will wait 10 seconds before firing again.

Reminders are registered in a similar way. The following example shows a reminder registration with a due time of 5 minutes, and an empty period:

```bash
curl -X POST http://localhost:3500/v1.0/actors/<actorType>/<actorId>/reminders/<name> \
  -H "Content-Type: application/json" \
  -d '{
        "dueTime": "0h5m0s0ms",
        "period": ""
      }'
```

This reminder will fire in 5 minutes. Because the given period is empty, this will be a one-time reminder.

> [!NOTE]
> Timers and reminders both respect the turn-based access model. When a timer or reminder fires, the callback will not be executed until any other method invocation or timer/reminder callback has finished.

### State persistence

Actor state is persisted using the Dapr [state management building block](state-management.md). Because actors can execute multiple state operations in a single turn, the state store component must support multi-item transactions. At the time of writing, the following state stores support multi-item transactions:

- Azure Cosmos DB
- MongoDB
- MySQL
- PostgreSQL
- Redis
- RethinkDB
- SQL Server

To configure a state store component for use with actors, you need to append the following metadata to the state store configuration:

```yaml
- name: actorStateStore
  value: "true"
```

Here's a complete example for a Redis state store:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    value: ""
  - name: actorStateStore
    value: "true"
```

## Use the Dapr .NET SDK

You can create an actor model implementation using only HTTP/gRPC calls. However, it's much more convenient to use the language specific Dapr SDKs. At the time of writing, the .NET, Java and Python SDKs all provide extensive support for working with actors.

To get started with the .NET Dapr actors SDK, you add a package reference to [`Dapr.Actors`](https://www.nuget.org/packages/Dapr.Actors) to your service project. The first step of creating an actual actor is to define an interface that derives from `IActor`. Clients use the interface to invoke operations on the actor. Here's a simple example of an actor interface for keeping scores:

```csharp
public interface IScoreActor : IActor
{
    Task<int> IncrementScoreAsync();

    Task<int> GetScoreAsync();
}
```

> [!IMPORTANT]
> The return type of an actor method must be `Task` or `Task<T>`. Also, actor methods can have at most one argument. Both the return type and the arguments must be `System.Text.Json` serializable.

Next, implement the actor by deriving a `ScoreActor` class from `Actor`. The `ScoreActor` class must also implement the `IScoreActor` interface:

```csharp
public class ScoreActor : Actor, IScoreActor
{
    public ScoreActor(ActorHost host) : base(host)
    {
    }

    // TODO Implement interface methods.
}
```

The constructor in the snippet above takes a `host` argument of type `ActorHost`. The `ActorHost` class represents the host for an actor type within the actor runtime. You need to pass this argument to the constructor of the `Actor` base class. Actors also support dependency injection. Any additional arguments that you add to the actor constructor are resolved using the .NET dependency injection container.

Let's now implement the `IncrementScoreAsync` method of the interface:

```csharp
public Task<int> IncrementScoreAsync()
{
    return StateManager.AddOrUpdateStateAsync(
        "score",
        1,
        (key, currentScore) => currentScore + 1
    );
}
```

In the snippet above, a single call to `StateManager.AddOrUpdateStateAsync` provides the full implementation for the `IncrementScoreAsync` method. The `AddOrUpdateStateAsync` method takes three arguments:

1. The key of the state to update.
1. The value to write if no score is stored in the state store yet.
1. A `Func` to call if there already is a score stored in the state store. It takes the state key and current score, and returns the updated score to write back to the state store.

The `GetScoreAsync` implementation reads the current score from the state store and returns it to the client:

```csharp
public async Task<int> GetScoreAsync()
{
    var scoreValue = await StateManager.TryGetStateAsync<int>("score");
    if (scoreValue.HasValue)
    {
        return scoreValue.Value;
    }

    return 0;
}
```

To host actors in an ASP.NET Core service, you must add a reference to the [`Dapr.Actors.AspNetCore`](https://www.nuget.org/packages/Dapr.Actors.AspNetCore) package and make some changes in the `Program` file. In the following example, the call to `MapActorsHandlers` registers Dapr Actor endpoints in ASP.NET Core routing:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Actors building block does not support HTTPS redirection.
//app.UseHttpsRedirection();
app.MapControllers();
// Add actor endpoints.
app.MapActorsHandlers();
```

The actors endpoints are necessary because the Dapr sidecar calls the application to host and interact with actor instances.

> [!IMPORTANT]
> Make sure your `Startup` class does not contain an `app.UseHttpsRedirection` call to redirect clients to the HTTPS endpoint. This will not work with actors. By design, a Dapr sidecar sends requests over unencrypted HTTP by default. The HTTPS middleware will block these requests when enabled.

The `Program` file is also the place to register the specific actor types. The following example registers the `ScoreActor` using the `AddActors` extension method:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddActors(options =>
{
    options.Actors.RegisterActor<ScoreActor>();
});
```

At this point, the ASP.NET Core service is ready to host the `ScoreActor` and accept incoming requests. Client applications use actor proxies to invoke operations on actors. The following example shows how a console client application invokes the `IncrementScoreAsync` operation on a `ScoreActor` instance:

```csharp
var actorId = new ActorId("scoreActor1");

var proxy = ActorProxy.Create<IScoreActor>(actorId, "ScoreActor");

var score = await proxy.IncrementScoreAsync();

Console.WriteLine($"Current score: {score}");
```

The above example uses the [`Dapr.Actors`](https://www.nuget.org/packages/Dapr.Actors) package to call the actor service. To invoke an operation on an actor, you need to be able to address it. You'll need two parts for this:

1. The **actor type** uniquely identifies the actor implementation across the whole application. By default, the actor type is the name of the implementation class (without namespace). You can customize the actor type by adding an `ActorAttribute` to the implementation class and setting its `TypeName` property.
1. The `ActorId` uniquely identifies an instance of an actor type. You can also use this class to generate a random actor id by calling `ActorId.CreateRandom`.

The example uses `ActorProxy.Create` to create a proxy instance for the `ScoreActor`. The `Create` method takes two arguments: the `ActorId` identifying the specific actor and the actor type. It also has a generic type parameter to specify the actor interface that the actor type implements. As both the server and client applications need to use the actor interfaces, they're typically stored in a separate shared project.

The final step in the example calls the `IncrementScoreAsync` method on the actor and outputs the result. Remember that the Dapr placement service distributes the actor instances across the Dapr sidecars. Therefore, expect an actor call to be a network call to another node.

### Call actors from ASP.NET Core clients

The console client example in the previous section uses the static `ActorProxy.Create` method directly to get an actor proxy instance. If the client application is an ASP.NET Core application, you should use the `IActorProxyFactory` interface to create actor proxies. The main benefit is that it allows you to manage configuration in one place. The `AddActors` extension method on `IServiceCollection` takes a delegate that allows you to specify actor runtime options, such as the HTTP endpoint of the Dapr sidecar. The following example specifies custom `JsonSerializerOptions` to use for actor state persistence and message deserialization:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddActors(options =>
{
    var jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    options.JsonSerializerOptions = jsonSerializerOptions;
    options.Actors.RegisterActor<ScoreActor>();
});
```

The call to `AddActors` registers the `IActorProxyFactory` for .NET dependency injection. This allows ASP.NET Core to inject an `IActorProxyFactory` instance into your controller classes. The following example calls an actor method from an ASP.NET Core controller class:

```csharp
[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly IActorProxyFactory _actorProxyFactory;

    public ScoreController(IActorProxyFactory actorProxyFactory)
    {
        _actorProxyFactory = actorProxyFactory;
    }

    [HttpPut("{scoreId}")]
    public Task<int> IncrementAsync(string scoreId)
    {
        var scoreActor = _actorProxyFactory.CreateActorProxy<IScoreActor>(
            new ActorId(scoreId),
            "ScoreActor");

        return scoreActor.IncrementScoreAsync();
    }
}
```

Actors can also call other actors directly. The `Actor` base class exposes an `IActorProxyFactory` class through the `ProxyFactory` property. To create an actor proxy from within an actor, use the `ProxyFactory` property of the `Actor` base class. The following example shows an `OrderActor` that invokes operations on two other actors:

```csharp
public class OrderActor : Actor, IOrderActor
{
    public OrderActor(ActorHost host) : base(host)
    {
    }

    public async Task ProcessOrderAsync(Order order)
    {
        var stockActor = ProxyFactory.CreateActorProxy<IStockActor>(
            new ActorId(order.OrderNumber),
            "StockActor");

        await stockActor.ReserveStockAsync(order.OrderLines);

        var paymentActor = ProxyFactory.CreateActorProxy<IPaymentActor>(
            new ActorId(order.OrderNumber),
            "PaymentActor");

        await paymentActor.ProcessPaymentAsync(order.PaymentDetails);
    }
}
```

> [!NOTE]
> By default, Dapr actors aren't reentrant. This means that a Dapr actor cannot be called more than once in the same chain. For example, the call chain `Actor A -> Actor B -> Actor A` is not allowed. At the time of writing, there's a preview feature available to support reentrancy. However, there is no SDK support yet. For more details, see the [official documentation](https://docs.dapr.io/developing-applications/building-blocks/actors/actor-reentrancy/).

### Call non-.NET actors

So far, the examples used strongly-typed actor proxies based on .NET interfaces to illustrate actor invocations. This works great when both the actor host and client are .NET applications. However, if the actor host is not a .NET application, you don't have an actor interface to create a strongly-typed proxy. In these cases, you can use a weakly-typed proxy.

You create weakly-typed proxies in a similar way to strongly-typed proxies. Instead of relying on a .NET interface, you need to pass in the actor method name as a string.

```csharp
[HttpPut("{scoreId}")]
public Task<int> IncrementAsync(string scoreId)
{
    var scoreActor = _actorProxyFactory.CreateActorProxy(
        new ActorId(scoreId),
        "ScoreActor");

    return scoreActor("IncrementScoreAsync");
}
```

### Timers and reminders

Use the `RegisterTimerAsync` method of the `Actor` base class to schedule actor timers. In the following example, a `TimerActor` exposes a `StartTimerAsync` method. Clients can call the method to start a timer that repeatedly writes a given text to the log output.

```csharp
public class TimerActor : Actor, ITimerActor
{
    public TimerActor(ActorHost host) : base(host)
    {
    }

    public Task StartTimerAsync(string name, string text)
    {
        return RegisterTimerAsync(
            name,
            nameof(TimerCallback),
            Encoding.UTF8.GetBytes(text),
            TimeSpan.Zero,
            TimeSpan.FromSeconds(3));
    }

    public Task TimerCallbackAsync(byte[] state)
    {
        var text = Encoding.UTF8.GetString(state);

        Logger.LogInformation($"Timer fired: {text}");

        return Task.CompletedTask;
    }
}
```

The `StartTimerAsync` method calls `RegisterTimerAsync` to schedule the timer. `RegisterTimerAsync` takes five arguments:

1. The name of the timer.
1. The name of the method to call when the timer fires.
1. The state to pass to the callback method.
1. The amount of time to wait before the callback method is first invoked.
1. The time interval between callback method invocations. You can specify `TimeSpan.FromMilliseconds(-1)` to disable periodic signaling.

The `TimerCallbackAsync` method receives the user state in binary form. In the example, the callback decodes the state back to a `string` before writing it to the log.

Timers can be stopped by calling `UnregisterTimerAsync`:

```csharp
public class TimerActor : Actor, ITimerActor
{
    // ...

    public Task StopTimerAsync(string name)
    {
        return UnregisterTimerAsync(name);
    }
}
```

Remember that timers do not reset the actor idle timer. When no other calls are made on the actor, it may be deactivated and the timer will be stopped automatically. To schedule work that does reset the idle timer, use reminders which we'll look at next.

To use reminders in an actor, your actor class must implement the `IRemindable` interface:

```csharp
public interface IRemindable
{
    Task ReceiveReminderAsync(
        string reminderName, byte[] state,
        TimeSpan dueTime, TimeSpan period);
}
```

The `ReceiveReminderAsync` method is called when a reminder is fired. It takes 4 arguments:

1. The name of the reminder.
1. The user state provided during registration.
1. The invocation due time provided during registration.
1. The invocation period provided during registration.

To register a reminder, use the `RegisterReminderAsync` method of the actor base class. The following example sets a reminder to fire a single time with a due time of three minutes.

```csharp
public class ReminderActor : Actor, IReminderActor, IRemindable
{
    public ReminderActor(ActorHost host) : base(host)
    {
    }

    public Task SetReminderAsync(string text)
    {
        return RegisterReminderAsync(
            "DoNotForget",
            Encoding.UTF8.GetBytes(text),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromMilliseconds(-1));
    }

    public Task ReceiveReminderAsync(
        string reminderName, byte[] state,
        TimeSpan dueTime, TimeSpan period)
    {
        if (reminderName == "DoNotForget")
        {
            var text = Encoding.UTF8.GetString(state);

            Logger.LogInformation($"Don't forget: {text}");
        }

        return Task.CompletedTask;
    }
}
```

The `RegisterReminderAsync` method is similar to `RegisterTimerAsync` but you don't have to specify a callback method explicitly. As the above example shows, you implement `IRemindable.ReceiveReminderAsync` to handle fired reminders.

Reminders both reset the idle timer and are persistent. Even if your actor is deactivated, it will be reactivated at the moment a reminder fires. To stop a reminder from firing, call `UnregisterReminderAsync`.

## Sample application: Dapr Traffic Control

The default version of Dapr Traffic Control does not use the actor model. However, it does contain an alternative actor-based implementation of the TrafficControl service that you can enable. To make use of actors in the TrafficControl service, open up the `src/TrafficControlService/Controllers/TrafficController.cs` file and uncomment the `USE_ACTORMODEL` statement at the top of the file:

```csharp
#define USE_ACTORMODEL
```

When the actor model is enabled, the application uses actors to represent vehicles. The operations that can be invoked on the vehicle actors are defined in an `IVehicleActor` interface:

```csharp
public interface IVehicleActor : IActor
{
    Task RegisterEntryAsync(VehicleRegistered msg);
    Task RegisterExitAsync(VehicleRegistered msg);
}
```

The (simulated) entry cameras call the `RegisterEntryAsync` method when a new vehicle is first detected in the lane. The only responsibility of this method is storing the entry timestamp in the actor state:

```csharp
var vehicleState = new VehicleState
{
    LicenseNumber = msg.LicenseNumber,
    EntryTimestamp = msg.Timestamp
};
await StateManager.SetStateAsync("VehicleState", vehicleState);
```

When the vehicle reaches the end of the speed camera zone, the exit camera calls the `RegisterExitAsync` method. The `RegisterExitAsync` method first gets the current states and updates it to include the exit timestamp:

```csharp
var vehicleState = await StateManager.GetStateAsync<VehicleState>("VehicleState");
vehicleState.ExitTimestamp = msg.Timestamp;
```

> [!NOTE]
> The code above currently assumes that a `VehicleState` instance has already been saved by the `RegisterEntryAsync` method. The code could be improved by first checking to make sure the state exists. Thanks to the turn-based access model, no explicit locks are required in the code.

After the state is updated, the `RegisterExitAsync` method checks if the vehicle was driving too fast. If it was, the actor publishes a message to the `collectfine` pub/sub topic:

```csharp
int violation = _speedingViolationCalculator.DetermineSpeedingViolationInKmh(
    vehicleState.EntryTimestamp, vehicleState.ExitTimestamp);

if (violation > 0)
{
    var speedingViolation = new SpeedingViolation
    {
        VehicleId = msg.LicenseNumber,
        RoadId = _roadId,
        ViolationInKmh = violation,
        Timestamp = msg.Timestamp
    };

    await _daprClient.PublishEventAsync("pubsub", "collectfine", speedingViolation);
}
```

The code above uses two external dependencies. The `_speedingViolationCalculator` encapsulates the business logic for determining whether or not a vehicle has driven too fast. The `_daprClient` allows the actor to publish messages using the Dapr pub/sub building block.

Both dependencies are registered in the `Startup` class and injected into the actor using constructor dependency injection:

```csharp
private readonly DaprClient _daprClient;
private readonly ISpeedingViolationCalculator _speedingViolationCalculator;
private readonly string _roadId;

public VehicleActor(
    ActorHost host, DaprClient daprClient,
    ISpeedingViolationCalculator speedingViolationCalculator)
    : base(host)
{
    _daprClient = daprClient;
    _speedingViolationCalculator = speedingViolationCalculator;
    _roadId = _speedingViolationCalculator.GetRoadId();
}
```

The actor based implementation no longer uses the Dapr state management building block directly. Instead, the state is automatically persisted after each operation is executed.

## Summary

The Dapr actors building block makes it easier to write correct concurrent systems. Actors are small units of state and logic. They use a turn-based access model which saves you from having to use locking mechanisms to write thread-safe code. Actors are created implicitly and are silently unloaded from memory when no operations are performed. Any state stored in the actor is automatically persisted and loaded when the actor is reactivated. Actor model implementations are typically created for a specific language or platform. With the Dapr actors building block however, you can leverage the actor model from any language or platform.

Actors support timers and reminders to schedule future work. Timers do not reset the idle timer and will allow the actor to be deactivated when no other operations are performed. Reminders do reset the idle timer and are also persisted automatically. Both timers and reminders respect the turn-based access model, making sure that no other operations can execute while the timer/reminder events are handled.

Actor state is persisted using the Dapr [state management building block](state-management.md). Any state store that supports multi-item transactions can be used to store actor state.

### References

- [Dapr supported state stores](https://docs.dapr.io/operations/components/setup-state-store/supported-state-stores/)

>[!div class="step-by-step"]
>[Previous](bindings.md)
>[Next](observability.md)

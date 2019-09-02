---
title: Migrating Duplex Services to gRPC
description: gRPC for WCF Developers | Migrating Duplex Services to gRPC
author: markrendle
ms.date: 09/02/2019
---

# Duplex Services

There are multiple ways to use Duplex services in WCF. Some services are initiated by the client and then stream data from the server; other "Full Duplex" services might involve more ongoing two-way communication like the classic "Calculator" example from the WCF documentation. In this chapter we'll take two possible WCF "Stock Ticker" implementations and migrate them to gRPC, one using a Server-streaming RPC, and one a Bi-directional Streaming RPC.

## Server-streaming RPC

In our server-streaming WCF example, *SimpleStockPriceTicker*, we have a Duplex service where the client initiates the connection with a list of stock symbols, and the server uses the *callback interface* to send updates as they become available. The client implements that interface and does whatever it does with the stream of real-time information.

### The WCF solution

The WCF solution is implemented as a self-hosted NetTCP server in a .NET 4.x console application.

#### The ServiceContract

```csharp
[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISimpleStockTickerCallback))]
public interface ISimpleStockTickerService
{
    [OperationContract(IsOneWay = true)]
    void Subscribe(string[] symbols);
}
```

The service has a single method with no return type, because it will be using the callback interface `ISimpleStockTickerCallback` to send data to the client in real time.

#### The Callback interface

```csharp
[ServiceContract]
public interface ISimpleStockTickerCallback
{
    [OperationContract(IsOneWay = true)]
    void Update(string symbol, decimal price);
}
```

The implementations of these interfaces can be found in the solution, along with faked external dependencies to provide test data.

### gRPC Streaming

The gRPC way of handling real time data is different. A call from client to server can create a persistent stream, which can be monitored for messages arriving asynchronously. Despite the difference, we will see how streams can be a more intuitive way of dealing with this data, and are more relevant in modern programming with the emphasis on LINQ, Reactive Streams, functional programming and so on.

Our service definition needs two messages: one for the request, and one for the stream. The service returns a stream of the `StockTickerUpdate` message using the `stream` keyword in its `return` declaration. We'll add a `Timestamp` to the update to show the exact time the price changed.

#### simple_stock_ticker.proto

```protobuf
syntax = "proto3";

option csharp_namespace = "TraderSys.SimpleStockTickerServer.Protos";

import "google/protobuf/timestamp.proto";

package SimpleStockTickerServer;

service SimpleStockTicker {
  rpc Subscribe (SubscribeRequest) returns (stream StockTickerUpdate);
}

message SubscribeRequest {
  repeated string symbols = 1;
}

message StockTickerUpdate {
  string symbol = 1;
  double price = 2;
  google.protobuf.Timestamp time = 3;
}
```

### Implementing the SimpleStockTicker

We can reuse the `StockPriceSubscriber` fake from the WCF project by copying the three classes from the `TraderSys.StockMarket` class library into a new .NET Standard class library in our target solution. To better follow best practices, we'll add a `Factory` type to create instances of it and register the `IStockPriceSubscribeFactory` with ASP.NET Core's dependency injection services.

#### The Factory implementation

```csharp
public interface IStockPriceSubscriberFactory
{
    IStockPriceSubscriber GetSubscriber(string[] symbols);
}

public class StockPriceSubscriberFactory : IStockPriceSubscriberFactory
{
    public IStockPriceSubscriber GetSubscriber(string[] symbols)
    {
        return new StockPriceSubscriber(symbols);
    }
}
```

#### Registering the Factory

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
    services.AddSingleton<IStockPriceSubscriberFactory, StockPriceSubscriberFactory>();
}
```

Now we can use this class to implement the gRPC StockTicker service.

#### StockTickerService.cs

```csharp
public class StockTickerService : Protos.SimpleStockTicker.SimpleStockTickerBase
{
    private readonly IStockPriceSubscriberFactory _subscriberFactory;

    public StockTickerService(IStockPriceSubscriberFactory subscriberFactory)
    {
        _subscriberFactory = subscriberFactory;
    }

    public override async Task Subscribe(SubscribeRequest request, IServerStreamWriter<StockTickerUpdate> responseStream, ServerCallContext context)
    {
        var subscriber = _subscriberFactory.GetSubscriber(request.Symbols.ToArray());

        subscriber.Update += async (sender, args) =>
            await WriteUpdateAsync(responseStream, args.Symbol, args.Price);

        await AwaitCancellation(context.CancellationToken);
    }

    private async Task WriteUpdateAsync(IServerStreamWriter<StockTickerUpdate> stream, string symbol, decimal price)
    {
        try
        {
            await stream.WriteAsync(new StockTickerUpdate
            {
                Symbol = symbol,
                Price = Convert.ToDouble(price),
                Time = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
            });
        }
        catch (Exception e)
        {
            // Handle any errors due to broken connection etc.
            _logger.LogError($"Failed to write message: {e.Message}");
        }
    }

    private static Task AwaitCancellation(CancellationToken token)
    {
        var completion = new TaskCompletionSource<object>();
        token.Register(() => completion.SetResult(null));
        return completion.Task;
    }
}
```

As you can see, although the declaration in the `.proto` file says the method "returns" a stream of `StockTickerUpdate` messages, in fact it returns a vanilla `Task`. The job of creating the stream is handled by the generated code and the gRPC runtime libraries, and we are just handed the `IServerStreamWriter<StockTickerUpdate>` response stream, ready to use.

Unlike a WCF duplex service, where the instance of the service class is kept alive while the connection is open, our gRPC service uses the returned Task to keep the service alive. The Task should not complete until the connection is closed.

We can tell when the client has closed the connection by using the `CancellationToken` from the `ServerCallContext`. We've used a simple static method, `AwaitCancellation`, to create a Task that completes when the token is cancelled.

In the `Subscribe` method, then, we get a `StockPriceSubscriber` and add an event handler that writes to the response stream. Then we wait for the connection to be closed, before immediately disposing the `subscriber` to prevent it trying to write data to the closed stream.

The `WriteUpdateAsync` method has a `try`/`catch` block to handle any errors that might happen when writing a message to the stream. This is an important consideration in persistent connections over networks, which could be broken at any millisecond, whether intentionally or due to an failure somewhere.

### Using the StockTickerService from a client application

We can follow the same steps in the previous section to create a shareable client class library from the `.proto` file. In the sample, there is a .NET Core 3.0 console application that demonstrates how to use the client.

#### Example Program.cs

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new SimpleStockTicker.SimpleStockTickerClient(channel);

        var request = new SubscribeRequest();
        request.Symbols.AddRange(args);

        using var stream = client.Subscribe(request);

        var tokenSource = new CancellationTokenSource();

        var task = DisplayAsync(stream.ResponseStream, tokenSource.Token);

        WaitForExitKey();

        tokenSource.Cancel();
        await task;
    }
}
```

In this case, the `Subscribe` method on the generated client is not asynchronous. The stream is created and usable right away, because its `MoveNext` method is asynchronous and the first time it is called it will not complete until the connection is alive.

We pass the stream to an async `DisplayAsync` method, wait for the user to press a key, then cancel the `DisplayAsync` method and wait for the task to complete before exiting.

> [!NOTE]
> We're using the new C# 8 "using declaration" syntax here to dispose of the stream and the channel when the `Main` method exits. It's a small change, but a nice one that reduces indentations and empty lines.

#### Consuming the stream

```csharp
static async Task DisplayAsync(IAsyncStreamReader<StockTickerUpdate> stream, CancellationToken token)
{
    try
    {
        while (await stream.MoveNext(token))
        {
            var update = stream.Current;
            Console.WriteLine($"{update.Symbol}: {update.Price}");
        }
    }
    catch (RpcException e)
    {
        if (e.StatusCode == StatusCode.Cancelled)
        {
            return;
        }
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Finished.");
    }
}
```

The `IAsyncStreamReader<T>` type works much like an `IEnumerator<T>`: there is a `MoveNext` method that will return true as long as there is more data, and a `Current` property that returns the latest value. The only difference is that the `MoveNext` method returns a `Task<bool>` instead of just a `bool`.

> [!TIP]
> In the section at the end of the chapter, we'll look at how to add extension methods to wrap `IAsyncStreamReader<T>` in C# 8's new `IAsyncEnumerable<T>` type, as well as an `IObservable<T>` for Reactive programming.

Again, we're being careful to catch exceptions here because of the possibility of network failure (as well as the `OperationCanceledException` that will inevitably be thrown because we're using a `CancellationToken` to break the loop). The `RpcException` type has a lot of useful information about gRPC runtime errors, including the `StatusCode` (see [Chapter X section Y]()).

## Bi-directional Streaming

A WCF Full Duplex service allows for asynchronous, real-time messaging in both directions. In our server-streaming example, the client simply initiates a request, then receives a stream of updates. A better version of that service would allow the client to add and remove stocks from the list without needing to stop and create a new subscription. That functionality has been implemented in the [FullStockTickerServer](https://github.com/RendleLabs/grpc-for-wcf-developers/tree/master/FullStockTickerSample/wcf/FullStockTicker) sample.

The `IFullStockTickerService` interface provides three methods:

- `Subscribe` initiates the connection
- `AddSymbol` adds a stock symbol to watch
- `RemoveSymbol` removes a symbol

```csharp
[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IFullStockTickerCallback))]
public interface IFullStockTickerService
{
    [OperationContract(IsOneWay = true)]
    void Subscribe();

    [OperationContract(IsOneWay = true)]
    void AddSymbol(string symbol);

    [OperationContract(IsOneWay = true)]
    void RemoveSymbol(string symbol);
}
```

The callback interface remains the same.

Implementing this pattern in gRPC is less straightforward, because we are not working with a service in the same way. Instead, we have two streams of data with messages being passed. We can't use multiple methods to implement the Add and Remove operation, but we can pass more than one type of message on a single stream, using either the `Any` type or `oneof` keyword.

For a case where there is a very specific set of types that are acceptable, `oneof` is a better way to go. We'll create an `ActionMessage` that can hold either an `AddSymbolRequest` or a `RemoveSymbolRequest`.

```protobuf
message ActionMessage {
  oneof action {
    AddSymbolRequest add = 1;
    RemoveSymbolRequest remove = 2;
  }
}

message AddSymbolRequest {
  string symbol = 1;
}

message RemoveSymbolRequest {
  string symbol = 1;
}
```

And we'll declare a bi-directional streaming service that takes a stream of `ActionMessage` messages.

```protobuf
service FullStockTicker {
  rpc Subscribe (stream ActionMessage) returns (stream StockTickerUpdate);
}
```

Our implementation for this service is very similar to the previous sample, except the first parameter of the `Subscribe` method is now an `IAsyncStreamReader<ActionMessage>` which we need to process to handle the `Add` and `Remove` requests.

```csharp
public override async Task Subscribe(IAsyncStreamReader<ActionMessage> requestStream, IServerStreamWriter<StockTickerUpdate> responseStream, ServerCallContext context)
{
    using var subscriber = _subscriberFactory.GetSubscriber();

    subscriber.Update += async (sender, args) =>
        await WriteUpdateAsync(responseStream, args.Symbol, args.Price);

    var actionsTask = HandleActions(requestStream, subscriber, context.CancellationToken);
    
    _logger.LogInformation("Subscription started.");
    await AwaitCancellation(context.CancellationToken);

    try { await actionsTask; } catch { /* Ignored */ }

    _logger.LogInformation("Subscription finished.");
}
```

The `ActionMessage` class that gRPC has generated for us guarantees that only one of the `Add` and `Remove` properties can be set, and finding which one is not `null` is a valid way of finding which type of message is used, but there is a better way. The code generation also created an `enum ActionOneOfCase` in the `ActionMessage` class, which looks like this:

```csharp
public enum ActionOneofCase {
    None = 0,
    Add = 1,
    Remove = 2,
}
```

The property `ActionCase` on the `ActionMessage` object can be used with a `switch` statement to determine which field is set.

```csharp
private async Task HandleActions(IAsyncStreamReader<ActionMessage> requestStream, IFullStockPriceSubscriber subscriber, CancellationToken token)
{
    while (await requestStream.MoveNext(token))
    {
        var action = requestStream.Current;
        switch (action.ActionCase)
        {
            case ActionMessage.ActionOneofCase.None:
                _logger.LogWarning("No Action specified.");
                break;
            case ActionMessage.ActionOneofCase.Add:
                subscriber.Add(action.Add.Symbol);
                break;
            case ActionMessage.ActionOneofCase.Remove:
                subscriber.Remove(action.Remove.Symbol);
                break;
            default:
                _logger.LogWarning($"Unknown Action '{action.ActionCase}'.");
                break;
        }
    }
}
```

> [!TIP]
> The `switch` statement has a `default` case that logs a warning if an unknown `ActionOneOfCase` value is encountered. This could be useful in indicating that a client is using a later version of the `.proto` file which has added more actions. This is one reason why using a `switch` is better than testing for `null` on known fields.

### Using the FullStockTickerService from a client application

We have created a simple .NET Core 3.0 WPF application to demonstrate use of this more complex client. The full application can be found [on GitHub](https://github.com/RendleLabs/grpc-for-wcf-developers/tree/master/FullStockTickerSample/grpc/FullStockTicker).

The client is used in the `MainWindowViewModel` class, which gets an instance of the `FullStockTicker.FullStockTickerClient` type from dependency injection.

```csharp
public class MainWindowViewModel : IAsyncDisposable, INotifyPropertyChanged
{
    private readonly FullStockTicker.FullStockTickerClient _client;
    private readonly AsyncDuplexStreamingCall<ActionMessage, StockTickerUpdate> _duplexStream;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Task _responseTask;
    private string _addSymbol;

    public MainWindowViewModel(FullStockTicker.FullStockTickerClient client)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _client = client;
        _duplexStream = _client.Subscribe();
        _responseTask = HandleResponsesAsync(_cancellationTokenSource.Token);

        AddCommand = new AsyncCommand(Add, CanAdd);
    }
```

The object returned by the `client.Subscribe()` method is now an instance of the gRPC library type `AsyncDuplexStreamingCall<TRequest, TResponse>`, which provides a `RequestStream` for sending requests to the server, and a `ResponseStream` for handling responses.

We can use the request stream from some WCF `ICommand` methods to add and remove symbols. For each operation, we simply set the relevant field on an `ActionMessage` object.

```csharp
private async Task Add()
{
    if (CanAdd())
    {
        await _duplexStream.RequestStream.WriteAsync(new ActionMessage {Add = new AddSymbolRequest {Symbol = AddSymbol}});
    }
}

public async Task Remove(PriceViewModel priceViewModel)
{
    await _duplexStream.RequestStream.WriteAsync(new ActionMessage {Remove = new RemoveSymbolRequest {Symbol = priceViewModel.Symbol}});
    Prices.Remove(priceViewModel);
}
```

> [!IMPORTANT]
> Setting a `oneof` field's value on a message automatically clears any fields that have been previously set.

The stream of responses is handled in an `async` method, and the `Task` it returns is held to be disposed when the window is closed.

```csharp
private async Task HandleResponsesAsync(CancellationToken token)
{
    var stream = _duplexStream.ResponseStream;

    while (await stream.MoveNext(token))
    {
        var update = stream.Current;
        var price = Prices.FirstOrDefault(p => p.Symbol.Equals(update.Symbol));
        if (price == null)
        {
            price = new PriceViewModel(this) {Symbol = update.Symbol, Price = Convert.ToDecimal(update.Price)};
            Prices.Add(price);
        }
        else
        {
            price.Price = Convert.ToDecimal(update.Price);
        }
    }
}
```

>[!div class="step-by-step"]
<!-->[Next](streaming-vs-repeated.md)-->

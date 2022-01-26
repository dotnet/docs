---
title: Create gRPC client libraries - gRPC for WCF Developers
description: Discussion of shared client libraries/packages for gRPC services.
ms.date: 12/14/2021
---

# Create gRPC client libraries

It isn't necessary to distribute client libraries for a gRPC application. You can create a shared library of `.proto` files within your organization, and other teams can use those files to generate client code in their own projects. But if you have a private NuGet repository and many other teams are using .NET, you can create and publish client NuGet packages as part of your service project. This approach can be a good way of sharing and promoting your service.

One advantage of distributing a client library is that you can enhance the generated gRPC and Protobuf classes with helpful "convenience" methods and properties. In the client code, as in the server, all the classes are declared as `partial`, so you can extend them without editing the generated code. This behavior means it's easy to add constructors, methods, and calculated properties to the basic types.

> [!CAUTION]
> You shouldn't use custom code to provide essential functionality. You don't want to restrict that essential functionality to .NET teams that use the shared library, and not provide it to teams that use other languages or platforms, such as Python or Java.

Ensure that as many teams as possible can access your gRPC service. The best way to do this functionality is to share `.proto` files so developers can generate their own clients. This approach is particularly true in a multi-platform environment, where different teams frequently use different programming languages and frameworks, or where your API is externally accessible.

## Useful extensions

There are two commonly used interfaces in .NET for dealing with streams of objects: <xref:System.Collections.Generic.IEnumerable%601> and <xref:System.IObservable%601>. Starting with .NET Core 3.0 and C# 8.0, there's an <xref:System.Collections.Generic.IAsyncEnumerable%601> interface for processing streams asynchronously, and an `await foreach` syntax for using the interface. This section presents reusable code for applying these interfaces to gRPC streams.

With the .NET gRPC client libraries, there's a `ReadAllAsync` extension method for `IAsyncStreamReader<T>` that creates an `IAsyncEnumerable<T>` interface. For developers using reactive programming, an equivalent extension method to create an `IObservable<T>` interface might look like the example in the following section.

### IObservable

The `IObservable<T>` interface is the "reactive" inverse of `IEnumerable<T>`. Rather than pulling items from a stream, the reactive approach lets the stream push items to a subscriber. This behavior is very similar to gRPC streams, and it's easy to wrap an `IObservable<T>` interface around an `IAsyncStreamReader<T>` interface.

This code is longer than the `IAsyncEnumerable<T>` code, because C# doesn't have built-in support for working with observables. You have to create the implementation class manually. It's a generic class, though, so a single implementation works across all types.

```csharp
namespace Grpc.Core;

public class GrpcStreamObservable<T> : IObservable<T>
{
    private readonly IAsyncStreamReader<T> _reader;
    private readonly CancellationToken _token;
    private int _used;

    public GrpcStreamObservable(IAsyncStreamReader<T> reader, CancellationToken token = default)
    {
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        _token = token;
        _used = 0;
    }

    public IDisposable Subscribe(IObserver<T> observer) =>
        Interlocked.Exchange(ref _used, 1) == 0
            ? new GrpcStreamSubscription<T>(_reader, observer, _token)
            : throw new InvalidOperationException("Subscribe can only be called once.");

}
```

> [!IMPORTANT]
> This observable implementation allows the `Subscribe` method to be called only once, because having multiple subscribers trying to read from the stream would result in chaos. There are operators, such as `Replay` in the [System.Reactive.Linq](https://www.nuget.org/packages/System.Reactive.Linq), that enable buffering and repeatable sharing of observables, which can be used with this implementation.

The `GrpcStreamSubscription` class handles the enumeration of the `IAsyncStreamReader`:

```csharp
public class GrpcStreamSubscription<T> : IDisposable
{
    private readonly IAsyncStreamReader<T> _reader;
    private readonly IObserver<T> _observer;

    private readonly CancellationTokenSource _tokenSource;

    private readonly Task _task;

    private bool _completed;

    public GrpcStreamSubscription(IAsyncStreamReader<T> reader, IObserver<T> observer, CancellationToken token = default)
    {
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        _observer = observer ?? throw new ArgumentNullException(nameof(observer));

        _tokenSource = new CancellationTokenSource();
        token.Register(_tokenSource.Cancel);

        _task = Run(_tokenSource.Token);
    }

    private async Task Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                if (!await _reader.MoveNext(token)) break;
            }
            catch (RpcException e) when (e.StatusCode == Grpc.Core.StatusCode.NotFound)
            {
                break;
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception e)
            {
                _observer.OnError(e);
                _completed = true;
                return;
            }

            _observer.OnNext(_reader.Current);
        }

        _completed = true;
        _observer.OnCompleted();
    }

    public void Dispose()
    {
        if (!_completed && !_tokenSource.IsCancellationRequested)
        {
            _tokenSource.Cancel();
        }

        _tokenSource.Dispose();
        _task.Dispose();
    }

}
```

All that is required now is a simple extension method to create the observable from the stream reader.

```csharp
namespace Grpc.Core;
public static class AsyncStreamReaderObservableExtensions
{
    public static IObservable<T> AsObservable<T>(
        this IAsyncStreamReader<T> reader,
        CancellationToken cancellationToken = default) =>
        new GrpcStreamObservable<T>(reader, cancellationToken);
}
```

## Summary

The <xref:System.Collections.Generic.IAsyncEnumerable%601> and <xref:System.IObservable%601> models are both well-supported and well-documented ways of dealing with asynchronous streams of data in .NET. gRPC streams map well to both paradigms, offering close integration with .NET, and reactive and asynchronous programming styles.

>[!div class="step-by-step"]
>[Previous](streaming-versus-repeated.md)
>[Next](security.md)

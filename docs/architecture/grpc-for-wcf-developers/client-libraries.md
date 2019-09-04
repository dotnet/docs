---
title: Client Libraries
description: gRPC for WCF Developers | Client Libraries
author: markrendle
ms.date: 09/02/2019
---

# Client Libraries

It is not strictly necessary to distribute client libraries for a gPRC application. You can create a shared library of `.proto` files within your organization, and other teams can use those to generate client code in their own projects. But if you have a private NuGet repository, and many other teams are using .NET Core, creating and publishing client NuGet packages as part of your service project may be the best way of sharing and promoting your service.

One advantage of distributing a client library is that you can enhance the generated gRPC and Protobuf classes. In the client code, as in the server, all the classes are declared as `partial` so you can extend them without editing the generated code. This means it is easy to add constructors, methods, calculated properties and more to the basic types.

> [!CAUTION]
> You should **not** use custom code to provide essential functionality, as this would mean that functionality would be restricted to .NET teams using the shared library, and not to teams using other languages or platforms such as Python or Java.

> [!IMPORTANT]
> In a multi-platform environment where different teams frequently use different programming languages and frameworks, or where your API is externally accessible, simply sharing `.proto` files so developers can generate their own clients is the best way to ensure as many teams as possible can access your gRPC service.

## Useful extensions

There are two commonly-used interface in .NET for dealing with streams of objects: `IEnumerable<T>` and `IObservable<T>`. As of .NET Core 3.0 and C# 8.0, there is an `IAsyncEnumerable<T>` interface for processing streams asynchronously, and an `await foreach` syntax for using the interface. This section presents reusable code for applying these interfaces to gRPC streams.

With the .NET Core gRPC client libraries, there is a `ReadAllAsync` extension method for `IAsyncStreamReader<T>` that creates an `IAsyncEnumerable<T>`. For developers using reactive programming, an equivalent extension method to create an `IObservable<T>` might look like this.

### IObservable

The `IObservable<T>` interface is the "reactive" inverse of `IEnumerable<T>`. Rather than pulling items from a stream, the reactive approach lets the stream push items to a subscriber. This is very similar to gRPC streams, and it is easy to wrap an `IObservable<T>` around an `IAsyncStreamReader<T>`.

This code is longer than the `IAsyncEnumerable<T>` code because C# does not have built-in support for working with observables, so the implementation class has to be created manually. It is a generic class, though, so a single implementation will work across all types.

```csharp
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Grpc.Core
{
    public class GrpcStreamObservable<T> : IObservable<T>
    {
        private readonly IAsyncStreamReader<T> _reader;
        private readonly CancellationToken _token;
        private int _used;

        public Observable(IAsyncStreamReader<T> reader, CancellationToken token = default)
        {
            _reader = reader;
            _token = token;
            _used = 0;
        }

        public IDisposable Subscribe(IObserver<T> observer) =>
            Interlocked.Exchange(ref _used, 1) == 0
                ? new GrpcStreamSubscription(_reader, observer, _token)
                : throw new InvalidOperationException("Subscribe can only be called once.");

    }
}
```

> [!IMPORTANT]
> This observable implementation only allows the `Subscribe` method to be called once, as having multiple subscribers trying to read from the stream would result in chaos. There are operators such as `Replay` in the [System.Reactive.Linq](https://www.nuget.org/packages/System.Reactive.Linq) that enable buffering and repeatable sharing of observables, which can be used with this implementation.

The `GrpcStreamSubscription` class handles the enumeration of the `IAsyncStreamReader`.

```csharp
public class GrpcStreamSubscription : IDisposable
{
    private readonly Task _task;
    private readonly CancellationTokenSource _tokenSource;
    private bool _completed;

    public Subscription(IAsyncStreamReader<T> reader, IObserver<T> observer, CancellationToken token)
    {
        Debug.Assert(reader != null);
        Debug.Assert(observer != null);
        _tokenSource = new CancellationTokenSource();
        token.Register(_tokenSource.Cancel);
        _task = Run(reader, observer, _tokenSource.Token);
    }

    private async Task Run(IAsyncStreamReader<T> reader, IObserver<T> observer, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                if (!await reader.MoveNext(token)) break;
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception e)
            {
                observer.OnError(e);
                _completed = true;
                return;
            }

            observer.OnNext(reader.Current);
        }

        _completed = true;
        observer.OnCompleted();
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
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Grpc.Core
{
    public static class AsyncStreamReaderObservableExtensions
    {
        public static IObservable<T> AsObservable<T>(this IAsyncStreamReader<T> reader) =>
            new GrpcStreamObservable<T>(reader);
    }
}
```

>[!div class="step-by-step"]
<!-->[Next](authentication.md)-->

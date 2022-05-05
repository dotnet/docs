---
title: DiagnosticSource and DiagnosticListener
description: An overview of DiagnosticSource/DiagnosticListener including guidance on logging events, instrumenting code, and consuming data.
ms.date: 05/03/2022
---
# DiagnosticSource and DiagnosticListener

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

<xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> is a module that allows code to be instrumented for production-time
logging of rich data payloads for consumption within the process that was instrumented. At runtime, consumers can dynamically discover
data sources and subscribe to the ones of interest. <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> was designed to allow in-process
tools to access rich data. When using <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>, the consumer is assumed
to be within the same process and as a result, non-serializable types (e.g. `HttpResponseMessage` or `HttpContext`) can be passed,
giving customers plenty of data to work with.

> [!NOTE]
> Many technologies that integrate with DiagnosticSource use the terms 'Tracing' and 'Traces' instead of 'Logging' and 'Logs'.
> The meaning is the same here.

## Getting Started with DiagnosticSource


This walkthrough shows how to create a DiagnosticSource event and instrument code with <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>.
It then explains how <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> consumes the data by first
finding the specified DiagnosticListeners one is interested in, subscribing to them, and decoding payloads for more specific data.
It finishes by describing filtering, which controls which events pass through the system.

## Log an event

The `DiagnosticSource` type is an abstract base class that defines the methods needed to log events. The class that holds the implementation is `DiagnosticListener`.
The first step in instrumenting code with `DiagnosticSource` is to create a
`DiagnosticListener`. For example:

```C#
    private static DiagnosticSource httpLogger = new DiagnosticListener("System.Net.Http");
```

Notice that httpLogger is typed as a `DiagnosticSource`.
This is because this code
only cares about writing events and thus only cares about the  `DiagnosticSource` methods that
the `DiagnosticListener` implements. `DiagnosticListeners` are given names when they are created
and this name should be the name of logical grouping of related events (typically the component).
Later this name is used to find the Listener and subscribe to any of its events. `DiagnosticListeners` have a name, which is used to represent the component associated with the event.
Thus the event names only need to be unique within a component.

-------------------------------------------

## Instrumenting with DiagnosticSource/DiagnosticListener

We show how to instrument DiagnosticListener using the DiagnosticListener we made in the code above.

The `DiagnosticSource` logging
interface consists of two methods:

```C#
    bool IsEnabled(string name)
    void Write(string name, object value);
```

A typical call site will look like:

```C#
    if (httpLogger.IsEnabled("RequestStart"))
        httpLogger.Write("RequestStart", new { Url="http://clr", }); //any object can be the second argument
```

Architectural elements shown in the above code are as follows.
Every event has a `string` name (e.g. `RequestStart`), and exactly one `object` as a payload.
If you need to send more than one item, you can do so by creating an `object` with all information
in it as properties. C#'s [anonymous type](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/anonymous-types)
feature is typically used to create a type to pass 'on the fly', and makes this scheme very
convenient. At the instrumentation site, you must guard the call to `Write()` with an `IsEnabled()` check on
the same event name. Without this check, even when the instrumentation is inactive, the rules
of the C# language require all the work of creating the payload `object` and calling `Write()` to be
done, even though nothing is actually listening for the data. By guarding the `Write()` call, we
make it efficient when the source is not enabled.

Create a class to house the `DiagnosticListener and call site: 

```C#
    class MessageSender
    {
        private static DiagnosticSource httpLogger = new DiagnosticListener("System.Net.Http");

        public void SendMessage()
        {
            if (httpLogger.IsEnabled("RequestStart"))
            {
                httpLogger.Write("RequestStart", new
                {
                    Url = "http://clr",
                });
            }

        }
    }
```

-------------------------------------------

### Discovery of DiagnosticListeners

The first step in receiving events is to discover which `DiagnosticListeners` you are
interested in. `DiagnosticListener` supports a way of discovering `DiagnosticListeners` that are
active in the system at runtime. The API to accomplish this is the `AllListeners`
`IObservable<DiagnosticListener>`.

The `IObservable` interface is the 'callback' version of the `IEnumerable` interface. You can learn
more about it at the [Reactive Extensions](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/anonymous-types) site.
An `IObserver` has three callbacks, `OnNext`, `OnComplete`
and `OnError`, and an `IObservable` has single method called `Subscribe` which gets passed one of these
Observers. Once connected, the Observer gets callbacks (mostly `OnNext` callbacks) when things
happen. By including the `System.Reactive.Core` NuGet package, you can gain access to extensions that work well with `IObservable`.

A typical use of the `AllListeners` static property looks like this:

```C#
    class Observer<T> : IObserver<T>
    {
        public Observer(Action<T> onNext, Action onCompleted)
        {
            _onNext = onNext ?? new Action<T>(_ => { });
            _onCompleted = onCompleted ?? new Action(() => { });
        }

        public void OnCompleted() { _onCompleted(); }
        public void OnError(Exception error) { }
        public void OnNext(T value) { _onNext(value); }

        private Action<T> _onNext;
        private Action _onCompleted;
    }
    
    Action<DiagnosticListener> onNewListener = delegate (DiagnosticListener listener)
    {
        Console.WriteLine($"New Listener discovered: {listener.Name}");
        if (listener.Name == "System.Net.Http")
        {
            // Here is where we put code to subscribe to the Listener.
        }
    };
    IObserver<DiagnosticListener> TheIObserver = new Observer<DiagnosticListener>(onNewListener, null);
    //when a listener is created, invoke the Observer onNext function which calls the delegate
    listenerSubscription = DiagnosticListener.AllListeners.Subscribe(TheIObserver);

    // Typically you leave the listenerSubscription subscription active forever.
    // However when you no longer want your callback to be called, you can
    // call listenerSubscription.Dispose() to cancel your subscription to the IObservable.
```

This code creates a callback delegate and using the `AllListeners.Subscribe` method requests
that the delegate be called for every active `DiagnosticListener` in the system. The decision of whether or not to subscribe to the listener
is made by inspecting its name. The code above is looking for our 'System.Net.Http' listener that we created previously.

Like all calls to `Subscribe()`, this one returns an `IDisposable` that represents the subscription itself.
Callbacks will continue to happen as long as nothing calls `Dispose()` on this subscription object.
The above code never calls `Dispose()`, so it will receive callbacks forever.

When you subscribe to `AllListeners`, you get a callback for ALL ACTIVE `DiagnosticListeners`.
Thus, upon subscribing, you get a flurry of callbacks for all existing `DiagnosticListeners`, and as new ones
are created, you receive a callback for those as well. You receive a complete list of everything it is possible
to subscribe to.

#### Subscribing to DiagnosticListeners

A `DiagnosticListener` implements the `IObservable<KeyValuePair<string, object>>` interface, so you can
call `Subscribe()` on it as well. We show how to fill out the previous example:

```C#
    static IDisposable networkSubscription = null;
    static IDisposable listenerSubscription;
    Action<KeyValuePair<string, object>> onMessage = delegate (KeyValuePair<string, object> message)
    {
        Console.WriteLine($"Message received: {message.Key}: {message.Value}");
    };
    Action<DiagnosticListener> onNewListener = delegate (DiagnosticListener listener)
    {
        if (listener.Name == "System.Net.Http")
        {
          lock(allListeners)
          {
            if (networkSubscription != null)
            {
              networkSubscription.Dispose();
            }
            IObserver<KeyValuePair<string, object>> iobserver = new Observer<KeyValuePair<string, object>>(onMessage, null);
            networkSubscription = listener.Subscribe(iobserver);
          }
        }
   };

    // At some point you may wish to dispose the networkSubscription.
```

In the above example, after finding the 'System.Net.Http' `DiagnosticListener`, an action is created that
prints out the name of the listener, event, and `payload.ToString()`. Please note the following.

`DiagnosticListener` implements `IObservable<KeyValuePair<string, object>>`. This means
 on each callback we get a `KeyValuePair`. The key of this pair is the name of the event
 and the value is the payload `object`. In the code above we simply log this information
 to the console.

It is important to keep track of subscriptions to the `DiagnosticListener`. In the above code the
networkSubscription variable that remembers this. If another `creation` is formed, one must
unsubscribe the previous listener and subscribe to the new one.

The `DiagnosticSource`/`DiagnosticListener` code is thread safe, but the
callback code also needs to be thread safe. To ensure the callback code is thread safe, locks are used. It is possible to create two `DiagnosticListeners`
with the same name at the same time. To avoid races updates of shared variables are performed under the protection of a lock.

Once the above code is run, the next time a `Write()` is done on 'System.Net.Http' `DiagnosticListener`
the information will be logged to the console.

Subscriptions are independent of one another. As a result, other code
can do exactly the same thing as the code above, and generate two 'pipes' of the logging
information.

#### Decoding Payloads

The `KeyvaluePair` that is passed to the callback has the event name and payload, but the payload is typed simply as
an `object`. There are two ways of getting more specific data:

1. If the payload is a well known type (e.g. a `string`, or an `HttpMessageRequest`) then you can simply
   cast the `object` to the expected type (using the `as` operator so as not to cause an exception if
   you are wrong) and then access the fields. This is very efficient.

2. Use reflection API. For example, assume the method below is present.

```C#
    /// Define a shortcut method that fetches a field of a particular name.
    static class PropertyExtensions
    {
        static object GetProperty(this object _this, string propertyName)
        {
            return _this.GetType().GetTypeInfo().GetDeclaredProperty(propertyName)?.GetValue(_this);
        }
    }
```

The `listener.Subscribe()` call above could be replaced with the following code, to decode the payload more fully.

```C#
    networkSubscription = listener.Subscribe(delegate(KeyValuePair<string, object> evnt) {
        var eventName = evnt.Key;
        var payload = evnt.Value;
        if (eventName == "RequestStart")
        {
            var url = payload.GetProperty("Url") as string;
            var request = payload.GetProperty("Request");
            Console.WriteLine("Got RequestStart with URL {0} and Request {1}", url, request);
        }
    });
```

Note that using reflection is relatively expensive. However, using reflection is the only
option if the payloads were generated using anonymous types. This overhead can be reduced by
making fast, specialized property fetchers either using `PropertyInfo.CreateDelegate` or
`ReflectEmit`, but that is beyond the scope of this document.
(See the [PropertySpec](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Diagnostics.DiagnosticSource/src/System/Diagnostics/DiagnosticSourceEventSource.cs#L784)
class used in the `DiagnosticSourceEventSource` for an example of a fast, delegate-based property fetcher.)

#### Filtering

In the example above, the code uses the `IObservable.Subscribe()` method to hook up the callback. This
causes all events to be given to the callback. However `DiagnosticListener` has overloads of
`Subscribe()` that allow the controller to control which events are given.

The `listener.Subscribe()` call in the previous example can be replaced with the following code to demonstrate.

```C#
    // Create the callback delegate
    Action<KeyValuePair<string, object>> callback = (KeyValuePair<string, object> evnt) =>
        Console.WriteLine("From Listener {0} Received Event {1} with payload {2}", networkListener.Name, evnt.Key, evnt.Value.ToString());

    // Turn it into an observer (using System.Reactive.Core's AnonymousObserver)
    Observer<KeyValuePair<string, object>> observer = new AnonymousObserver<KeyValuePair<string, object>>(callback);

    // Create a predicate (asks only for one kind of event)
    Predicate<string> predicate = (string eventName) => eventName == "RequestStart";

    // Subscribe with a filter predicate
    IDisposable subscription = listener.Subscribe(observer, predicate);

    // subscription.Dispose() to stop the callbacks.
```

This very efficiently subscribes to only the 'RequestStart' events. All other events will cause the `DiagnosticSource.IsEnabled()`
method to return `false`, and thus be efficiently filtered out.

##### Context-based Filtering

Some scenarios require advanced filtering based on extended context.
Producers may call `DiagnosticSource.IsEnabled()` overloads and supply additional event properties as shown in the code below.

```C#
    if (httpLogger.IsEnabled("RequestStart", aRequest, anActivity))
        httpLogger.Write("RequestStart", new { Url="http://clr", Request=aRequest });
```

The next code demonstrates that consumers may use such properties to filter events more precisely:

```C#
    // Create a predicate (asks only for Requests for certains URIs)
    Func<string, object, object, bool> predicate = (string eventName, object context, object activity) =>
    {
        if (eventName == "RequestStart")
        {
            HttpRequestMessage request = context as HttpRequestMessage;
            if (request != null)
            {
                return IsUriEnabled(request.RequestUri);
            }
        }
        return false;
    }

    // Subscribe with a filter predicate
    IDisposable subscription = listener.Subscribe(observer, predicate);
```

Note that producers are not aware of the filter a consumer has provided. `DiagnosticListener`
will invoke the provided filter, omitting additional arguments if necessary, thus the filter
should expect to receive a `null` context.
Producers should enclose `IsEnabled()` calls with event name and context with pure `IsEnabled()`
calls for event name, so consumers must ensure that their filter allows events without context
to pass through.

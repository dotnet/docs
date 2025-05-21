---
title: DiagnosticSource and DiagnosticListener
description: An overview of DiagnosticSource/DiagnosticListener including guidance on logging events, instrumenting code, and consuming data.
ms.date: 05/12/2022
ms.topic: article
---
# DiagnosticSource and DiagnosticListener

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

<xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> is a module that allows code to be instrumented for production-time
logging of rich data payloads for consumption within the process that was instrumented. At run time, consumers can dynamically discover
data sources and subscribe to the ones of interest. <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> was designed to allow in-process
tools to access rich data. When using <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>, the consumer is assumed
to be within the same process and as a result, non-serializable types (for example, `HttpResponseMessage` or `HttpContext`) can be passed,
giving customers plenty of data to work with.

## Getting Started with DiagnosticSource

This walkthrough shows how to create a DiagnosticSource event and instrument code with <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>.
It then explains how to consume the event by finding interesting DiagnosticListeners, subscribing to their events, and decoding event data payloads.
It finishes by describing *filtering*, which allows only specific events to pass through the system.

## DiagnosticSource Implementation

You will work with the following code. This code is an *HttpClient* class with a `SendWebRequest` method that sends an HTTP request to the URL and receives a reply.

:::code language="csharp" source="snippets/diagnosticsource/csharp/Program.cs" id="WholeProgram":::

Running the provided implementation prints to the console.

```console
New Listener discovered: System.Net.Http
Data received: RequestStart: { Url = https://learn.microsoft.com/dotnet/core/diagnostics/ }
```

## Log an event

The `DiagnosticSource` type is an abstract base class that defines the methods needed to log events. The class that holds the implementation is `DiagnosticListener`.
The first step in instrumenting code with `DiagnosticSource` is to create a
`DiagnosticListener`. For example:

:::code language="csharp" source="snippets/diagnosticsource/csharp/Program.cs" id="Snippet1":::

Notice that `httpLogger` is typed as a `DiagnosticSource`.
That's because this code
only writes events and thus is only concerned with the `DiagnosticSource` methods that
the `DiagnosticListener` implements. `DiagnosticListeners` are given names when they are created,
and this name should be the name of a logical grouping of related events (typically the component).
Later, this name is used to find the Listener and subscribe to any of its events.
Thus the event names only need to be unique within a component.

-------------------------------------------

The `DiagnosticSource` logging
interface consists of two methods:

```csharp
    bool IsEnabled(string name)
    void Write(string name, object value);
```

This is instrument site specific. You need to check the instrumentation site to see what types are passed into `IsEnabled`. This provides you with the information to know what to cast the payload to.

A typical call site will look like:

:::code language="csharp" source="snippets/diagnosticsource/csharp/Program.cs" id="Snippet3":::

Every event has a `string` name (for example, `RequestStart`), and exactly one `object` as a payload.
If you need to send more than one item, you can do so by creating an `object` with properties to represent all its information. C#'s [anonymous type](../../csharp/fundamentals/types/anonymous-types.md)
feature is typically used to create a type to pass 'on the fly', and makes this scheme very
convenient. At the instrumentation site, you must guard the call to `Write()` with an `IsEnabled()` check on
the same event name. Without this check, even when the instrumentation is inactive, the rules
of the C# language require all the work of creating the payload `object` and calling `Write()` to be
done, even though nothing is actually listening for the data. By guarding the `Write()` call, you
make it efficient when the source is not enabled.

Combining everything you have:

:::code language="csharp" source="snippets/diagnosticsource/csharp/Program.cs" id="Snippet4":::

-------------------------------------------

### Discovery of DiagnosticListeners

The first step in receiving events is to discover which `DiagnosticListeners` you are
interested in. `DiagnosticListener` supports a way of discovering `DiagnosticListeners` that are
active in the system at run time. The API to accomplish this is the <xref:System.Diagnostics.DiagnosticListener.AllListeners> property.

Implement an `Observer<T>` class that inherits from the `IObservable` interface, which is the 'callback' version of the `IEnumerable` interface. You can learn more about it at the [Reactive Extensions](https://github.com/dotnet/reactive) site.
An `IObserver` has three callbacks, `OnNext`, `OnComplete`,
and `OnError`. An `IObservable` has a single method called `Subscribe` that gets passed one of these
Observers. Once connected, the Observer gets callbacks (mostly `OnNext` callbacks) when things
happen.

A typical use of the `AllListeners` static property looks like this:

:::code language="csharp" source="snippets/diagnosticsource/csharp/Program.cs" id="Snippet5":::

This code creates a callback delegate and, using the `AllListeners.Subscribe` method, requests
that the delegate be called for every active `DiagnosticListener` in the system. The decision of whether or not to subscribe to the listener
is made by inspecting its name. The code above is looking for the 'System.Net.Http' listener that you created previously.

Like all calls to `Subscribe()`, this one returns an `IDisposable` that represents the subscription itself.
Callbacks will continue to happen as long as nothing calls `Dispose()` on this subscription object.
The code example never calls `Dispose()`, so it will receive callbacks forever.

When you subscribe to `AllListeners`, you get a callback for ALL ACTIVE `DiagnosticListeners`.
Thus, upon subscribing, you get a flurry of callbacks for all existing `DiagnosticListeners`, and as new ones
are created, you receive a callback for those as well. You receive a complete list of everything it's possible
to subscribe to.

#### Subscribe to DiagnosticListeners

A `DiagnosticListener` implements the `IObservable<KeyValuePair<string, object>>` interface, so you can
call `Subscribe()` on it as well. The following code shows how to fill out the previous example:

:::code language="csharp" source="snippets/diagnosticsource/csharp/Program.cs" id="Snippet6":::

In this example, after finding the 'System.Net.Http' `DiagnosticListener`, an action is created that
prints out the name of the listener, event, and `payload.ToString()`.

> [!NOTE]
> `DiagnosticListener` implements `IObservable<KeyValuePair<string, object>>`. This means
 on each callback we get a `KeyValuePair`. The key of this pair is the name of the event
 and the value is the payload `object`. The example simply logs this information
 to the console.

It's important to keep track of subscriptions to the `DiagnosticListener`. In the previous code, the
`networkSubscription` variable remembers this. If you form another `creation`, you must
unsubscribe the previous listener and subscribe to the new one.

The `DiagnosticSource`/`DiagnosticListener` code is thread safe, but the
callback code also needs to be thread safe. To ensure the callback code is thread safe, locks are used. It is possible to create two `DiagnosticListeners`
with the same name at the same time. To avoid race conditions, updates of shared variables are performed under the protection of a lock.

Once the previous code is run, the next time a `Write()` is done on 'System.Net.Http' `DiagnosticListener`
the information will be logged to the console.

Subscriptions are independent of one another. As a result, other code
can do exactly the same thing as the code example and generate two 'pipes' of the logging
information.

#### Decode Payloads

The `KeyvaluePair` that is passed to the callback has the event name and payload, but the payload is typed simply as
an `object`. There are two ways of getting more specific data:

If the payload is a well known type (for example, a `string`, or an `HttpMessageRequest`), then you can simply
cast the `object` to the expected type (using the `as` operator so as not to cause an exception if
you are wrong) and then access the fields. This is very efficient.

Use reflection API. For example, assume the following method is present.

```csharp
    /// Define a shortcut method that fetches a field of a particular name.
    static class PropertyExtensions
    {
        static object GetProperty(this object _this, string propertyName)
        {
            return _this.GetType().GetTypeInfo().GetDeclaredProperty(propertyName)?.GetValue(_this);
        }
    }
```

To decode the payload more fully, you could replace the `listener.Subscribe()` call with the following code.

```csharp
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
making fast, specialized property fetchers using either [PropertyInfo.GetMethod.CreateDelegate()](xref:System.Reflection.MethodInfo.CreateDelegate%2A) or
<xref:System.Reflection.Emit> namespace, but that's beyond the scope of this article.
(For an example of a fast, delegate-based property fetcher, see the [PropertySpec](https://github.com/dotnet/runtime/blob/6de7147b9266d7730b0d73ba67632b0c198cb11e/src/libraries/System.Diagnostics.DiagnosticSource/src/System/Diagnostics/DiagnosticSourceEventSource.cs#L1235)
class used in the `DiagnosticSourceEventSource`.)

#### Filtering

In the previous example, the code uses the `IObservable.Subscribe()` method to hook up the callback. This
causes all events to be given to the callback. However, `DiagnosticListener` has overloads of
`Subscribe()` that allow the controller to control which events are given.

The `listener.Subscribe()` call in the previous example can be replaced with the following code to demonstrate.

```csharp
    // Create the callback delegate.
    Action<KeyValuePair<string, object>> callback = (KeyValuePair<string, object> evnt) =>
        Console.WriteLine("From Listener {0} Received Event {1} with payload {2}", networkListener.Name, evnt.Key, evnt.Value.ToString());

    // Turn it into an observer (using the Observer<T> Class above).
    Observer<KeyValuePair<string, object>> observer = new Observer<KeyValuePair<string, object>>(callback);

    // Create a predicate (asks only for one kind of event).
    Predicate<string> predicate = (string eventName) => eventName == "RequestStart";

    // Subscribe with a filter predicate.
    IDisposable subscription = listener.Subscribe(observer, predicate);

    // subscription.Dispose() to stop the callbacks.
```

This efficiently subscribes to only the 'RequestStart' events. All other events will cause the `DiagnosticSource.IsEnabled()`
method to return `false` and thus be efficiently filtered out.

> [!NOTE]
> Filtering is only designed as a performance optimization. It is possible for a listener to receive events even when they
> do not satisfy the filter. This could occur because some other listener has subscribed to the event or because the source
> of the event didn't check IsEnabled() prior to sending it. If you want to be certain that a given event satisfies the filter
> you will need to check it inside the callback. For example:

```C#
    Action<KeyValuePair<string, object>> callback = (KeyValuePair<string, object> evnt) =>
        {
            if(predicate(evnt.Key)) // only print out events that satisfy our filter
            {
                Console.WriteLine("From Listener {0} Received Event {1} with payload {2}", networkListener.Name, evnt.Key, evnt.Value.ToString());
            }
        };
```

##### Context-based filtering

Some scenarios require advanced filtering based on extended context.
Producers can call <xref:System.Diagnostics.DiagnosticSource.IsEnabled%2A?displayProperty=nameWithType> overloads and supply additional event properties as shown in the following code.

```csharp
//aRequest and anActivity are the current request and activity about to be logged.
if (httpLogger.IsEnabled("RequestStart", aRequest, anActivity))
    httpLogger.Write("RequestStart", new { Url="http://clr", Request=aRequest });
```

The next code example demonstrates that consumers can use such properties to filter events more precisely.

```csharp
    // Create a predicate (asks only for Requests for certain URIs)
    Func<string, object, object, bool> predicate = (string eventName, object context, object activity) =>
    {
        if (eventName == "RequestStart")
        {
            if (context is HttpRequestMessage request)
            {
                return IsUriEnabled(request.RequestUri);
            }
        }
        return false;
    }

    // Subscribe with a filter predicate
    IDisposable subscription = listener.Subscribe(observer, predicate);
```

Producers are not aware of the filter a consumer has provided. `DiagnosticListener`
will invoke the provided filter, omitting additional arguments if necessary, thus the filter
should expect to receive a `null` context.
If a producer calls `IsEnabled()` with event name and context, those calls are enclosed in an overload that takes
only the event name. Consumers must ensure that their filter allows events without context
to pass through.

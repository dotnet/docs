---
title: Request context
description: Learn about request context in .NET Orleans.
ms.date: 03/16/2022
---

# Request context

The <xref:Orleans.Runtime.RequestContext> is an Orleans feature that allows application metadata, such as a trace ID, to flow with requests. Application metadata may be added on the client; it will flow with Orleans requests to the receiving grain. The feature is implemented by a public static class, `RequestContext`, in the Orleans namespace. This class exposes two simple methods:

```csharp
void Set(string key, object value)
```

The preceding API is used to store a value in the request context. The value can be any serializable type.

```csharp
Object Get(string key)
```

The preceding API is used to retrieve a value from the current request context.

The backing storage for `RequestContext` is async-local. When a caller (whether client-side or within Orleans) sends a request, the contents of the caller's `RequestContext` are included with the Orleans message for the request; when the grain code receives the request, that metadata is accessible from the local `RequestContext`. If the grain code does not modify the `RequestContext`, then any grain it requests to will receive the same metadata, and so on.

Application metadata also is maintained when you schedule a future computation using <xref:System.Threading.Tasks.TaskFactory.StartNew%2A> or <xref:System.Threading.Tasks.Task.ContinueWith%2A>; in both cases, the continuation will execute with the same metadata as the scheduling code had at the moment the computation was scheduled (that is, the system makes a copy of the current metadata and passes it to the continuation, so changes after the call to `StartNew` or `ContinueWith` will not be seen by the continuation).

> [!IMPORTANT]
> The application metadata does not flow back with responses; that is, code that runs as a result of a response being received, either within a `ContinueWith` continuation or after a call to <xref:System.Threading.Tasks.Task.Wait?displayProperty=nameWithType> or `GetValue`, will still run within the current context that was set by the original request.

For example, to set a trace id in the client to a new `Guid`, one would simply call:

```csharp
RequestContext.Set("TraceId", Guid.NewGuid());
```

Within grain code (or other code that runs within Orleans on a scheduler thread), the trace id of the original client request could be used, for instance, when writing a log:

```csharp
Logger.Info("Currently processing external request {0}", RequestContext.Get("TraceId"));
```

While any serializable object may be sent as application metadata, it's worth mentioning that large or complex objects may add noticeable overhead to message serialization time. For this reason, the use of simple types (strings, GUIDs, or numeric types) is recommended.

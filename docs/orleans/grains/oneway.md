---
title: One-way requests
description: Learn about one-way requests in .NET Orleans.
ms.date: 06/26/2023
---

# One-way requests

Grains perform asynchronous request execution, requiring all grain interface methods to return an asynchronous type, like <xref:System.Threading.Tasks.Task>. Awaiting the completion of a task returned from a grain call notifies the caller that the request has finished, allowing them to handle any exceptions or receive return values. Orleans also supports *one-way requests*, enabling callers to notify a grain about an event without expecting exceptions or completion signals.

One-way requests return to the caller immediately and don't signal failure or completion. A one-way request doesn't even guarantee that the callee received the request. The primary benefit of a one-way request is that they save messaging costs associated with sending a response back to the caller and can therefore improve performance in some specialized cases. One-way requests are an advanced performance feature and should be used with care and only when a developer has determined that a one-way request is beneficial. It's recommended to prefer regular bi-directional requests, which signal completion and propagate errors back to callers.

A request can be made one way by marking the grain interface method with the <xref:Orleans.Concurrency.OneWayAttribute>, like so:

```csharp
public interface IOneWayGrain : IGrainWithGuidKey
{
    [OneWay]
    Task Notify(MyData data);
}
```

One-way requests must return either <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask> and must not return generic variants of those types (<xref:System.Threading.Tasks.Task%601> and <xref:System.Threading.Tasks.ValueTask%601>).

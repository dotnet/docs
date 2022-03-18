---
title: One-way requests
description: Learn about one-way requests in .NET Orleans.
ms.date: 03/16/2022
---

# One-way requests

Grains execute requests (method calls) asynchronously and so all grain interface methods must return an asynchronous type, such as <xref:System.Threading.Tasks.Task>. By awaiting the completion of a task returned from a grain call, the caller is notified that the request has been completed and any exceptions or return values can be propagated back to the caller so that they can be handled. There are cases where a caller merely wants to *notify* a grain that some event has happened and doesn't need to be informed of any exceptions or receive a completion signal. For these cases, Orleans supports *one-way requests*.

One-way requests return to the caller immediately and do not signal failure or completion. A one-way request does not even guarantee that the caller received the request. The primary benefit of a one-way request is that they save messaging costs associated with sending a response back to the caller and can therefore improve performance in some specialized cases. One-way requests are an advanced performance feature and should be used with care and only when a developer has determined that a one-way request is beneficial. It is recommended to prefer regular bi-directional requests, which signal completion and propagate errors back to callers.

A request can be made one way by marking the grain interface method with the <xref:Orleans.Concurrency.OneWayAttribute>, like so:

```csharp
public interface IOneWayGrain : IGrainWithGuidKey
{
    [OneWay]
    Task Notify(MyData data);
}
```

One-way requests must return either <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask> and must not return generic variants of those types (<xref:System.Threading.Tasks.Task%601> and <xref:System.Threading.Tasks.ValueTask%601>).

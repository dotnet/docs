---
title: Grain cancellation tokens
description: Learn how to use grain cancellation tokens in .NET Orleans.
ms.date: 03/31/2025
ms.topic: conceptual
---

# Grain cancellation tokens

The Orleans runtime provides a mechanism called a grain cancellation token, enabling cancellation of an executing grain operation.

## Description

<xref:Orleans.GrainCancellationToken> is a wrapper around the standard <xref:System.Threading.CancellationToken>. It enables cooperative cancellation between threads, thread pool work items, or `Task` objects, and can be passed as a grain method argument.

A <xref:Orleans.GrainCancellationTokenSource> provides a cancellation token through its `Token` property and sends a cancellation message when its <xref:Orleans.GrainCancellationTokenSource.Cancel%2A?displayProperty=nameWithType> method is called.

## Usage

- Instantiate a `CancellationTokenSource` object. This object manages and sends cancellation notifications to individual cancellation tokens.

```csharp
var tcs = new GrainCancellationTokenSource();
```

- Pass the token returned by the <xref:Orleans.GrainCancellationTokenSource.Token%2A?displayProperty=nameWithType> property to each grain method listening for cancellation.

```csharp
var waitTask = grain.LongIoWork(tcs.Token, TimeSpan.FromSeconds(10));
```

- A cancellable grain operation needs to handle the underlying `CancellationToken` property of `GrainCancellationToken` just like in any other .NET code.

```csharp
public async Task LongIoWork(GrainCancellationToken tc, TimeSpan delay)
{
    while (!tc.CancellationToken.IsCancellationRequested)
    {
        await IoOperation(tc.CancellationToken);
    }
}
```

- Call the `GrainCancellationTokenSource.Cancel` method to initiate cancellation.

```csharp
await tcs.Cancel();
```

- Call the `Dispose` method when finished with the `GrainCancellationTokenSource` object.

```csharp
tcs.Dispose();
```

#### Important considerations

- The `GrainCancellationTokenSource.Cancel` method returns a `Task`. To ensure cancellation, retry the cancel call in case of transient communication failure.
- Callbacks registered on the underlying `System.Threading.CancellationToken` are subject to single-threaded execution guarantees within the grain activation where they were registered.
- Each `GrainCancellationToken` can be passed through multiple method invocations.

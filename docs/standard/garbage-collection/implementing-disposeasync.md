---
title: "Implement a DisposeAsync method"
ms.date: 05/28/2020
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
helpviewer_keywords:
  - "DisposeAsync method"
  - "garbage collection, DisposeAsync method"
---

# Implement a DisposeAsync method

The <xref:System.IAsyncDisposable> interface was introduced as part of C# 8.0. You implement the <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType> method when you need to perform resource cleanup, just as you would when [implementing a Dispose method](implementing-dispose.md). One of the key differences however, is that this implementation allows for asynchronous cleanup operations. The <xref:System.IAsyncDisposable.DisposeAsync> returns a <xref:System.Threading.Tasks.ValueTask> that represents the asynchronous dispose operation. This article assumes that you're already familiar with how to [implement a Dispose method](implementing-dispose.md).

## DisposeAsync() and DisposeAsyncCore()

The <xref:System.IAsyncDisposable> interface requires the implementation of a single parameterless method, <xref:System.IAsyncDisposable.DisposeAsync>. Also, any non-sealed class should have an additional `DisposeAsyncCore()` method that also returns a <xref:System.Threading.Tasks.ValueTask>.

- A `public` <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType> implementation that has no parameters.
- A `protected virtual ValueTask DisposeAsyncCore` method whose signature is:

```csharp
protected virtual ValueTask DisposeAsyncCore()
{
}
```

### The DisposeAsync() method

Because the `public`, parameterless `DisposeAsync` method is called by a consumer of the type, its purpose is to free unmanaged resources, perform general cleanup, and to indicate that the finalizer, if one is present, doesn't have to run. Freeing the actual memory associated with a managed object is always the domain of the [garbage collector](index.md). Because of this, it has a standard implementation:

```csharp
public async ValueTask DisposeAsync()
{
    // Perform async cleanup.
    await DisposeAsyncCore();

    // Dispose of managed resources.
    Dispose(false);
    // Suppress finalization.
    GC.SuppressFinalize(this);
}
```

> [!NOTE]
> One primary difference in the asynchronous version of the dispose pattern, is that the call from `DisposeAsync` to the `Dispose(bool)` overload method is given `false` as an argument - whereas the call from <xref:System.IDisposable.Dispose?displayProperty=nameWithType> passes `true`. This is intended to help ensure functional equivalence with the synchronous dispose pattern, and ensures finalizer code paths still get invoked.

## Implement the async dispose pattern

## See also


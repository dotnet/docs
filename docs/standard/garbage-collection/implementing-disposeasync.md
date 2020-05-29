---
title: Implement a DisposeAsync method
description: 
ms.date: 05/29/2020
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
- A `protected virtual ValueTask DisposeAsyncCore()` method whose signature is:

```csharp
protected virtual ValueTask DisposeAsyncCore()
{
}
```

The `DisposeAsyncCore()` method is `virtual` so that derived classes can define additional cleanup in their overrides.

### The DisposeAsync() method

The `public`, parameterless `DisposeAsync()` method is called implicitly in an `await using` statement, and its purpose is to free unmanaged resources, perform general cleanup, and to indicate that the finalizer, if one is present, doesn't have to run. Freeing the actual memory associated with a managed object is always the domain of the [garbage collector](index.md). Because of this, it has a standard implementation:

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
> One primary difference in the asynchronous version of the dispose pattern, is that the call from `DisposeAsync()` to the `Dispose(bool)` overload method is given `false` as an argument - whereas the call from <xref:System.IDisposable.Dispose?displayProperty=nameWithType> passes `true`. This is intended to help ensure functional equivalence with the synchronous dispose pattern, and further ensures that finalizer code paths still get invoked.

## Implement the async dispose pattern

All non-sealed classes should be considered a potential base class, because they could be inherited. If you implement the async dispose pattern for any potential base class, you must provide the `protected virtual ValueTask DisposeAsyncCore()` method. Here is an example implementation of the async dispose pattern that uses a <xref:System.Text.Json.Utf8JsonWriter?displayProperty=nameWithType>.

```csharp
using System;
using System.Text.Json;
using System.Threading.Tasks;

public class ExampleAsyncDisposable : IAsyncDisposable, IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    // Created in .ctor, omitted for brevity.
    private Utf8JsonWriter _jsonWriter;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        // Cascade async dispose calls
        if (_jsonWriter != null)
        {
            await _jsonWriter.DisposeAsync();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }
}
```

The previous example used the <xref:System.Text.Json.Utf8JsonWriter>, for more information on `System.Text.Json` see, [migrate from Newtonsoft.Json to System.Text.Json](../serialization/system-text-json-migrate-from-newtonsoft-how-to.md).

## Using async disposable

To properly consume an object that implements the <xref:System.IAsyncDisposable> interface, you use the [await](../../csharp/language-reference/operators/await.md), and [using](../../csharp/language-reference/keywords/using.md) keywords together. Consider the following example, where the `ExampleAsyncDisposable` class is instantiated, then wrapped in an `await using` statement.

```csharp
class ExampleProgram
{
    static async Task Main()
    {
        var exampleAsyncDisposable = new ExampleAsyncDisposable();
        await using (exampleAsyncDisposable.ConfigureAwait(false))
        {
            // Interact with the exampleAsyncDisposable instance.
        }

        Console.ReadLine();
    }
}
```

> [!IMPORTANT]
> Use the <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait(System.IAsyncDisposable,System.Boolean)> extension method of the <xref:System.IAsyncDisposable> interface to configure how the continuation of the task is marshalled on its original context or scheduler. For more information on `ConfigureAwait`, see [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq/).

For situations where the usage of `ConfigureAwait` is not needed, the `await using` statement could be simplified as follows:

```csharp
class ExampleProgram
{
    static async Task Main()
    {
        await using (var exampleAsyncDisposable = new ExampleAsyncDisposable())
        {
            // Interact with the exampleAsyncDisposable instance.
        }

        Console.ReadLine();
    }
}
```

Furthermore, this could be written to use the implicit scoping of a [using declaration](../../csharp/whats-new/csharp-8.md#using-declarations).

```csharp
class ExampleProgram
{
    static async Task Main()
    {
        await using var exampleAsyncDisposable = new ExampleAsyncDisposable();

        // Interact with the exampleAsyncDisposable instance.

        Console.ReadLine();
    }
}
```

## Stacked usings

In situations where you may have multiple instances of <xref:System.IAsyncDisposable> implementations, it is possible that stacking `using` statements in errant conditions could prevent calls to <xref:System.IAsyncDisposable.DisposeAsync>. In order to alleviate that potential concern, you should avoid stacking and instead follow this example pattern:

```csharp
class ExampleProgram
{
    static async Task Main()
    {
        var exampleAsyncDisposableOne = new ExampleAsyncDisposable();
        await using exampleAsyncDisposableOne.ConfigureAwait(false);
        // Interact with the exampleAsyncDisposableOne instance.

        var exampleAsyncDisposableTwo = new ExampleAsyncDisposable();
        await using exampleAsyncDisposableTwo.ConfigureAwait(false);
        // Interact with the exampleAsyncDisposableTwo instance.

        Console.ReadLine();
    }
}
```

## See also

- <xref:System.IAsyncDisposable>
- <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType>
- <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait(System.IAsyncDisposable,System.Boolean)>

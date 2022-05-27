---
title: Implement a DisposeAsync method
description: Learn how to implement DisposeAsync and DisposeAsyncCore methods to perform asynchronous resource cleanup.
author: IEvangelist
ms.author: dapine
ms.date: 11/10/2021
dev_langs:
  - "csharp"
helpviewer_keywords:
  - "DisposeAsync method"
  - "garbage collection, DisposeAsync method"
ms.topic: how-to
---

# Implement a DisposeAsync method

The <xref:System.IAsyncDisposable?displayProperty=nameWithType> interface was introduced as part of C# 8.0. You implement the <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType> method when you need to perform resource cleanup, just as you would when [implementing a Dispose method](implementing-dispose.md). One of the key differences however, is that this implementation allows for asynchronous cleanup operations. The <xref:System.IAsyncDisposable.DisposeAsync> returns a <xref:System.Threading.Tasks.ValueTask> that represents the asynchronous dispose operation.

It is typical when implementing the <xref:System.IAsyncDisposable> interface that classes will also implement the <xref:System.IDisposable> interface. A good implementation pattern of the <xref:System.IAsyncDisposable> interface is to be prepared for either synchronous or asynchronous dispose. All of the guidance for implementing the dispose pattern also applies to the asynchronous implementation. This article assumes that you're already familiar with how to [implement a Dispose method](implementing-dispose.md).

[!INCLUDE [disposables-and-dependency-injection](includes/disposables-and-dependency-injection.md)]

## DisposeAsync() and DisposeAsyncCore()

The <xref:System.IAsyncDisposable> interface declares a single parameterless method, <xref:System.IAsyncDisposable.DisposeAsync>. Any non-sealed class should have an additional `DisposeAsyncCore()` method that also returns a <xref:System.Threading.Tasks.ValueTask>.

- A `public` <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType> implementation that has no parameters.
- A `protected virtual ValueTask DisposeAsyncCore()` method whose signature is:

  ```csharp
  protected virtual ValueTask DisposeAsyncCore()
  {
  }
  ```

### The DisposeAsync() method

The `public` parameterless `DisposeAsync()` method is called implicitly in an `await using` statement, and its purpose is to free unmanaged resources, perform general cleanup, and to indicate that the finalizer, if one is present, need not run. Freeing the memory associated with a managed object is always the domain of the [garbage collector](index.md). Because of this, it has a standard implementation:

```csharp
public async ValueTask DisposeAsync()
{
    // Perform async cleanup.
    await DisposeAsyncCore();

    // Dispose of unmanaged resources.
    Dispose(false);

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
    // Suppress finalization.
    GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
}
```

> [!NOTE]
> One primary difference in the async dispose pattern compared to the dispose pattern, is that the call from <xref:System.IAsyncDisposable.DisposeAsync> to the `Dispose(bool)` overload method is given `false` as an argument. When implementing the <xref:System.IDisposable.Dispose?displayProperty=nameWithType> method, however, `true` is passed instead. This helps ensure functional equivalence with the synchronous dispose pattern, and further ensures that finalizer code paths still get invoked. In other words, the `DisposeAsyncCore()` method will dispose of managed resources asynchronously, so you don't want to dispose of them synchronously as well. Therefore, call `Dispose(false)` instead of `Dispose(true)`.

### The DisposeAsyncCore() method

The `DisposeAsyncCore()` method is intended to perform the asynchronous cleanup of managed resources or for cascading calls to `DisposeAsync()`. It encapsulates the common asynchronous cleanup operations when a subclass inherits a base class that is an implementation of <xref:System.IAsyncDisposable>. The `DisposeAsyncCore()` method is `virtual` so that derived classes can define additional cleanup in their overrides.

> [!TIP]
> If an implementation of <xref:System.IAsyncDisposable> is `sealed`, the `DisposeAsyncCore()` method is not needed, and the asynchronous cleanup can be performed directly in the <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType> method.

## Implement the async dispose pattern

All non-sealed classes should be considered a potential base class, because they could be inherited. If you implement the async dispose pattern for any potential base class, you must provide the `protected virtual ValueTask DisposeAsyncCore()` method. Here is an example implementation of the async dispose pattern that uses a <xref:System.Text.Json.Utf8JsonWriter?displayProperty=nameWithType>.

:::code language="csharp" source="snippets/dispose-async/ExampleAsyncDisposable.cs":::

The preceding example uses the <xref:System.Text.Json.Utf8JsonWriter>. For more information about `System.Text.Json`, see [How to migrate from Newtonsoft.Json to System.Text.Json](../serialization/system-text-json-migrate-from-newtonsoft-how-to.md).

## Implement both dispose and async dispose patterns

You may need to implement both the <xref:System.IDisposable> and <xref:System.IAsyncDisposable> interfaces, especially when your class scope contains instances of these implementations. Doing so ensures that you can properly cascade clean up calls. Here is an example class that implements both interfaces and demonstrates the proper guidance for cleanup.

:::code language="csharp" source="snippets/dispose-async/ExampleConjunctiveDisposable.cs":::

The <xref:System.IDisposable.Dispose?displayProperty=nameWithType> and <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType> implementations are both simple boilerplate code.

In the `Dispose(bool)` overload method, the <xref:System.IDisposable> instance is conditionally disposed of if it is not `null`. The <xref:System.IAsyncDisposable> instance is cast as <xref:System.IDisposable>, and if it is also not `null`, it is disposed of as well. Both instances are then assigned to `null`.

With the `DisposeAsyncCore()` method, the same logical approach is followed. If the <xref:System.IAsyncDisposable> instance is not `null`, its call to `DisposeAsync().ConfigureAwait(false)` is awaited. If the <xref:System.IDisposable> instance is also an implementation of <xref:System.IAsyncDisposable>, it's also disposed of asynchronously. Both instances are then assigned to `null`.

## Using async disposable

To properly consume an object that implements the <xref:System.IAsyncDisposable> interface, you use the [await](../../csharp/language-reference/operators/await.md) and [using](../../csharp/language-reference/keywords/using-statement.md) keywords together. Consider the following example, where the `ExampleAsyncDisposable` class is instantiated and then wrapped in an `await using` statement.

:::code language="csharp" source="snippets/dispose-async/ExampleConfigureAwaitProgram.cs":::

> [!IMPORTANT]
> Use the <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait(System.IAsyncDisposable,System.Boolean)> extension method of the <xref:System.IAsyncDisposable> interface to configure how the continuation of the task is marshalled on its original context or scheduler. For more information on `ConfigureAwait`, see [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq/).

For situations where the usage of `ConfigureAwait` is not needed, the `await using` statement could be simplified as follows:

:::code language="csharp" source="snippets/dispose-async/ExampleUsingStatementProgram.cs":::

Furthermore, it could be written to use the implicit scoping of a [using declaration](../../csharp/whats-new/csharp-8.md#using-declarations).

:::code language="csharp" source="snippets/dispose-async/ExampleUsingDeclarationProgram.cs":::

## Multiple await keywords in a single line

Sometimes the `await` keyword may appear multiple times within a single line. For example, consider the following code:

```csharp
await using var transaction = await context.Database.BeginTransactionAsync(token);
```

In the preceding example:

- The <xref:System.Data.Common.DbConnection.BeginTransactionAsync%2A> method is awaited.
- The return type is <xref:System.Data.Common.DbTransaction>, which implements `IAsyncDisposable`.
- The `transaction` is used asynchronously, and also awaited.

## Stacked usings

In situations where you create and use multiple objects that implement <xref:System.IAsyncDisposable>, it's possible that stacking `await using` statements with <xref:System.Threading.Tasks.ValueTask.ConfigureAwait%2A> could prevent calls to <xref:System.IAsyncDisposable.DisposeAsync> in errant conditions. To ensure that <xref:System.IAsyncDisposable.DisposeAsync> is always called, you should avoid stacking. The following three code examples show acceptable patterns to use instead.

### Acceptable pattern one

:::code language="csharp" id="one" source="snippets/dispose-async/ExamplePatterns.cs":::

In the preceding example, each asynchronous clean up operation is explicitly scoped under the `await using` block. The outer scope is defined by how `objOne` sets its braces, enclosing `objTwo`, as such `objTwo` is disposed first, followed by `objOne`. Both `IAsyncDisposable` instances have their <xref:System.IAsyncDisposable.DisposeAsync> method awaited, so each instance performs its asynchronous clean up operation. The calls are nested, not stacked.

### Acceptable pattern two

:::code language="csharp" id="two" source="snippets/dispose-async/ExamplePatterns.cs":::

In the preceding example, each asynchronous clean up operation is explicitly scoped under the `await using` block. At the end of each block, the corresponding `IAsyncDisposable` instance has its <xref:System.IAsyncDisposable.DisposeAsync> method awaited, thus performing its asynchronous clean up operation. The calls are sequential, not stacked. In this scenario `objOne` is disposed first, then `objTwo` is disposed.

### Acceptable pattern three

:::code language="csharp" id="three" source="snippets/dispose-async/ExamplePatterns.cs":::

In the preceding example, each asynchronous clean up operation is implicitly scoped with the containing method body. At the end of the enclosing block, the `IAsyncDisposable` instances perform their asynchronous clean up operations. This runs in reverse order from which they were declared, meaning that `objTwo` is disposed before `objOne`.

### Unacceptable pattern

The highlighted lines in the following code show what it means to have "stacked usings". If an exception is thrown from the `AnotherAsyncDisposable` constructor, neither object is properly disposed of. The variable `objTwo` is never assigned because the constructor did not complete successfully. As a result, the constructor for `AnotherAsyncDisposable` is responsible for disposing any resources allocated before it throws an exception.

:::code language="csharp" id="dontdothis" source="snippets/dispose-async/ExamplePatterns.cs" highlight="9-10":::

> [!TIP]
> Avoid this pattern as it could lead to unexpected behavior.

## See also

For a dual implementation example of `IDisposable` and `IAsyncDisposable`, see the <xref:System.Text.Json.Utf8JsonWriter> source code [on GitHub](https://github.com/dotnet/runtime/blob/035b729d829368c2790d825bd02db14f0c0fd2ea/src/libraries/System.Text.Json/src/System/Text/Json/Writer/Utf8JsonWriter.cs#L297-L345).

- [Disposal of services](../../core/extensions/dependency-injection-guidelines.md#disposal-of-services)
- <xref:System.IAsyncDisposable>
- <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType>
- <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait(System.IAsyncDisposable,System.Boolean)>

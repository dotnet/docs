---
title: "Breaking change: Task.FromResult may return singleton"
description: Learn about the .NET 6 breaking change where Task.FromResult may return a singleton.
ms.date: 10/01/2021
---
# Task.FromResult may return singleton

<xref:System.Threading.Tasks.Task.FromResult%60%601(%60%600)?displayProperty=nameWithType> may now return a cached <xref:System.Threading.Tasks.Task%601> instance rather than always creating a new instance.

## Old behavior

In previous versions, <xref:System.Threading.Tasks.Task.FromResult%60%601(%60%600)?displayProperty=nameWithType> would always allocate a new <xref:System.Threading.Tasks.Task%601>, regardless of the type of `T` or the result value.

## New behavior

For some `T` types and some result values, <xref:System.Threading.Tasks.Task.FromResult%60%601(%60%600)?displayProperty=nameWithType> may return a cached singleton object rather than allocating a new object. For example, it is likely that every call to `Task.FromResult(true)` will return the same already-completed `Task<bool>` object.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Many developers expected <xref:System.Threading.Tasks.Task.FromResult%60%601(%60%600)?displayProperty=nameWithType> to behave similarly to asynchronous methods, which already performed such caching. Developers that knew about the allocation behavior often maintained their own cache to avoid the performance cost of always allocating for these commonly used values. For example:

```csharp
private static readonly Task<bool> s_trueTask = Task.FromResult(true);
```

Now, such custom caches are no longer required for values such as <xref:System.Boolean> and small <xref:System.Int32> values.

## Recommended action

Unless you're using reference equality to check whether one `Task` instance is the same as another `Task` instance, you should not be impacted by this change. If you are using such reference equality and need to continue this checking, use the following code to be guaranteed to always get back a unique <xref:System.Threading.Tasks.Task%601> instance:

```csharp
private static Task<T> NewInstanceFromResult<T>(T result)
{
    var tcs = new TaskCompletionSource<T>();
    tcs.TrySetResult(result);
    return tcs.Task;
}
```

> [!NOTE]
> This pattern is much less efficient than just using `Task.FromResult(result)`, and should be avoided unless you really need it.

## Affected APIs

- <xref:System.Threading.Tasks.Task.FromResult%60%601(%60%600)?displayProperty=fullName>

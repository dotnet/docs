---
title: "lock statement - synchronize thread access to a shared resource"
description: "Use the C# lock statement to ensure that only a single thread exclusively reads or writes a shared resource, blocking all other threads until it completes."
ms.date: 11/22/2022
f1_keywords: 
  - "lock_CSharpKeyword"
  - "lock"
helpviewer_keywords: 
  - "lock keyword [C#]"
---
# lock statement - ensure exclusive access to a shared resource

The `lock` statement acquires the mutual-exclusion lock for a given object, executes a statement block, and then releases the lock. While a lock is held, the thread that holds the lock can again acquire and release the lock. Any other thread is blocked from acquiring the lock and waits until the lock is released. The `lock` statement ensures that a single thread has exclusive access to that object.

The `lock` statement is of the form

```csharp
lock (x)
{
    // Your code...
}
```

where `x` is an expression of a [reference type](../keywords/reference-types.md). It's precisely equivalent to

```csharp
object __lockObj = x;
bool __lockWasTaken = false;
try
{
    System.Threading.Monitor.Enter(__lockObj, ref __lockWasTaken);
    // Your code...
}
finally
{
    if (__lockWasTaken) System.Threading.Monitor.Exit(__lockObj);
}
```

Since the code uses a [try-finally](exception-handling-statements.md#the-try-finally-statement) statement, the lock is released even if an exception is thrown within the body of a `lock` statement.

You can't use the [await operator](../operators/await.md) in the body of a `lock` statement.

## Guidelines

When you synchronize thread access to a shared resource, lock on a dedicated object instance (for example, `private readonly object balanceLock = new object();`) or another instance that is unlikely to be used as a lock object by unrelated parts of the code. Avoid using the same lock object instance for different shared resources, as it might result in deadlock or lock contention. In particular, avoid using the following types as lock objects:

- `this`, as it might be used by the callers as a lock.
- <xref:System.Type> instances, as those objects might be obtained by the [typeof](../operators/type-testing-and-cast.md#typeof-operator) operator or reflection.
- string instances, including string literals, as string literals might be [interned](/dotnet/api/system.string.intern#remarks).

Hold a lock for as short time as possible to reduce lock contention.

## Example

The following example defines an `Account` class that synchronizes access to its private `balance` field by locking on a dedicated `balanceLock` instance. Using the same instance for locking ensures that the `balance` field can't be updated simultaneously by two threads attempting to call the `Debit` or `Credit` methods simultaneously.

:::code language="csharp" source="snippets/lock/Program.cs":::

## C# language specification

For more information, see [The lock statement](~/_csharpstandard/standard/statements.md#1313-the-lock-statement) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# reference](../index.md)
- <xref:System.Threading.Monitor?displayProperty=nameWithType>
- <xref:System.Threading.SpinLock?displayProperty=nameWithType>
- <xref:System.Threading.Interlocked?displayProperty=nameWithType>
- [Overview of synchronization primitives](../../../standard/threading/overview-of-synchronization-primitives.md)
- [Introduction to System.Threading.Channels](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels)

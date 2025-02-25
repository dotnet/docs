---
title: "The lock statement - synchronize access to shared resources"
description: "Use the C# lock statement to ensure that only a single thread exclusively reads or writes a shared resource, blocking all other threads until it completes."
ms.date: 05/02/2024
f1_keywords: 
  - "lock_CSharpKeyword"
  - "lock"
helpviewer_keywords: 
  - "lock keyword [C#]"
---
# The lock statement - ensure exclusive access to a shared resource

The `lock` statement acquires the mutual-exclusion lock for a given object, executes a statement block, and then releases the lock. While a lock is held, the thread that holds the lock can again acquire and release the lock. Any other thread is blocked from acquiring the lock and waits until the lock is released. The `lock` statement ensures that at maximum only one thread executes its body at any moment in time.

The `lock` statement takes the following form:

```csharp
lock (x)
{
    // Your code...
}
```

The variable `x` is an expression of <xref:System.Threading.Lock?displayProperty=fullName> type, or a [reference type](../keywords/reference-types.md). When `x` is known at compile-time to be of the type <xref:System.Threading.Lock?displayProperty=fullName>, it's precisely equivalent to:

```csharp
using (x.EnterScope())
{
    // Your code...
}
```

The object returned by <xref:System.Threading.Lock.EnterScope?displayProperty=nameWithType> is a [`ref struct`](../builtin-types/ref-struct.md) that includes a `Dispose()` method. The generated [`using`](using.md) statement ensures the scope is released even if an exception is thrown with the body of the `lock` statement.

Otherwise, the `lock` statement is precisely equivalent to:

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

Since the code uses a [`try-finally` statement](exception-handling-statements.md#the-try-finally-statement), the lock is released even if an exception is thrown within the body of a `lock` statement.

You can't use the [`await` expression](../operators/await.md) in the body of a `lock` statement.

## Guidelines

Beginning with .NET 9 and C# 13, lock a dedicated object instance of the <xref:System.Threading.Lock?displayProperty=nameWithType> type for best performance. In addition, the compiler issues a warning if a known `Lock` object is cast to another type and locked. If using an older version of .NET and C#, lock on a dedicated object instance that isn't used for another purpose. Avoid using the same lock object instance for different shared resources, as it might result in deadlock or lock contention. In particular, avoid using the following instances as lock objects:

- `this`, as callers might also lock `this`.
- <xref:System.Type> instances, as they might be obtained by the [typeof](../operators/type-testing-and-cast.md#the-typeof-operator) operator or reflection.
- string instances, including string literals, as they might be [interned](/dotnet/api/system.string.intern#remarks).

Hold a lock for as short time as possible to reduce lock contention.

## Example

The following example defines an `Account` class that synchronizes access to its private `balance` field by locking on a dedicated `balanceLock` instance. Using the same instance for locking ensures that two different threads can't update the `balance` field by calling the `Debit` or `Credit` methods simultaneously. The sample uses C# 13 and the new `Lock` object. If you're using an older version of C# or an older .NET library, lock an instance of `object`.

:::code language="csharp" source="snippets/lock/Program.cs":::

## C# language specification

For more information, see [The lock statement](~/_csharpstandard/standard/statements.md#1313-the-lock-statement) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- <xref:System.Threading.Monitor?displayProperty=nameWithType>
- <xref:System.Threading.SpinLock?displayProperty=nameWithType>
- <xref:System.Threading.Interlocked?displayProperty=nameWithType>
- [Overview of synchronization primitives](../../../standard/threading/overview-of-synchronization-primitives.md)
- [Introduction to System.Threading.Channels](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels)

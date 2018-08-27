---
title: "lock statement (C# Reference)"
description: "Use the C# lock statement to synchronize thread access to shared resource"
ms.date: 08/28/2018
f1_keywords: 
  - "lock_CSharpKeyword"
  - "lock"
helpviewer_keywords: 
  - "lock keyword [C#]"
ms.assetid: 656da1a4-707e-4ef6-9c6e-6d13b646af42
---
# lock statement (C# Reference)

The `lock` statement obtains the mutual-exclusion lock for a given object, executes a statement block, and then releases the lock.

The `lock` statement of the form

```csharp
lock (x)
{
    // Your code...
}
```

where `x` is an expression of a [reference type](reference-types.md) is precisely equivalent to

```csharp
bool __lockWasTaken = false;
try
{
    System.Threading.Monitor.Enter(x, ref __lockWasTaken);
    // Your code...
}
finally
{
    if (__lockWasTaken) System.Threading.Monitor.Exit(x);
}
```

except that `x` is only evaluated once.

Since the code uses a [try...finally](try-finally.md) block, the lock is released even if an exception is thrown within the body of a `lock` statement.

While a lock is held, the same thread can again obtain and release the lock. However, any other thread is blocked from obtaining the lock and waits until the lock is released.

You can't use the [await](await.md) keyword in the body of a `lock` statement.

## Remarks

Avoid locking on publicly accessible instances, as it might result in lock contention or deadlock. Consider the following constructs:

- `lock(this)` is a problem if the instance referenced by `this` can be accessed publicly.

- `lock(typeof(MyType))` is a problem if `MyType` is publicly accessible.

- `lock("myLock")` is a problem because any other code in the process using the same string, would share the same lock.

Instead, lock on a privately accessible object that uniquely identifies the shared resource, when you synchronize thread access to that resource.

## Example

The following example defines an `Account` class that synchronizes access to its private `balance` field by locking on a dedicated `balanceLock` instance. Using the same instance for locking ensures that the `balance` field cannot be updated simultaneously by both the `Debit` and `Credit` methods.

[!code-csharp[lock-statement-example](~/samples/snippets/csharp/keywords/LockStatementExample.cs)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Threading.Monitor?displayProperty=nameWithType>
- <xref:System.Threading.SpinLock?displayProperty=nameWithType>
- <xref:System.Threading.Interlocked?displayProperty=nameWithType>
- [C# Reference](../index.md)
- [C# Keywords](index.md)
- [Statement Keywords](statement-keywords.md)
- [Interlocked operations](../../../standard/threading/interlocked-operations.md)
- [Overview of synchronization primitives](../../../standard/threading/overview-of-synchronization-primitives.md)
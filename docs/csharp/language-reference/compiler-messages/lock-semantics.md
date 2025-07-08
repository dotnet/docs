---
title: Lock statement errors and warnings
description: This article helps you diagnose and correct compiler errors and warnings when you use the `lock` statement.
f1_keywords:
  - "CS0185"
  - "CS1996"
  - "CS9216"
  - "CS9217"
helpviewer_keywords:
  - "CS0185"
  - "CS1996"
  - "CS9216"
  - "CS9217"
ms.date: 05/02/2024
---
# Errors and warnings related to the `lock` statement and thread synchronization

There are a few *errors* related to the `lock` statement and thread synchronization:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0185**](#lock-statement-errors): *'type' is not a reference type as required by the lock statement.*
- [**CS1996**](#lock-statement-errors): *Cannot await in the body of a lock statement*
- [**CS9217**](#lock-statement-errors): *A lock statement on a value of type 'System.Threading.Lock' cannot be used in async methods or async lambda expressions.*

In addition, the compiler might produce the following *warning* related to `lock` statements and thread synchronization:

- [**CS9216**](#lock-warning): *A value of type `System.Threading.Lock` converted to a different type will use likely unintended monitor-based locking in `lock` statement.*

## lock statement errors

- **CS0185**: *'type' is not a reference type as required by the lock statement.*
- **CS1996**: *Cannot await in the body of a lock statement*
- **CS9217**: *A lock statement on a value of type 'System.Threading.Lock' cannot be used in async methods or async lambda expressions.*

These errors indicate that your code violates rules regarding the `lock` the statement:

- The object being `lock`ed must be a reference types. Value types aren't allowed.
- An `await` expression can't be used in the scope of a `lock` statement.
- The `lock` statement can't be used with `async` methods or lambda expressions. For this error, you can replace the type of object locked with a different type. The `lock` statement uses the <xref:System.Threading.Monitor> API.

You must update your code to follow the rules of the `lock` statement.

## lock warning

- **CS9216**: *A value of type `System.Threading.Lock` converted to a different type will use likely unintended monitor-based locking in `lock` statement.*

Beginning with C# 13, the [`lock`](../statements/lock.md) generates specialized code when the target object is a `System.Threading.Lock` object. The compiler generates this warning when you're using a `Lock` object, but your code converts its type to something else. Therefore, the compiler generates the general locking code, not the locking code specific to the `Lock` type. For example:

```csharp
object lockObject = new System.Threading.Lock();

lock (lockObject) // CS9216
{
    // .. Your code
}
```

You should ensure the variable or expression represents the type of the `Lock` object.

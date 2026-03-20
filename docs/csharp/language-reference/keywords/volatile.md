---
description: "volatile - C# Reference"
title: "volatile keyword"
ms.date: 01/22/2026
f1_keywords: 
  - "volatile_CSharpKeyword"
  - "volatile"
helpviewer_keywords: 
  - "volatile keyword [C#]"
---
# volatile (C# Reference)

Use the `volatile` keyword to indicate that a field might be modified by multiple threads that are executing at the same time. For performance reasons, the compiler, the runtime system, and even hardware might rearrange reads and writes to memory locations. Declaring a field as `volatile` excludes it from certain kinds of optimizations. There's no guarantee of a single total ordering of volatile writes as seen from all threads of execution. For more information, see the <xref:System.Threading.Volatile> class.

> [!CAUTION]
> The `volatile` keyword is often misunderstood and misused in multithreaded programming. In most scenarios, use safer and more reliable alternatives instead of `volatile`. Modern .NET provides better concurrency tools like the <xref:System.Threading.Interlocked> class, the [`lock`](../statements/lock.md) statement, or higher-level synchronization primitives. These alternatives provide clearer semantics and stronger guarantees than `volatile`. Consider using `volatile` only in rare, advanced scenarios where you fully understand its limitations and have verified it's the appropriate solution.

> [!NOTE]
> On a multiprocessor system, a volatile read operation doesn't guarantee to obtain the latest value written to that memory location by any processor. Similarly, a volatile write operation doesn't guarantee that the value written is immediately visible to other processors.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Apply the `volatile` keyword to fields of these types:

- Reference types.
- Pointer types (in an unsafe context). Although the pointer itself can be volatile, the object that it points to can't be. In other words, you can't declare a "pointer to volatile."
- Simple types such as `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `char`, `float`, and `bool`.
- An `enum` type with one of the following base types: `byte`, `sbyte`, `short`, `ushort`, `int`, or `uint`.
- Generic type parameters known to be reference types.
- <xref:System.IntPtr> and <xref:System.UIntPtr>.

You can't mark other types, including `double` and `long`, as `volatile` because reads and writes to fields of those types can't be guaranteed to be atomic. To protect multithreaded access to those types of fields, use the <xref:System.Threading.Interlocked> class members or protect access by using the [`lock`](../statements/lock.md) statement.

For most multithreaded scenarios, even with supported types, prefer using <xref:System.Threading.Interlocked> operations, [`lock`](../statements/lock.md) statements, or other synchronization primitives instead of `volatile`. These alternatives are less prone to subtle concurrency bugs.

You can only apply the `volatile` keyword to fields of a `class` or `struct`. You can't declare local variables as `volatile`.

## Alternatives to volatile

In most cases, use one of these safer alternatives instead of `volatile`:

- **<xref:System.Threading.Interlocked> operations**: Provide atomic operations for numeric types and reference assignments. These operations are generally faster and provide stronger guarantees than `volatile`.
- **[`lock` statement](../statements/lock.md)**: Provides mutual exclusion and memory barriers. Use it for protecting larger critical sections.
- **<xref:System.Threading.Volatile> class**: Provides explicit volatile read and write operations with clearer semantics than the `volatile` keyword.
- **Higher-level synchronization primitives**: Such as <xref:System.Threading.ReaderWriterLockSlim>, <xref:System.Threading.Semaphore>, or concurrent collections from <xref:System.Collections.Concurrent>.

The `volatile` keyword doesn't provide atomicity for operations other than assignment. It doesn't prevent race conditions, and it doesn't provide ordering guarantees for other memory operations. These limitations make it unsuitable for most concurrency scenarios.

The following example shows how to declare a public field variable as `volatile`.

:::code language="csharp" source="./snippets/volatile.cs" id="Declaration":::

The following example demonstrates how an auxiliary or worker thread can be created and used to perform processing in parallel with that of the primary thread. For more information about multithreading, see [Managed Threading](../../../standard/threading/managed-threading-basics.md).

:::code language="csharp" source="./snippets/volatile.cs" id="Volatile":::

When you add the `volatile` modifier to the declaration of `_shouldStop`, you always get the same results (similar to the excerpt shown in the preceding code). However, without that modifier on the `_shouldStop` member, the behavior is unpredictable. The `DoWork` method might optimize the member access, resulting in reading stale data. Because of the nature of multithreaded programming, the number of stale reads is unpredictable. Different runs of the program produce somewhat different results.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# language specification: volatile keyword](~/_csharpstandard/standard/classes.md#1554-volatile-fields)
- [C# Keywords](index.md)
- [Modifiers](index.md)
- [lock statement](../statements/lock.md)
- <xref:System.Threading.Interlocked>
- <xref:System.Threading.Volatile>
- <xref:System.Collections.Concurrent>
- [Managed Threading](../../../standard/threading/managed-threading-basics.md)

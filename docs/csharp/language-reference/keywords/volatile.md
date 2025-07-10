---
description: "volatile - C# Reference"
title: "volatile keyword"
ms.date: 10/24/2018
f1_keywords: 
  - "volatile_CSharpKeyword"
  - "volatile"
helpviewer_keywords: 
  - "volatile keyword [C#]"
ms.assetid: 78089bc7-7b38-4cfd-9e49-87ac036af009
---
# volatile (C# Reference)

The `volatile` keyword indicates that a field might be modified by multiple threads that are executing at the same time. The compiler, the runtime system, and even hardware may rearrange reads and writes to memory locations for performance reasons. Fields that are declared `volatile` are excluded from certain kinds of optimizations. There is no guarantee of a single total ordering of volatile writes as seen from all threads of execution. For more information, see the <xref:System.Threading.Volatile> class.

> [!CAUTION]
> The `volatile` keyword is often misunderstood and misused in multithreaded programming. In most scenarios, you should use safer and more reliable alternatives instead of `volatile`. Modern .NET provides better concurrency tools like the <xref:System.Threading.Interlocked> class, the [`lock`](../statements/lock.md) statement, or higher-level synchronization primitives. These alternatives provide clearer semantics and stronger guarantees than `volatile`. Consider using `volatile` only in rare, advanced scenarios where you fully understand its limitations and have verified it's the appropriate solution.

> [!NOTE]
> On a multiprocessor system, a volatile read operation does not guarantee to obtain the latest value written to that memory location by any processor. Similarly, a volatile write operation does not guarantee that the value written would be immediately visible to other processors.  

The `volatile` keyword can be applied to fields of these types:

- Reference types.
- Pointer types (in an unsafe context). Note that although the pointer itself can be volatile, the object that it points to cannot. In other words, you cannot declare a "pointer to volatile."
- Simple types such as `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `char`, `float`, and `bool`.
- An `enum` type with one of the following base types: `byte`, `sbyte`, `short`, `ushort`, `int`, or `uint`.
- Generic type parameters known to be reference types.
- <xref:System.IntPtr> and <xref:System.UIntPtr>.

Other types, including `double` and `long`, cannot be marked `volatile` because reads and writes to fields of those types cannot be guaranteed to be atomic. To protect multi-threaded access to those types of fields, use the <xref:System.Threading.Interlocked> class members or protect access using the [`lock`](../statements/lock.md) statement.

For most multithreaded scenarios, even with supported types, prefer using <xref:System.Threading.Interlocked> operations, [`lock`](../statements/lock.md) statements, or other synchronization primitives instead of `volatile`. These alternatives provide stronger guarantees and are less prone to subtle concurrency bugs.

The `volatile` keyword can only be applied to fields of a `class` or `struct`. Local variables cannot be declared `volatile`.

## Alternatives to volatile

In most cases, you should use one of these safer alternatives instead of `volatile`:

- **<xref:System.Threading.Interlocked> operations**: Provide atomic operations for numeric types and reference assignments. These are generally faster and provide stronger guarantees than `volatile`.
- **[`lock` statement](../statements/lock.md)**: Provides mutual exclusion and memory barriers. Use for protecting larger critical sections.
- **<xref:System.Threading.Volatile> class**: Provides explicit volatile read and write operations with clearer semantics than the `volatile` keyword.
- **Higher-level synchronization primitives**: Such as <xref:System.Threading.ReaderWriterLockSlim>, <xref:System.Threading.Semaphore>, or concurrent collections from <xref:System.Collections.Concurrent>.

The `volatile` keyword doesn't provide atomicity for operations other than assignment, doesn't prevent race conditions, and doesn't provide ordering guarantees for other memory operations. These limitations make it unsuitable for most concurrency scenarios.

## Example

The following example shows how to declare a public field variable as `volatile`.

[!code-csharp[declareVolatile](~/samples/snippets/csharp/language-reference/keywords/volatile/Program.cs#Declaration)]

The following example demonstrates how an auxiliary or worker thread can be created and used to perform processing in parallel with that of the primary thread. For more information about multithreading, see [Managed Threading](../../../standard/threading/managed-threading-basics.md).

[!code-csharp[declareVolatile](~/samples/snippets/csharp/language-reference/keywords/volatile/Program.cs#Volatile)]

With the `volatile` modifier added to the declaration of `_shouldStop` in place, you'll always get the same results (similar to the excerpt shown in the preceding code). However, without that modifier on the `_shouldStop` member, the behavior is unpredictable. The `DoWork` method may optimize the member access, resulting in reading stale data. Because of the nature of multi-threaded programming, the number of stale reads is unpredictable. Different runs of the program will produce somewhat different results.

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

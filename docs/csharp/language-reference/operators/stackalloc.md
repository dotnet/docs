---
title: "stackalloc expression - Allocate variable storage on the stack instead of the heap"
description: "The C# stackalloc expression allocates a block of memory on the stack. Stackalloc memory is automatically discarded when that method returns."
ms.date: 11/28/2022
f1_keywords:
  - "stackalloc_CSharpKeyword"
helpviewer_keywords:
  - "stackalloc expression [C#]"
---
# stackalloc expression (C# reference)

A `stackalloc` expression allocates a block of memory on the stack. A stack-allocated memory block created during the method execution is automatically discarded when that method returns. You can't explicitly free the memory allocated with `stackalloc`. A stack allocated memory block isn't subject to [garbage collection](../../../standard/garbage-collection/index.md) and doesn't have to be pinned with a [`fixed` statement](../statements/fixed.md).

You can assign the result of a `stackalloc` expression to a variable of one of the following types:

- <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>, as the following example shows:

  [!code-csharp[stackalloc span](snippets/shared/StackallocOperator.cs#AssignToSpan)]

  You don't have to use an [unsafe](../keywords/unsafe.md) context when you assign a stack allocated memory block to a <xref:System.Span%601> or <xref:System.ReadOnlySpan%601> variable.

  When you work with those types, you can use a `stackalloc` expression in [conditional](conditional-operator.md) or assignment expressions, as the following example shows:

  [!code-csharp[stackalloc expression](snippets/shared/StackallocOperator.cs#AsExpression)]

  You can use a `stackalloc` expression or a collection expression inside other expressions whenever a <xref:System.Span%601> or <xref:System.ReadOnlySpan%601> variable is allowed, as the following example shows:

  [!code-csharp[stackalloc in nested expressions](snippets/shared/StackallocOperator.cs#Nested)]

  > [!NOTE]
  > We recommend using <xref:System.Span%601> or <xref:System.ReadOnlySpan%601> types to work with stack allocated memory whenever possible.

- A [pointer type](../unsafe-code.md#pointer-types), as the following example shows:

  [!code-csharp[stackalloc pointer](snippets/shared/StackallocOperator.cs#AssignToPointer)]

  As the preceding example shows, you must use an `unsafe` context when you work with pointer types.

  In the case of pointer types, you can use a `stackalloc` expression only in a local variable declaration to initialize the variable.

The amount of memory available on the stack is limited. If you allocate too much memory on the stack, a <xref:System.StackOverflowException> is thrown. To avoid that, follow the rules below:

- Limit the amount of memory you allocate with `stackalloc`. For example, if the intended buffer size is below a certain limit, you allocate the memory on the stack; otherwise, use an array of the required length, as the following code shows:

  [!code-csharp[limit stackalloc](snippets/shared/StackallocOperator.cs#LimitStackalloc)]

  > [!NOTE]
  > Because the amount of memory available on the stack depends on the environment in which the code is executed, be conservative when you define the actual limit value.

- Avoid using `stackalloc` inside loops. Allocate the memory block outside a loop and reuse it inside the loop.

The content of the newly allocated memory is undefined. You should initialize it, either with a `stackalloc` initializer, or a method like <xref:System.Span%601.Clear%2A?displayProperty=nameWithType> before it's used.

> [!IMPORTANT]
> Not initializing memory allocated by `stackalloc` is an important difference from the `new` operator. Memory allocated using the `new` operator is initialized to the 0 bit pattern.

You can use array initializer syntax to define the content of the newly allocated memory. The following example demonstrates various ways to do that:

[!code-csharp[stackalloc initialization](snippets/shared/StackallocOperator.cs#StackallocInit)]

In expression `stackalloc T[E]`, `T` must be an [unmanaged type](../builtin-types/unmanaged-types.md) and `E` must evaluate to a non-negative [int](../builtin-types/integral-numeric-types.md) value. When you use the [collection expression](./collection-expressions.md) syntax to initialize the span, the compiler may use stack allocated storage for a span if it won't violate ref safety.

## Security

The use of `stackalloc` automatically enables buffer overrun detection features in the common language runtime (CLR). If a buffer overrun is detected, the process is terminated as quickly as possible to minimize the chance that malicious code is executed.

## C# language specification

For more information, see the [Stack allocation](~/_csharpstandard/standard/unsafe-code.md#239-stack-allocation) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
- [Pointer related operators](pointer-related-operators.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [Dos and Don'ts of stackalloc](https://vcsjones.dev/2020/02/24/stackalloc/)

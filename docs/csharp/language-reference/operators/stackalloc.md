---
title: "stackalloc operator - C# reference"
ms.custom: seodec18
ms.date: 06/10/2019
f1_keywords: 
  - "stackalloc_CSharpKeyword"
helpviewer_keywords: 
  - "stackalloc operator [C#]"
---
# stackalloc operator (C# reference)

The `stackalloc` operator allocates a block of memory on the stack. A stack allocated memory block created during the method execution is automatically discarded when that method returns. You cannot explicitly free memory allocated with the `stackalloc` operator. A stack allocated memory block is not subject to [garbage collection](../../../standard/garbage-collection/index.md) and doesn't have to be pinned with the [`fixed` statement](../keywords/fixed-statement.md).

In expression `stackalloc T[E]`, `T` must be an [unmanaged type](../builtin-types/unmanaged-types.md) and `E` must be an expression of type `int`.

You can assign the result of the `stackalloc` operator to a variable of one of the following types:

- Starting with C# 7.2, <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>, as the following example shows:

  [!code-csharp[stackalloc span](~/samples/csharp/language-reference/operators/StackallocOperator.cs#AssignToSpan)]

  You don't have to use an [unsafe](../keywords/unsafe.md) context when you assign a stack allocated memory block to a <xref:System.Span%601> or <xref:System.ReadOnlySpan%601> variable.

  When you work with those types, you can use a `stackalloc` expression in [conditional](conditional-operator.md) or assignment expressions, as the following example shows:

  [!code-csharp[stackalloc expression](~/samples/csharp/language-reference/operators/StackallocOperator.cs#AsExpression)]

  > [!NOTE]
  > We recommend using <xref:System.Span%601> or <xref:System.ReadOnlySpan%601> types to work with stack allocated memory whenever possible.

- A [pointer type](../../programming-guide/unsafe-code-pointers/pointer-types.md), as the following example shows:

  [!code-csharp[stackalloc pointer](~/samples/csharp/language-reference/operators/StackallocOperator.cs#AssignToPointer)]

  As the preceding example shows, you must use an `unsafe` context when you work with pointer types.

The content of the newly allocated memory is undefined. Starting with C# 7.3, you can use array initializer syntax to define the content of the newly allocated memory. The following example demonstrates various ways to do that:

[!code-csharp[stackalloc initialization](~/samples/csharp/language-reference/operators/StackallocOperator.cs#StackallocInit)]

## Security

The use of `stackalloc` automatically enables buffer overrun detection features in the common language runtime (CLR). If a buffer overrun is detected, the process is terminated as quickly as possible to minimize the chance that malicious code is executed.

## C# language specification

For more information, see the [Stack allocation](~/_csharplang/spec/unsafe-code.md#stack-allocation) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Pointer related operators](pointer-related-operators.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)

---
title: "stackalloc keyword - C# Reference"
ms.custom: seodec18

ms.date: 04/12/2018
f1_keywords: 
  - "stackalloc_CSharpKeyword"
  - "stackalloc"
helpviewer_keywords: 
  - "stackalloc keyword [C#]"
---
# stackalloc (C# Reference)

The `stackalloc` keyword is used to allocate a block of memory on the stack.

```csharp
Span<int> block = stackalloc int[100];
```

Assigning the allocated block to a <xref:System.Span%601?displayName=nameWithType> instead of an `int*` allows stack allocations in a safe block. The `unsafe` context is not required.

## Remarks

The keyword is valid only in local variable initializers. The following code causes compiler errors.

```csharp
int* block;
// The following assignment statement causes compiler errors. You
// can use stackalloc only when declaring and initializing a local
// variable.
block = stackalloc int[100];
Span<int> span;
// The following assignment statement causes compiler errors. You
// can use stackalloc only when declaring and initializing a local
// variable.
span = stackalloc int[100];
```

Beginning with C# 7.3, you can use array initializer syntax for `stackalloc` arrays. All the following declarations declare an array with three elements whose values are the integers `1`, `2`, and `3`. The second initialization assigns the memory to a <xref:System.ReadOnlySpan%601>, indicating that the memory cannot be modified.

```csharp
// Valid starting with C# 7.3
Span<int> first = stackalloc int[3] { 1, 2, 3 };
ReadOnlySpan<int> second = stackalloc int[] { 1, 2, 3 };
Span<int> third = stackalloc[] { 1, 2, 3 };
```

When pointer types are involved, `stackalloc` requires an [unsafe](unsafe.md) context. For more information, see [Unsafe Code and Pointers](../../programming-guide/unsafe-code-pointers/index.md).

`stackalloc` is like [_alloca](/cpp/c-runtime-library/reference/alloca) in the C run-time library.

## Examples

The following example calculates and displays the first 20 numbers in the Fibonacci sequence. Each number is the sum of the previous two numbers. In the code, a block of memory of sufficient size to contain 20 elements of type `int` is allocated on the stack, not the heap. The address of the block is stored in the `Span` `fib`. This memory is not subject to garbage collection and therefore does not have to be pinned (by using [fixed](fixed-statement.md)). The lifetime of the memory block is limited to the lifetime of the method that defines it. You cannot free the memory before the method returns.

[!code-csharp[csrefKeywordsOperator#15](~/samples/snippets/csharp/keywords/StackAllocExamples.cs#1)]

The following example initializes a `stackalloc` array of integers to a bit mask with one bit set in each element. This demonstrates the new initializer syntax available starting in C# 7.3:

[!code-csharp[csrefKeywordsOperator#15](~/samples/snippets/csharp/keywords/StackAllocExamples.cs#2)]

## Security

You should use <xref:System.Span%601> or <xref:System.ReadonlySpan%601> when possible because unsafe code is less secure than safe alternatives. Even when used with pointers, the use of `stackalloc` automatically enables buffer overrun detection features in the common language runtime (CLR). If a buffer overrun is detected, the process is terminated as quickly as possible to minimize the chance that malicious code is executed.

## C# language specification

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Operator Keywords](operator-keywords.md)
- [Unsafe Code and Pointers](../../programming-guide/unsafe-code-pointers/index.md)
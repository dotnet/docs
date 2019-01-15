---
title: "[] Operator - C# Reference"
ms.custom: seodec18
ms.date: 01/10/2019
f1_keywords: 
  - "[]_CSharpKeyword"
helpviewer_keywords: 
  - "subscript operator [C#]"
  - "square brackets [ ] operator [C#]"
  - "[] operator [C#]"
  - "indexing operator [C#]"
ms.assetid: 5c16bb45-88f7-45ff-b42c-1af1972b042c
---
# [] Operator (C# Reference)

Square brackets, `[]`, are typically used for array, indexer, or pointer element access.

For more information about pointer element access, see [How to: access an array element with a pointer](../../programming-guide/unsafe-code-pointers/how-to-access-an-array-element-with-a-pointer.md).

You also use square brackets to specify [attributes](../../programming-guide/concepts/attributes/index.md):

```csharp
[System.Diagnostics.Conditional("DEBUG")]
void TraceMethod() {}
```

## Array access

The following example demonstrates how to access array elements:

[!code-csharp-interactive[array access](~/samples/snippets/csharp/language-reference/operators/IndexOperatorExamples.cs#Arrays)]

If an array index is outside the bounds of the corresponding dimension of an array, an <xref:System.IndexOutOfRangeException> is thrown.

As the preceding example shows, you also use square brackets in declaration of an array type and instantiation of array instances.

For more information about arrays, see [Arrays](../../programming-guide/arrays/index.md).

## Indexer access

The following example uses .NET <xref:System.Collections.Generic.Dictionary%602> type to demonstrate indexer access:

[!code-csharp-interactive[indexer access](~/samples/snippets/csharp/language-reference/operators/IndexOperatorExamples.cs#Indexers)]

Indexers allow you to index instances of a user-defined type in the similar way as array indexing. Unlike array indices, which must be integer, the indexer arguments can be declared to be of any type.

For more information about indexers, see [Indexers](../../programming-guide/indexers/index.md).

## Operator overloadability

Element access `[]` is not considered an overloadable operator. Use [indexers](../../programming-guide/indexers/index.md) to support indexing with user-defined types.

## C# language specification

For more information, see the [Element access](~/_csharplang/spec/expressions.md#element-access) and [Pointer element access](~/_csharplang/spec/unsafe-code.md#pointer-element-access) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Arrays](../../programming-guide/arrays/index.md)
- [Indexers](../../programming-guide/indexers/index.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
- [Attributes](../../programming-guide/concepts/attributes/index.md)

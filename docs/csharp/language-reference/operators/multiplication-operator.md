---
title: "* operator - C# Reference"
ms.custom: seodec18
ms.date: 02/26/2019
f1_keywords: 
  - "*_CSharpKeyword"
helpviewer_keywords: 
  - "multiplication operator (*) [C#]"
  - "* operator [C#]"
ms.assetid: abd9a5f0-9b24-431e-971a-09ee1c45c50e
---
# * operator (C# Reference)

The `*` operator is supported in two forms: a unary pointer indirection operator or a binary multiplication operator.

## Pointer indirection operator

Use the unary `*` operator to obtain the variable to which an operand of a pointer type points. For more information, see [How to: obtain the value of a pointer variable](../../programming-guide/unsafe-code-pointers/how-to-obtain-the-value-of-a-pointer-variable.md).

The pointer indirection operator `*` requires [unsafe](../keywords/unsafe.md) context.

## Multiplication operator

For numeric types, the `*` operator computes the product of its operands:

[!code-csharp-interactive[multiplication](~/samples/snippets/csharp/language-reference/operators/MultiplicationExamples.cs#Multiply)]

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) a binary `*` operator. When a binary `*` operator is overloaded, the [multiplication assignment operator](multiplication-assignment-operator.md) `*=` is also implicitly overloaded.

## C# language specification

For more information, see the [Pointer indirection](~/_csharplang/spec/unsafe-code.md#pointer-indirection) and [Multiplication operator](~/_csharplang/spec/expressions.md#multiplication-operator) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
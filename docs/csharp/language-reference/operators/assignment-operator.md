---
title: "= Operator - C# Reference"
ms.custom: seodec18

ms.date: 11/26/2018
f1_keywords: 
  - "=_CSharpKeyword"
helpviewer_keywords: 
  - "= operator [C#]"
ms.assetid: d802a6d5-32f0-42b8-b180-12f5a081bfc1
---
# = Operator (C# Reference)

The assignment operator `=` assigns the value of its right-hand operand to a variable, a [property](../../programming-guide/classes-and-structs/properties.md), or an [indexer](../../../csharp/programming-guide/indexers/index.md) element given by its left-hand operand. The result of an assignment expression is the value assigned to the left-hand operand. The type of the right-hand operand must be the same as the type of the left-hand operand or implicitly convertible to it.

The assignment operator is right-associative, that is, an expression of the form

```csharp
a = b = c
```

is evaluated as

```csharp
a = (b = c)
```

The following example demonstrates the usage of the assignment operator to assign values to a local variable, a property, and an indexer element:

[!code-csharp-interactive[assignment operator](~/samples/snippets/csharp/language-reference/operators/AssignmentExamples.cs#Assignments)]

## ref assignment operator

Beginning with C# 7.3, you can use the ref assignment operator `= ref` to reassign a [ref local](../keywords/ref.md#ref-locals) or [ref readonly local](../keywords/ref.md#ref-readonly-locals) variable. The following example demonstrates the usage of the ref assignment operator:

[!code-csharp[ref assignment operator](~/samples/snippets/csharp/language-reference/operators/AssignmentExamples.cs#RefAssignment)]

In the case of the ref assignment operator, the type of the left operand and the right operand must be the same.

For more information, see the [feature proposal note](../../../../_csharplang/proposals/csharp-7.3/ref-local-reassignment.md).

## Operator overloadability

A user-defined type cannot overload the assignment operator. However, a user-defined type can define an implicit conversion to another type. That way, the value of a user-defined type can be assigned to a variable, a property, or an indexer element of another type. For more information, see the [implicit](../keywords/implicit.md) keyword article.

## C# language specification

For more information, see the [Simple assignment](~/_csharplang/spec/expressions.md#simple-assignment) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [ref keyword](../keywords/ref.md)

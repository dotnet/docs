---
title: "Type-testing and assignment operators - C# reference"
description: "Learn about C# operators that you can use to check the type of an expression and assign an expression result to a variable, a property, or an indexer element."
ms.date: 06/18/2019
author: pkulikov
f1_keywords: 
  - "=_CSharpKeyword"
helpviewer_keywords: 
  - "type-testing operators [C#]"
  - "assignment operator [C#]"
  - "ref assignment operator [C#]"
  - "= operator [C#]"
---
# Type-testing and assignment operators (C# reference)

Introduction.

## is operator

Text.

## typeof operator

Text.

## as operator

Text.

## Cast expression with ()

Text.

## Assignment operator =

The `=` operator assigns the value of its right-hand operand to a variable, a [property](../../programming-guide/classes-and-structs/properties.md), or an [indexer](../../../csharp/programming-guide/indexers/index.md) element given by its left-hand operand. The result of an assignment expression is the value assigned to the left-hand operand. The type of the right-hand operand must be the same as the type of the left-hand operand or implicitly convertible to it.

The assignment operator is right-associative, that is, an expression of the form

```csharp
a = b = c
```

is evaluated as

```csharp
a = (b = c)
```

The following example demonstrates the usage of the assignment operator with a local variable, a property, and an indexer element as its left-hand operand:

[!code-csharp-interactive[= operator](~/samples/csharp/language-reference/operators/TypeTestingAndAssignmentOperators.cs#Assignment)]

## ref assignment operator

Beginning with C# 7.3, you can use the ref assignment operator `= ref` to reassign a [ref local](../keywords/ref.md#ref-locals) or [ref readonly local](../keywords/ref.md#ref-readonly-locals) variable. The following example demonstrates the usage of the ref assignment operator:

[!code-csharp[ref assignment operator](~/samples/csharp/language-reference/operators/TypeTestingAndAssignmentOperators.cs#RefAssignment)]

In the case of the ref assignment operator, the type of its both operands must be the same.

For more information, see the [feature proposal note](~/_csharplang/proposals/csharp-7.3/ref-local-reassignment.md).

## Compound assignment

For a binary operator `op`, a compound assignment expression of the form

```csharp
x op= y
```

is equivalent to

```csharp
x = x op y
```

except that `x` is only evaluated once.

Compound assignment is supported by [arithmetic](arithmetic-operators.md#compound-assignment), [Boolean logical](boolean-logical-operators.md#compound-assignment), and [bitwise logical and shift](bitwise-and-shift-operators.md#compound-assignment) operators.

## Operator overloadability

The `is`, `as`, and `typeof` operators are not overloadable.

A user-defined type cannot overload the assignment operator `=`. However, a user-defined type can define an implicit conversion to another type. That way, the value of a user-defined type can be assigned to a variable, a property, or an indexer element of another type. For more information, see the [implicit](../keywords/implicit.md) keyword article.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Assignment operators](~/_csharplang/spec/expressions.md#assignment-operators)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)

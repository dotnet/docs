---
title: "?? operator - C# Reference"
ms.custom: seodec18
ms.date: 06/07/2019
f1_keywords: 
  - "??_CSharpKeyword"
helpviewer_keywords: 
  - "null-coalescing operator [C#]"
  - "?? operator [C#]"
ms.assetid: 088b1f0d-c1af-4fe1-b4b8-196fd5ea9132
---
# ?? operator (C# Reference)

The null-coalescing operator `??` returns the value of its left-hand operand if it isn't `null`; otherwise, it evaluates the right-hand operand and returns its result. The `??` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

The null-coalescing operator is right-associative, that is, an expression of the form

```csharp
a ?? b ?? c
```

is evaluated as

```csharp
a ?? (b ?? c)
```

The `??` operator can be useful in the following scenarios:

- In expressions with the [null-conditional operators ?. and ?[]](member-access-operators.md#null-conditional-operators--and-), you can use the null-coalescing operator to provide an alternative expression to evaluate in case the result of the expression with null-conditional operations is `null`:

  [!code-csharp-interactive[with null-conditional](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#WithNullConditional)]

- When you work with [nullable value types](../../programming-guide/nullable-types/index.md) and need to provide a value of an underlying value type, use the null-coalescing operator to specify the value to provide in case a nullable type value is `null`:

  [!code-csharp-interactive[with nullable types](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#WithNullableTypes)]

  Use the <xref:System.Nullable%601.GetValueOrDefault?displayProperty=nameWithType> method if the value to be used when a nullable type value is `null` should be the default value of the underlying value type.

- Starting with C# 7.0, you can use a [`throw` expression](../keywords/throw.md#the-throw-expression) as the right-hand operand of the null-coalescing operator to make the argument-checking code more concise:

  [!code-csharp[with throw expression](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#WithThrowExpression)]

  The preceding example also demonstrates how to use [expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md) to define a property.

## Operator overloadability

The null-coalescing operator cannot be overloaded.

## C# language specification

For more information, see [The null coalescing operator](~/_csharplang/spec/expressions.md#the-null-coalescing-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [?. and ?[] operators](member-access-operators.md#null-conditional-operators--and-)
- [?: operator](conditional-operator.md)

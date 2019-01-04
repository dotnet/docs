---
title: "?: Operator - C# Reference"
ms.custom: seodec18

ms.date: "11/20/2018"
f1_keywords: 
  - "?:_CSharpKeyword"
  - "?_CSharpKeyword"
  - ":_CSharpKeyword"
helpviewer_keywords: 
  - "?: operator [C#]"
  - "conditional operator (?:) [C#]"
ms.assetid: e83a17f1-7500-48ba-8bee-2fbc4c847af4
---
# ?: Operator (C# Reference)

The conditional operator `?:`, commonly known as the ternary conditional operator, evaluates a Boolean expression, and returns the result of evaluating one of two expressions, depending on whether the Boolean expression evaluates to `true` or `false`. Beginning with C# 7.2, the [conditional ref expression](#conditional-ref-expression) returns the reference to the result of one of the two expressions.

The syntax for the conditional operator is as follows:

```csharp
condition ? consequence : alternative
```

The `condition` expression must evaluate to `true` or `false`. If `condition` evaluates to `true`, the `consequence` expression is evaluated, and its result becomes the result of the operation. If `condition` evaluates to `false`, the `alternative` expression is evaluated, and its result becomes the result of the operation. Only `consequence` or `alternative` is evaluated.

The type of `consequence` and `alternative` must be the same, or there must be an implicit conversion from one type to the other.

The conditional operator is right-associative, that is, an expression of the form

```csharp
a ? b : c ? d : e
```

is evaluated as

```csharp
a ? b : (c ? d : e)
```

The following example demonstrates the usage of the conditional operator:

[!code-csharp[non ref condtional](~/samples/snippets/csharp/language-reference/operators/ConditionalExamples.cs#ConditionalValue)]

## Conditional ref expression

Beginning with C# 7.2, you can use the conditional ref expression to return the reference to the result of one of the two expressions. You can assign that reference to a [ref local](../keywords/ref.md#ref-locals) or [ref readonly local](../keywords/ref.md#ref-readonly-locals) variable, or use it as a [reference return value](../keywords/ref.md#reference-return-values) or as a [`ref` method parameter](../keywords/ref.md#passing-an-argument-by-reference).

The syntax for the conditional ref expression is as follows:

```csharp
condition ? ref consequence : ref alternative
```

Like the original conditional operator, the conditional ref expression evaluates only one of the two expressions: either `consequence` or `alternative`.

In the case of the conditional ref expression, the type of `consequence` and `alternative` must be the same.

The following example demonstrates the usage of the conditional ref expression:

[!code-csharp[conditional ref](~/samples/snippets/csharp/language-reference/operators/ConditionalExamples.cs#ConditionalRef)]

For more information, see the [feature proposal note](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/conditional-ref.md).

## Conditional operator and an `if..else` statement

Use of the conditional operator over an [if-else](../keywords/if-else.md) statement might result in more concise code in cases when you need conditionally to compute a value. The following example demonstrates two ways to classify an integer as negative or nonnegative:

[!code-csharp[conditional and if-else](~/samples/snippets/csharp/language-reference/operators/ConditionalExamples.cs#CompareWithIf)]

## Operator overloadability

The conditional operator cannot be overloaded.

## C# language specification

For more information, see the [Conditional operator](~/_csharplang/spec/expressions.md#conditional-operator) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [if-else statement](../keywords/if-else.md)
- [?. and ?[] Operators](null-conditional-operators.md)
- [?? Operator](null-coalescing-operator.md)
- [ref keyword](../keywords/ref.md)

---
title: "?: operator - C# reference"
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
# ?: operator (C# reference)

The conditional operator `?:`, also known as the ternary conditional operator, evaluates a Boolean expression and returns the result of one of the two expressions, depending on whether the Boolean expression evaluates to `true` or `false`. Beginning with C# 7.2, the [conditional ref expression](#conditional-ref-expression) returns the reference to the result of one of the two expressions.

The syntax for the conditional operator is as follows:

```csharp
condition ? consequent : alternative
```

The `condition` expression must evaluate to `true` or `false`. If `condition` evaluates to `true`, the `consequent` expression is evaluated, and its result becomes the result of the operation. If `condition` evaluates to `false`, the `alternative` expression is evaluated, and its result becomes the result of the operation. Only `consequent` or `alternative` is evaluated.

The type of `consequent` and `alternative` must be the same, or there must be an implicit conversion from one type to the other.

The conditional operator is right-associative, that is, an expression of the form

```csharp
a ? b : c ? d : e
```

is evaluated as

```csharp
a ? b : (c ? d : e)
```

> [!TIP]
> You can use the following mnemonic device to remember how the conditional operator is evaluated:
>
> ```text
> is this condition true ? yes : no
> ```

The following example demonstrates the usage of the conditional operator:

[!code-csharp-interactive[non ref conditional](~/samples/csharp/language-reference/operators/ConditionalOperator.cs#ConditionalValue)]

## Conditional ref expression

Beginning with C# 7.2, you can use the conditional ref expression to return the reference to the result of one of the two expressions. You can assign that reference to a [ref local](../keywords/ref.md#ref-locals) or [ref readonly local](../keywords/ref.md#ref-readonly-locals) variable, or use it as a [reference return value](../keywords/ref.md#reference-return-values) or as a [`ref` method parameter](../keywords/ref.md#passing-an-argument-by-reference).

The syntax for the conditional ref expression is as follows:

```csharp
condition ? ref consequent : ref alternative
```

Like the original conditional operator, the conditional ref expression evaluates only one of the two expressions: either `consequent` or `alternative`.

In the case of the conditional ref expression, the type of `consequent` and `alternative` must be the same.

The following example demonstrates the usage of the conditional ref expression:

[!code-csharp-interactive[conditional ref](~/samples/csharp/language-reference/operators/ConditionalOperator.cs#ConditionalRef)]

## Conditional operator and an `if..else` statement

Use of the conditional operator instead of an [if-else](../keywords/if-else.md) statement might result in more concise code in cases when you need conditionally to compute a value. The following example demonstrates two ways to classify an integer as negative or nonnegative:

[!code-csharp[conditional and if-else](~/samples/csharp/language-reference/operators/ConditionalOperator.cs#CompareWithIf)]

## Operator overloadability

A user-defined type cannot overload the conditional operator.

## C# language specification

For more information, see the [Conditional operator](~/_csharplang/spec/expressions.md#conditional-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about the conditional ref expression, see the [feature proposal note](~/_csharplang/proposals/csharp-7.2/conditional-ref.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [if-else statement](../keywords/if-else.md)
- [?. and ?[] operators](member-access-operators.md#null-conditional-operators--and-)
- [?? and ??= operators](null-coalescing-operator.md)
- [ref keyword](../keywords/ref.md)

---
title: "?: operator - C# reference"
description: "Learn about the C# ternary conditional operator that returns the result of one of the two expressions based on a Boolean expression's result."
ms.date: "09/17/2020"
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

The conditional operator `?:`, also known as the ternary conditional operator, evaluates a Boolean expression and returns the result of one of the two expressions, depending on whether the Boolean expression evaluates to `true` or `false`, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ConditionalOperator.cs" id="BasicExample":::

As the preceding example shows, the syntax for the conditional operator is as follows:

```csharp
condition ? consequent : alternative
```

The `condition` expression must evaluate to `true` or `false`. If `condition` evaluates to `true`, the `consequent` expression is evaluated, and its result becomes the result of the operation. If `condition` evaluates to `false`, the `alternative` expression is evaluated, and its result becomes the result of the operation. Only `consequent` or `alternative` is evaluated.

Beginning with C# 9.0, conditional expressions are target-typed. That is, if a target type of a conditional expression is known, the types of `consequent` and `alternative` must be implicitly convertible to the target type, as the following example shows:

[!code-csharp[target-typed conditional](snippets/shared/ConditionalOperator.cs#TargetTyped)]

If a target type of a conditional expression is unknown (for example, when you use the [`var`](../keywords/var.md) keyword) or in C# 8.0 and earlier, the type of `consequent` and `alternative` must be the same or there must be an implicit conversion from one type to the other:

[!code-csharp[not target-typed conditional](snippets/shared/ConditionalOperator.cs#NotTargetTyped)]

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

## Conditional ref expression

Beginning with C# 7.2, a [ref local](../keywords/ref.md#ref-locals) or [ref readonly local](../keywords/ref.md#ref-readonly-locals) variable can be assigned conditionally with a conditional ref expression. You can also use a conditional ref expression as a [reference return value](../keywords/ref.md#reference-return-values) or as a [`ref` method argument](../keywords/ref.md#passing-an-argument-by-reference).

The syntax for a conditional ref expression is as follows:

```csharp
condition ? ref consequent : ref alternative
```

Like the original conditional operator, a conditional ref expression evaluates only one of the two expressions: either `consequent` or `alternative`.

In the case of a conditional ref expression, the type of `consequent` and `alternative` must be the same. Conditional ref expressions are not target-typed.

The following example demonstrates the usage of a conditional ref expression:

[!code-csharp-interactive[conditional ref](snippets/shared/ConditionalOperator.cs#ConditionalRef)]

## Conditional operator and an `if` statement

Use of the conditional operator instead of an [`if` statement](../statements/selection-statements.md#the-if-statement) might result in more concise code in cases when you need conditionally to compute a value. The following example demonstrates two ways to classify an integer as negative or nonnegative:

[!code-csharp[conditional and if-else](snippets/shared/ConditionalOperator.cs#CompareWithIf)]

## Operator overloadability

A user-defined type cannot overload the conditional operator.

## C# language specification

For more information, see the [Conditional operator](~/_csharplang/spec/expressions.md#conditional-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about features added in C# 7.2 and later, see the following feature proposal notes:

- [Conditional ref expressions (C# 7.2)](~/_csharplang/proposals/csharp-7.2/conditional-ref.md)
- [Target-typed conditional expression (C# 9.0)](~/_csharplang/proposals/csharp-9.0/target-typed-conditional-expression.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [if statement](../statements/selection-statements.md#the-if-statement)
- [?. and ?[] operators](member-access-operators.md#null-conditional-operators--and-)
- [?? and ??= operators](null-coalescing-operator.md)
- [ref keyword](../keywords/ref.md)

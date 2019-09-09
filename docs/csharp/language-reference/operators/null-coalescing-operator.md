---
title: "?? and ??= operators - C# reference"
ms.custom: seodec18
ms.date: 09/09/2019
f1_keywords: 
  - "??_CSharpKeyword"
  - "??=_CSharpKeyword"
helpviewer_keywords: 
  - "null-coalescing operator [C#]"
  - "?? operator [C#]"
  - "null-coalescing assignment [C#]"
  - "??= operator [C#]"
ms.assetid: 088b1f0d-c1af-4fe1-b4b8-196fd5ea9132
---
# ?? and ??= operators (C# reference)

The null-coalescing operator `??` returns the value of its left-hand operand if it isn't `null`; otherwise, it evaluates the right-hand operand and returns its result. The `??` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

The null-coalescing operator is right-associative, that is, an expression of the form

```csharp
a ?? b ?? c
```

is evaluated as

```csharp
a ?? (b ?? c)
```

In C# 7.3 and earlier, the type of the left-hand operand must be either a reference type or a [nullable value type](../../programming-guide/nullable-types/index.md). Beginning with C# 8.0, that requirement is replaced with the following: the type of the left-hand operand cannot be a non-nullable value type. In particular, you can use the null-coalescing operator with unconstrained type parameters:

[!code-csharp[unconstrained type parameter](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#UnconstrainedType)]

## Null-coalescing assignment

Available in C# 8.0 and later, the null-coalescing assignment operator `??=` assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand is null. The `??=` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

[!code-csharp[null-coalescing assignment](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#Assignment)]

Unlike with [compound assignment operators](assignment-operator.md#compound-assignment), the type of the result of the `??=` operator may differ from the type of its left-hand operand. For expression `a ??= b`, if `a` is of a nullable value type `T?` and `b` is implicitly convertible to the corresponding underlying type `T`, the type of the result of `a ??= b` is `T`. The null-coalescing operator `??` also behaves that way.

[!code-csharp[type of null-coalescing assignment](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#TypeOfResult)]

For more information, see the [feature proposal note](~/_csharplang/proposals/csharp-8.0/null-coalescing-assignment.md).

## Use cases

The `??` and `??=` operators can be useful in the following scenarios:

- In expressions with the [null-conditional operators ?. and ?[]](member-access-operators.md#null-conditional-operators--and-), you can use the null-coalescing operator to provide an alternative expression to evaluate in case the result of the expression with null-conditional operations is `null`:

  [!code-csharp-interactive[with null-conditional](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#WithNullConditional)]

- When you work with [nullable value types](../../programming-guide/nullable-types/index.md) and need to provide a value of an underlying value type, use the null-coalescing operator to specify the value to provide in case a nullable type value is `null`:

  [!code-csharp-interactive[with nullable types](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#WithNullableTypes)]

  Use the <xref:System.Nullable%601.GetValueOrDefault?displayProperty=nameWithType> method if the value to be used when a nullable type value is `null` should be the default value of the underlying value type.

- Starting with C# 7.0, you can use a [`throw` expression](../keywords/throw.md#the-throw-expression) as the right-hand operand of the null-coalescing operator to make the argument-checking code more concise:

  [!code-csharp[with throw expression](~/samples/csharp/language-reference/operators/NullCoalescingOperator.cs#WithThrowExpression)]

  The preceding example also demonstrates how to use [expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md) to define a property.

- Starting with C# 8.0, you can use the `??=` operator to replace the code of the form

  ```csharp
  if (variable is null)
  {
      variable = expression;
  }
  ```

  with the following code:

  ```csharp
  variable ??= expression;
  ```

## Operator overloadability

The operators `??` and `??=` cannot be overloaded.

## C# language specification

For more information, see [The null coalescing operator](~/_csharplang/spec/expressions.md#the-null-coalescing-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [?. and ?[] operators](member-access-operators.md#null-conditional-operators--and-)
- [?: operator](conditional-operator.md)

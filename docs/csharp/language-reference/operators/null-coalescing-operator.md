---
title: "?? and ??= operators - null-coalescing operators"
description: "The `??` and `??=` operators are the C# null-coalescing operators. They return the value of the left-hand operand if it isn't null. Otherwise, they return the value of the right-hand operand"
ms.date: 04/04/2025
f1_keywords:
  - "??_CSharpKeyword"
  - "??=_CSharpKeyword"
helpviewer_keywords:
  - "null-coalescing operator [C#]"
  - "?? operator [C#]"
  - "null-coalescing assignment [C#]"
  - "??= operator [C#]"
---
# ?? and ??= operators - the null-coalescing operators

<!--
  Note: All the remaining acrolinx issues in this article are because of the `??` and `??=` operator. Acrolinx believes it's a misspelling of the ? mark.
-->

The null-coalescing operator `??` returns the value of its left-hand operand if it isn't `null`; otherwise, it evaluates the right-hand operand and returns its result. The `??` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null. The null-coalescing assignment operator `??=` assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to `null`. The `??=` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

:::code language="csharp" source="snippets/shared/NullCoalescingOperator.cs" id="Assignment":::

The left-hand operand of the `??=` operator must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md), or an [indexer](../../programming-guide/indexers/index.md) element.

The type of the left-hand operand of the `??` and `??=` operators can't be a non-nullable value type. In particular, you can use the null-coalescing operators with unconstrained type parameters:

:::code language="csharp" source="snippets/shared/NullCoalescingOperator.cs" id="UnconstrainedType":::

The null-coalescing operators are right-associative. That is, expressions of the form

```csharp
a ?? b ?? c
d ??= e ??= f
```

are evaluated as

```csharp
a ?? (b ?? c)
d ??= (e ??= f)
```

## Examples

The `??` and `??=` operators can be useful in the following scenarios:

- In expressions with the [null-conditional operators `?.` and `?[]`](member-access-operators.md#null-conditional-operators--and-), you can use the `??` operator to provide an alternative expression to evaluate in case the result of the expression with null-conditional operations is `null`:

  :::code language="csharp" source="snippets/shared/NullCoalescingOperator.cs" id="WithNullConditional" interactive="try-dotnet-method":::

- When you work with [nullable value types](../builtin-types/nullable-value-types.md) and need to provide a value of an underlying value type, use the `??` operator to specify the value to provide in case a nullable type value is `null`:

  :::code language="csharp" source="snippets/shared/NullCoalescingOperator.cs" id="WithNullableTypes" interactive="try-dotnet-method":::

  Use the <xref:System.Nullable%601.GetValueOrDefault?displayProperty=nameWithType> method if the value to be used when a nullable type value is `null` should be the default value of the underlying value type.

- You can use a [`throw` expression](../statements/exception-handling-statements.md#the-throw-expression) as the right-hand operand of the `??` operator to make the argument-checking code more concise:

  :::code language="csharp" source="snippets/shared/NullCoalescingOperator.cs" id="WithThrowExpression" interactive="try-dotnet-method":::

  The preceding example also demonstrates how to use [expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md) to define a property.

- You can use the `??=` operator to replace the code of the form

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

The operators `??` and `??=` can't be overloaded.

## C# language specification

For more information about the `??` operator, see [The null coalescing operator](~/_csharpstandard/standard/expressions.md#1215-the-null-coalescing-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about the `??=` operator, see the [feature proposal note](~/_csharplang/proposals/csharp-8.0/null-coalescing-assignment.md).

## See also

- [Null check can be simplified (IDE0029, IDE0030, and IDE0270)](../../../fundamentals/code-analysis/style-rules/ide0029-ide0030-ide0270.md)
- [C# operators and expressions](index.md)
- [?. and ?[] operators](member-access-operators.md#null-conditional-operators--and-)
- [?: operator](conditional-operator.md)

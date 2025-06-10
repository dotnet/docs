---
title: "- and -= operators - subtraction (minus) operators"
description: "Learn about the C# subtraction (minus) operator and how it works with operands of numeric or delegate types."
ms.date: 06/11/2025
f1_keywords: 
  - "-_CSharpKeyword"
  - "-=_CSharpKeyword"
helpviewer_keywords: 
  - "subtraction operator [C#]"
  - "delegate removal [C#]"
  - "- operator [C#]"
  - "subtraction assignment operator [C#]"
  - "event unsubscription [C#]"
  - "-= operator [C#]"
---
# - and -= operators - subtraction (minus)

The built-in [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types and [delegate](../builtin-types/reference-types.md#the-delegate-type) types all support the `-` and `-=` operators.

For information about the arithmetic `-` operator, see the [Unary plus and minus operators](arithmetic-operators.md#unary-plus-and-minus-operators) and [Subtraction operator -](arithmetic-operators.md#subtraction-operator--) sections of the [Arithmetic operators](arithmetic-operators.md) article.

## Delegate removal

For operands of the same [delegate](../builtin-types/reference-types.md#the-delegate-type) type, the `-` operator returns a delegate instance that is calculated as follows:

- If both operands are non-null and the invocation list of the right-hand operand is a proper contiguous sublist of the invocation list of the left-hand operand, the result of the operation is a new invocation list that is obtained by removing the right-hand operand's entries from the invocation list of the left-hand operand. If the right-hand operand's list matches multiple contiguous sublists in the left-hand operand's list, only the right-most matching sublist is removed. If removal results in an empty list, the result is `null`.

  :::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/SubtractionOperator.cs" id="DelegateRemoval":::

- If the invocation list of the right-hand operand isn't a proper contiguous sublist of the invocation list of the left-hand operand, the result of the operation is the left-hand operand. For example, removing a delegate that isn't part of the multicast delegate does nothing and results in the unchanged multicast delegate.

  :::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/SubtractionOperator.cs" id="DelegateRemovalNoChange":::

  The preceding example also demonstrates that during delegate removal delegate instances are compared. For example, delegates that are produced from evaluation of identical [lambda expressions](lambda-expressions.md) aren't equal. For more information about delegate equality, see the [Delegate equality operators](~/_csharpstandard/standard/expressions.md#12129-delegate-equality-operators) section of the [C# language specification](~/_csharpstandard/standard/README.md).

- If the left-hand operand is `null`, the result of the operation is `null`. If the right-hand operand is `null`, the result of the operation is the left-hand operand.

  :::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/SubtractionOperator.cs" id="DelegateRemovalAndNull":::

To combine delegates, use the [`+` operator](addition-operator.md#delegate-combination).

For more information about delegate types, see [Delegates](../../programming-guide/delegates/index.md).

## Subtraction assignment operator -=

An expression using the `-=` operator, such as

```csharp
x -= y
```

Is equivalent to

```csharp
x = x - y
```

Except that `x` is only evaluated once.

The following example demonstrates the usage of the `-=` operator:

:::code interactive="try-dotnet-method" language="csharp" source="snippets/shared/SubtractionOperator.cs" id="SubtractAndAssign":::

You also use the `-=` operator to specify an event handler method to remove when you unsubscribe from an [event](../keywords/event.md). For more information, see [How to subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `-` operator. When a binary `-` operator is overloaded, the `-=` operator is also implicitly overloaded. Beginning with C# 14, a user-defined type can explicitly overload the `-=` operator to provide a more efficient implementation. Typically, a type overloads the `-=` operator because the value can be updated in place, rather than allocating performing the addition and return a new instance. If a type doesn't provide an explicit overload, the compiler generates the implicit overload.

## C# language specification

For more information, see the [Unary minus operator](~/_csharpstandard/standard/expressions.md#1293-unary-minus-operator) and [Subtraction operator](~/_csharpstandard/standard/expressions.md#12106-subtraction-operator) sections of the [C# language specification](~/_csharpstandard/standard/README.md). For more information on overloading the compound assignment operators in C# 14 and later, see the [user defined compound assignment](~/_csharplang/proposals/user-defined-compound-assignment.md) feature specification.

## See also

- [C# operators and expressions](index.md)
- [Events](../../programming-guide/events/index.md)
- [Arithmetic operators](arithmetic-operators.md)
- [+ and += operators](addition-operator.md)

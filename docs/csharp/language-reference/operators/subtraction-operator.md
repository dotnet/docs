---
title: "- and -= operators - C# reference"
ms.date: 05/27/2019
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
ms.assetid: 4de7a4fa-c69d-48e6-aff1-3130af970b2d
---
# - and -= operators (C# reference)

The `-` and `-=` operators are supported by the built-in [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types and [delegate](../builtin-types/reference-types.md#the-delegate-type) types.

For information about the arithmetic `-` operator, see the [Unary plus and minus operators](arithmetic-operators.md#unary-plus-and-minus-operators) and [Subtraction operator -](arithmetic-operators.md#subtraction-operator--) sections of the [Arithmetic operators](arithmetic-operators.md) article.

## Delegate removal

For operands of the same [delegate](../builtin-types/reference-types.md#the-delegate-type) type, the `-` operator returns a delegate instance that is calculated as follows:

- If both operands are non-null and the invocation list of the right-hand operand is a proper contiguous sublist of the invocation list of the left-hand operand, the result of the operation is a new invocation list that is obtained by removing the right-hand operand's entries from the invocation list of the left-hand operand. If the right-hand operand's list matches multiple contiguous sublists in the left-hand operand's list, only the right-most matching sublist is removed. If removal results in an empty list, the result is `null`.

  [!code-csharp-interactive[delegate removal](~/samples/csharp/language-reference/operators/SubtractionOperator.cs#DelegateRemoval)]

- If the invocation list of the right-hand operand is not a proper contiguous sublist of the invocation list of the left-hand operand, the result of the operation is the left-hand operand. For example, removing a delegate that is not part of the multicast delegate does nothing and results in the unchanged multicast delegate.

  [!code-csharp-interactive[delegate removal with no effect](~/samples/csharp/language-reference/operators/SubtractionOperator.cs#DelegateRemovalNoChange)]

  The preceding example also demonstrates that during delegate removal delegate instances are compared. For example, delegates that are produced from evaluation of identical [lambda expressions](../../programming-guide/statements-expressions-operators/lambda-expressions.md) are not equal. For more information about delegate equality, see the [Delegate equality operators](~/_csharplang/spec/expressions.md#delegate-equality-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

- If the left-hand operand is `null`, the result of the operation is `null`. If the right-hand operand is `null`, the result of the operation is the left-hand operand.

  [!code-csharp-interactive[delegate removal and null](~/samples/csharp/language-reference/operators/SubtractionOperator.cs#DelegateRemovalAndNull)]

To combine delegates, use the [`+` operator](addition-operator.md#delegate-combination).

For more information about delegate types, see [Delegates](../../programming-guide/delegates/index.md).

## Subtraction assignment operator -=

An expression using the `-=` operator, such as

```csharp
x -= y
```

is equivalent to

```csharp
x = x - y
```

except that `x` is only evaluated once.

The following example demonstrates the usage of the `-=` operator:

[!code-csharp-interactive[-= examples](~/samples/csharp/language-reference/operators/SubtractionOperator.cs#SubtractAndAssign)]

You also use the `-=` operator to specify an event handler method to remove when you unsubscribe from an [event](../keywords/event.md). For more information, see [How to subscribe to and unsubscribe from events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `-` operator. When a binary `-` operator is overloaded, the `-=` operator is also implicitly overloaded. A user-defined type cannot explicitly overload the `-=` operator.

## C# language specification

For more information, see the [Unary minus operator](~/_csharplang/spec/expressions.md#unary-minus-operator) and [Subtraction operator](~/_csharplang/spec/expressions.md#subtraction-operator) sections of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Events](../../programming-guide/events/index.md)
- [Arithmetic operators](arithmetic-operators.md)
- [+ and += operators](addition-operator.md)

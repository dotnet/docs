---
title: "% Operator (C# Reference)"
ms.date: 09/04/2018
f1_keywords: 
  - "%_CSharpKeyword"
helpviewer_keywords: 
  - "remainder operator [C#]"
  - "% operator [C#]"
ms.assetid: 3b74f4f9-fd9c-45e7-84fa-c8d71a0dfad7
---
# % Operator (C# Reference)

The remainder operator `%` computes the remainder after dividing its first operand by its second operand. User-defined types can [overload](../keywords/operator.md) the `%` operator. When the `%` is overloaded, the [remainder assignment operator](remainder-assignment-operator.md) `%=` is also implicitly overloaded.

All numeric types support the remainder operator.

## Integer remainder
  
For the integer operands, the result of `a % b` is the value produced by `a - (a / b) * b`. The sign of the non-zero remainder is the same as that of the first operand, as the following example shows:

[!code-csharp-interactive[integer remainder](~/samples/snippets/csharp/language-reference/operators/RemainderExamples.cs#1)]

## Floating-point remainder

For the [float](../keywords/float.md) and [double](../keywords/double.md) operands, the result of `x % y` for the finite `x` and `y` is the value `z` such that

- the sign of `z`, if non-zero, is the same as the sign of `x`;
- the absolute value of `z` is the value produced by `|x| - n * |y|` where `n` is the largest possible integer that is less than or equal to `|x| / |y|` and `|x|` and `|y|` are the absolute values of `x` and `y`, respectively.

For information about behavior of the `%` operator in case of non-finite operands, see the [Remainder operator](/dotnet/csharp/language-reference/language-specification/expressions#remainder-operator) section of the [C# language specification](/dotnet/csharp/language-reference/language-specification/index).

> [!NOTE]
> This method of computing the remainder is analogous to that used for integer operands, but differs from the IEEE 754. If you need the remainder operation that complies with the IEEE 754, use the <xref:System.Math.IEEERemainder%2A?displayProperty=nameWithType> method.

The following example demonstrates the behavior of the remainder operator for `float` and `double` operands:

[!code-csharp-interactive[float and double remainder](~/samples/snippets/csharp/language-reference/operators/RemainderExamples.cs#2)]

Note the round-off errors that can be associated with the floating-point types.

For the [decimal](../keywords/decimal.md) operands, the remainder operator `%` is equivalent to the [remainder operator](<xref:System.Decimal.op_Modulus(System.Decimal,System.Decimal)>) of the <xref:System.Decimal?displayProperty=nameWithType> type.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- <xref:System.Math.IEEERemainder%2A?displayProperty=nameWithType>
- <xref:System.Math.DivRem%2A?displayProperty=nameWithType>

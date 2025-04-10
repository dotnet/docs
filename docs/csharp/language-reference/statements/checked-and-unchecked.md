---
title: "The checked and unchecked statements - overflow-checking"
description: "Control the overflow-checking context. In a checked context, overflow causes an exception to be thrown. In an unchecked context, the result is truncated."
ms.date: 10/29/2022
f1_keywords: 
  - "checked_CSharpKeyword"
  - "unchecked_CSharpKeyword"
helpviewer_keywords: 
  - "checked statement [C#]"
  - "unchecked statement [C#]"
  - "statements [C#], checked and unchecked"
  - "overflow checking [C#]"
---
# The checked and unchecked statements (C# reference)

The `checked` and `unchecked` statements specify the overflow-checking context for integral-type arithmetic operations and conversions. The default statement is `unchecked`. When integer arithmetic overflow occurs, the overflow-checking context defines what happens. In a checked context, a <xref:System.OverflowException?displayProperty=nameWithType> is thrown; if overflow happens in a constant expression, a compile-time error occurs. In an unchecked context, the operation result is truncated by discarding any high-order bits that don't fit in the destination type. For example, addition wraps from the maximum value to the minimum value. The following example shows the same operation in both a checked and unchecked context:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/checked-and-unchecked/Program.cs" id="MainExample":::

> [!NOTE]
> The overflow behavior of *user-defined* operators and conversions can differ from the one described in the preceding paragraph. In particular, [user-defined checked operators](../operators/arithmetic-operators.md#user-defined-checked-operators) might not throw an exception in a checked context.

For more information, see the [Arithmetic overflow and division by zero](../operators/arithmetic-operators.md#arithmetic-overflow-and-division-by-zero) and [User-defined checked operators](../operators/arithmetic-operators.md#user-defined-checked-operators) sections of the [Arithmetic operators](../operators/arithmetic-operators.md) article.

To specify the overflow-checking context for an expression, you can also use the `checked` and `unchecked` operators, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/checked-and-unchecked/Program.cs" id="OperatorForm":::

The `checked` and `unchecked` statements and operators only affect the overflow-checking context for those operations that are *textually* inside the statement block or operator's parentheses, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/checked-and-unchecked/Program.cs" id="ScopeExample":::

At the preceding example, the first invocation of the `Multiply` local function shows that the `checked` statement doesn't affect the overflow-checking context within the `Multiply` function as no exception is thrown. At the second invocation of the `Multiply` function, the expression that calculates the second argument of the function is evaluated in a checked context and results in an exception as it's textually inside the block of the `checked` statement.

The behavior of `checked` and `unchecked` depends on the type and the operation. Even for integers, operations like `unchecked(x / 0)` always throw because there's no sensible behavior. Check the behavior for the type and the operation to understand how the `checked` and `unchecked` keywords affect your code.

## Numeric types and overflow-checking context

The `checked` and `unchecked` keywords primarily apply to integral types where there's a sensible overflow behavior. The wraparound behavior where `T.MaxValue + 1` becomes `T.MinValue` is sensible in a two's complement value. The represented value isn't *correct* since it can't fit in the storage for the type. Therefore, the bits are representative of the lower n-bits of the full result.

For types like `decimal`, `float`, `double`, and `Half` that represent a more complex value or a one's complement value, wraparound isn't sensible. It can't be used to compute larger or more accurate results, so `unchecked` isn't beneficial.

`float`, `double`, and `Half` have sensible saturating values for `PositiveInfinity` and `NegativeInfinity`, so you can detect overflow in an `unchecked` context. For `decimal`, no such limits exist, and saturating at `MaxValue` can lead to errors or confusion. Operations that use `decimal` throw in both a `checked` and `unchecked` context.

## Operations affected by the overflow-checking context

The overflow-checking context affects the following operations:

- The following built-in [arithmetic operators](../operators/arithmetic-operators.md): unary `++`, `--`, `-` and binary `+`, `-`, `*`, and `/` operators, when their operands are of an integral type (that is, either [integral numeric](../builtin-types/integral-numeric-types.md) or [char](../builtin-types/char.md) type) or an [enum](../builtin-types/enum.md) type.
- [Explicit numeric conversions](../builtin-types/numeric-conversions.md#explicit-numeric-conversions) between integral types or from [`float` or `double`](../builtin-types/floating-point-numeric-types.md) to an integral type.

  > [!NOTE]
  > When you convert a `decimal` value to an integral type and the result is outside the range of the destination type, an <xref:System.OverflowException> is always thrown, regardless of the overflow-checking context.

- Beginning with C# 11, user-defined checked operators and conversions. For more information, see the [User-defined checked operators](../operators/arithmetic-operators.md#user-defined-checked-operators) section of the [Arithmetic operators](../operators/arithmetic-operators.md) article.

## Default overflow-checking context

If you don't specify the overflow-checking context, the value of the [**CheckForOverflowUnderflow**](../compiler-options/language.md#checkforoverflowunderflow) compiler option defines the default context for nonconstant expressions. By default the value of that option is unset and integral-type arithmetic operations and conversions are executed in an **unchecked** context.

Constant expressions are evaluated by default in a checked context and overflow causes a compile-time error. You can explicitly specify an unchecked context for a constant expression with the `unchecked` statement or operator.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The checked and unchecked statements](~/_csharpstandard/standard/statements.md#1312-the-checked-and-unchecked-statements)
- [The checked and unchecked operators](~/_csharpstandard/standard/expressions.md#12820-the-checked-and-unchecked-operators)
- [User-defined checked and unchecked operators - C# 11](~/_csharplang/proposals/csharp-11.0/checked-user-defined-operators.md)

## See also

- [**CheckForOverflowUnderflow** compiler option](../compiler-options/language.md#checkforoverflowunderflow)

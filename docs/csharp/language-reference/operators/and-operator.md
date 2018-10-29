---
title: "&amp; Operator (C# Reference)"
ms.date: 10/29/2018
f1_keywords: 
  - "&_CSharpKeyword"
helpviewer_keywords: 
  - "bitwise AND operator [C#]"
  - "ampersand operator (&) [C#]"
  - "& operator [C#]"
  - "AND operator (&) [C#]"
ms.assetid: afa346d5-90ec-4b1f-a2c8-3881f018741d
---
# &amp; Operator (C# Reference)

The `&` operator is supported in two forms: a unary address-of operator or a binary logical operator.

## Unary address-of operator

The unary `&` operator returns the address of its operand. For more information, see [How to: obtain the address of a variable](../../programming-guide/unsafe-code-pointers/how-to-obtain-the-address-of-a-variable.md).

The address-of operator `&` requires [unsafe](../keywords/unsafe.md) context.

## Integer logical bitwise AND operator

For integer types, the `&` operator computes the logical bitwise AND of its operands:

[!code-csharp-interactive[integer logical bitwise AND](~/samples/snippets/csharp/language-reference/operators/AndOperatorExamples.cs#IntegerOperands)]

> [!NOTE]
> The preceding example uses the binary literals that are [introduced](../../whats-new/csharp-7.md#numeric-literal-syntax-improvements) in C# 7.0 and [enhanced](../../whats-new/csharp-7-2.md#leading-underscores-in-numeric-literals) in C# 7.2.

Because operations on integer types are generally allowed on enumeration types, the `&` operator also supports [enum](../keywords/enum.md) operands.

## Boolean logical AND operator

For [bool](../keywords/bool.md) operands, the `&` operator computes the logical AND of its operands. The result of `x & y` is `true` if both `x` and `y` are `true`. Otherwise, the result is `false`.

The `&` operator evaluates both operands even if the first operand evaluates to `false`, so that the result must be `false` regardless of the value of the second operand. The following example demonstrates that behavior:

[!code-csharp-interactive[bool logical AND](~/samples/snippets/csharp/language-reference/operators/AndOperatorExamples.cs#BooleanOperands)]

The [conditional AND operator](conditional-and-operator.md) `&&` also computes the logical AND of its operands, but evaluates the second operand only if the first operand evaluates to `true`.

For nullable bool operands, the behavior of the `&` operator is consistent with SQL's three-valued logic. For more information, see the [The bool? type](../../programming-guide/nullable-types/using-nullable-types.md#the-bool-type) section of the [Using nullable types](../../programming-guide/nullable-types/using-nullable-types.md) article.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the binary `&` operator. When a binary `&` operator is overloaded, the [AND assignment operator](and-assignment-operator.md) `&=` is also implicitly overloaded.

## C# language specification

For more information, see [The address-of operator](~/_csharplang/spec/unsafe-code.md#the-address-of-operator) and [Logical operators](~/_csharplang/spec/expressions.md#logical-operators) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
- [| operator](or-operator.md)
- [^ operator](xor-operator.md)
- [&& operator](conditional-and-operator.md)

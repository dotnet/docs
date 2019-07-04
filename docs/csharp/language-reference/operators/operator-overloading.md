---
title: "Operator overloading - C# reference"
description: "Learn how to overload a C# operator and get known with the set of overloadable operators."
ms.date: 07/05/2019
f1_keywords: 
  - "operator_CSharpKeyword"
helpviewer_keywords: 
  - "operator keyword [C#]"
  - "operator overloading [C#]"
---
# Operator overloading (C# reference)

A user-defined type can overload a predefined operator. That is, a type can provide the custom implementation of an operation when one or both operands are of that type. For information about overloadable operators, see the [Overloadable operators](#overloadable-operators) section.

Use the `operator` keyword to declare an operator. An operator declaration must satisfy the following rules:

- It includes both a `public` and a `static` modifier.
- Unary operator takes one parameter. Binary operator takes two parameters. In each case, at least one parameter must have type `T` or `T?` where `T` is the type that contains the operator declaration.

The following examples defines the `Fraction` structure that overloads some of the [arithmetic operators](arithmetic-operators.md):

[!code-csharp[fraction example](~/samples/csharp/language-reference/operators/OperatorOverloading.cs)]

## Overloadable operators

The following table provides information about overloadability of C# operators:

| Operators | Overloadability |
| --------- | --------------- |
|[+](arithmetic-operators.md#unary-plus-and-minus-operators), [-](arithmetic-operators.md#unary-plus-and-minus-operators), [!](boolean-logical-operators.md#logical-negation-operator-), [~](bitwise-and-shift-operators.md#bitwise-complement-operator-), [++](arithmetic-operators.md#increment-operator-), [--](arithmetic-operators.md#decrement-operator---), [true](true-false-operators.md), [false](true-false-operators.md)|These unary operators can be overloaded.|
|[+](addition-operator.md), [-](subtraction-operator.md), [\*](arithmetic-operators.md#multiplication-operator-), [/](arithmetic-operators.md#division-operator-), [%](arithmetic-operators.md#remainder-operator-), [&](boolean-logical-operators.md#logical-and-operator-), [&#124;](boolean-logical-operators.md#logical-or-operator-), [^](boolean-logical-operators.md#logical-exclusive-or-operator-), [\<\<](bitwise-and-shift-operators.md#left-shift-operator-), [>>](bitwise-and-shift-operators.md#right-shift-operator-), [==](equality-operators.md#equality-operator-), [!=](equality-operators.md#inequality-operator-), [\<](comparison-operators.md#less-than-operator-), [>](comparison-operators.md#greater-than-operator-), [\<=](comparison-operators.md#less-than-or-equal-operator-), [>=](comparison-operators.md#greater-than-or-equal-operator-)|These binary operators can be overloaded. Certain operators must be overloaded in pairs; for more information, see the note that follows this table.|
|[&&](boolean-logical-operators.md#conditional-logical-and-operator-), [&#124;&#124;](boolean-logical-operators.md#conditional-logical-or-operator-)|Conditional logical operators cannot be overloaded. However, if a type with the overloaded [`true` and `false` operators](true-false-operators.md) also overloads the `&` or <code>&#124;</code> operator in a certain way, the `&&` or <code>&#124;&#124;</code> operator, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).|
|[&#91;&#93;](member-access-operators.md#indexer-operator-)|Element access is not considered an overloadable operator, but you can define [indexers](../../programming-guide/indexers/index.md).|
|[(T)x](type-testing-and-conversion-operators.md#cast-operator-)|The cast operator cannot be overloaded, but you can define new conversion operators (see [explicit](../keywords/explicit.md) and [implicit](../keywords/implicit.md)).|
|[+=](arithmetic-operators.md#compound-assignment), [-=](arithmetic-operators.md#compound-assignment), [\*=](arithmetic-operators.md#compound-assignment), [/=](arithmetic-operators.md#compound-assignment), [%=](arithmetic-operators.md#compound-assignment), [&=](boolean-logical-operators.md#compound-assignment), [&#124;=](boolean-logical-operators.md#compound-assignment), [^=](boolean-logical-operators.md#compound-assignment), [\<\<=](bitwise-and-shift-operators.md#compound-assignment), [>>=](bitwise-and-shift-operators.md#compound-assignment)|Compound assignment operators cannot be explicitly overloaded. However, when you overload a binary operator, the corresponding compound assignment operator, if any, is also implicitly overloaded. For example, `+=` is evaluated using `+`, which can be overloaded.|
|[=](assignment-operator.md), [.](member-access-operators.md#member-access-operator-), [?:](conditional-operator.md), [??](null-coalescing-operator.md), [->](pointer-related-operators.md#pointer-member-access-operator--), [=>](lambda-operator.md), [f(x)](member-access-operators.md#invocation-operator-), [as](type-testing-and-conversion-operators.md#as-operator), [checked](../keywords/checked.md), [unchecked](../keywords/unchecked.md), [default](../../programming-guide/statements-expressions-operators/default-value-expressions.md), [delegate](../../programming-guide/statements-expressions-operators/anonymous-methods.md), [is](type-testing-and-conversion-operators.md#is-operator), [nameof](../keywords/nameof.md), [new](new-operator.md), [sizeof](../keywords/sizeof.md), [typeof](type-testing-and-conversion-operators.md#typeof-operator)|These operators cannot be overloaded.|

> [!NOTE]
> The comparison operators must be overloaded in pairs. That is, if either operator of a pair is overloaded, the other operator must be overloaded as well. Such pairs are as follows:
>
> - `==` and `!=` operators
> - `<` and `>` operators
> - `<=` and `>=` operators

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Operator overloading](~/_csharplang/spec/expressions.md#operator-overloading)
- [Operators](~/_csharplang/spec/classes.md#operators)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Why are overloaded operators always static in C#?](https://blogs.msdn.microsoft.com/ericlippert/2007/05/14/why-are-overloaded-operators-always-static-in-c/)

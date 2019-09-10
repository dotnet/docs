---
title: "Operator overloading - C# reference"
description: "Learn how to overload a C# operator and which C# operators are overloadable."
ms.date: 07/05/2019
f1_keywords: 
  - "operator_CSharpKeyword"
helpviewer_keywords: 
  - "operator keyword [C#]"
  - "operator overloading [C#]"
---
# Operator overloading (C# reference)

A user-defined type can overload a predefined C# operator. That is, a type can provide the custom implementation of an operation when one or both of the operands are of that type. The [Overloadable operators](#overloadable-operators) section shows which C# operators can be overloaded.

Use the `operator` keyword to declare an operator. An operator declaration must satisfy the following rules:

- It includes both a `public` and a `static` modifier.
- A unary operator takes one parameter. A binary operator takes two parameters. In each case, at least one parameter must have type `T` or `T?` where `T` is the type that contains the operator declaration.

The following example defines a simplified structure to represent a rational number. The structure overloads some of the [arithmetic operators](arithmetic-operators.md):

[!code-csharp[fraction example](~/samples/csharp/language-reference/operators/OperatorOverloading.cs)]

You could extend the preceding example by defining an implicit conversion from `int` to `Fraction`. Then, overloaded operators would support arguments of those two types. That is, it would become possible to add an integer to a fraction and obtain a fraction as a result.

You also use the `operator` keyword to define a custom type conversion. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).

## Overloadable operators

The following table provides information about overloadability of C# operators:

| Operators | Overloadability |
| --------- | --------------- |
|[+x](arithmetic-operators.md#unary-plus-and-minus-operators), [-x](arithmetic-operators.md#unary-plus-and-minus-operators), [!x](boolean-logical-operators.md#logical-negation-operator-), [~x](bitwise-and-shift-operators.md#bitwise-complement-operator-), [++](arithmetic-operators.md#increment-operator-), [--](arithmetic-operators.md#decrement-operator---), [true](true-false-operators.md), [false](true-false-operators.md)|These unary operators can be overloaded.|
|[x + y](addition-operator.md), [x - y](subtraction-operator.md), [x \* y](arithmetic-operators.md#multiplication-operator-), [x / y](arithmetic-operators.md#division-operator-), [x % y](arithmetic-operators.md#remainder-operator-), [x & y](boolean-logical-operators.md#logical-and-operator-), [x &#124; y](boolean-logical-operators.md#logical-or-operator-), [x ^ y](boolean-logical-operators.md#logical-exclusive-or-operator-), [x \<\< y](bitwise-and-shift-operators.md#left-shift-operator-), [x >> y](bitwise-and-shift-operators.md#right-shift-operator-), [x == y](equality-operators.md#equality-operator-), [x != y](equality-operators.md#inequality-operator-), [x \< y](comparison-operators.md#less-than-operator-), [x > y](comparison-operators.md#greater-than-operator-), [x \<= y](comparison-operators.md#less-than-or-equal-operator-), [x >= y](comparison-operators.md#greater-than-or-equal-operator-)|These binary operators can be overloaded. Certain operators must be overloaded in pairs; for more information, see the note that follows this table.|
|[x && y](boolean-logical-operators.md#conditional-logical-and-operator-), [x &#124;&#124; y](boolean-logical-operators.md#conditional-logical-or-operator-)|Conditional logical operators cannot be overloaded. However, if a type with the overloaded [`true` and `false` operators](true-false-operators.md) also overloads the `&` or <code>&#124;</code> operator in a certain way, the `&&` or <code>&#124;&#124;</code> operator, respectively, can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).|
|[a&#91;i&#93;](member-access-operators.md#indexer-operator-)|Element access is not considered an overloadable operator, but you can define an [indexer](../../programming-guide/indexers/index.md).|
|[(T)x](type-testing-and-cast.md#cast-operator-)|The cast operator cannot be overloaded, but you can define new conversion operators. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).|
|[+=](arithmetic-operators.md#compound-assignment), [-=](arithmetic-operators.md#compound-assignment), [\*=](arithmetic-operators.md#compound-assignment), [/=](arithmetic-operators.md#compound-assignment), [%=](arithmetic-operators.md#compound-assignment), [&=](boolean-logical-operators.md#compound-assignment), [&#124;=](boolean-logical-operators.md#compound-assignment), [^=](boolean-logical-operators.md#compound-assignment), [\<\<=](bitwise-and-shift-operators.md#compound-assignment), [>>=](bitwise-and-shift-operators.md#compound-assignment)|Compound assignment operators cannot be explicitly overloaded. However, when you overload a binary operator, the corresponding compound assignment operator, if any, is also implicitly overloaded. For example, `+=` is evaluated using `+`, which can be overloaded.|
|[x = y](assignment-operator.md), [x.y](member-access-operators.md#member-access-operator-), [c ? t : f](conditional-operator.md), [x ?? y](null-coalescing-operator.md), [x ??= y](null-coalescing-operator.md), [x->y](pointer-related-operators.md#pointer-member-access-operator--), [=>](lambda-operator.md), [f(x)](member-access-operators.md#invocation-operator-), [as](type-testing-and-cast.md#as-operator), [await](await.md), [checked](../keywords/checked.md), [unchecked](../keywords/unchecked.md), [default](default.md), [delegate](delegate-operator.md), [is](type-testing-and-cast.md#is-operator), [nameof](nameof.md), [new](new-operator.md), [sizeof](sizeof.md), [stackalloc](stackalloc.md), [typeof](type-testing-and-cast.md#typeof-operator)|These operators cannot be overloaded.|

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
- [User-defined conversion operators](user-defined-conversion-operators.md)
- [Why are overloaded operators always static in C#?](https://blogs.msdn.microsoft.com/ericlippert/2007/05/14/why-are-overloaded-operators-always-static-in-c/)

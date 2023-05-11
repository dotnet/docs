---
title: "Operator overloading - Define unary, arithmetic, equality, and comparison operators."
description: "Learn how to overload a C# operator and which C# operators are overloadable. In general, the unary, arithmetic, equality and comparison operators are overloadable."
ms.date: 11/28/2022
f1_keywords: 
  - "operator_CSharpKeyword"
  - operator
helpviewer_keywords: 
  - "operator keyword [C#]"
  - "operator overloading [C#]"
---
# Operator overloading - predefined unary, arithmetic, equality and comparison operators

A user-defined type can overload a predefined C# operator. That is, a type can provide the custom implementation of an operation in case one or both of the operands are of that type. The [Overloadable operators](#overloadable-operators) section shows which C# operators can be overloaded.

Use the `operator` keyword to declare an operator. An operator declaration must satisfy the following rules:

- It includes both a `public` and a `static` modifier.
- A unary operator has one input parameter. A binary operator has two input parameters. In each case, at least one parameter must have type `T` or `T?` where `T` is the type that contains the operator declaration.

The following example defines a simplified structure to represent a rational number. The structure overloads some of the [arithmetic operators](arithmetic-operators.md):

[!code-csharp[fraction example](snippets/shared/OperatorOverloading.cs)]

You could extend the preceding example by [defining an implicit conversion](user-defined-conversion-operators.md) from `int` to `Fraction`. Then, overloaded operators would support arguments of those two types. That is, it would become possible to add an integer to a fraction and obtain a fraction as a result.

You also use the `operator` keyword to define a custom type conversion. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).

## Overloadable operators

The following table shows the operators that can be overloaded:

| Operators | Notes |
| :--------------------: | ------------- |
|[`+x`](arithmetic-operators.md#unary-plus-and-minus-operators), [`-x`](arithmetic-operators.md#unary-plus-and-minus-operators), [`!x`](boolean-logical-operators.md#logical-negation-operator-), [`~x`](bitwise-and-shift-operators.md#bitwise-complement-operator-), [`++`](arithmetic-operators.md#increment-operator-), [`--`](arithmetic-operators.md#decrement-operator---), [`true`](true-false-operators.md), [`false`](true-false-operators.md)|The `true` and `false` operators must be overloaded together.|
|[`x + y`](arithmetic-operators.md#addition-operator-), [`x - y`](arithmetic-operators.md#subtraction-operator--), [`x * y`](arithmetic-operators.md#multiplication-operator-), [`x / y`](arithmetic-operators.md#division-operator-), [`x % y`](arithmetic-operators.md#remainder-operator-), <br /> [`x & y`](boolean-logical-operators.md#logical-and-operator-), [<code>x &#124; y</code>](boolean-logical-operators.md#logical-or-operator-), [`x ^ y`](boolean-logical-operators.md#logical-exclusive-or-operator-), <br /> [`x << y`](bitwise-and-shift-operators.md#left-shift-operator-), [`x >> y`](bitwise-and-shift-operators.md#right-shift-operator-), [`x >>> y`](bitwise-and-shift-operators.md#unsigned-right-shift-operator-) | |
|[`x == y`](equality-operators.md#equality-operator-), [`x != y`](equality-operators.md#inequality-operator-), [`x < y`](comparison-operators.md#less-than-operator-), [`x > y`](comparison-operators.md#greater-than-operator-), [`x <= y`](comparison-operators.md#less-than-or-equal-operator-), [`x >= y`](comparison-operators.md#greater-than-or-equal-operator-)|Must be overloaded in pairs as follows:  `==` and `!=`, `<` and `>`, `<=` and `>=`.|

## Non overloadable operators

The following table shows the operators that can't be overloaded:

| Operators | Alternatives |
| :---------: | --------------- |
|[`x && y`](boolean-logical-operators.md#conditional-logical-and-operator-), [<code>x &#124;&#124; y</code>](boolean-logical-operators.md#conditional-logical-or-operator-)| Overload both the [`true`](true-false-operators.md) and [`false`](true-false-operators.md) operators and the [`&`](boolean-logical-operators.md#logical-and-operator-) or [<code>&#124;</code>](boolean-logical-operators.md#logical-or-operator-) operators. For more information, see [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12143-user-defined-conditional-logical-operators).|
|[<code>a&#91;i&#93;</code>](member-access-operators.md#indexer-operator-), [`a?[i]`](member-access-operators.md#null-conditional-operators--and-)|Define an [indexer](../../programming-guide/indexers/index.md).|
|[`(T)x`](type-testing-and-cast.md#cast-expression)|Define custom type conversions that can be performed by a cast expression. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).|
|[`+=`](arithmetic-operators.md#compound-assignment), [`-=`](arithmetic-operators.md#compound-assignment), [`*=`](arithmetic-operators.md#compound-assignment), [`/=`](arithmetic-operators.md#compound-assignment), [`%=`](arithmetic-operators.md#compound-assignment), [`&=`](boolean-logical-operators.md#compound-assignment), [<code>&#124;=</code>](boolean-logical-operators.md#compound-assignment), [`^=`](boolean-logical-operators.md#compound-assignment), [`<<=`](bitwise-and-shift-operators.md#compound-assignment), [`>>=`](bitwise-and-shift-operators.md#compound-assignment), [`>>>=`](bitwise-and-shift-operators.md#compound-assignment)|Overload the corresponding binary operator. For example, when you overload the binary `+` operator, `+=` is implicitly overloaded.|
|[`^x`](member-access-operators.md#index-from-end-operator-), [`x = y`](assignment-operator.md), [`x.y`](member-access-operators.md#member-access-expression-), [`x?.y`](member-access-operators.md#null-conditional-operators--and-), [`c ? t : f`](conditional-operator.md), [`x ?? y`](null-coalescing-operator.md), [`??= y`](null-coalescing-operator.md),<br />[`x..y`](member-access-operators.md#range-operator-), [`x->y`](pointer-related-operators.md#pointer-member-access-operator--), [`=>`](lambda-operator.md), [`f(x)`](member-access-operators.md#invocation-expression-), [`as`](type-testing-and-cast.md#as-operator), [`await`](await.md), [`checked`](../statements/checked-and-unchecked.md), [`unchecked`](../statements/checked-and-unchecked.md), [`default`](default.md), [`delegate`](delegate-operator.md), [`is`](type-testing-and-cast.md#is-operator), [`nameof`](nameof.md), [`new`](new-operator.md), <br />[`sizeof`](sizeof.md), [`stackalloc`](stackalloc.md), [`switch`](switch-expression.md), [`typeof`](type-testing-and-cast.md#typeof-operator), [`with`](with-expression.md)|None.|

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Operator overloading](~/_csharpstandard/standard/expressions.md#1243-operator-overloading)
- [Operators](~/_csharpstandard/standard/classes.md#1510-operators)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [User-defined conversion operators](user-defined-conversion-operators.md)
- [Design guidelines - Operator overloads](../../../standard/design-guidelines/operator-overloads.md)
- [Design guidelines - Equality operators](../../../standard/design-guidelines/equality-operators.md)
- [Why are overloaded operators always static in C#?](/archive/blogs/ericlippert/why-are-overloaded-operators-always-static-in-c)

---
title: "Overloadable operators - C# Programming Guide"
ms.custom: seodec18
ms.date: 08/27/2018
helpviewer_keywords: 
  - "C# language, operator overloading"
  - "operator overloading [C#]"
ms.assetid: 390d9d01-79fc-40ab-9ed3-0bf448da1b6a
---
# Overloadable operators (C# Programming Guide)

C# allows user-defined types to overload operators by defining static member functions using the [operator](../../language-reference/keywords/operator.md) keyword. Not all operators can be overloaded, however, and others have restrictions, as listed in this table:

| Operators | Overloadability |
| --------- | --------------- |
|[+](../../language-reference/operators/addition-operator.md), [-](../../language-reference/operators/subtraction-operator.md), [!](../../language-reference/operators/boolean-logical-operators.md#logical-negation-operator-), [~](../../language-reference/operators/bitwise-and-shift-operators.md#bitwise-complement-operator-), [++](../../language-reference/operators/arithmetic-operators.md#increment-operator-), [--](../../language-reference/operators/arithmetic-operators.md#decrement-operator---), [true](../../language-reference/operators/true-false-operators.md), [false](../../language-reference/operators/true-false-operators.md)|These unary operators can be overloaded.|
|[+](../../language-reference/operators/addition-operator.md), [-](../../language-reference/operators/subtraction-operator.md), [\*](../../language-reference/operators/arithmetic-operators.md#multiplication-operator-), [/](../../language-reference/operators/arithmetic-operators.md#division-operator-), [%](../../language-reference/operators/arithmetic-operators.md#remainder-operator-), [&](../../language-reference/operators/boolean-logical-operators.md#logical-and-operator-), [&#124;](../../language-reference/operators/boolean-logical-operators.md#logical-or-operator-), [^](../../language-reference/operators/boolean-logical-operators.md#logical-exclusive-or-operator-), [\<\<](../../language-reference/operators/bitwise-and-shift-operators.md#left-shift-operator-), [>>](../../language-reference/operators/bitwise-and-shift-operators.md#right-shift-operator-)|These binary operators can be overloaded.|
|[==](../../language-reference/operators/equality-operators.md#equality-operator-), [!=](../../language-reference/operators/equality-operators.md#inequality-operator-), [\<](../../language-reference/operators/comparison-operators.md#less-than-operator-), [>](../../language-reference/operators/comparison-operators.md#greater-than-operator-), [\<=](../../language-reference/operators/comparison-operators.md#less-than-or-equal-operator-), [>=](../../language-reference/operators/comparison-operators.md#greater-than-or-equal-operator-)|The comparison operators can be overloaded (but see the note that follows this table).|
|[&&](../../language-reference/operators/boolean-logical-operators.md#conditional-logical-and-operator-), [&#124;&#124;](../../language-reference/operators/boolean-logical-operators.md#conditional-logical-or-operator-)|The conditional logical operators cannot be overloaded, but they are evaluated using `&` and <code>&#124;</code>, which can be overloaded.|
|[&#91;&#93;](../../language-reference/operators/member-access-operators.md#indexer-operator-)|The array indexing operator cannot be overloaded, but you can define [indexers](../indexers/index.md).|
|[(T)x](../../language-reference/operators/type-testing-and-conversion-operators.md#cast-operator-)|The cast operator cannot be overloaded, but you can define new conversion operators (see [explicit](../../language-reference/keywords/explicit.md) and [implicit](../../language-reference/keywords/implicit.md)).|
|[+=](../../language-reference/operators/arithmetic-operators.md#compound-assignment), [-=](../../language-reference/operators/arithmetic-operators.md#compound-assignment), [\*=](../../language-reference/operators/arithmetic-operators.md#compound-assignment), [/=](../../language-reference/operators/arithmetic-operators.md#compound-assignment), [%=](../../language-reference/operators/arithmetic-operators.md#compound-assignment), [&=](../../language-reference/operators/boolean-logical-operators.md#compound-assignment), [&#124;=](../../language-reference/operators/boolean-logical-operators.md#compound-assignment), [^=](../../language-reference/operators/boolean-logical-operators.md#compound-assignment), [\<\<=](../../language-reference/operators/bitwise-and-shift-operators.md#compound-assignment), [>>=](../../language-reference/operators/bitwise-and-shift-operators.md#compound-assignment)|Assignment operators cannot be explicitly overloaded. However, when you overload a binary operator, the corresponding assignment operator, if any, is also implicitly overloaded. For example, `+=` is evaluated using `+`, which can be overloaded.|
|[=](../../language-reference/operators/assignment-operator.md), [.](../../language-reference/operators/member-access-operators.md#member-access-operator-), [?:](../../language-reference/operators/conditional-operator.md), [??](../../language-reference/operators/null-coalescing-operator.md), [->](../../language-reference/operators/pointer-related-operators.md#pointer-member-access-operator--), [=>](../../language-reference/operators/lambda-operator.md), [f(x)](../../language-reference/operators/member-access-operators.md#invocation-operator-), [as](../../language-reference/operators/type-testing-and-conversion-operators.md#as-operator), [checked](../../language-reference/keywords/checked.md), [unchecked](../../language-reference/keywords/unchecked.md), [default](../../programming-guide/statements-expressions-operators/default-value-expressions.md), [delegate](../../programming-guide/statements-expressions-operators/anonymous-methods.md), [is](../../language-reference/operators/type-testing-and-conversion-operators.md#is-operator), [new](../../language-reference/keywords/new.md), [sizeof](../../language-reference/keywords/sizeof.md), [typeof](../../language-reference/keywords/typeof.md)|These operators cannot be overloaded.|

> [!NOTE]
> The comparison operators, if overloaded, must be overloaded in pairs; that is, if `==` is overloaded, `!=` must also be overloaded. The reverse is also true, where overloading `!=` requires an overload for `==`. The same is true for comparison operators `<` and `>` and for `<=` and `>=`.

For information about how to overload an operator, see the [operator](../../language-reference/keywords/operator.md) keyword article.

## See also

- [C# Programming Guide](../index.md)
- [Statements, Expressions, and Operators](index.md)
- [Operators](operators.md)
- [C# Operators](../../language-reference/operators/index.md)
- [Why are overloaded operators always static in C#?](https://blogs.msdn.microsoft.com/ericlippert/2007/05/14/why-are-overloaded-operators-always-static-in-c/)

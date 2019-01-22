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
|[+](../../language-reference/operators/addition-operator.md), [-](../../language-reference/operators/subtraction-operator.md), [!](../../language-reference/operators/logical-negation-operator.md), [~](../../language-reference/operators/bitwise-complement-operator.md), [++](../../language-reference/operators/increment-operator.md), [--](../../language-reference/operators/decrement-operator.md), [true](../../language-reference/keywords/true.md), [false](../../language-reference/keywords/false.md)|These unary operators can be overloaded.|
|[+](../../language-reference/operators/addition-operator.md), [-](../../language-reference/operators/subtraction-operator.md), [\*](../../language-reference/operators/multiplication-operator.md), [/](../../language-reference/operators/division-operator.md), [%](../../language-reference/operators/modulus-operator.md), [&](../../language-reference/operators/and-operator.md), [&#124;](../../language-reference/operators/or-operator.md), [^](../../language-reference/operators/xor-operator.md), [\<\<](../../language-reference/operators/left-shift-operator.md), [>>](../../language-reference/operators/right-shift-operator.md)|These binary operators can be overloaded.|
|[==](../../language-reference/operators/equality-comparison-operator.md), [!=](../../language-reference/operators/not-equal-operator.md), [\<](../../language-reference/operators/less-than-operator.md), [>](../../language-reference/operators/greater-than-operator.md), [\<=](../../language-reference/operators/less-than-equal-operator.md), [>=](../../language-reference/operators/greater-than-equal-operator.md)|The comparison operators can be overloaded (but see the note that follows this table).|
|[&&](../../language-reference/operators/conditional-and-operator.md), [&#124;&#124;](../../language-reference/operators/conditional-or-operator.md)|The conditional logical operators cannot be overloaded, but they are evaluated using `&` and <code>&#124;</code>, which can be overloaded.|
|[&#91;&#93;](../../language-reference/operators/index-operator.md)|The array indexing operator cannot be overloaded, but you can define [indexers](../indexers/index.md).|
|[(T)x](../../language-reference/operators/invocation-operator.md)|The cast operator cannot be overloaded, but you can define new conversion operators (see [explicit](../../language-reference/keywords/explicit.md) and [implicit](../../language-reference/keywords/implicit.md)).|
|[+=](../../language-reference/operators/addition-assignment-operator.md), [-=](../../language-reference/operators/subtraction-assignment-operator.md), [\*=](../../language-reference/operators/multiplication-assignment-operator.md), [/=](../../language-reference/operators/division-assignment-operator.md), [%=](../../language-reference/operators/modulus-assignment-operator.md), [&=](../../language-reference/operators/and-assignment-operator.md), [&#124;=](../../language-reference/operators/or-assignment-operator.md), [^=](../../language-reference/operators/xor-assignment-operator.md), [\<\<=](../../language-reference/operators/left-shift-assignment-operator.md), [>>=](../../language-reference/operators/right-shift-assignment-operator.md)|Assignment operators cannot be explicitly overloaded. However, when you overload a binary operator, the corresponding assignment operator, if any, is also implicitly overloaded. For example, `+=` is evaluated using `+`, which can be overloaded.|
|[=](../../language-reference/operators/assignment-operator.md), [.](../../language-reference/operators/member-access-operator.md), [?:](../../language-reference/operators/conditional-operator.md), [??](../../language-reference/operators/null-coalescing-operator.md), [->](../../language-reference/operators/dereference-operator.md), [=>](../../language-reference/operators/lambda-operator.md), [f(x)](../../language-reference/operators/invocation-operator.md), [as](../../language-reference/keywords/as.md), [checked](../../language-reference/keywords/checked.md), [unchecked](../../language-reference/keywords/unchecked.md), [default](../../programming-guide/statements-expressions-operators/default-value-expressions.md), [delegate](../../programming-guide/statements-expressions-operators/anonymous-methods.md), [is](../../language-reference/keywords/is.md), [new](../../language-reference/keywords/new.md), [sizeof](../../language-reference/keywords/sizeof.md), [typeof](../../language-reference/keywords/typeof.md)|These operators cannot be overloaded.|

> [!NOTE]
> The comparison operators, if overloaded, must be overloaded in pairs; that is, if `==` is overloaded, `!=` must also be overloaded. The reverse is also true, where overloading `!=` requires an overload for `==`. The same is true for comparison operators `<` and `>` and for `<=` and `>=`.

For information about how to overload an operator, see the [operator](../../language-reference/keywords/operator.md) keyword article.

## See also

- [C# Programming Guide](../index.md)
- [Statements, Expressions, and Operators](index.md)
- [Operators](operators.md)
- [C# Operators](../../language-reference/operators/index.md)  
- [Why are overloaded operators always static in C#?](https://blogs.msdn.microsoft.com/ericlippert/2007/05/14/why-are-overloaded-operators-always-static-in-c/)

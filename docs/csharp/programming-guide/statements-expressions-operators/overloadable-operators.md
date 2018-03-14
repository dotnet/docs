---
title: "Overloadable Operators (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, operator overloading"
  - "operator overloading [C#]"
ms.assetid: 390d9d01-79fc-40ab-9ed3-0bf448da1b6a
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# Overloadable Operators (C# Programming Guide)

C# allows user-defined types to overload operators by defining static member functions using the [operator](../../../csharp/language-reference/keywords/operator.md) keyword. Not all operators can be overloaded, however, and others have restrictions, as listed in this table:

| Operators | Overloadability |
| --------- | --------------- |
|[+](../../../csharp/language-reference/operators/addition-operator.md), [-](../../../csharp/language-reference/operators/subtraction-operator.md), [!](../../../csharp/language-reference/operators/logical-negation-operator.md), [~](../../../csharp/language-reference/operators/bitwise-complement-operator.md), [++](../../../csharp/language-reference/operators/increment-operator.md), [--](../../../csharp/language-reference/operators/decrement-operator.md), [true](../../../csharp/language-reference/keywords/true.md), [false](../../../csharp/language-reference/keywords/false.md)|These unary operators can be overloaded.|
|[+](../../../csharp/language-reference/operators/addition-operator.md), [-](../../../csharp/language-reference/operators/subtraction-operator.md), [\*](../../../csharp/language-reference/operators/multiplication-operator.md), [/](../../../csharp/language-reference/operators/division-operator.md), [%](../../../csharp/language-reference/operators/modulus-operator.md), [&](../../../csharp/language-reference/operators/and-operator.md), [&#124;](../../../csharp/language-reference/operators/or-operator.md), [^](../../../csharp/language-reference/operators/xor-operator.md), [\<\<](../../../csharp/language-reference/operators/left-shift-operator.md), [>>](../../../csharp/language-reference/operators/right-shift-operator.md)|These binary operators can be overloaded.|
|[==](../../../csharp/language-reference/operators/equality-comparison-operator.md), [!=](../../../csharp/language-reference/operators/not-equal-operator.md), [\<](../../../csharp/language-reference/operators/less-than-operator.md), [>](../../../csharp/language-reference/operators/greater-than-operator.md), [\<=](../../../csharp/language-reference/operators/less-than-equal-operator.md), [>=](../../../csharp/language-reference/operators/greater-than-equal-operator.md)|The comparison operators can be overloaded (but see the note that follows this table).|
|[&&](../../../csharp/language-reference/operators/conditional-and-operator.md), [&#124;&#124;](../../../csharp/language-reference/operators/conditional-or-operator.md)|The conditional logical operators cannot be overloaded, but they are evaluated using `&` and <code>&#124;</code>, which can be overloaded.|
|[&#91;&#93;](../../../csharp/language-reference/operators/index-operator.md)|The array indexing operator cannot be overloaded, but you can define indexers.|
|[(T)x](../../../csharp/language-reference/operators/invocation-operator.md)|The cast operator cannot be overloaded, but you can define new conversion operators (see [explicit](../../../csharp/language-reference/keywords/explicit.md) and [implicit](../../../csharp/language-reference/keywords/implicit.md)).|
|[+=](../../../csharp/language-reference/operators/addition-assignment-operator.md), [-=](../../../csharp/language-reference/operators/subtraction-assignment-operator.md), [\*=](../../../csharp/language-reference/operators/multiplication-assignment-operator.md), [/=](../../../csharp/language-reference/operators/division-assignment-operator.md), [%=](../../../csharp/language-reference/operators/modulus-assignment-operator.md), [&=](../../../csharp/language-reference/operators/and-assignment-operator.md), [&#124;=](../../../csharp/language-reference/operators/or-assignment-operator.md), [^=](../../../csharp/language-reference/operators/xor-assignment-operator.md), [\<\<=](../../../csharp/language-reference/operators/left-shift-assignment-operator.md), [>>=](../../../csharp/language-reference/operators/right-shift-assignment-operator.md)|Assignment operators cannot be overloaded, but `+=`, for example, is evaluated using `+`, which can be overloaded.|
|[=](../../../csharp/language-reference/operators/assignment-operator.md), [.](../../../csharp/language-reference/operators/member-access-operator.md), [?:](../../../csharp/language-reference/operators/conditional-operator.md), [??](../../../csharp/language-reference/operators/null-conditional-operator.md), [->](../../../csharp/language-reference/operators/dereference-operator.md), [=>](../../../csharp/language-reference/operators/lambda-operator.md), [f(x)](../../../csharp/language-reference/operators/invocation-operator.md), [as](../../../csharp/language-reference/keywords/as.md), [checked](../../../csharp/language-reference/keywords/checked.md), [unchecked](../../../csharp/language-reference/keywords/unchecked.md), [default](../../../csharp/programming-guide/statements-expressions-operators/default-value-expressions.md), [delegate](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md), [is](../../../csharp/language-reference/keywords/is.md), [new](../../../csharp/language-reference/keywords/new.md), [sizeof](../../../csharp/language-reference/keywords/sizeof.md), [typeof](../../../csharp/language-reference/keywords/typeof.md)|These operators cannot be overloaded.|

> [!NOTE]
> The comparison operators, if overloaded, must be overloaded in pairs; that is, if `==` is overloaded, `!=` must also be overloaded. The reverse is also true, where overloading `!=` requires an overload for `==`. The same is true for comparison operators `<` and `>` and for `<=` and `>=`.

To overload an operator on a custom class requires creating a method on the class with the correct signature. The method must be named "operator X" where X is the name or symbol of the operator being overloaded. Unary operators have one parameter, and binary operators have two parameters. In each case, one parameter must be the same type as the class or struct that declares the operator.

```csharp
public static Complex operator +(Complex c1, Complex c2)
{
    return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
}
```

It is common to have definitions that simply return immediately with the result of an expression.  There is a syntax shortcut using `=>` for these situations.

```csharp
public static Complex operator +(Complex c1, Complex c2) =>
        new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
  
// Override ToString() to display a complex number in the traditional format:
public override string ToString() => $"{this.real} + {this.imaginary}";
```

For more information, see [How to: Use Operator Overloading to Create a Complex Number Class](../../../csharp/programming-guide/statements-expressions-operators/how-to-use-operator-overloading-to-create-a-complex-number-class.md).

## See also

[C# Programming Guide](../../../csharp/programming-guide/index.md)  
[Statements, Expressions, and Operators](../../../csharp/programming-guide/statements-expressions-operators/index.md)  
[Operators](../../../csharp/programming-guide/statements-expressions-operators/operators.md)  
[C# Operators](../../../csharp/language-reference/operators/index.md)  
[Why are overloaded operators always static in C#?](https://blogs.msdn.microsoft.com/ericlippert/2007/05/14/why-are-overloaded-operators-always-static-in-c/)

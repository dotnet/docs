---
title: "Delegates - C# Programming Guide"
description: A delegate in C# is a type that refers to methods with a parameter list and return type. Delegates are used to pass methods as arguments to other methods.
ms.date: 02/02/2021
helpviewer_keywords: 
  - "C# language, delegates"
  - "delegates [C#]"
ms.assetid: 97de039b-c76b-4b9c-a27d-8c1e1c8d93da
---
# Delegates (C# Programming Guide)

A [delegate](../../language-reference/builtin-types/reference-types.md) is a type that represents references to methods with a particular parameter list and return type. When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type. You can invoke (or call) the method through the delegate instance.

Delegates are used to pass methods as arguments to other methods. Event handlers are nothing more than methods that are invoked through delegates. You create a custom method, and a class such as a windows control can call your method when a certain event occurs. The following example shows a delegate declaration:

[!code-csharp[csProgGuideDelegates#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#20)]

Any method from any accessible class or struct that matches the delegate type can be assigned to the delegate. The method can be either static or an instance method. This flexibility means you can programmatically change method calls, or plug new code into existing classes.

> [!NOTE]
> In the context of method overloading, the signature of a method does not include the return value. But in the context of delegates, the signature does include the return value. In other words, a method must have the same return type as the delegate.

This ability to refer to a method as a parameter makes delegates ideal for defining callback methods. You can write a method that compares two objects in your application. That method can be used in a delegate for a sort algorithm. Because the comparison code is separate from the library, the sort method can be more general.

[Function pointers](~/_csharplang/proposals/csharp-9.0/function-pointers.md) were added to C# 9 for similar scenarios, where you need more control over the calling convention. The code associated with a delegate is invoked using a virtual method added to a delegate type. Using function pointers, you can specify different conventions.

## Delegates Overview

Delegates have the following properties:

- Delegates are similar to C++ function pointers, but delegates are fully object-oriented, and unlike C++ pointers to member functions, delegates encapsulate both an object instance and a method.
- Delegates allow methods to be passed as parameters.
- Delegates can be used to define callback methods.
- Delegates can be chained together; for example, multiple methods can be called on a single event.
- Methods don't have to match the delegate type exactly. For more information, see [Using Variance in Delegates](../concepts/covariance-contravariance/using-variance-in-delegates.md).
- Lambda expressions are a more concise way of writing inline code blocks. Lambda expressions (in certain contexts) are compiled to delegate types. For more information about lambda expressions, see [Lambda expressions](../../language-reference/operators/lambda-expressions.md).

## In This Section

- [Using Delegates](./using-delegates.md)
- [When to Use Delegates Instead of Interfaces (C# Programming Guide)](/previous-versions/visualstudio/visual-studio-2010/ms173173(v=vs.100))
- [Delegates with Named vs. Anonymous Methods](./delegates-with-named-vs-anonymous-methods.md)
- [Using Variance in Delegates](../concepts/covariance-contravariance/using-variance-in-delegates.md)
- [How to combine delegates (Multicast Delegates)](./how-to-combine-delegates-multicast-delegates.md)
- [How to declare, instantiate, and use a delegate](./how-to-declare-instantiate-and-use-a-delegate.md)

## C# Language Specification

For more information, see [Delegates](~/_csharplang/spec/delegates.md) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

## Featured Book Chapters

- [Delegates, Events, and Lambda Expressions](/previous-versions/visualstudio/visual-studio-2008/ff518994(v=orm.10)) in [C# 3.0 Cookbook, Third Edition: More than 250 solutions for C# 3.0 programmers](/previous-versions/visualstudio/visual-studio-2008/ff518995(v=orm.10))
- [Delegates and Events](/previous-versions/visualstudio/visual-studio-2008/ff652490(v=orm.10)) in [Learning C# 3.0: Fundamentals of C# 3.0](/previous-versions/visualstudio/visual-studio-2008/ff652493(v=orm.10))

## See also

- <xref:System.Delegate>
- [C# Programming Guide](../index.md)
- [Events](../events/index.md)

---
title: "Abstract and Sealed Classes and Class Members"
description: Learn how to use the abstract and sealed modifiers in C# to create incomplete base classes or prevent class and member inheritance.
ms.date: 11/01/2026
helpviewer_keywords: 
  - "abstract classes [C#]"
  - "sealed classes [C#]"
  - "C# language, abstract classes"
  - "C# language, sealed"
ms.assetid: 99aa52f7-b435-43f9-936e-2470af734c4e
---
# Abstract and Sealed Classes and Class Members (C# Programming Guide)

In object-oriented programming, classes can participate in an inheritance hierarchy where a *base class* supplies common characteristics and *derived classes* customize or extend that behavior. C# provides two modifiers to control this inheritance:

- The [`abstract`](../../language-reference/keywords/abstract.md) keyword allows you to define incomplete classes and members that derived classes must implement.
- The [`sealed`](../../language-reference/keywords/sealed.md) keyword prevents other classes from inheriting from a class, or prevents derived classes from overriding specific virtual members.

## Abstract classes and class members

You declare an abstract class by adding the `abstract` keyword before the class definition:

[!code-csharp[csProgGuideInheritance#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#13)]

You cannot *instantiate* an abstract class&mdash;that is, you cannot create an object directly from it using the `new` operator. Attempting to write `new A()` generates compiler error CS0144.

Instead, the purpose of an abstract class is to serve as a shared base class for multiple derived classes. For example, a class library might define an abstract `Shape` class with shared properties like `Color`, and require applications to create concrete derived classes such as `Circle` or `Rectangle` that supply shape-specific logic.

### Abstract methods

Abstract classes can also define abstract methods, properties, indexers, or events. To declare an abstract method, place the `abstract` modifier before the method's return type:

[!code-csharp[csProgGuideInheritance#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#14)]

Abstract methods have no implementation body; the declaration ends with a semicolon (`;`) instead of a method block (`{ }`). Any concrete (non-abstract) class derived from the abstract class must provide an implementation for all inherited abstract methods using the [`override`](../../language-reference/keywords/override.md) keyword.

When an abstract class inherits a virtual method from a base class, it can override the virtual method and declare it `abstract`:

[!code-csharp[csProgGuideInheritance#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#15)]

When a `virtual` method is redeclared as `abstract`, it remains virtual to classes that inherit from the abstract class. A class inheriting that abstract method cannot call the original base implementation. In the preceding example, `DoWork` on class `F` cannot call `DoWork` on class `D`. In this way, an abstract class can force subsequent derived classes to provide new method implementations for virtual methods.

## Sealed classes and class members

You declare a class as [`sealed`](../../language-reference/keywords/sealed.md) by putting the `sealed` keyword before the class definition:

[!code-csharp[csProgGuideInheritance#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#16)]

A sealed class cannot be used as a base class; other classes cannot derive (inherit) from it. Because an abstract class requires derived classes while a sealed class forbids them, a class cannot be declared as both `abstract` and `sealed`. Sealed classes prevent unintended extension and allow the runtime to perform devirtualization optimizations that can make calling class members slightly faster.

### Sealed members

You can also seal an individual member on a derived class that is overriding a virtual member of a base class. Sealing an overridden member stops the virtual behavior for any further derived classes. To seal a member, place the `sealed` keyword before the `override` keyword in the member declaration:

[!code-csharp[csProgGuideInheritance#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#17)]

In the preceding example, class `Z` inherits from class `Y`, but `Z` cannot override the virtual method `DoWork` because class `Y` declared it `sealed`.

## See also

- [The C# type system](../../fundamentals/types/index.md)
- [Inheritance](../../fundamentals/object-oriented/inheritance.md)
- [Methods](./methods.md)
- [Fields](./fields.md)
- [How to define abstract properties](./how-to-define-abstract-properties.md)

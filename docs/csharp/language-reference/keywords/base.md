---
title: "The base keyword"
description: Learn about the base keyword, which is used to access members of the base class from within a derived class in C#.
ms.date: 04/17/2025
f1_keywords: 
  - "base"
  - "BaseClass.BaseClass"
  - "base_CSharpKeyword"
helpviewer_keywords: 
  - "base keyword [C#]"
---
# The base keyword

The `base` keyword is used to access members of the base class from within a derived class. Use it if you want to:

- Call a method on the base class overridden by another method.
- Specify which base-class constructor should be called when creating instances of the derived class.

The base class access is permitted only in a constructor, in an instance method, and in an instance property accessor. Using the `base` keyword from within a static method produces an error.

The base class that is accessed is the base class specified in the class declaration. For example, if you specify `class ClassB : ClassA`, the members of ClassA are accessed from ClassB, regardless of the base class of ClassA.

In this example, both the base class `Person` and the derived class `Employee` have a method named `GetInfo`. By using the `base` keyword, it's possible to call the `GetInfo` method of the base class from within the derived class.

:::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet1":::

This example shows how to specify the base-class constructor called when creating instances of a derived class.

:::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet2":::

For more examples, see [new](new-modifier.md), [virtual](virtual.md), and [override](override.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](./index.md)
- [The `this` keyword](./this.md)

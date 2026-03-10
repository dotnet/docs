---
title: "The base keyword"
description: Learn about the base keyword, which is used to access members of the base class from within a derived class in C#.
ms.date: 01/21/2026
f1_keywords: 
  - "base"
  - "BaseClass.BaseClass"
  - "base_CSharpKeyword"
helpviewer_keywords: 
  - "base keyword [C#]"
---
# The base keyword

Use the `base` keyword to access members of the base class from within a derived class. Use it if you want to:

- Call a method on the base class that's overridden by another method.
- Specify which base-class constructor to call when creating instances of the derived class.

You can access the base class only in a constructor, in an instance method, and in an instance property accessor. Using the `base` keyword from within a static method produces an error.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The base class you access is the base class you specify in the class declaration. For example, if you specify `class ClassB : ClassA`, you access the members of ClassA from ClassB, regardless of the base class of ClassA.

In this example, both the base class `Person` and the derived class `Employee` have a method named `GetInfo`. By using the `base` keyword, you can call the `GetInfo` method of the base class from within the derived class.

:::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet1":::

This example shows how to specify the base-class constructor to call when creating instances of a derived class.

:::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet2":::

For more examples, see [new](new-modifier.md), [virtual](virtual.md), and [override](override.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](./index.md)
- [The `this` keyword](./this.md)

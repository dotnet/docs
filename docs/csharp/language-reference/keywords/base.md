---
title: "base keyword - C# Reference"
description: Learn about the base keyword, which is used to access members of the base class from within a derived class in C#.
ms.date: 07/20/2015
f1_keywords: 
  - "base"
  - "BaseClass.BaseClass"
  - "base_CSharpKeyword"
helpviewer_keywords: 
  - "base keyword [C#]"
ms.assetid: 8b645dbe-1a33-49b8-8716-1c401f9a5ea5
---
# base (C# Reference)

The `base` keyword is used to access members of the base class from within a derived class:

- Call a method on the base class that has been overridden by another method.

- Specify which base-class constructor should be called when creating instances of the derived class.

A base class access is permitted only in a constructor, an instance method, or an instance property accessor.

It is an error to use the `base` keyword from within a static method.

The base class that is accessed is the base class specified in the class declaration. For example, if you specify `class ClassB : ClassA`, the members of ClassA are accessed from ClassB, regardless of the base class of ClassA.

## Example 1

In this example, both the base class, `Person`, and the derived class, `Employee`, have a method named `Getinfo`. By using the `base` keyword, it is possible to call the `Getinfo` method on the base class, from within the derived class.

[!code-csharp[csrefKeywordsAccess#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#1)]

For additional examples, see [new](new-modifier.md), [virtual](virtual.md), and [override](override.md).

## Example 2

This example shows how to specify the base-class constructor called when creating instances of a derived class.

[!code-csharp[csrefKeywordsAccess#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#2)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [this](./this.md)

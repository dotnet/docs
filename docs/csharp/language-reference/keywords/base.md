---
title: "base (C# Reference)"
description: Learn about the base keyword, which is used to access members of the base class from within a derived class in C#.
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "base"
  - "BaseClass.BaseClass"
  - "base_CSharpKeyword"
helpviewer_keywords: 
  - "base keyword [C#]"
ms.assetid: 8b645dbe-1a33-49b8-8716-1c401f9a5ea5
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# base (C# Reference)

The `base` keyword is used to access members of the base class from within a derived class:

- Call a method on the base class that has been overridden by another method.

- Specify which base-class constructor should be called when creating instances of the derived class.

A base class access is permitted only in a constructor, an instance method, or an instance property accessor.

It is an error to use the `base` keyword from within a static method.

The base class that is accessed is the base class specified in the class declaration. For example, if you specify `class ClassB : ClassA`, the members of ClassA are accessed from ClassB, regardless of the base class of ClassA.

## Example
In this example, both the base class, `Person`, and the derived class, `Employee`, have a method named `Getinfo`. By using the `base` keyword, it is possible to call the `Getinfo` method on the base class, from within the derived class.

[!code-csharp[csrefKeywordsAccess#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/base_1.cs)]

For additional examples, see [new](../../../csharp/language-reference/keywords/new.md), [virtual](../../../csharp/language-reference/keywords/virtual.md), and [override](../../../csharp/language-reference/keywords/override.md).

## Example
This example shows how to specify the base-class constructor called when creating instances of a derived class.

[!code-csharp[csrefKeywordsAccess#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/base_2.cs)]

## C# language specification
[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [this](../../../csharp/language-reference/keywords/this.md)
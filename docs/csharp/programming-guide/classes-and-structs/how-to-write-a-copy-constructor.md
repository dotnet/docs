---
title: "How to write a copy constructor - C# Programming Guide"
description: Learn how to write a copy constructor in C# that takes an instance of class and returns a new instance with the values of the input.
ms.date: 05/24/2023
helpviewer_keywords: 
  - "C# Language, copy constructor"
  - "copy constructor [C#]"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: fba899b5-fc41-428e-a745-3ebdbf37990a
---
# How to write a copy constructor (C# Programming Guide)

C# [records](../../fundamentals/types/records.md) provide a copy constructor for objects, but for classes you have to write one yourself.

> [!IMPORTANT]
> Writing copy constructors that work for all derived types in a class hierarchy can be difficult. If your `class` isn't `sealed`, you should strongly consider creating a hierarchy of `record class` types to use the compiler synthesized copy constructor.

## Example

In the following example, the `Person`[class](../../language-reference/keywords/class.md) defines a copy constructor that takes, as its argument, an instance of `Person`. The values of the properties of the argument are assigned to the properties of the new instance of `Person`. The code contains an alternative copy constructor that sends the `Name` and `Age` properties of the instance that you want to copy to the instance constructor of the class. The `Person` class is `sealed`, so no derived types can be declared that could introduce errors by copying only the base class.

:::code source="snippets/how-to-write-a-copy-constructor/Program.cs" :::

## See also

- <xref:System.ICloneable>
- [Records](../../fundamentals/types/records.md)
- [C# Programming Guide](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Constructors](./constructors.md)
- [Finalizers](./finalizers.md)

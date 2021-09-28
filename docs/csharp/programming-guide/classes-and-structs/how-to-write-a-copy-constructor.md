---
title: "How to write a copy constructor - C# Programming Guide"
description: Learn how to write a copy constructor in C# that takes an instance of class and returns a new instance with the values of the input.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "C# Language, copy constructor"
  - "copy constructor [C#]"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: fba899b5-fc41-428e-a745-3ebdbf37990a
---
# How to write a copy constructor (C# Programming Guide)

C# [records](../../fundamentals/types/records.md) provide a copy constructor for objects, but for classes you have to write one yourself.  
  
## Example  

 In the following example, the `Person`[class](../../language-reference/keywords/class.md) defines a copy constructor that takes, as its argument, an instance of `Person`. The values of the properties of the argument are assigned to the properties of the new instance of `Person`. The code contains an alternative copy constructor that sends the `Name` and `Age` properties of the instance that you want to copy to the instance constructor of the class.  
  
 [!code-csharp[CopyConstructor](snippets/how-to-write-a-copy-constructor/Program.cs)]

## See also

- <xref:System.ICloneable>
- [Records](../../fundamentals/types/records.md)
- [C# Programming Guide](../index.md)
- [Classes, structs, and records](/dotnet/csharp/fundamentals/object-oriented)
- [Constructors](./constructors.md)
- [Finalizers](./finalizers.md)

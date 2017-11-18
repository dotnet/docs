---
title: "How to: Write a Copy Constructor (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# Language, copy constructor"
  - "copy constructor [C#]"
ms.assetid: fba899b5-fc41-428e-a745-3ebdbf37990a
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Write a Copy Constructor (C# Programming Guide)
C# doesn't provide a copy constructor for objects, but you can write one yourself.  
  
## Example  
 In the following example, the `Person`[class](../../../csharp/language-reference/keywords/class.md) defines a copy constructor that takes, as its argument, an instance of `Person`. The values of the properties of the argument are assigned to the properties of the new instance of `Person`. The code contains an alternative copy constructor that sends the `Name` and `Age` properties of the instance that you want to copy to the instance constructor of the class.  
  
 [!code-csharp[csProgGuideObjects#16](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-write-a-copy-constructor_1.cs)]  
  
## See Also  
 <xref:System.ICloneable>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)  
 [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)

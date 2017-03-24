---
title: "Constructors (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "constructors [C#]"
  - "classes [C#], constructors"
  - "C# language, constructors"
ms.assetid: df2e2e9d-7998-418b-8e7d-890c17ff6c95
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Constructors (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Whenever a [class](../../../csharp/language-reference/keywords/class.md) or [struct](../../../csharp/language-reference/keywords/struct.md) is created, its constructor is called. A class or struct may have multiple constructors that take different arguments. Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read. For more information and examples, see [Using Constructors](../../../csharp/programming-guide/classes-and-structs/using-constructors.md) and [Instance Constructors](../../../csharp/programming-guide/classes-and-structs/instance-constructors.md).  
  
 If you do not provide a constructor for your object, C# will create one by default that instantiates the object and sets member variables to the default values as listed in [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md). For more information and examples, see [Instance Constructors](../../../csharp/programming-guide/classes-and-structs/instance-constructors.md).  
  
 Static classes and structs can also have constructors. For more information and examples, see [Static Constructors](../../../csharp/programming-guide/classes-and-structs/static-constructors.md).  
  
## In This Section  
 [Using Constructors](../../../csharp/programming-guide/classes-and-structs/using-constructors.md)  
  
 [Instance Constructors](../../../csharp/programming-guide/classes-and-structs/instance-constructors.md)  
  
 [Private Constructors](../../../csharp/programming-guide/classes-and-structs/private-constructors.md)  
  
 [Static Constructors](../../../csharp/programming-guide/classes-and-structs/static-constructors.md)  
  
 [How to: Write a Copy Constructor](../../../csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor.md)  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)   
 [Destructors](../../../csharp/programming-guide/classes-and-structs/destructors.md)   
 [static](../../../csharp/language-reference/keywords/static.md)   
 [Why Do Initializers Run In The Opposite Order As Constructors? Part One](http://go.microsoft.com/fwlink/?LinkId=112374)
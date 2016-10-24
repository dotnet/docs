---
title: "How to: Write a Copy Constructor (C# Programming Guide)"
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
  - "C# Language, copy constructor"
  - "copy constructor [C#]"
ms.assetid: fba899b5-fc41-428e-a745-3ebdbf37990a
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Write a Copy Constructor (C# Programming Guide)
C# doesn't provide a copy constructor for objects, but you can write one yourself.  
  
## Example  
 In the following example, the `Person`[class](../keywords/class--csharp-reference-.md) defines a copy constructor that takes, as its argument, an instance of `Person`. The values of the properties of the argument are assigned to the properties of the new instance of `Person`. The code contains an alternative copy constructor that sends the `Name` and `Age` properties of the instance that you want to copy to the instance constructor of the class.  
  
 [!code[csProgGuideObjects#16](../classes-and-structs/codesnippet/CSharp/how-to--write-a-copy-constructor--csharp-programming-guide-_1.cs)]  
  
## See Also  
 <xref:System.ICloneable>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)   
 [Destructors](../classes-and-structs/destructors--csharp-programming-guide-.md)
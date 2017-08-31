---
title: "How to: Write a Copy Constructor (C# Programming Guide) | Microsoft Docs"
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
---
# How to: Write a Copy Constructor (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

C# doesn't provide a copy constructor for objects, but you can write one yourself.  
  
## Example  
 In the following example, the `Person`[class](../../../csharp/language-reference/keywords/class.md) defines a copy constructor that takes, as its argument, an instance of `Person`. The values of the properties of the argument are assigned to the properties of the new instance of `Person`. The code contains an alternative copy constructor that sends the `Name` and `Age` properties of the instance that you want to copy to the instance constructor of the class.  
  
 [!code-csharp[csProgGuideObjects#16](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#16)]  
  
## See Also  
 <xref:System.ICloneable>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)   
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)   
 [Destructors](../../../csharp/programming-guide/classes-and-structs/destructors.md)
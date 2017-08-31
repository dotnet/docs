---
title: "Generic Delegates (C# Programming Guide) | Microsoft Docs"
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
  - "generics [C#], delegates"
  - "delegates [C#], generic"
ms.assetid: bdea509c-44c1-4309-aaa9-15c7aee009df
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Generic Delegates (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A [delegate](../../../csharp/language-reference/keywords/delegate.md) can define its own type parameters. Code that references the generic delegate can specify the type argument to create a closed constructed type, just like when instantiating a generic class or calling a generic method, as shown in the following example:  
  
 [!code-csharp[csProgGuideGenerics#36](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#36)]  
  
 C# version 2.0 has a new feature called method group conversion, which applies to concrete as well as generic delegate types, and enables you to write the previous line with this simplified syntax:  
  
 [!code-csharp[csProgGuideGenerics#37](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#37)]  
  
 Delegates defined within a generic class can use the generic class type parameters in the same way that class methods do.  
  
 [!code-csharp[csProgGuideGenerics#38](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#38)]  
  
 Code that references the delegate must specify the type argument of the containing class, as follows:  
  
 [!code-csharp[csProgGuideGenerics#39](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#39)]  
  
 Generic delegates are especially useful in defining events based on the typical design pattern because the sender argument can be strongly typed and no longer has to be cast to and from <xref:System.Object>.  
  
 [!code-csharp[csProgGuideGenerics#40](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#40)]  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)   
 [Generic Methods](../../../csharp/programming-guide/generics/generic-methods.md)   
 [Generic Classes](../../../csharp/programming-guide/generics/generic-classes.md)   
 [Generic Interfaces](../../../csharp/programming-guide/generics/generic-interfaces.md)   
 [Delegates](../../../csharp/programming-guide/delegates/index.md)   
 [Generics](../Topic/Generics%20in%20the%20.NET%20Framework.md)
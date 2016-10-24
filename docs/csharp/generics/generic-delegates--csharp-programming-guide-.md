---
title: "Generic Delegates (C# Programming Guide)"
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
# Generic Delegates (C# Programming Guide)
A [delegate](../keywords/delegate--csharp-reference-.md) can define its own type parameters. Code that references the generic delegate can specify the type argument to create a closed constructed type, just like when instantiating a generic class or calling a generic method, as shown in the following example:  
  
 [!code[csProgGuideGenerics#36](../generics/codesnippet/CSharp/generic-delegates--csharp-programming-guide-_1.cs)]  
  
 C# version 2.0 has a new feature called method group conversion, which applies to concrete as well as generic delegate types, and enables you to write the previous line with this simplified syntax:  
  
 [!code[csProgGuideGenerics#37](../generics/codesnippet/CSharp/generic-delegates--csharp-programming-guide-_2.cs)]  
  
 Delegates defined within a generic class can use the generic class type parameters in the same way that class methods do.  
  
 [!code[csProgGuideGenerics#38](../generics/codesnippet/CSharp/generic-delegates--csharp-programming-guide-_3.cs)]  
  
 Code that references the delegate must specify the type argument of the containing class, as follows:  
  
 [!code[csProgGuideGenerics#39](../generics/codesnippet/CSharp/generic-delegates--csharp-programming-guide-_4.cs)]  
  
 Generic delegates are especially useful in defining events based on the typical design pattern because the sender argument can be strongly typed and no longer has to be cast to and from <xref:System.Object>.  
  
 [!code[csProgGuideGenerics#40](../generics/codesnippet/CSharp/generic-delegates--csharp-programming-guide-_5.cs)]  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Introduction to Generics](../generics/introduction-to-generics--csharp-programming-guide-.md)   
 [Generic Methods](../generics/generic-methods--csharp-programming-guide-.md)   
 [Generic Classes](../generics/generic-classes--csharp-programming-guide-.md)   
 [Generic Interfaces](../generics/generic-interfaces--csharp-programming-guide-.md)   
 [Delegates](../delegates/delegates--csharp-programming-guide-.md)   
 [Generics](../Topic/Generics%20in%20the%20.NET%20Framework.md)
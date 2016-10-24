---
title: "How to: Explicitly Implement Interface Members (C# Programming Guide)"
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
  - "interfaces [C#], explicitly implementing"
ms.assetid: 514cde76-f981-474e-8b40-9493619f899c
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
# How to: Explicitly Implement Interface Members (C# Programming Guide)
This example declares an [interface](../keywords/interface--csharp-reference-.md), `IDimensions`, and a class, `Box`, which explicitly implements the interface members `getLength` and `getWidth`. The members are accessed through the interface instance `dimensions`.  
  
## Example  
 [!code[csProgGuideInheritance#8](../classes-and-structs/codesnippet/CSharp/how-to--explicitly-implement-interface-members--csharp-programming-guide-_1.cs)]  
  
## Robust Programming  
  
-   Notice that the following lines, in the `Main` method, are commented out because they would produce compilation errors. An interface member that is explicitly implemented cannot be accessed from a [class](../keywords/class--csharp-reference-.md) instance:  
  
     [!code[csProgGuideInheritance#45](../classes-and-structs/codesnippet/CSharp/how-to--explicitly-implement-interface-members--csharp-programming-guide-_2.cs)]  
  
-   Notice also that the following lines, in the `Main` method, successfully print out the dimensions of the box because the methods are being called from an instance of the interface:  
  
     [!code[csProgGuideInheritance#46](../classes-and-structs/codesnippet/CSharp/how-to--explicitly-implement-interface-members--csharp-programming-guide-_3.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)   
 [How to: Explicitly Implement Members of Two Interfaces](../interfaces/8b402ddc-dff9-4869-89cb-d718c764e68e.md)
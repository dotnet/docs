---
title: "How to: Combine Delegates (Multicast Delegates)(C# Programming Guide) | Microsoft Docs"
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
  - "delegates [C#], combining"
  - "multicast delegates [C#]"
ms.assetid: 4e689450-6d0c-46de-acfd-f961018ae5dd
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Combine Delegates (Multicast Delegates)(C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This example demonstrates how to create multicast delegates. A useful property of [delegate](../../../csharp/language-reference/keywords/delegate.md) objects is that multiple objects can be assigned to one delegate instance by using the `+` operator. The multicast delegate contains a list of the assigned delegates. When the multicast delegate is called, it invokes the delegates in the list, in order. Only delegates of the same type can be combined.  
  
 The `-` operator can be used to remove a component delegate from a multicast delegate.  
  
## Example  
 [!code-csharp[csProgGuideDelegates#11](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#11)]  
  
## See Also  
 <xref:System.MulticastDelegate>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Events](../../../csharp/programming-guide/events/index.md)
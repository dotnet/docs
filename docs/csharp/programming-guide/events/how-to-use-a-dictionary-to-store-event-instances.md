---
title: "How to: Use a Dictionary to Store Event Instances (C# Programming Guide) | Microsoft Docs"
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
  - "events [C#], storing instances in a Dictionary"
ms.assetid: 9512c64d-5aaf-40cd-b941-ca2a592f0064
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Use a Dictionary to Store Event Instances (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

One use for `accessor-declarations` is to expose many events without allocating a field for each event, but instead using a Dictionary to store the event instances. This is only useful if you have many events, but you expect most of the events will not be implemented.  
  
## Example  
 [!code-csharp[csProgGuideEvents#9](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEvents/CS/Events.cs#9)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Events](../../../csharp/programming-guide/events/index.md)   
 [Delegates](../../../csharp/programming-guide/delegates/index.md)
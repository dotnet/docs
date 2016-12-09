---
title: "How to: Use a Dictionary to Store Event Instances (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "events [C#], storing instances in a Dictionary"
ms.assetid: 9512c64d-5aaf-40cd-b941-ca2a592f0064
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"

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
# How to: Use a Dictionary to Store Event Instances (C# Programming Guide)
One use for `accessor-declarations` is to expose many events without allocating a field for each event, but instead using a Dictionary to store the event instances. This is only useful if you have many events, but you expect most of the events will not be implemented.  
  
## Example  
 [!code-cs[csProgGuideEvents#9](../../../csharp/programming-guide/events/codesnippet/CSharp/how-to-use-a-dictionary-to-store-event-instances_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Events](../../../csharp/programming-guide/events/index.md)   
 [Delegates](../../../csharp/programming-guide/delegates/index.md)
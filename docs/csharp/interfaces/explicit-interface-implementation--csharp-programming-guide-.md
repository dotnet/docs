---
title: "Explicit Interface Implementation (C# Programming Guide)"
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
  - "explicit interfaces [C#]"
  - "interfaces [C#], explicit"
ms.assetid: 181c901f-0d4c-4f29-97fc-895079617bf2
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Explicit Interface Implementation (C# Programming Guide)
If a [class](../keywords/class--csharp-reference-.md) implements two interfaces that contain a member with the same signature, then implementing that member on the class will cause both interfaces to use that member as their implementation. In the following example, all the calls to `Paint` invoke the same method.  
  
 [!code[csProgGuideInheritance#39](../classes-and-structs/codesnippet/CSharp/explicit-interface-implementation--csharp-programming-guide-_1.cs)]  
  
 If the two [interface](../keywords/interface--csharp-reference-.md) members do not perform the same function, however, this can lead to an incorrect implementation of one or both of the interfaces. It is possible to implement an interface member explicitly—creating a class member that is only called through the interface, and is specific to that interface. This is accomplished by naming the class member with the name of the interface and a period. For example:  
  
 [!code[csProgGuideInheritance#40](../classes-and-structs/codesnippet/CSharp/explicit-interface-implementation--csharp-programming-guide-_2.cs)]  
  
 The class member `IControl.Paint` is only available through the `IControl` interface, and `ISurface.Paint` is only available through `ISurface`. Both method implementations are separate, and neither is available directly on the class. For example:  
  
 [!code[csProgGuideInheritance#41](../classes-and-structs/codesnippet/CSharp/explicit-interface-implementation--csharp-programming-guide-_3.cs)]  
  
 Explicit implementation is also used to resolve cases where two interfaces each declare different members of the same name such as a property and a method:  
  
 [!code[csProgGuideInheritance#42](../classes-and-structs/codesnippet/CSharp/explicit-interface-implementation--csharp-programming-guide-_4.cs)]  
  
 To implement both interfaces, a class has to use explicit implementation either for the property P, or the method P, or both, to avoid a compiler error. For example:  
  
 [!code[csProgGuideInheritance#43](../classes-and-structs/codesnippet/CSharp/explicit-interface-implementation--csharp-programming-guide-_5.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)   
 [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md)
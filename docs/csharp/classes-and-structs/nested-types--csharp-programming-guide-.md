---
title: "Nested Types (C# Programming Guide)"
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
  - "nested types [C#]"
ms.assetid: f2e1b315-e3d1-48ce-977f-7bae0960ba99
caps.latest.revision: 13
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
# Nested Types (C# Programming Guide)
A type defined within a [class](../keywords/class--csharp-reference-.md) or [struct](../keywords/struct--csharp-reference-.md) is called a nested type. For example:  
  
 [!code[csProgGuideObjects#68](../classes-and-structs/codesnippet/CSharp/nested-types--csharp-programming-guide-_1.cs)]  
  
 Regardless of whether the outer type is a class or a struct, nested types default to [private](../keywords/private--csharp-reference-.md), but can be made [public](../keywords/public--csharp-reference-.md), protected internal, [protected](../keywords/protected--csharp-reference-.md), [internal](../keywords/internal--csharp-reference-.md), or [private](../keywords/private--csharp-reference-.md). In the previous example, `Nested` is inaccessible to external types, but can be made public like this:  
  
 [!code[csProgGuideObjects#69](../classes-and-structs/codesnippet/CSharp/nested-types--csharp-programming-guide-_2.cs)]  
  
 The nested, or inner type can access the containing, or outer type. To access the containing type, pass it as a constructor to the nested type. For example:  
  
 [!code[csProgGuideObjects#70](../classes-and-structs/codesnippet/CSharp/nested-types--csharp-programming-guide-_3.cs)]  
  
 A nested type has access to all of the members that are accessible to its containing type. It can access private and protected members of the containing type, including any inherited protected members.  
  
 In the previous declaration, the full name of class `Nested` is `Container.Nested`. This is the name used to create a new instance of the nested class, as follows:  
  
 [!code[csProgGuideObjects#71](../classes-and-structs/codesnippet/CSharp/nested-types--csharp-programming-guide-_4.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md)   
 [Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)
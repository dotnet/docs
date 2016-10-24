---
title: "default Keyword in Generic Code (C# Programming Guide)"
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
  - "generics [C#], default keyword"
  - "default keyword [C#], generic programming"
ms.assetid: b9daf449-4e64-496e-8592-6ed2c8875a98
caps.latest.revision: 22
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
# default Keyword in Generic Code (C# Programming Guide)
In generic classes and methods, one issue that arises is how to assign a default value to a parameterized type T when you do not know the following in advance:  
  
-   Whether T will be a reference type or a value type.  
  
-   If T is a value type, whether it will be a numeric value or a struct.  
  
 Given a variable t of a parameterized type T, the statement t = null is only valid if T is a reference type and t = 0 will only work for numeric value types but not for structs. The solution is to use the `default` keyword, which will return null for reference types and zero for numeric value types. For structs, it will return each member of the struct initialized to zero or null depending on whether they are value or reference types. For nullable value types, default returns a <xref:System.Nullable`1?displayProperty=fullName>, which is initialized like any struct.  
  
 The following example from the `GenericList<T>` class shows how to use the `default` keyword. For more information, see [Generics Overview](../generics/introduction-to-generics--csharp-programming-guide-.md).  
  
 [!code[csProgGuideGenerics#41](../generics/codesnippet/CSharp/default-keyword-in-generic-code--csharp-programming-guide-_1.cs)]  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Generics](../generics/generics--csharp-programming-guide-.md)   
 [Generic Methods](../generics/generic-methods--csharp-programming-guide-.md)   
 [Generics](../Topic/Generics%20in%20the%20.NET%20Framework.md)
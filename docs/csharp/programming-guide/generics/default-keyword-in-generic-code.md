---
title: "default Keyword in Generic Code (C# Programming Guide) | Microsoft Docs"
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
---
# default Keyword in Generic Code (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

In generic classes and methods, one issue that arises is how to assign a default value to a parameterized type T when you do not know the following in advance:  
  
-   Whether T will be a reference type or a value type.  
  
-   If T is a value type, whether it will be a numeric value or a struct.  
  
 Given a variable t of a parameterized type T, the statement t = null is only valid if T is a reference type and t = 0 will only work for numeric value types but not for structs. The solution is to use the `default` keyword, which will return null for reference types and zero for numeric value types. For structs, it will return each member of the struct initialized to zero or null depending on whether they are value or reference types. For nullable value types, default returns a <xref:System.Nullable%601?displayProperty=fullName>, which is initialized like any struct.  
  
 The following example from the `GenericList<T>` class shows how to use the `default` keyword. For more information, see [Generics Overview](../../../csharp/programming-guide/generics/introduction-to-generics.md).  
  
 [!code-csharp[csProgGuideGenerics#41](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#41)]  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Generics](../../../csharp/programming-guide/generics/index.md)   
 [Generic Methods](../../../csharp/programming-guide/generics/generic-methods.md)   
 [Generics](~/docs/standard/generics/index.md)
---
title: "Nested Types (C# Programming Guide) | Microsoft Docs"
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
---
# Nested Types (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A type defined within a [class](../../../csharp/language-reference/keywords/class.md) or [struct](../../../csharp/language-reference/keywords/struct.md) is called a nested type. For example:  
  
 [!code-csharp[csProgGuideObjects#68](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#68)]  
  
 Regardless of whether the outer type is a class or a struct, nested types default to [private](../../../csharp/language-reference/keywords/private.md), but can be made [public](../../../csharp/language-reference/keywords/public.md), protected internal, [protected](../../../csharp/language-reference/keywords/protected.md), [internal](../../../csharp/language-reference/keywords/internal.md), or [private](../../../csharp/language-reference/keywords/private.md). In the previous example, `Nested` is inaccessible to external types, but can be made public like this:  
  
 [!code-csharp[csProgGuideObjects#69](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#69)]  
  
 The nested, or inner type can access the containing, or outer type. To access the containing type, pass it as a constructor to the nested type. For example:  
  
 [!code-csharp[csProgGuideObjects#70](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#70)]  
  
 A nested type has access to all of the members that are accessible to its containing type. It can access private and protected members of the containing type, including any inherited protected members.  
  
 In the previous declaration, the full name of class `Nested` is `Container.Nested`. This is the name used to create a new instance of the nested class, as follows:  
  
 [!code-csharp[csProgGuideObjects#71](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#71)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)   
 [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md)   
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)
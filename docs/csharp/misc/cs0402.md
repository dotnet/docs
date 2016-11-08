---
title: "Compiler Warning (level 4) CS0402 | Microsoft Docs"
ms.custom: ""
ms.date: "11/04/2016"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "CS0402"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0402"
ms.assetid: 5a252c95-18c7-4569-bae0-e1f7b582cf6a
caps.latest.revision: 6
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
# Compiler Warning (level 4) CS0402
'identifier' : an entry point cannot be generic or in a generic type  
  
 The entry point was found in a generic type. To remove this warning, implement Main in a non-generic class or struct.  
  
```  
// CS0402.cs  
// compile with: /W:4  
class C<T>  
{  
   public static void Main()  // CS0402  
   {  
  
   }  
}  
  
class CMain  
{  
   public static void Main() {}  
}  
```
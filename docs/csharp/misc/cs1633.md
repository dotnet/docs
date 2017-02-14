---
title: "Compiler Warning (level 1) CS1633 | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS1633"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1633"
ms.assetid: f31db218-f880-4fc4-ab34-8bcdc49011da
caps.latest.revision: 6
author: "BillWagner"
ms.author: "wiwagn"

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
# Compiler Warning (level 1) CS1633
Unrecognized #pragma directive  
  
 The pragma used was not one of the known pragmas supported by the C# compiler. To resolve this error, use only pragmas supported.  
  
 The following sample generates CS1633:  
  
```  
// CS1633.cs  
// compile with: /W:1  
#pragma unknown  // CS1633  
  
class C  
{  
   public static void Main()  
   {  
   }  
}  
```
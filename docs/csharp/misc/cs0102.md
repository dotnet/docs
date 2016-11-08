---
title: "Compiler Error CS0102 | Microsoft Docs"
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
  - "CS0102"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0102"
ms.assetid: c9419779-649f-4c24-b0f3-f0a1be46659e
caps.latest.revision: 11
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
# Compiler Error CS0102
The type 'type name' already contains a definition for 'identifier'  
  
 A class contains multiple declarations for identifiers with the same name at the same scope. To fix the error, rename the duplicate identifiers.  
  
## Example  
 The following sample generates CS0102.  
  
```  
// CS0102.cs  
// compile with: /target:library  
namespace MyApp  
{  
   public class MyClass  
   {  
      string s = "Hello";  
      string s = "Goodbye";   // CS0102  
  
      public void GetString()  
      {  
         string s = "Hello again";   // method scope, no error  
      }  
   }  
}  
  
```
---
title: "Compiler Error CS1615 | Microsoft Docs"
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
  - "CS1615"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1615"
ms.assetid: 518bb07f-0e3a-4761-9931-66845eb5df1a
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
# Compiler Error CS1615
Argument 'number' should not be passed with the 'keyword' keyword  
  
 One of the keywords `ref` or **out** was used when the function did not take a `ref` or **out** parameter for that argument. To resolve this error, remove the incorrect keyword and use the appropriate keyword that matches the function declaration, if any.  
  
 The following sample generates CS1615:  
  
```  
// CS1615.cs  
class C  
{  
   public void f(int i) {}  
   public static void Main()  
   {  
      int i = 1;  
      f(ref i);  // CS1615  
   }  
}  
```
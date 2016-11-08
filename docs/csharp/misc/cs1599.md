---
title: "Compiler Error CS1599 | Microsoft Docs"
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
  - "CS1599"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1599"
ms.assetid: 4cdb282d-0f5d-459b-afc1-8980fbb22067
caps.latest.revision: 10
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
# Compiler Error CS1599
Method or delegate cannot return type 'type'  
  
 Some types in the .NET Framework class library, for example, <xref:System.TypedReference>, <xref:System.RuntimeArgumentHandle> and <xref:System.ArgIterator> cannot be used as return types because they can potentially be used to perform unsafe operations.  
  
 The following sample generates CS1599:  
  
```  
// CS1599.cs  
using System;  
  
class MyClass  
{  
   public static void Main()  
   {  
   }  
  
   public TypedReference Test1()   // CS1599  
   {  
      return null;  
   }  
  
   public ArgIterator Test2()   // CS1599  
   {  
      return null;  
   }  
}  
```
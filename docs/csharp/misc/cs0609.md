---
title: "Compiler Error CS0609 | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS0609"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0609"
ms.assetid: f3ff07a6-1190-4a1c-86a5-f607e1a32b78
caps.latest.revision: 8
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
# Compiler Error CS0609
Cannot set the IndexerName attribute on an indexer marked override  
  
 The name attribute (**IndexerNameAttribute**) cannot be applied to an indexed property that is an override. For more information, see [Indexers](../../csharp/programming-guide/indexers/index.md).  
  
 The following sample generates CS0609:  
  
```  
// CS0609.cs  
using System;  
using System.Runtime.CompilerServices;  
  
public class idx  
{  
   public virtual int this[int iPropIndex]  
   {  
      get  
      {  
         return 0;  
      }  
      set  
      {  
      }  
   }  
}  
  
public class MonthDays : idx  
{  
   [IndexerName("MonthInfoIndexer")]   // CS0609, delete to resolve this CS0609  
   public override int this[int iPropIndex]  
   {  
      get  
      {  
         return 0;  
      }  
      set  
      {  
      }  
   }  
}  
  
public class test  
{  
   public static void Main( string[] args )  
   {  
   }  
}  
```
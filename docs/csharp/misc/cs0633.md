---
title: "Compiler Error CS0633 | Microsoft Docs"
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
  - "CS0633"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0633"
ms.assetid: a24d310b-151a-45eb-b150-3407940ec24c
caps.latest.revision: 14
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
# Compiler Error CS0633
The argument to the 'attribute' attribute must be a valid identifier  
  
 Any argument that you pass to the <xref:System.Diagnostics.ConditionalAttribute> or <xref:System.Runtime.CompilerServices.IndexerNameAttribute> attributes must be a valid identifier. This means that it may not contain characters such as "+" that are illegal when they occur in identifiers.  
  
## Example  
 This example illustrates CS0633 using the <xref:System.Diagnostics.ConditionalAttribute>. The following sample generates CS0633.  
  
```  
// CS0633a.cs  
#define DEBUG  
using System.Diagnostics;  
public class Test  
{  
   [Conditional("DEB+UG")]   // CS0633  
   // try the following line instead  
   // [Conditional("DEBUG")]  
   public static void Main() { }  
}  
```  
  
## Example  
 This example illustrates CS0633 using the <xref:System.Runtime.CompilerServices.IndexerNameAttribute>.  
  
```  
// CS0633b.cs  
// compile with: /target:module  
#define DEBUG  
using System.Runtime.CompilerServices;  
public class Test  
{  
   [IndexerName("Invalid+Identifier")]   // CS0633  
   // try the following line instead  
   // [IndexerName("DEBUG")]  
   public int this[int i]   
   {   
      get { return i; }   
   }  
}  
  
```
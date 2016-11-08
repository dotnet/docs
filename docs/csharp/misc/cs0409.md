---
title: "Compiler Error CS0409 | Microsoft Docs"
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
  - "CS0409"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0409"
ms.assetid: 23d86c13-7978-41b7-a087-ffcea52476fa
caps.latest.revision: 7
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
# Compiler Error CS0409
A constraint clause has already been specified for type parameter 'type parameter'. All of the constraints for a type parameter must be specified in a single where clause.  
  
 Multiple constraint clauses (where clauses) were found for a single type parameter. Remove the extraneous where clause, or correct the where clauses so that a unique type parameter in each clause.  
  
```  
// CS0409.cs  
interface I  
{  
}  
  
class C<T1, T2> where T1 : I where T1 : I  // CS0409 – T1 used twice  
{  
}  
```
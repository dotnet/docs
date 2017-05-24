---
title: "Range variable name cannot match the name of a member of the &#39;Object&#39; class | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc36606"
  - "vbc36606"
helpviewer_keywords: 
  - "BC36606"
ms.assetid: 964245e6-2601-4de6-8a51-25c0d9633418
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

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
# Range variable name cannot match the name of a member of the &#39;Object&#39; class
A range variable in a LINQ query matches the name of a member of the <xref:System.Object> class. This creates a conflict with the objects created by Visual Basic for the LINQ query.  
  
 **Error ID:** BC36606  
  
## To correct this error  
  
1.  Choose a new name for the range variable that does not match the name of any member of the <xref:System.Object> class.  
  
## See Also  
 <xref:System.Object>   
 [Introduction to LINQ in Visual Basic](../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)   
 [From Clause](../../visual-basic/language-reference/queries/from-clause.md)   
 [Aggregate Clause](../../visual-basic/language-reference/queries/aggregate-clause.md)   
 [Select Clause](../../visual-basic/language-reference/queries/select-clause.md)
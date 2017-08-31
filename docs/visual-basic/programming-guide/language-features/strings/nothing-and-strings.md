---
title: "Nothing and Strings in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "strings [Visual Basic], Nothing"
ms.assetid: 261380af-2024-4ecf-823b-43b1034d92cd
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Nothing and Strings in Visual Basic
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

The [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] runtime and the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] evaluate `Nothing` differently when it comes to strings.  
  
## Visual Basic Runtime and the .NET Framework  
 Consider the following example:  
  
 [!code-vb[VbVbalrStrings#47](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#47)]  
  
 The [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] runtime usually evaluates `Nothing` as an empty string (""). The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] does not, however, and throws an exception whenever an attempt is made to perform a string operation on `Nothing`.  
  
## See Also  
 [Introduction to Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)
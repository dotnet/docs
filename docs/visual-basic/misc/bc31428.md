---
title: "Arrays of type &#39;System.Void&#39; are not allowed in this expression | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vbc31428"
  - "bc31428"
helpviewer_keywords: 
  - "BC31428"
ms.assetid: 21d77b56-585f-4107-b7ec-21933ba58017
caps.latest.revision: 5
author: "stevehoag"
ms.author: "shoag"
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
# Arrays of type &#39;System.Void&#39; are not allowed in this expression
An expression in an assignment statement or a declaration specifies an array of type <xref:System.Void>.  
  
 The <xref:System.Void> structure is a specialized type used internally by the .NET Framework and particularly by Visual C# and Visual C++. It represents a return value type for a method that does not return a value. Visual Basic uses a `Sub` procedure when a value is not returned and a `Function` procedure when a value is returned.  
  
 Arrays of type <xref:System.Void> are not meaningful and are not allowed in any context.  
  
 **Error ID:** BC31428  
  
### To correct this error  
  
1.  Remove the parentheses that designate an array.  
  
2.  Unless you have a particular reason to compare a run-time type to <xref:System.Void>, remove the reference to it altogether.  
  
## See Also  
 <xref:System.Void>
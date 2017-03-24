---
title: "Declaration expected | Microsoft Docs"
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
  - "vbc30188"
  - "bc30188"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30188"
ms.assetid: da6b1df3-fe6b-4415-88e6-0977e5189e0b
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Declaration expected
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

A nondeclarative statement, such as an assignment or loop statement, occurs outside any procedure. Only declarations are allowed outside procedures.  
  
 Alternatively, a programming element is declared without a declaration keyword such as `Dim` or `Const`.  
  
 **Error ID:** BC30188  
  
### To correct this error  
  
-   Move the nondeclarative statement to the body of a procedure.  
  
-   Begin the declaration with an appropriate declaration keyword.  
  
-   Ensure that a declaration keyword is not misspelled.  
  
## See Also  
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)   
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)
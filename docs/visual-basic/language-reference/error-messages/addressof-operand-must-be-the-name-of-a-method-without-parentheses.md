---
title: "&#39;AddressOf&#39; operand must be the name of a method (without parentheses) | Microsoft Docs"
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
  - "vbc30577"
  - "bc30577"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30577"
ms.assetid: c2c55640-5c61-4e66-97a4-4322020c6001
caps.latest.revision: 10
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# &#39;AddressOf&#39; operand must be the name of a method (without parentheses)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The `AddressOf` operator creates a procedure delegate instance that references a specific procedure. The syntax is as follows.  
  
 `AddressOf` `procedurename`  
  
 You inserted parentheses around the argument following `AddressOf`, where none are needed.  
  
 **Error ID:** BC30577  
  
### To correct this error  
  
1.  Remove the parentheses around the argument following `AddressOf`.  
  
2.  Make sure the argument is a method name.  
  
## See Also  
 [AddressOf Operator](../../../visual-basic/language-reference/operators/addressof-operator.md)   
 [Delegates](../../../visual-basic/programming-guide/language-features/delegates/delegates.md)
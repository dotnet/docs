---
title: "Argument not optional (Visual Basic) | Microsoft Docs"
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
  - "vbrID449"
dev_langs: 
  - "VB"
ms.assetid: 76e7bcf3-24ed-4cd5-945b-b98f1c76944b
caps.latest.revision: 7
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Argument not optional (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The number and types of arguments must match those expected. Either there is an incorrect number of arguments, or an omitted argument is not optional. An argument can only be omitted from a call to a user-defined procedure if it was declared `Optional` in the procedure definition.  
  
### To correct this error  
  
1.  Supply all necessary arguments.  
  
2.  Make sure omitted arguments are optional. If they are not, either supply the argument in the call, or declare the parameter `Optional` in the definition.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)
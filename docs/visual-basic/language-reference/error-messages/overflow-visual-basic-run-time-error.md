---
title: "Overflow (Visual Basic Run-Time Error) | Microsoft Docs"
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
  - "vbrERRID_Overflow"
dev_langs: 
  - "VB"
ms.assetid: c6a23279-3086-412a-bcff-ff8ed2cb8c6f
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Overflow (Visual Basic Run-Time Error)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An overflow results when you attempt an assignment that exceeds the limits of the assignment's target.  
  
### To correct this error  
  
1.  Make sure that results of assignments, calculations, and data type conversions are not too large to be represented within the range of variables allowed for that type of value, and assign the value to a variable of a type that can hold a larger range of values, if necessary.  
  
2.  Make sure assignments to properties fit the range of the property to which they are made.  
  
3.  Make sure that numbers used in calculations that are coerced into integers do not have results larger than integers.  
  
## See Also  
 <xref:System.Int32.MaxValue?displayProperty=fullName>   
 <xref:System.Double.MaxValue?displayProperty=fullName>   
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)   
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)
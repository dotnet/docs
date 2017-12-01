---
title: "Overflow (Visual Basic Run-Time Error)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrERRID_Overflow"
ms.assetid: c6a23279-3086-412a-bcff-ff8ed2cb8c6f
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Overflow (Visual Basic Run-Time Error)
An overflow results when you attempt an assignment that exceeds the limits of the assignment's target.  
  
## To correct this error  
  
1.  Make sure that results of assignments, calculations, and data type conversions are not too large to be represented within the range of variables allowed for that type of value, and assign the value to a variable of a type that can hold a larger range of values, if necessary.  
  
2.  Make sure assignments to properties fit the range of the property to which they are made.  
  
3.  Make sure that numbers used in calculations that are coerced into integers do not have results larger than integers.  
  
## See Also  
 <xref:System.Int32.MaxValue?displayProperty=nameWithType>  
 <xref:System.Double.MaxValue?displayProperty=nameWithType>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)

---
description: "Learn more about: Overflow (Visual Basic Run-Time Error)"
title: "Overflow (Visual Basic Run-Time Error)"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrERRID_Overflow"
ms.assetid: c6a23279-3086-412a-bcff-ff8ed2cb8c6f
---
# Overflow (Visual Basic Run-Time Error)

An overflow results when you attempt an assignment that exceeds the limits of the assignment's target.  
  
## To correct this error  
  
1. Make sure that results of assignments, calculations, and data type conversions are not too large to be represented within the range of variables allowed for that type of value, and assign the value to a variable of a type that can hold a larger range of values, if necessary.  
  
2. Make sure assignments to properties fit the range of the property to which they are made.  
  
3. Make sure that numbers used in calculations that are coerced into integers do not have results larger than integers.  
  
## See also

- <xref:System.Int32.MaxValue?displayProperty=nameWithType>
- <xref:System.Double.MaxValue?displayProperty=nameWithType>
- [Data Types](../data-types/index.md)
- [Error Types](../../programming-guide/language-features/error-types.md)

---
title: "Return Values for the CStr Function (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "times [Visual Basic], CStr Function return values"
  - "type conversion [Visual Basic]"
  - "dates [Visual Basic], CStr Function return values"
  - "CStr function"
  - "strings [Visual Basic], return value"
  - "Date data type [Visual Basic], converting"
  - "dates [Visual Basic]"
  - "String data type [Visual Basic], converting"
ms.assetid: 3aa744e7-1419-45d5-85e3-e5abc2953673
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# Return Values for the CStr Function (Visual Basic)
The following table describes the return values for `CStr` for different data types of `expression`.  
  
|If `expression` type is|`CStr` returns|  
|-----------------------------|--------------------|  
|[Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md)|A string containing "True" or "False".|  
|[Date Data Type](../../../visual-basic/language-reference/data-types/date-data-type.md)|A string containing a `Date` value (date and time) in the short date format of your system.|  
|[Numeric Data Types](../../../visual-basic/programming-guide/language-features/data-types/numeric-data-types.md)|A string representing the number.|  
  
## CStr and Date  
 The `Date` type always contains both date and time information. For purposes of type conversion, Visual Basic considers 1/1/0001 (January 1 of the year 1) to be a *neutral value* for the date, and 00:00:00 (midnight) to be a neutral value for the time. `CStr` does not include neutral values in the resulting string. For example, if you convert `#January 1, 0001 9:30:00#` to a string, the result is "9:30:00 AM"; the date information is suppressed. However, the date information is still present in the original `Date` value and can be recovered with functions such as <xref:Microsoft.VisualBasic.DateAndTime.DatePart%2A>.  
  
> [!NOTE]
>  The `CStr` function performs its conversion based on the current culture settings for the application. To get the string representation of a number in a particular culture, use the number's `ToString(IFormatProvider)` method. For example, use <xref:System.Double.ToString%2A?displayProperty=nameWithType> when converting a value of type `Double` to a `String`.  
  
## See Also  
 <xref:Microsoft.VisualBasic.DateAndTime.DatePart%2A>  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md)  
 [Date Data Type](../../../visual-basic/language-reference/data-types/date-data-type.md)

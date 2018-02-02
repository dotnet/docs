---
title: "Single Data Type (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Single"
helpviewer_keywords: 
  - "Single data type"
  - "F literal type character [Visual Basic]"
  - "trailing zeros"
  - "real numbers"
  - "literal type characters [Visual Basic], F"
  - "trailing 0 characters [Visual Basic]"
  - "identifier type characters [Visual Basic], !"
  - "single-precision numbers"
  - "! identifier type character"
  - "0 characters [Visual Basic], trailing"
  - "data types [Visual Basic], assigning"
  - "floating-point numbers [Visual Basic], Single data type"
  - "numbers [Visual Basic], real"
  - "zeros, trailing"
  - "numbers [Visual Basic], floating point"
ms.assetid: 224a2795-4cd5-496c-8f7a-a4f05a06d45d
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Single Data Type (Visual Basic)
Holds signed IEEE 32-bit (4-byte) single-precision floating-point numbers ranging in value from -3.4028235E+38 through -1.401298E-45 for negative values and from 1.401298E-45 through 3.4028235E+38 for positive values. Single-precision numbers store an approximation of a real number.  
  
## Remarks  
 Use the `Single` data type to contain floating-point values that do not require the full data width of `Double`. In some cases the common language runtime might be able to pack your `Single` variables closely together and save memory consumption.  
  
 The default value of `Single` is 0.  
  
## Programming Tips  
  
-   **Precision.** When you work with floating-point numbers, keep in mind that they do not always have a precise representation in memory. This could lead to unexpected results from certain operations, such as value comparison and the `Mod` operator. For more information, see [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md).  
  
-   **Widening.** The `Single` data type widens to `Double`. This means you can convert `Single` to `Double` without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.  
  
-   **Trailing Zeros.** The floating-point data types do not have any internal representation of trailing 0 characters. For example, they do not distinguish between 4.2000 and 4.2. Consequently, trailing 0 characters do not appear when you display or print floating-point values.  
  
-   **Type Characters.** Appending the literal type character `F` to a literal forces it to the `Single` data type. Appending the identifier type character `!` to any identifier forces it to `Single`.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Single?displayProperty=nameWithType> structure.  
  
## See Also  
 <xref:System.Single?displayProperty=nameWithType>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Decimal Data Type](../../../visual-basic/language-reference/data-types/decimal-data-type.md)  
 [Double Data Type](../../../visual-basic/language-reference/data-types/double-data-type.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)  
 [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)

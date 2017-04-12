---
title: "Double Data Type (Visual Basic) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net

ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vb.Double"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "identifier type characters, #"
  - "trailing zeros"
  - "real numbers"
  - "trailing 0 characters"
  - "0 characters, trailing"
  - "literal type characters, R"
  - "data types [Visual Basic], assigning"
  - "Double data type [Visual Basic]"
  - "# identifier type character"
  - "double-precision numbers"
  - "floating-point numbers, Double data type"
  - "R literal type character"
  - "zeros, trailing"
  - "Double data type"
ms.assetid: 0c5670f7-fcb1-453a-bef1-374730cd38fd
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Double Data Type (Visual Basic)
Holds signed IEEE 64-bit (8-byte) double-precision floating-point numbers that range in value from -1.79769313486231570E+308 through -4.94065645841246544E-324 for negative values and from 4.94065645841246544E-324 through 1.79769313486231570E+308 for positive values. Double-precision numbers store an approximation of a real number.  
  
## Remarks  
 The `Double` data type provides the largest and smallest possible magnitudes for a number.  
  
 The default value of `Double` is 0.  
  
## Programming Tips  
  
-   **Precision.** When you work with floating-point numbers, remember that they do not always have a precise representation in memory. This could lead to unexpected results from certain operations, such as value comparison and the `Mod` operator. For more information, see [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md).  
  
-   **Trailing Zeros.** The floating-point data types do not have any internal representation of trailing zero characters. For example, they do not distinguish between 4.2000 and 4.2. Consequently, trailing zero characters do not appear when you display or print floating-point values.  
  
-   **Type Characters.** Appending the literal type character `R` to a literal forces it to the `Double` data type. For example, if an integer value is followed by `R`, the value is changed to a `Double`.  
  
    ```  
    ' Visual Basic expands the 4 in the statement Dim dub As Double = 4R to 4.0:  
    Dim dub As Double = 4.0R  
    ```  
  
     Appending the identifier type character `#` to any identifier forces it to `Double`. In the following example, the variable `num` is typed as a `Double`:  
  
    ```  
    Dim num# = 3  
    ```  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Double?displayProperty=fullName> structure.  
  
## See Also  
 <xref:System.Double?displayProperty=fullName>   
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)   
 [Decimal Data Type](../../../visual-basic/language-reference/data-types/decimal-data-type.md)   
 [Single Data Type](../../../visual-basic/language-reference/data-types/single-data-type.md)   
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)   
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)   
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)   
 [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)   
 [Type Characters](../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)
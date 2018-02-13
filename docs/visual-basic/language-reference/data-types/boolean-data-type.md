---
title: "Boolean Data Type (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.FALSE"
  - "vb.TRUE"
  - "vb.Boolean"
helpviewer_keywords: 
  - "Boolean data type"
  - "Boolean values [Visual Basic], False keyword"
  - "False keyword [Visual Basic]"
  - "True keyword [Visual Basic]"
  - "Boolean values [Visual Basic], True keyword"
ms.assetid: 4858e630-4813-4216-a55e-f4d0feb884e4
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Boolean Data Type (Visual Basic)
Holds values that can be only `True` or `False`. The keywords `True` and `False` correspond to the two states of `Boolean` variables.  
  
## Remarks  
 Use the [Boolean Data Type (Visual Basic)](../../../visual-basic/language-reference/data-types/boolean-data-type.md) to contain two-state values such as true/false, yes/no, or on/off.  
  
 The default value of `Boolean` is `False`.  
  
 `Boolean` values are not stored as numbers, and the stored values are not intended to be equivalent to numbers. You should never write code that relies on equivalent numeric values for `True` and `False`. Whenever possible, you should restrict usage of `Boolean` variables to the logical values for which they are designed.  
  
## Type Conversions  
 When Visual Basic converts numeric data type values to `Boolean`, 0 becomes `False` and all other values become `True`. When Visual Basic converts `Boolean` values to numeric types, `False` becomes 0 and `True` becomes -1.  
  
 When you convert between `Boolean` values and numeric data types, keep in mind that the .NET Framework conversion methods do not always produce the same results as the Visual Basic conversion keywords. This is because the Visual Basic conversion retains behavior compatible with previous versions. For more information, see "Boolean Type Does Not Convert to Numeric Type Accurately" in [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md).  
  
## Programming Tips  
  
-   **Negative Numbers.** `Boolean` is not a numeric type and cannot represent a negative value. In any case, you should not use `Boolean` to hold numeric values.  
  
-   **Type Characters.** `Boolean` has no literal type character or identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Boolean?displayProperty=nameWithType> structure.  
  
## Example  
 In the following example, `runningVB` is a `Boolean` variable, which stores a simple yes/no setting.  
  
```  
Dim runningVB As Boolean  
' Check to see if program is running on Visual Basic engine.  
If scriptEngine = "VB" Then  
    runningVB = True  
End If  
```  
  
## See Also  
 <xref:System.Boolean?displayProperty=nameWithType>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)  
 [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [CType Function](../../../visual-basic/language-reference/functions/ctype-function.md)

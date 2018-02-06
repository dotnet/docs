---
title: "How to: Assign One Array to Another Array (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "covariance, arrays"
  - "arrays [Visual Basic], assigning"
  - "arrays [Visual Basic], covariance"
ms.assetid: 1ae89ea5-f292-4282-bcfc-e9b06b37fbd5
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Assign One Array to Another Array (Visual Basic)
Because arrays are objects, you can use them in assignment statements like other object types. An array variable holds a pointer to the data constituting the array elements and the rank and length information, and an assignment copies only this pointer.  
  
### To assign one array to another array  
  
1.  Ensure that the two arrays have the same rank (number of dimensions) and compatible element data types.  
  
2.  Use a standard assignment statement to assign the source array to the destination array. Do not follow either array name with parentheses.  
  
    ```  
    Dim formArray() As System.Windows.Forms.Form  
    Dim controlArray() As System.Windows.Forms.Control  
    controlArray = formArray  
    ```  
  
 When you assign one array to another, the following rules apply:  
  
-   **Equal Ranks.** The rank (number of dimensions) of the destination array must be the same as that of the source array.  
  
     Provided the ranks of the two arrays are equal, the dimensions do not need to be equal. The number of elements in a given dimension can change during assignment.  
  
-   **Element Types.** Either both arrays must have *reference type* elements or both arrays must have *value type* elements. For more information, see [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md).  
  
    -   If both arrays have value type elements, the element data types must be exactly the same. The only exception to this is that you can assign an array of `Enum` elements to an array of the base type of that `Enum`.  
  
    -   If both arrays have reference type elements, the source element type must derive from the destination element type. When this is the case, the two arrays have the same inheritance relationship as their elements. This is called *array covariance*.  
  
 The compiler reports an error if the above rules are violated, for example if the data types are not compatible or the ranks are unequal. You can add error handling to your code to make sure that the arrays are compatible before attempting an assignment. You can also use the [TryCast Operator](../../../../visual-basic/language-reference/operators/trycast-operator.md) keyword if you want to avoid throwing an exception.  
  
## See Also  
 [Arrays](../../../../visual-basic/programming-guide/language-features/arrays/index.md)  
 [Troubleshooting Arrays](../../../../visual-basic/programming-guide/language-features/arrays/troubleshooting-arrays.md)  
 [Enum Statement](../../../../visual-basic/language-reference/statements/enum-statement.md)  
 [Array Conversions](../../../../visual-basic/programming-guide/language-features/data-types/array-conversions.md)

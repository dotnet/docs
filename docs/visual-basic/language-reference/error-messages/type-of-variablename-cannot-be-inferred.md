---
title: "Type of '<variablename>' cannot be inferred because the loop bounds and the step variable do not widen to the same type"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30982"
  - "vbc30982"
helpviewer_keywords: 
  - "BC30982"
ms.assetid: 741e85d9-a747-42ad-a1e1-a3f1928aaff5
---
# Type of '\<variablename>' cannot be inferred because the loop bounds and the step variable do not widen to the same type
You have written a `For...Next` loop in which the compiler cannot infer a data type for the loop control variable because the following conditions are true:  
  
-   The data type of the loop control variable is not specified with an `As` clause.  
  
-   The loop bounds and step variable contain at least two data types.  
  
-   No standard conversions exist between the data types.  
  
 Therefore, the compiler cannot infer the data type of a loop's control variable.  
  
 In the following example, the step variable is a character and the loop bounds are both integers. Because there is no standard conversion between characters and integers, this error is reported.  
  
```vb  
Dim stepVar = "1"c  
Dim m = 0  
Dim n = 20  
  
' Not valid.  
' For i = 1 To 10 Step stepVar  
    ' Loop processing  
' Next  
```  
  
 **Error ID:** BC30982  
  
## To correct this error  
  
-   Change the types of the loop bounds and step variable as necessary so that at least one of them is a type that the others widen to. In the preceding example, change the type of `stepVar` to `Integer`.  
  
    ```  
    Dim stepVar = 1  
    ```  
  
     —or—  
  
    ```  
    Dim stepVar As Integer = 1  
    ```  
  
-   Use explicit conversion functions to convert the loop bounds and step variable to the appropriate types. In the preceding example, apply the `Val` function to `stepVar`.  
  
    ```  
    For i = 1 To 10 Step Val(stepVar)  
        ' Loop processing  
    Next  
    ```  
  
## See also

- <xref:Microsoft.VisualBasic.Conversion.Val%2A>
- [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md)
- [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
- [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)
- [Option Infer Statement](../../../visual-basic/language-reference/statements/option-infer-statement.md)
- [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)
- [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)

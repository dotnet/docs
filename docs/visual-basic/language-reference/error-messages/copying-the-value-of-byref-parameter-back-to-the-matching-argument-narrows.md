---
title: "Copying the value of &#39;ByRef&#39; parameter &#39;&lt;parametername&gt;&#39; back to the matching argument narrows from type &#39;&lt;typename1&gt;&#39; to type &#39;&lt;typename2&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc32053"
  - "vbc32053"
helpviewer_keywords: 
  - "BC32053"
ms.assetid: 281564b7-99f7-451f-b10d-f985e831bb25
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Copying the value of &#39;ByRef&#39; parameter &#39;&lt;parametername&gt;&#39; back to the matching argument narrows from type &#39;&lt;typename1&gt;&#39; to type &#39;&lt;typename2&gt;&#39;
A procedure is called with an argument that widens to the corresponding parameter type, and the conversion from the parameter to the argument is narrowing.  
  
 When you define a class or structure, you can define one or more conversion operators to convert that class or structure type to other types. You can also define reverse conversion operators to convert those other types back to your class or structure type. When you use your class or structure type in a procedure call, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] can use these conversion operators to convert the type of an argument to the type of its corresponding parameter.  
  
 If you pass the argument [ByRef](../../../visual-basic/language-reference/modifiers/byref.md), [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] sometimes copies the argument value into a local variable in the procedure instead of passing a reference. In such a case, when the procedure returns, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] must then copy the local variable value back into the argument in the calling code.  
  
 If a `ByRef` argument value is copied into the procedure and the argument and parameter are of the same type, no conversion is necessary. But if the types are different, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] must convert in both directions. If one of the types is your class or structure type, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] must convert it both to and from the other type. If one of these conversions is widening, the reverse conversion might be narrowing.  
  
 **Error ID:** BC32053  
  
## To correct this error  
  
-   If possible, use a calling argument of the same type as the procedure parameter, so [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] does not need to do any conversion.  
  
-   If you need to call the procedure with an argument type different from the parameter type but do not need to return a value into the calling argument, define the parameter to be [ByVal](../../../visual-basic/language-reference/modifiers/byval.md) instead of `ByRef`.  
  
-   If you need to return a value into the calling argument, define the reverse conversion operator as [Widening](../../../visual-basic/language-reference/modifiers/widening.md), if possible.  
  
## See Also  
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)  
 [Procedure Parameters and Arguments](../../../visual-basic/programming-guide/language-features/procedures/procedure-parameters-and-arguments.md)  
 [Passing Arguments by Value and by Reference](../../../visual-basic/programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md)  
 [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md)  
 [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)  
 [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)  
 [How to: Define a Conversion Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)  
 [Type Conversions in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)

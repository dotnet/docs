---
title: "Implicit conversion from &#39;&lt;typename1&gt;&#39; to &#39;&lt;typename2&gt;&#39; in copying the value of &#39;ByRef&#39; parameter &#39;&lt;parametername&gt;&#39; back to the matching argument."
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc41999"
  - "bc41999"
helpviewer_keywords: 
  - "BC41999"
ms.assetid: ae48c738-dff8-4c0f-8931-bbb70b2c8b03
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
---
# Implicit conversion from &#39;&lt;typename1&gt;&#39; to &#39;&lt;typename2&gt;&#39; in copying the value of &#39;ByRef&#39; parameter &#39;&lt;parametername&gt;&#39; back to the matching argument.
A procedure is called with a [ByRef](../../../visual-basic/language-reference/modifiers/byref.md) argument of a different type than that of its corresponding parameter.  
  
 If you pass an argument `ByRef`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] sometimes copies the argument value into a local variable in the procedure instead of passing a reference. In such a case, when the procedure returns, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] must then copy the local variable value back into the argument in the calling code.  
  
 If a `ByRef` argument value is copied into the procedure and the argument and parameter are of the same type, no conversion is necessary. But if the types are different, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] must convert in both directions. Because you cannot use `CType` or any of the other conversion keywords on a procedure argument or parameter, such a conversion is always implicit.  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC41999  
  
## To correct this error  
  
-   If possible, use a calling argument of the same type as the procedure parameter, so [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] does not need to do any conversion.  
  
-   If you need to call the procedure with an argument type different from the parameter type but do not need to return a value into the calling argument, define the parameter to be [ByVal](../../../visual-basic/language-reference/modifiers/byval.md) instead of `ByRef`.  
  
## See Also  
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)  
 [Procedure Parameters and Arguments](../../../visual-basic/programming-guide/language-features/procedures/procedure-parameters-and-arguments.md)  
 [Passing Arguments by Value and by Reference](../../../visual-basic/programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md)  
 [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)

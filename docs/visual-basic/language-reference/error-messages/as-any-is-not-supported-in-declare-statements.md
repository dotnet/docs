---
title: "&#39;As Any&#39; is not supported in &#39;Declare&#39; statements"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30828"
  - "vbc30828"
helpviewer_keywords: 
  - "BC30828"
ms.assetid: 7e5cf519-8b64-4ac5-8116-705fe26c846d
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;As Any&#39; is not supported in &#39;Declare&#39; statements
The `Any` data type was used with `Declare` statements in Visual Basic 6.0 and earlier versions to permit the use of arguments that could contain any type of data. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] supports overloading, however, and so makes the `Any` data type obsolete.  
  
 **Error ID:** BC30828  
  
## To correct this error  
  
1.  Declare parameters of the specific type you want to use; for example.  
  
     [!code-vb[VbVbalrStatements#95](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/as-any-is-not-supported-in-declare-statements_1.vb)]  
  
2.  Use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to specify `As Any` when `Void*` is expected by the procedure being called.  
  
     [!code-vb[VbVbalrStatements#96](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/as-any-is-not-supported-in-declare-statements_2.vb)]  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Walkthrough: Calling Windows APIs](../../../visual-basic/programming-guide/com-interop/walkthrough-calling-windows-apis.md)  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
 [Creating Prototypes in Managed Code](../../../framework/interop/creating-prototypes-in-managed-code.md)

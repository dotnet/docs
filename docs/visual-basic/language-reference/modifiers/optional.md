---
title: "Optional (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Optional"
  - "vb.optional"
helpviewer_keywords: 
  - "Optional keyword [Visual Basic], contexts"
  - "Optional keyword [Visual Basic]"
ms.assetid: 4571ce88-a539-4115-b230-54eb277c6aa7
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# Optional (Visual Basic)
Specifies that a procedure argument can be omitted when the procedure is called.  
  
## Remarks  
 For each optional parameter, you must specify a constant expression as the default value of that parameter. If the expression evaluates to [Nothing](../../../visual-basic/language-reference/nothing.md), the default value of the value data type is used as the default value of the parameter.  
  
 If the parameter list contains an optional parameter, every parameter that follows it must also be optional.  
  
 The `Optional` modifier can be used in these contexts:  
  
-   [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
  
-   [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
-   [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
-   [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
> [!NOTE]
>  When calling a procedure with or without optional parameters, you can pass arguments by position or by name. For more information, see [Passing Arguments by Position and by Name](../../../visual-basic/programming-guide/language-features/procedures/passing-arguments-by-position-and-by-name.md).  
  
> [!NOTE]
>  You can also define a procedure with optional parameters by using overloading. If you have one optional parameter, you can define two overloaded versions of the procedure, one that accepts the parameter and one that doesn’t. For more information, see [Procedure Overloading](../../../visual-basic/programming-guide/language-features/procedures/procedure-overloading.md).  
  
## Example  
 The following example defines a procedure that has an optional parameter.  
  
```  
Public Function FindMatches(ByRef values As List(Of String),  
                            ByVal searchString As String,  
                            Optional ByVal matchCase As Boolean = False) As List(Of String)  
  
    Dim results As IEnumerable(Of String)  
  
    If matchCase Then  
        results = From v In values  
                  Where v.Contains(searchString)  
    Else  
        results = From v In values  
                  Where UCase(v).Contains(UCase(searchString))  
    End If  
  
    Return results.ToList()  
End Function  
```  
  
## Example  
 The following example demonstrates how to call a procedure with arguments passed by position and with arguments passed by name. The procedure has two optional parameters.  
  
 [!code-vb[VbVbalrKeywords#21](../../../visual-basic/language-reference/codesnippet/VisualBasic/optional_1.vb)]  
  
## See Also  
 [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md)  
 [Optional Parameters](../../../visual-basic/programming-guide/language-features/procedures/optional-parameters.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)

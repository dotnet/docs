---
title: "Anonymous type member name can be inferred only from a simple or qualified name with no arguments"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc36556"
  - "bc36556"
helpviewer_keywords: 
  - "BC36556"
ms.assetid: e3ba1f33-3a71-4f03-9b04-ed5ec17de17c
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Anonymous type member name can be inferred only from a simple or qualified name with no arguments
You cannot infer an anonymous type member name from a complex expression.  
  
```vb  
Dim numbers() As Integer = {1, 2, 3, 4, 5}  
' Not valid.  
' Dim instanceName1 = New With {numbers(3)}  
```  
  
 For more information about sources from which anonymous types can and cannot infer member names and types, see [How to: Infer Property Names and Types in Anonymous Type Declarations](../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-infer-property-names-and-types-in-anonymous-type-declarations.md).  
  
 **Error ID:** BC36556  
  
## To correct this error  
  
-   Assign the expression to a member name, as shown in the following code:  
  
    ```  
    Dim instanceName2 = New With {.number = numbers(3)}  
    ```  
  
## See Also  
 [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [How to: Infer Property Names and Types in Anonymous Type Declarations](../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-infer-property-names-and-types-in-anonymous-type-declarations.md)

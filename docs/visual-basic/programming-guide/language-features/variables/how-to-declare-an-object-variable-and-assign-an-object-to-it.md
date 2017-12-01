---
title: "How to: Declare an Object Variable and Assign an Object to It in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "object variables [Visual Basic], declaring"
  - "declaring object variables [Visual Basic]"
ms.assetid: 2fa77dde-1fb2-439a-80d4-3e9787649fad
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Declare an Object Variable and Assign an Object to It in Visual Basic
You declare a variable of the [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md) by specifying `As Object` in a [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md). You assign an object to such a variable by placing the object after the equal sign (`=`) in an assignment statement or initialization clause.  
  
## Example  
 The following example declares an `Object` variable and assigns the current instance to it.  
  
```  
      Dim thisObject As Object  
thisObject = "This is an Object"  
```  
  
 You can combine the declaration and assignment by initializing the variable as part of its declaration. The following example is equivalent to the preceding example.  
  
```  
Dim thisObject As Object= "This is an Object"  
```  
  
## Compiling the Code  
 This example requires:  
  
-   A reference to the <xref:System> namespace.  
  
-   A class, structure, or module in which to put the `Dim` statement.  
  
-   A procedure in which to put the assignment statement.  
  
## See Also  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md)  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)

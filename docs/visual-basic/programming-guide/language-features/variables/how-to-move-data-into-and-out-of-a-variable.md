---
title: "How to: Move Data Into and Out of a Variable (Visual Basic)"
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
  - "variables [Visual Basic], retrieving values"
  - "variables [Visual Basic], storing data"
ms.assetid: 93744f46-bf78-4fa0-9640-1de01bc38d9a
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Move Data Into and Out of a Variable (Visual Basic)
You store a value in a variable by putting the variable name on the left side of an assignment statement.  
  
## Putting Data in a Variable  
  
#### To store a value in a variable  
  
-   Use the variable name on the left side of an assignment statement.  
  
     The following example sets the value of the variable `alpha`.  
  
    ```  
    alpha = (beta * 6.27) / (gamma + 2.1)  
    ```  
  
     The value generated on the right side of the assignment statement is stored in the variable.  
  
## Getting Data from a Variable  
 You retrieve a variable's value by including the variable name in an expression.  
  
#### To retrieve a value from a variable  
  
-   Use the variable name in an expression. You can use a variable anywhere you can use a constant or a literal, except in an expression that defines the value of a constant.  
  
     -or-  
  
-   Use the variable name following the equal (`=`) sign in an assignment statement.  
  
     The following example reads the value of the variable `startValue` and then uses the value of the variable `counter` in an expression.  
  
    ```  
    counter = startValue  
    cellValue = (counter + 5) ^ 2  
    ```  
  
     The value of the variable participates in the expression just as a constant would, and then it is stored in the variable or property on the left side of the assignment statement.  
  
## See Also  
 [Variables](../../../../visual-basic/programming-guide/language-features/variables/index.md)  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)

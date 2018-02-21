---
title: "How to: Refer to the Current Instance of an Object (Visual Basic)"
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
  - "variables [Visual Basic], object"
  - "objects [Visual Basic], referring to current instance"
  - "instances [Visual Basic], referring to current"
  - "current instance"
  - "object variables [Visual Basic]"
ms.assetid: 7f9b2c77-03cd-428f-adc2-b18070226e7c
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Refer to the Current Instance of an Object (Visual Basic)
The *current instance* of an object is the instance in which the code is currently executing.  
  
 You use the `Me` keyword to refer to the current instance.  
  
### To refer to the current instance  
  
-   Use the `Me` keyword where you would normally use the name of an object variable.  
  
    ```  
    Me.ForeColor = System.Drawing.Color.Crimson  
    Me.Close()  
    ```  
  
     Although `Me` behaves like an object variable, you cannot declare it or assign anything to it. `Me` always refers to the current instance.  
  
## See Also  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Assignment](../../../../visual-basic/programming-guide/language-features/variables/object-variable-assignment.md)  
 [Me, My, MyBase, and MyClass](../../../../visual-basic/programming-guide/program-structure/me-my-mybase-and-myclass.md)

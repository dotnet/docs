---
title: "How to: Make an Object Variable Not Refer to Any Instance (Visual Basic)"
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
  - "Nothing keyword [Visual Basic], variable assignment"
  - "object variables [Visual Basic], null reference"
ms.assetid: e6d30578-bdae-4142-a3ac-a10697bf696a
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Make an Object Variable Not Refer to Any Instance (Visual Basic)
You can disassociate an object variable from any object instance by setting it to [Nothing](../../../../visual-basic/language-reference/nothing.md).  
  
### To disassociate an object variable from any object instance  
  
-   Set the variable to `Nothing` in an assignment statement.  
  
    ```  
    ' Assume account is a defined class  
    Dim currentAccount As account  
    currentAccount = Nothing  
    ```  
  
## Robust Programming  
 If your code tries to access a member of an object variable that has been set to `Nothing`, a <xref:System.NullReferenceException> occurs. If you set an object variable to `Nothing` frequently, or if it is possible the variable is not initialized, it is a good idea to enclose member accesses in a `Try...Catch...Finally` block.  
  
## .NET Framework Security  
 If you use an object variable for objects that contain confidential or sensitive data, you can set the variable to `Nothing` when you are not actively dealing with one of those objects. This reduces the chance of malicious code gaining access to the data.  
  
## See Also  
 <xref:System.NullReferenceException>  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Assignment](../../../../visual-basic/programming-guide/language-features/variables/object-variable-assignment.md)  
 [Nothing](../../../../visual-basic/language-reference/nothing.md)  
 [Try...Catch...Finally Statement](../../../../visual-basic/language-reference/statements/try-catch-finally-statement.md)  
 [Troubleshooting Exceptions: System.NullReferenceException](http://msdn.microsoft.com/library/4822b0b4-8105-43fb-887a-3cc51ff02899)

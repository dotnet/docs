---
description: "Learn more about: How to: Make an Object Variable Not Refer to Any Instance (Visual Basic)"
title: "How to: Make an Object Variable Not Refer to Any Instance"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Nothing keyword [Visual Basic], variable assignment"
  - "object variables [Visual Basic], null reference"
ms.assetid: e6d30578-bdae-4142-a3ac-a10697bf696a
ms.topic: how-to
---
# How to: Make an Object Variable Not Refer to Any Instance (Visual Basic)

You can disassociate an object variable from any object instance by setting it to [Nothing](../../../language-reference/nothing.md).  
  
### To disassociate an object variable from any object instance  
  
- Set the variable to `Nothing` in an assignment statement.  
  
    ```vb  
    ' Assume account is a defined class  
    Dim currentAccount As account  
    currentAccount = Nothing  
    ```  
  
## Robust Programming  

 If your code tries to access a member of an object variable that has been set to `Nothing`, a <xref:System.NullReferenceException> occurs. If you set an object variable to `Nothing` frequently, or if it is possible the variable is not initialized, it is a good idea to enclose member accesses in a `Try...Catch...Finally` block.  
  
## .NET Framework Security  

 If you use an object variable for objects that contain confidential or sensitive data, you can set the variable to `Nothing` when you are not actively dealing with one of those objects. This reduces the chance of malicious code gaining access to the data.  
  
## See also

- <xref:System.NullReferenceException>
- [Object Variables](object-variables.md)
- [Object Variable Assignment](object-variable-assignment.md)
- [Nothing](../../../language-reference/nothing.md)
- [Try...Catch...Finally Statement](../../../language-reference/statements/try-catch-finally-statement.md)

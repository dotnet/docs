---
description: "Learn more about: How to: Dispose of a System Resource (Visual Basic)"
title: "How to: Dispose of a System Resource"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Using statement [Visual Basic], disposing of system resources"
  - "Visual Basic code, control flow"
  - "system resources, disposing of"
  - "resources [Visual Basic], disposing of system"
  - "system resources"
  - "Using statement [Visual Basic], Using...End Using"
  - "Using block"
ms.assetid: 8be2b239-8090-419b-8e7e-bcaa75b0ecc8
ms.topic: how-to
---
# How to: Dispose of a System Resource (Visual Basic)

You can use a `Using` block to guarantee that the system disposes of a resource when your code exits the block. This is useful if you are using a system resource that consumes a large amount of memory, or that other components also want to use.  
  
### To dispose of a file stream when your code is finished with it  
  
1. Make sure you include the appropriate [Imports Statement (.NET Namespace and Type)](../../../language-reference/statements/imports-statement-net-namespace-and-type.md) for the file stream at the beginning of your source file (in this case, <xref:System.IO>).  
  
2. Create a `Using` block with the `Using` and `End Using` statements. Inside the block, put the code that deals with the file stream.  
  
3. Declare the stream and create an instance of it as part of the `Using` statement.  
  
    ```vb  
    ' Insert the following line at the beginning of your source file.  
    Imports System.IO  
    Public Sub AccessFile(ByVal s As String)  
        Using fs As New StreamReader(s)
            MsgBox("reading file contents """ & fs.ReadToEnd() & """")  
        End Using  
    End Sub
    ```  
  
     The system disposes of the resource no matter how you exit the block, including the case of an unhandled exception.  
  
     Note that you cannot access `fs` from outside the `Using` block, because its scope is limited to the block.  
  
     You can use this same technique on a system resource such as a SQL database connection or a COM wrapper. You use a `Using` block when you want to be sure to leave the resource available for other components after you have exited the `Using` block.  
  
## See also

- [Control Flow](index.md)
- [Decision Structures](decision-structures.md)
- [Loop Structures](loop-structures.md)
- [Other Control Structures](other-control-structures.md)
- [Nested Control Structures](nested-control-structures.md)
- [Using Statement](../../../language-reference/statements/using-statement.md)

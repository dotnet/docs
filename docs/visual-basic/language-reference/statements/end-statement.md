---
title: "End Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.End"
  - "End"
helpviewer_keywords: 
  - "execution [Visual Basic], ending"
  - "files [Visual Basic], closing"
  - "End keyword [Visual Basic], End statements"
  - "programs [Visual Basic], quitting"
  - "code, exiting"
  - "program termination"
  - "End statement [Visual Basic]"
  - "execution [Visual Basic], stopping"
ms.assetid: 0e64467c-0f34-4aab-9ddd-43f8b9d55d90
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# End Statement
Terminates execution immediately.  
  
## Syntax  
  
```  
End  
```  
  
## Remarks  
 You can place the `End` statement anywhere in a procedure to force the entire application to stop running. `End` closes any files opened with an `Open` statement and clears all the application's variables. The application closes as soon as there are no other programs holding references to its objects and none of its code is running.  
  
> [!NOTE]
>  The `End` statement stops code execution abruptly, and does not invoke the `Dispose` or `Finalize` method, or any other Visual Basic code. Object references held by other programs are invalidated. If an `End` statement is encountered within a `Try` or `Catch` block, control does not pass to the corresponding `Finally` block.  
  
 The `Stop` statement suspends execution, but unlike `End`, it does not close any files or clear any variables, unless it is encountered in a compiled executable (.exe) file.  
  
 Because `End` terminates your application without attending to any resources that might be open, you should try to close down cleanly before using it. For example, if your application has any forms open, you should close them before control reaches the `End` statement.  
  
 You should use `End` sparingly, and only when you need to stop immediately. The normal ways to terminate a procedure ([Return Statement](../../../visual-basic/language-reference/statements/return-statement.md) and [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md)) not only close down the procedure cleanly but also give the calling code the opportunity to close down cleanly. A console application, for example, can simply `Return` from the `Main` procedure.  
  
> [!IMPORTANT]
>  The `End` statement calls the <xref:System.Environment.Exit%2A> method of the <xref:System.Environment> class in the <xref:System> namespace. <xref:System.Environment.Exit%2A> requires that you have `UnmanagedCode` permission. If you do not, a <xref:System.Security.SecurityException> error occurs.  
  
 When followed by an additional keyword, [End \<keyword> Statement](../../../visual-basic/language-reference/statements/end-keyword-statement.md) delineates the end of the definition of the appropriate procedure or block. For example, `End Function` terminates the definition of a `Function` procedure.  
  
## Example  
 The following example uses the `End` statement to terminate code execution if the user requests it.  
  
 [!code-vb[VbVersHelp60Controls#64](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/end-statement_1.vb)]  
  
## Smart Device Developer Notes  
 This statement is not supported.  
  
## See Also  
 <xref:System.Security.Permissions.SecurityPermissionFlag>  
 [Stop Statement](../../../visual-basic/language-reference/statements/stop-statement.md)  
 [End \<keyword> Statement](../../../visual-basic/language-reference/statements/end-keyword-statement.md)

---
description: "Learn more about: Alias Clause (Visual Basic)"
title: "Alias Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Alias"
helpviewer_keywords: 
  - "Alias keyword [Visual Basic]"
ms.assetid: 58c06b11-465d-4d87-906a-73200a3d7f19
---
# Alias Clause (Visual Basic)

Indicates that an external procedure has another name in its DLL.  
  
## Remarks  

 The `Alias` keyword can be used in this context:  
  
 [Declare Statement](declare-statement.md)  
  
 In the following example, the `Alias` keyword is used to provide the name of the function in advapi32.dll, `GetUserNameA`, that `getUserName` is used in place of in this example. Function `getUserName` is called in sub `getUser`, which displays the name of the current user.  
  
 [!code-vb[VbVbalrStatements#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#15)]  
  
## See also

- [Keywords](../keywords/index.md)

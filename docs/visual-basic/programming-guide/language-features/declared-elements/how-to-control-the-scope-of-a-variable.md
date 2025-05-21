---
description: "Learn more about: How to: Control the Scope of a Variable (Visual Basic)"
title: "How to: Control the Scope of a Variable"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "variables [Visual Basic], scope"
  - "declared elements [Visual Basic], scope"
  - "visibility [Visual Basic], declared elements"
  - "variables [Visual Basic], visibility"
  - "scope [Visual Basic], declared elements"
  - "scope [Visual Basic], variables"
  - "scope [Visual Basic], Visual Basic"
  - "declared elements [Visual Basic], visibility"
  - "visibility [Visual Basic], variables"
ms.assetid: 44b7f62a-cb5c-4d50-bce9-60ae68f87072
ms.topic: how-to
---
# How to: Control the Scope of a Variable (Visual Basic)

Normally, a variable is in *scope*, or visible for reference, throughout the region in which you declare it. In some cases, the variable's *access level* can influence its scope.  
  
 For more information, see [Scope in Visual Basic](scope.md).  
  
## Scope at Block or Procedure Level  
  
#### To make a variable visible only within a block  
  
- Place the [Dim Statement](../../../language-reference/statements/dim-statement.md) for the variable between the initiating and terminating declaration statements of that block, for example between the `For` and `Next` statements of a `For` loop.  
  
     You can refer to the variable only from within the block.  
  
#### To make a variable visible only within a procedure  
  
- Place the `Dim` statement for the variable inside the procedure but outside any block (such as a `With`...`End With` block).  
  
     You can refer to the variable only from within the procedure, including inside any block contained in the procedure.  
  
## Scope at Module or Namespace Level  

 For convenience, the single term *module level* applies equally to modules, classes, and structures. The access level of a module level variable determines its scope. The namespace that contains the module, class, or structure also influences the scope.  
  
#### To make a variable visible throughout a module, class, or structure  
  
1. Place the `Dim` statement for the variable inside the module, class, or structure, but outside any procedure.  
  
2. Include the [Private](../../../language-reference/modifiers/private.md) keyword in the `Dim` statement.  
  
3. You can refer to the variable from anywhere within the module, class, or structure, but not from outside it.  
  
#### To make a variable visible throughout a namespace  
  
1. Place the `Dim` statement for the variable inside the module, class, or structure, but outside any procedure.  
  
2. Include the [Friend](../../../language-reference/modifiers/friend.md) or [Public](../../../language-reference/modifiers/public.md) keyword in the `Dim` statement.  
  
3. You can refer to the variable from anywhere within the namespace containing the module, class, or structure.  
  
## Example  

 The following example declares a variable at module level and limits its visibility to code within the module.  
  
```vb  
Module demonstrateScope  
    Private strMsg As String  
    Sub initializePrivateVariable()  
        strMsg = "This variable cannot be used outside this module."  
    End Sub  
    Sub usePrivateVariable()  
        MsgBox(strMsg)  
    End Sub  
End Module  
```  
  
 In the preceding example, all the procedures defined in module `demonstrateScope` can refer to the `String` variable `strMsg`. When the `usePrivateVariable` procedure is called, it displays the contents of the string variable `strMsg` in a dialog box.  
  
 With the following alteration to the preceding example, the string variable `strMsg` can be referred to by code anywhere in the namespace of its declaration.  
  
```vb  
Public strMsg As String  
```  
  
## Robust Programming  

 The narrower the scope of a variable, the fewer opportunities you have for accidentally referring to it in place of another variable with the same name. You can also minimize problems of reference matching.  
  
## .NET Framework Security  

 The narrower the scope of a variable, the smaller the chances that malicious code can make improper use of it.  
  
## See also

- [Scope in Visual Basic](scope.md)
- [Lifetime in Visual Basic](lifetime.md)
- [Access levels in Visual Basic](access-levels.md)
- [Variables](../variables/index.md)
- [Variable Declaration](../variables/variable-declaration.md)
- [Dim Statement](../../../language-reference/statements/dim-statement.md)

---
title: "Scope in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "module scope [Visual Basic]"
  - "scope [Visual Basic], levels"
  - "module level"
  - "procedures [Visual Basic], scope"
  - "declared elements [Visual Basic], scope"
  - "namespaces [Visual Basic], scope"
  - "scope [Visual Basic], declared elements"
  - "scope [Visual Basic], about scope"
  - "levels of scope [Visual Basic]"
  - "block scope [Visual Basic]"
  - "scope [Visual Basic], Visual Basic"
  - "procedure scope [Visual Basic]"
ms.assetid: 208106fe-79c9-4eec-93c6-55f08548895f
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Scope in Visual Basic
The *scope* of a declared element is the set of all code that can refer to it without qualifying its name or making it available through an [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md). An element can have scope at one of the following levels:  
  
|Level|Description|  
|-----------|-----------------|  
|Block scope|Available only within the code block in which it is declared|  
|Procedure scope|Available to all code within the procedure in which it is declared|  
|Module scope|Available to all code within the module, class, or structure in which it is declared|  
|Namespace scope|Available to all code in the namespace in which it is declared|  
  
 These levels of scope progress from the narrowest (block) to the widest (namespace), where *narrowest scope* means the smallest set of code that can refer to the element without qualification. For more information, see "Levels of Scope" on this page.  
  
## Specifying Scope and Defining Variables  
 You specify the scope of an element when you declare it. The scope can depend on the following factors:  
  
-   The region (block, procedure, module, class, or structure) in which you declare the element  
  
-   The namespace containing the element's declaration  
  
-   The access level you declare for the element  
  
 Use care when you define variables with the same name but different scope, because doing so can lead to unexpected results. For more information, see [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md).  
  
## Levels of Scope  
 A programming element is available throughout the region in which you declare it. All code in the same region can refer to the element without qualifying its name.  
  
### Block Scope  
 A block is a set of statements enclosed within initiating and terminating declaration statements, such as the following:  
  
-   `Do` and `Loop`  
  
-   `For` [`Each`] and `Next`  
  
-   `If` and `End If`  
  
-   `Select` and `End Select`  
  
-   `SyncLock` and `End SyncLock`  
  
-   `Try` and `End Try`  
  
-   `While` and `End While`  
  
-   `With` and `End With`  
  
 If you declare a variable within a block, you can use it only within that block. In the following example, the scope of the integer variable `cube` is the block between `If` and `End If`, and you can no longer refer to `cube` when execution passes out of the block.  
  
```  
If n < 1291 Then  
    Dim cube As Integer  
    cube = n ^ 3  
End If  
```  
  
> [!NOTE]
>  Even if the scope of a variable is limited to a block, its lifetime is still that of the entire procedure. If you enter the block more than once during the procedure, each block variable retains its previous value. To avoid unexpected results in such a case, it is wise to initialize block variables at the beginning of the block.  
  
### Procedure Scope  
 An element declared within a procedure is not available outside that procedure. Only the procedure that contains the declaration can use it. Variables at this level are also known as *local variables*. You declare them with the [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md), with or without the [Static](../../../../visual-basic/language-reference/modifiers/static.md) keyword.  
  
 Procedure and block scope are closely related. If you declare a variable inside a procedure but outside any block within that procedure, you can think of the variable as having block scope, where the block is the entire procedure.  
  
> [!NOTE]
>  All local elements, even if they are `Static` variables, are private to the procedure in which they appear. You cannot declare any element using the [Public](../../../../visual-basic/language-reference/modifiers/public.md) keyword within a procedure.  
  
### Module Scope  
 For convenience, the single term *module level* applies equally to modules, classes, and structures. You can declare elements at this level by placing the declaration statement outside of any procedure or block but within the module, class, or structure.  
  
 When you make a declaration at the module level, the access level you choose determines the scope. The namespace that contains the module, class, or structure also affects the scope.  
  
 Elements for which you declare [Private](../../../../visual-basic/language-reference/modifiers/private.md) access level are available to every procedure in that module, but not to any code in a different module. The `Dim` statement at module level defaults to `Private` if you do not use any access level keywords. However, you can make the scope and access level more obvious by using the `Private` keyword in the `Dim` statement.  
  
 In the following example, all procedures defined in the module can refer to the string variable `strMsg`. When the second procedure is called, it displays the contents of the string variable `strMsg` in a dialog box.  
  
```  
' Put the following declaration at module level (not in any procedure).  
Private strMsg As String  
' Put the following Sub procedure in the same module.  
Sub initializePrivateVariable()  
    strMsg = "This variable cannot be used outside this module."  
End Sub  
' Put the following Sub procedure in the same module.  
Sub usePrivateVariable()  
    MsgBox(strMsg)  
End Sub  
```  
  
### Namespace Scope  
 If you declare an element at module level using the [Friend](../../../../visual-basic/language-reference/modifiers/friend.md) or [Public](../../../../visual-basic/language-reference/modifiers/public.md) keyword, it becomes available to all procedures throughout the namespace in which the element is declared. With the following alteration to the preceding example, the string variable `strMsg` can be referred to by code anywhere in the namespace of its declaration.  
  
```  
' Include this declaration at module level (not inside any procedure).  
Public strMsg As String  
```  
  
 Namespace scope includes nested namespaces. An element available from within a namespace is also available from within any namespace nested inside that namespace.  
  
 If your project does not contain any [Namespace Statement](../../../../visual-basic/language-reference/statements/namespace-statement.md)s, everything in the project is in the same namespace. In this case, namespace scope can be thought of as project scope. `Public` elements in a module, class, or structure are also available to any project that references their project.  
  
## Choice of Scope  
 When you declare a variable, you should keep in mind the following points when choosing its scope.  
  
### Advantages of Local Variables  
 Local variables are a good choice for any kind of temporary calculation, for the following reasons:  
  
-   **Name Conflict Avoidance.** Local variable names are not susceptible to conflict. For example, you can create several different procedures containing a variable called `intTemp`. As long as each `intTemp` is declared as a local variable, each procedure recognizes only its own version of `intTemp`. Any one procedure can alter the value in its local `intTemp` without affecting `intTemp` variables in other procedures.  
  
-   **Memory Consumption.** Local variables consume memory only while their procedure is running. Their memory is released when the procedure returns to the calling code. By contrast, [Shared](../../../../visual-basic/language-reference/modifiers/shared.md) and [Static](../../../../visual-basic/language-reference/modifiers/static.md) variables consume memory resources until your application stops running, so use them only when necessary. *Instance variables* consume memory while their instance continues to exist, which makes them less efficient than local variables, but potentially more efficient than `Shared` or `Static` variables.  
  
### Minimizing Scope  
 In general, when declaring any variable or constant, it is good programming practice to make the scope as narrow as possible (block scope is the narrowest). This helps conserve memory and minimizes the chances of your code erroneously referring to the wrong variable. Similarly, you should declare a variable to be [Static](../../../../visual-basic/language-reference/modifiers/static.md) only when it is necessary to preserve its value between procedure calls.  
  
## See Also  
 [Declared Element Characteristics](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md)  
 [How to: Control the Scope of a Variable](../../../../visual-basic/programming-guide/language-features/declared-elements/how-to-control-the-scope-of-a-variable.md)  
 [Lifetime in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/lifetime.md)  
 [Access levels in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
 [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)

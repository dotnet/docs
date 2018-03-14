---
title: "How to: Declare a Structure (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "declarations [Visual Basic], structures"
  - "structure statements [Visual Basic]"
  - "statements [Visual Basic], structure"
  - "structures [Visual Basic], declaring"
ms.assetid: d5e98381-eb81-47d4-af83-48cc534a2572
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Declare a Structure (Visual Basic)
You begin a structure declaration with the [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md), and you end it with the `End` `Structure` statement. Between these two statements you must declare at least one *element*. The elements can be of any data type, but at least one must be either a nonshared variable or a nonshared, noncustom event.  
  
 You cannot initialize any of the structure elements in the structure declaration. When you declare a variable to be of a structure type, you assign values to the elements by accessing them through the variable.  
  
 For a discussion of the differences between structures and classes, see [Structures and Classes](../../../../visual-basic/programming-guide/language-features/data-types/structures-and-classes.md).  
  
 For demonstration purposes, consider a situation where you want to keep track of an employee's name, telephone extension, and salary. A structure allows you to do this in a single variable.  
  
### To declare a structure  
  
1.  Create the beginning and ending statements for the structure.  
  
     You can specify the access level of a structure using the [Public](../../../../visual-basic/language-reference/modifiers/public.md), [Protected](../../../../visual-basic/language-reference/modifiers/protected.md), [Friend](../../../../visual-basic/language-reference/modifiers/friend.md), or [Private](../../../../visual-basic/language-reference/modifiers/private.md) keyword, or you can let it default to `Public`.  
  
    ```  
    Private Structure employee  
    End Structure  
    ```  
  
2.  Add elements to the body of the structure.  
  
     A structure must have at least one element. You must declare every element and specify an access level for it. If you use the [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md) without any keywords, the accessibility defaults to `Public`.  
  
    ```  
    Private Structure employee  
        Public givenName As String  
        Public familyName As String  
        Public phoneExtension As Long  
        Private salary As Decimal  
        Public Sub giveRaise(raise As Double)  
            salary *= raise  
        End Sub  
        Public Event salaryReviewTime()  
    End Structure  
    ```  
  
     The `salary` field in the preceding example is `Private`, which means it is inaccessible outside the structure, even from the containing class. However, the `giveRaise` procedure is `Public`, so it can be called from outside the structure. Similarly, you can raise the `salaryReviewTime` event from outside the structure.  
  
     In addition to variables, `Sub` procedures, and events, you can also define constants, `Function` procedures, and properties in a structure. You can designate at most one property as the *default property*, provided it takes at least one argument. You can handle an event with a [Shared](../../../../visual-basic/language-reference/modifiers/shared.md)`Sub` procedure. For more information, see [How to: Declare and Call a Default Property in Visual Basic](../../../../visual-basic/programming-guide/language-features/procedures/how-to-declare-and-call-a-default-property.md).  
  
## See Also  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [Structure Variables](../../../../visual-basic/programming-guide/language-features/data-types/structure-variables.md)  
 [Structures and Other Programming Elements](../../../../visual-basic/programming-guide/language-features/data-types/structures-and-other-programming-elements.md)  
 [Structures and Classes](../../../../visual-basic/programming-guide/language-features/data-types/structures-and-classes.md)  
 [User-Defined Data Type](../../../../visual-basic/language-reference/data-types/user-defined-data-type.md)

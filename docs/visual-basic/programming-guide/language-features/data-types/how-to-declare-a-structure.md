---
description: "Learn more about: How to: Declare a Structure (Visual Basic)"
title: "How to: Declare a Structure"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declarations [Visual Basic], structures"
  - "structure statements [Visual Basic]"
  - "statements [Visual Basic], structure"
  - "structures [Visual Basic], declaring"
ms.assetid: d5e98381-eb81-47d4-af83-48cc534a2572
---
# How to: Declare a Structure (Visual Basic)

You begin a structure declaration with the [Structure Statement](../../../language-reference/statements/structure-statement.md), and you end it with the `End Structure` statement. Between these two statements you must declare at least one *element*. The elements can be of any data type, but at least one must be either a nonshared variable or a nonshared, noncustom event.  
  
 You cannot initialize any of the structure elements in the structure declaration. When you declare a variable to be of a structure type, you assign values to the elements by accessing them through the variable.  
  
 For a discussion of the differences between structures and classes, see [Structures and Classes](structures-and-classes.md).  
  
 For demonstration purposes, consider a situation where you want to keep track of an employee's name, telephone extension, and salary. A structure allows you to do this in a single variable.  
  
### To declare a structure  
  
1. Create the beginning and ending statements for the structure.  
  
     You can specify the access level of a structure using the [Public](../../../language-reference/modifiers/public.md), [Protected](../../../language-reference/modifiers/protected.md), [Friend](../../../language-reference/modifiers/friend.md), or [Private](../../../language-reference/modifiers/private.md) keyword, or you can let it default to `Public`.  
  
    ```vb  
    Private Structure employee  
    End Structure  
    ```  
  
2. Add elements to the body of the structure.  
  
     A structure must have at least one element. You must declare every element and specify an access level for it. If you use the [Dim Statement](../../../language-reference/statements/dim-statement.md) without any keywords, the accessibility defaults to `Public`.  
  
    ```vb  
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
  
     In addition to variables, `Sub` procedures, and events, you can also define constants, `Function` procedures, and properties in a structure. You can designate at most one property as the *default property*, provided it takes at least one argument. You can handle an event with a [Shared](../../../language-reference/modifiers/shared.md)`Sub` procedure. For more information, see [How to: Declare and Call a Default Property in Visual Basic](../procedures/how-to-declare-and-call-a-default-property.md).  
  
## See also

- [Data Types](index.md)
- [Elementary Data Types](elementary-data-types.md)
- [Composite Data Types](composite-data-types.md)
- [Value Types and Reference Types](value-types-and-reference-types.md)
- [Structures](structures.md)
- [Troubleshooting Data Types](troubleshooting-data-types.md)
- [Structure Variables](structure-variables.md)
- [Structures and Other Programming Elements](structures-and-other-programming-elements.md)
- [Structures and Classes](structures-and-classes.md)
- [User-Defined Data Type](../../../language-reference/data-types/user-defined-data-type.md)

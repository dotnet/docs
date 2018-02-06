---
title: "Structure Variables (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "structures [Visual Basic], variables"
  - "structures [Visual Basic], structure variables"
  - "variables [Visual Basic], structure variables"
  - "structure variables [Visual Basic]"
ms.assetid: 156872f8-aabc-4454-8e2d-f2253c3c13c9
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Structure Variables (Visual Basic)
Once you have created a structure, you can declare procedure-level and module-level variables as that type. For example, you can create a structure that records information about a computer system. The following example demonstrates this.  
  
```  
Public Structure systemInfo  
    Public cPU As String  
    Public memory As Long  
    Public purchaseDate As Date  
End Structure  
```  
  
 You can now declare variables of that type. The following declaration illustrates this.  
  
```  
Dim mySystem, yourSystem As systemInfo  
```  
  
> [!NOTE]
>  In classes and modules, structures declared using the [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md) default to public access. If you intend a structure to be private, make sure you declare it using the [Private](../../../../visual-basic/language-reference/modifiers/private.md) keyword.  
  
## Access to Structure Values  
 To assign and retrieve values from the elements of a structure variable, you use the same syntax as you use to set and get properties on an object. You place the member access operator (`.`) between the structure variable name and the element name. The following example accesses elements of the variables previously declared as type `systemInfo`.  
  
```  
mySystem.cPU = "486"  
Dim tooOld As Boolean  
If yourSystem.purchaseDate < #1/1/1992# Then tooOld = True  
```  
  
## Assigning Structure Variables  
 You can also assign one variable to another if both are of the same structure type. This copies all the elements of one structure to the corresponding elements in the other. The following declaration illustrates this.  
  
```  
yourSystem = mySystem  
```  
  
 If a structure element is a reference type, such as a `String`, `Object`, or array, the pointer to the data is copied. In the previous example, if `systemInfo` had included an object variable, then the preceding example would have copied the pointer from `mySystem` to `yourSystem`, and a change to the object's data through one structure would be in effect when accessed through the other structure.  
  
## See Also  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [How to: Declare a Structure](../../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)  
 [Structures and Other Programming Elements](../../../../visual-basic/programming-guide/language-features/data-types/structures-and-other-programming-elements.md)  
 [Structures and Classes](../../../../visual-basic/programming-guide/language-features/data-types/structures-and-classes.md)  
 [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md)

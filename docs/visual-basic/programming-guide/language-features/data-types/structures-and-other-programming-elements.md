---
title: "Structures and Other Programming Elements (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "structures [Visual Basic], arrays"
  - "procedures [Visual Basic], structures as arguments to"
  - "objects [Visual Basic], structure elements"
  - "arrays [Visual Basic], structure elements"
  - "nested structures [Visual Basic]"
ms.assetid: 0f849313-ccd2-4c9a-acb9-69de6751c088
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Structures and Other Programming Elements (Visual Basic)
You can use structures in conjunction with arrays, objects, and procedures, as well as with each other. The interactions use the same syntax as these elements use individually.  
  
> [!NOTE]
>  You cannot initialize any of the structure elements in the structure declaration. You can assign values only to elements of a variable that has been declared to be of a structure type.  
  
## Structures and Arrays  
 A structure can contain an array as one or more of its elements. The following example illustrates this.  
  
```vb  
Public Structure systemInfo  
    Public cPU As String  
    Public memory As Long  
    Public diskDrives() As String  
    Public purchaseDate As Date  
End Structure   
```  
  
 You access the values of an array within a structure the same way you access a property on an object. The following example illustrates this.  
  
```vb  
Dim mySystem As systemInfo  
ReDim mySystem.diskDrives(3)  
mySystem.diskDrives(0) = "1.44 MB"  
```  
  
 You can also declare an array of structures. The following example illustrates this.  
  
```vb  
Dim allSystems(100) As systemInfo  
```  
  
 You follow the same rules to access the components of this data architecture. The following example illustrates this.  
  
```vb  
ReDim allSystems(5).diskDrives(3)  
allSystems(5).CPU = "386SX"  
allSystems(5).diskDrives(2) = "100M SCSI"  
```  
  
## Structures and Objects  
 A structure can contain an object as one or more of its elements. The following example illustrates this.  
  
```vb  
Protected Structure userInput  
    Public userName As String  
    Public inputForm As System.Windows.Forms.Form  
    Public userFileNumber As Integer  
End Structure  
```  
  
 You should use a specific object class in such a declaration, rather than `Object`.  
  
## Structures and Procedures  
 You can pass a structure as a procedure argument. The following example illustrates this.  
  
```vb  
Public currentCPUName As String = "700MHz Pentium compatible"  
Public currentMemorySize As Long = 256  
Public Sub fillSystem(ByRef someSystem As systemInfo)  
    someSystem.cPU = currentCPUName  
    someSystem.memory = currentMemorySize  
    someSystem.purchaseDate = Now  
End Sub  
```  
  
 The preceding example passes the structure *by reference*, which allows the procedure to modify its elements so that the changes take effect in the calling code. If you want to protect a structure against such modification, pass it by value.  
  
 You can also return a structure from a `Function` procedure. The following example illustrates this.  
  
```vb  
Dim allSystems(100) As systemInfo  
Function findByDate(ByVal searchDate As Date) As systemInfo  
    Dim i As Integer  
    For i = 1 To 100  
        If allSystems(i).purchaseDate = searchDate Then Return allSystems(i)  
    Next i  
   ' Process error: system with desired purchase date not found.  
End Function  
```  
  
## Structures Within Structures  
 Structures can contain other structures. The following example illustrates this.  
  
```vb  
Public Structure driveInfo  
    Public type As String  
    Public size As Long  
End Structure  
Public Structure systemInfo  
    Public cPU As String  
    Public memory As Long  
    Public diskDrives() As driveInfo  
    Public purchaseDate As Date  
End Structure  
```  
  
```vb  
Dim allSystems(100) As systemInfo  
ReDim allSystems(1).diskDrives(3)  
allSystems(1).diskDrives(0).type = "Floppy"  
```  
  
 You can also use this technique to encapsulate a structure defined in one module within a structure defined in a different module.  
  
 Structures can contain other structures to an arbitrary depth.  
  
## See Also  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [How to: Declare a Structure](../../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)  
 [Structure Variables](../../../../visual-basic/programming-guide/language-features/data-types/structure-variables.md)  
 [Structures and Classes](../../../../visual-basic/programming-guide/language-features/data-types/structures-and-classes.md)  
 [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md)

---
title: "Object Variable Assignment (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Nothing keyword [Visual Basic], object variable assignment"
  - "object variables [Visual Basic], initializing"
  - "variables [Visual Basic], initializing"
  - "objects [Visual Basic], current instance"
  - "object variables [Visual Basic], assigning"
  - "variables [Visual Basic], object variables"
  - "current instance [Visual Basic], defined"
  - "variables [Visual Basic], assigning"
  - "assignment statements [Visual Basic], object variable assignment"
  - "Me keyword [Visual Basic], as object variable"
ms.assetid: 3706811d-fd40-44fe-8727-d692e8e55d6d
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Object Variable Assignment (Visual Basic)
You use a normal assignment statement to assign an object to an object variable. You can assign an object expression or the [Nothing](../../../../visual-basic/language-reference/nothing.md) keyword, as the following example illustrates.  
  
```  
Dim thisObject As Object  
' The following statement assigns an object reference.  
thisObject = Form1  
' The following statement discontinues association with any object.  
thisObject = Nothing  
```  
  
 `Nothing` means there is no object currently assigned to the variable.  
  
## Initialization  
 When your code begins running, your object variables are initialized to `Nothing`. Those whose declarations include initialization are reinitialized to the values you specify when the declaration statements are executed.  
  
 You can include initialization in your declaration by using the [New](../../../../visual-basic/language-reference/operators/new-operator.md) keyword. The following declaration statements declare object variables `testUri` and `ver` and assign specific objects to them. Each uses one of the overloaded constructors of the appropriate class to initialize the object.  
  
```  
Dim testUri As New System.Uri("http://www.microsoft.com")  
Dim ver As New System.Version(6, 1, 0)  
```  
  
## Disassociation  
 Setting an object variable to `Nothing` discontinues the association of the variable with any specific object. This prevents you from accidentally changing the object by changing the variable. It also allows you to test whether the object variable points to a valid object, as the following example shows.  
  
```  
If otherObject IsNot Nothing Then  
    ' otherObject refers to a valid object, so your code can use it.  
End If  
```  
  
 If the object your variable refers to is in another application, this test cannot determine whether that application has terminated or just invalidated the object.  
  
 An object variable with a value of `Nothing` is also called a *null reference*.  
  
## Current Instance  
 The *current instance* of an object is the one in which the code is currently executing. Since all code executes inside a procedure, the current instance is the one in which the procedure was invoked.  
  
 The `Me` keyword acts as an object variable referring to the current instance. If a procedure is not [Shared](../../../../visual-basic/language-reference/modifiers/shared.md), it can use the `Me` keyword to obtain a pointer to the current instance. Shared procedures cannot be associated with a specific instance of a class.  
  
 Using `Me` is particularly useful for passing the current instance to a procedure in another module. For example, suppose you have a number of XML documents and wish to add some standard text to all of them. The following example defines a procedure to do this.  
  
```  
Sub addStandardText(XmlDoc As System.Xml.XmlDocument)  
    XmlDoc.CreateTextNode("This text goes into every XML document.")  
End Sub  
```  
  
 Every XML document object could then call the procedure and pass its current instance as an argument. The following example demonstrates this.  
  
```  
addStandardText(Me)  
```  
  
## See Also  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md)  
 [Object Variable Values](../../../../visual-basic/programming-guide/language-features/variables/object-variable-values.md)  
 [How to: Declare an Object Variable and Assign an Object to It in Visual Basic](../../../../visual-basic/programming-guide/language-features/variables/how-to-declare-an-object-variable-and-assign-an-object-to-it.md)  
 [How to: Make an Object Variable Not Refer to Any Instance](../../../../visual-basic/programming-guide/language-features/variables/how-to-make-an-object-variable-not-refer-to-any-instance.md)  
 [Me, My, MyBase, and MyClass](../../../../visual-basic/programming-guide/program-structure/me-my-mybase-and-myclass.md)

---
title: "Access of shared member through an instance; qualifying expression will not be evaluated"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc42025"
  - "BC42025"
helpviewer_keywords: 
  - "BC42025"
ms.assetid: db3337e5-c349-42bf-86df-d9c1e00952a5
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# Access of shared member through an instance; qualifying expression will not be evaluated
An instance variable of a class or structure is used to access a `Shared` variable, property, procedure, or event defined in that class or structure. This warning can also occur if an instance variable is used to access an implicitly shared member of a class or structure, such as a constant or enumeration, or a nested class or structure.  
  
 The purpose of sharing a member is to create only a single copy of that member and make that single copy available to every instance of the class or structure in which it is declared. It is consistent with this purpose to access a `Shared` member through the name of its class or structure, rather than through a variable that holds an individual instance of that class or structure.  
  
 Accessing a `Shared` member through an instance variable can make your code more difficult to understand by obscuring the fact that the member is `Shared`. Furthermore, if such access is part of an expression that performs other actions, such as a `Function` procedure that returns an instance of the shared member, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] bypasses the expression and any other actions it would otherwise perform.  
  
 For more information and an example, see [Shared](../../../visual-basic/language-reference/modifiers/shared.md).  
  
 By default, this message is a warning. For more information about hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42025  
  
## To correct this error  
  
-   Use the name of the class or structure that defines the `Shared` member to access it, as shown in the following example.  
  
```vb  
Public Class testClass  
    Public Shared Sub sayHello()  
        MsgBox("Hello")  
    End Sub  
End Class  
  
Module testModule  
    Public Sub Main()  
        ' Access a shared method through an instance variable.  
        ' This generates a warning.  
        Dim tc As New testClass  
        tc.sayHello()  
  
        ' Access a shared method by using the class name.  
        ' This does not generate a warning.  
        testClass.sayHello()  
    End Sub  
End Module  
```  
  
> [!NOTE]
>  Be alert for the effects of scope when two programming elements have the same name. In the previous example, if you declare an instance by using `Dim testClass as testClass = Nothing`, the compiler treats a call to `testClass.sayHello()` as an access of the method through the class name, and no warning occurs.  
  
## See Also  
 [Shared](../../../visual-basic/language-reference/modifiers/shared.md)  
 [Scope in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/scope.md)

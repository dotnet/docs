---
title: "Using the iteration variable in a lambda expression may have unexpected results"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc42324"
  - "bc42324"
helpviewer_keywords: 
  - "BC42324"
ms.assetid: b5c2c4bd-3b2a-4a73-aaeb-55728eb03b68
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Using the iteration variable in a lambda expression may have unexpected results
Using the iteration variable in a lambda expression may have unexpected results. Instead, create a local variable within the loop and assign it the value of the iteration variable.  
  
 This warning appears when you use a loop iteration variable in a lambda expression that is declared inside the loop. For example, the following example causes the warning to appear.  
  
```vb  
For i As Integer = 1 To 10  
    ' The warning is given for the use of i.  
    Dim exampleFunc As Func(Of Integer) = Function() i  
Next  
```  
  
 The following example shows the unexpected results that might occur.  
  
```vb  
Module Module1  
    Sub Main()  
        Dim array1 As Func(Of Integer)() = New Func(Of Integer)(4) {}  
  
        For i As Integer = 0 To 4  
            array1(i) = Function() i  
        Next  
  
        For Each funcElement In array1  
            System.Console.WriteLine(funcElement())  
        Next  
  
    End Sub  
End Module  
```  
  
 The `For` loop creates an array of lambda expressions, each of which returns the value of the loop iteration variable `i`. When the lambda expressions are evaluated in the `For Each` loop, you might expect to see 0, 1, 2, 3, and 4 displayed, the successive values of `i` in the `For` loop. Instead, you see the final value of `i` displayed five times:  
  
 `5`  
  
 `5`  
  
 `5`  
  
 `5`  
  
 `5`  
  
 By default, this message is a warning. For more information about hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42324  
  
## To correct this error  
  
-   Assign the value of the iteration variable to a local variable, and use the local variable in the lambda expression.  
  
```vb  
Module Module1  
    Sub Main()  
        Dim array1 As Func(Of Integer)() = New Func(Of Integer)(4) {}  
  
        For i As Integer = 0 To 4  
            Dim j = i  
            array1(i) = Function() j  
        Next  
  
        For Each funcElement In array1  
            System.Console.WriteLine(funcElement())  
        Next  
  
    End Sub  
End Module  
```  
  
## See Also  
 [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md)

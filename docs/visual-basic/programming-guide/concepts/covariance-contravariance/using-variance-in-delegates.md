---
title: "Using Variance in Delegates (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7b5c20f1-6416-46a3-94b6-f109c31c842c
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Using Variance in Delegates (Visual Basic)
When you assign a method to a delegate, *covariance* and *contravariance* provide flexibility for matching a delegate type with a method signature. Covariance permits a method to have return type that is more derived than that defined in the delegate. Contravariance permits a method that has parameter types that are less derived than those in the delegate type.  
  
## Example 1: Covariance  
  
### Description  
 This example demonstrates how delegates can be used with methods that have return types that are derived from the return type in the delegate signature. The data type returned by `DogsHandler` is of type `Dogs`, which derives from the `Mammals` type that is defined in the delegate.  
  
### Code  
  
```vb  
Class Mammals  
End Class  
  
Class Dogs  
    Inherits Mammals  
End Class  
Class Test  
    Public Delegate Function HandlerMethod() As Mammals  
    Public Shared Function MammalsHandler() As Mammals  
        Return Nothing  
    End Function  
    Public Shared Function DogsHandler() As Dogs  
        Return Nothing  
    End Function  
    Sub Test()  
        Dim handlerMammals As HandlerMethod = AddressOf MammalsHandler  
        ' Covariance enables this assignment.  
        Dim handlerDogs As HandlerMethod = AddressOf DogsHandler  
    End Sub  
End Class  
```  
  
## Example 2: Contravariance  
  
### Description  
 This example demonstrates how delegates can be used with methods that have parameters of a type that are base types of the delegate signature parameter type. With contravariance, you can use one event handler instead of separate handlers. For example, you can create an event handler that accepts an `EventArgs` input parameter and use it with a `Button.MouseClick` event that sends a `MouseEventArgs` type as a parameter, and also with a `TextBox.KeyDown` event that sends a `KeyEventArgs` parameter.  
  
### Code  
  
```vb  
' Event hander that accepts a parameter of the EventArgs type.  
Private Sub MultiHandler(ByVal sender As Object,  
                         ByVal e As System.EventArgs)  
    Label1.Text = DateTime.Now  
End Sub  
  
Private Sub Form1_Load(ByVal sender As System.Object,  
    ByVal e As System.EventArgs) Handles MyBase.Load  
  
    ' You can use a method that has an EventArgs parameter,  
    ' although the event expects the KeyEventArgs parameter.  
    AddHandler Button1.KeyDown, AddressOf MultiHandler  
  
    ' You can use the same method   
    ' for the event that expects the MouseEventArgs parameter.  
    AddHandler Button1.MouseClick, AddressOf MultiHandler  
End Sub  
```  
  
## See Also  
 [Variance in Delegates (Visual Basic)](../../../../visual-basic/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md)  
 [Using Variance for Func and Action Generic Delegates (Visual Basic)](../../../../visual-basic/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md)

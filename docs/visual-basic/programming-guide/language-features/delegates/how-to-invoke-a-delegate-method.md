---
title: "How to: Invoke a Delegate Method (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: b56866ae-abf9-4a5a-a855-486359455e9c
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Invoke a Delegate Method (Visual Basic)
This example shows how to associate a method with a delegate and then invoke that method through the delegate.  
  
### Create the delegate and matching procedures  
  
1.  Create a delegate named `MySubDelegate`.  
  
    ```  
    Delegate Sub MySubDelegate(ByVal x As Integer)  
    ```  
  
2.  Declare a class that contains a method with the same signature as the delegate.  
  
    ```  
    Class class1  
        Sub Sub1(ByVal x As Integer)  
            MsgBox("The value of x is: " & CStr(x))  
        End Sub  
    End Class  
    ```  
  
3.  Define a method that creates an instance of the delegate and invokes the method associated with the delegate by calling the built-in `Invoke` method.  
  
    ```  
    Protected Sub DelegateTest()  
        Dim c1 As New class1  
        ' Create an instance of the delegate.  
        Dim msd As MySubDelegate = AddressOf c1.Sub1  
        ' Call the method.  
        msd.Invoke(10)  
    End Sub  
    ```  
  
## See Also  
 [Delegate Statement](../../../../visual-basic/language-reference/statements/delegate-statement.md)  
 [Delegates](../../../../visual-basic/programming-guide/language-features/delegates/index.md)  
 [Events](../../../../visual-basic/programming-guide/language-features/events/index.md)  
 [Multithreaded Applications](http://msdn.microsoft.com/library/a06a1a56-dd16-44e8-bc01-2c2255511bc6)

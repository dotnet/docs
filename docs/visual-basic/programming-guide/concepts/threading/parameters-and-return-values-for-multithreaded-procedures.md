---
title: "Parameters and Return Values for Multithreaded Procedures (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cbdce172-7ff6-41a9-bb21-53a7c6f538a5
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent
---
# Parameters and Return Values for Multithreaded Procedures (Visual Basic)
Supplying and returning values in a multithreaded application is complicated because the constructor for the thread class must be passed a reference to a procedure that takes no arguments and returns no value. The following sections show some simple ways to supply parameters and return values from procedures on separate threads.  
  
## Supplying Parameters for Multithreaded Procedures  
 The best way to supply parameters for a multithreaded method call is to wrap the target method in a class and define fields for that class that will serve as parameters for the new thread. The advantage of this approach is that you can create a new instance of the class, with its own parameters, every time you want to start a new thread. For example, suppose you have a function that calculates the area of a triangle, as in the following code:  
  
```vb  
Function CalcArea(ByVal Base As Double, ByVal Height As Double) As Double  
    CalcArea = 0.5 * Base * Height  
End Function  
```  
  
 You can write a class that wraps the `CalcArea` function and creates fields to store input parameters, as follows:  
  
```vb  
Class AreaClass  
    Public Base As Double  
    Public Height As Double  
    Public Area As Double  
    Sub CalcArea()  
        Area = 0.5 * Base * Height  
        MessageBox.Show("The area is: " & Area.ToString)  
    End Sub  
End Class  
```  
  
 To use the `AreaClass`, you can create an `AreaClass` object, and set the `Base` and `Height` properties as shown in the following code:  
  
```vb  
Protected Sub TestArea()  
    Dim AreaObject As New AreaClass  
    Dim Thread As New System.Threading.Thread(  
                        AddressOf AreaObject.CalcArea)  
    AreaObject.Base = 30  
    AreaObject.Height = 40  
    Thread.Start()  
End Sub  
```  
  
 Notice that the `TestArea` procedure does not check the value of the `Area` field after calling the `CalcArea` method. Because `CalcArea` runs on a separate thread, the `Area` field is not guaranteed to be set if you check it immediately after calling `Thread.Start`. The next section discusses a better way to return values from multithreaded procedures.  
  
## Returning Values from Multithreaded Procedures  
 Returning values from procedures that run on separate threads is complicated by the fact that the procedures cannot be functions and cannot use `ByRef` arguments. The easiest way to return values is to use the <xref:System.ComponentModel.BackgroundWorker> component to manage your threads and raise an event when the task is done, and process the results with an event handler.  
  
 The following example returns a value by raising an event from a procedure running on a separate thread:  
  
```vb  
Private Class AreaClass2  
    Public Base As Double  
    Public Height As Double  
    Function CalcArea() As Double  
        ' Calculate the area of a triangle.  
        Return 0.5 * Base * Height  
    End Function  
End Class  
  
Private WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker  
  
Private Sub TestArea2()  
    Dim AreaObject2 As New AreaClass2  
    AreaObject2.Base = 30  
    AreaObject2.Height = 40  
  
    ' Start the asynchronous operation.  
    BackgroundWorker1.RunWorkerAsync(AreaObject2)  
End Sub  
  
' This method runs on the background thread when it starts.  
Private Sub BackgroundWorker1_DoWork(  
    ByVal sender As Object,   
    ByVal e As System.ComponentModel.DoWorkEventArgs  
    ) Handles BackgroundWorker1.DoWork  
  
    Dim AreaObject2 As AreaClass2 = CType(e.Argument, AreaClass2)  
    ' Return the value through the Result property.  
    e.Result = AreaObject2.CalcArea()  
End Sub  
  
' This method runs on the main thread when the background thread finishes.  
Private Sub BackgroundWorker1_RunWorkerCompleted(  
    ByVal sender As Object,  
    ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs  
    ) Handles BackgroundWorker1.RunWorkerCompleted  
  
    ' Access the result through the Result property.  
    Dim Area As Double = CDbl(e.Result)  
    MessageBox.Show("The area is: " & Area.ToString)  
End Sub  
```  
  
 You can provide parameters and return values to thread-pool threads by using the optional `ByVal` state-object variable of the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A> method. Thread-timer threads also support a state object for this purpose. For information on thread pooling and thread timers, see [Thread Pooling (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/thread-pooling.md)[Thread Pooling](http://msdn.microsoft.com/library/4b8bb2c8-8ca4-457c-9afd-d11bc9a05701) and [Thread Timers (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/thread-timers.md).  
  
## See Also  
 [Walkthrough: Multithreading with the BackgroundWorker Component (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/walkthrough-multithreading-with-the-backgroundworker-component.md)  
 [Thread Pooling (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/thread-pooling.md)  
 [Thread Synchronization (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/thread-synchronization.md)  
 [Events](../../../../visual-basic/programming-guide/language-features/events/index.md)  
 [Multithreaded Applications (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/multithreaded-applications.md)  
 [Delegates](../../../../visual-basic/programming-guide/language-features/delegates/index.md)  
 [Multithreading in Components](http://msdn.microsoft.com/library/2fc31e68-fb71-4544-b654-0ce720478779)

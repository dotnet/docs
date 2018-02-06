---
title: "Thread Timers (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 809cba93-cc93-4e21-afda-f299f9a39818
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Thread Timers (Visual Basic)
The <xref:System.Threading.Timer?displayProperty=nameWithType> class is useful for periodically running a task on a separate thread. For example, you could use a thread timer to check the status and integrity of a database or to back up critical files.  
  
## Thread Timer Example  
 The following example starts a task every two seconds and uses a flag to initiate the <xref:System.IDisposable.Dispose%2A> method that stops the timer. This example posts status to the output window.  
  
```vb  
Private Class StateObjClass  
    ' Used to hold parameters for calls to TimerTask.  
    Public SomeValue As Integer  
    Public TimerReference As System.Threading.Timer  
    Public TimerCanceled As Boolean  
End Class  
  
Public Sub RunTimer()  
    Dim StateObj As New StateObjClass  
    StateObj.TimerCanceled = False  
    StateObj.SomeValue = 1  
    Dim TimerDelegate As New System.Threading.TimerCallback(AddressOf TimerTask)  
    ' Create a timer that calls a procedure every 2 seconds.  
    ' Note: There is no Start method; the timer starts running as soon as   
    ' the instance is created.  
    Dim TimerItem As New System.Threading.Timer(TimerDelegate, StateObj,  
                                                2000, 2000)  
    ' Save a reference for Dispose.  
    StateObj.TimerReference = TimerItem  
  
    ' Run for ten loops.  
    While StateObj.SomeValue < 10  
        ' Wait one second.  
        System.Threading.Thread.Sleep(1000)  
    End While  
  
    ' Request Dispose of the timer object.  
    StateObj.TimerCanceled = True  
End Sub  
  
Private Sub TimerTask(ByVal StateObj As Object)  
    Dim State As StateObjClass = CType(StateObj, StateObjClass)  
    ' Use the interlocked class to increment the counter variable.  
    System.Threading.Interlocked.Increment(State.SomeValue)  
    System.Diagnostics.Debug.WriteLine("Launched new thread  " & Now.ToString)  
    If State.TimerCanceled Then  
        ' Dispose Requested.  
        State.TimerReference.Dispose()  
        System.Diagnostics.Debug.WriteLine("Done  " & Now)  
    End If  
End Sub  
```  
  
 Thread timers are particularly useful when the <xref:System.Windows.Forms.Timer?displayProperty=nameWithType> object is unavailable, such as when you are developing console applications.  
  
## See Also  
 <xref:System.Threading>  
 [Multithreaded Applications (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/multithreaded-applications.md)

Option Strict On
Option Explicit On

Class Class14501703298f4d43b139c4b6366af176
    ' SyncLock Statement

    ' <snippet1>
    Class simpleMessageList
        Public messagesList() As String = New String(50) {}
        Public messagesLast As Integer = -1
        Private messagesLock As New Object
        Public Sub addAnotherMessage(ByVal newMessage As String)
            SyncLock messagesLock
                messagesLast += 1
                If messagesLast < messagesList.Length Then
                    messagesList(messagesLast) = newMessage
                End If
            End SyncLock
        End Sub
    End Class
    ' </snippet1>

End Class

Class Class20440b0cfffd4408ab8153ba826e6b26
    ' Advanced Synchronization Techniques

    ' <snippet2>
    Sub ThreadA(ByRef IntA As Integer)
        System.Threading.Interlocked.Increment(IntA)
    End Sub

    Sub ThreadB(ByRef IntA As Integer)
        System.Threading.Interlocked.Increment(IntA)
    End Sub
    ' </snippet2>

End Class

Class Class4b8bb2c88ca4457c9afdd11bc9a05701
    ' Thread Pooling

    ' <snippet3>
    Sub DoWork()
        ' Queue a task
        System.Threading.ThreadPool.QueueUserWorkItem( 
            New System.Threading.WaitCallback(AddressOf SomeLongTask))
        ' Queue another task
        System.Threading.ThreadPool.QueueUserWorkItem( 
            New System.Threading.WaitCallback(AddressOf AnotherLongTask))
    End Sub
    Sub SomeLongTask(ByVal state As Object)
        ' Insert code to perform a long task.
    End Sub
    Sub AnotherLongTask(ByVal state As Object)
        ' Insert code to perform another long task.
    End Sub
    ' </snippet3>

End Class


' snippets are now in vbThreading.
'Class Class989134663d744f48a2c0f2a2c31a3049
'    ' Parameters and Return Values for Multithreaded Procedures

'    ' <snippet4>
'    Function CalcArea(ByVal Base As Double, ByVal Height As Double) As Double
'        CalcArea = 0.5 * Base * Height
'    End Function
'    ' </snippet4>

'    ' <snippet5>
'    Class AreaClass
'        Public Base As Double
'        Public Height As Double
'        Public Area As Double
'        Sub CalcArea()
'            Area = 0.5 * Base * Height
'            MsgBox("The area is: " & Area)
'        End Sub
'    End Class
'    ' </snippet5>

'    ' <snippet6>
'    Protected Sub TestArea()
'        Dim AreaObject As New AreaClass
'        Dim Thread As New System.Threading.Thread(
'                         AddressOf AreaObject.CalcArea)
'        AreaObject.Base = 30
'        AreaObject.Height = 40
'        Thread.Start()
'    End Sub
'    ' </snippet6>

'    ' <snippet7>
'    Private Class AreaClass2
'        Public Base As Double
'        Public Height As Double
'        Function CalcArea() As Double
'            ' Calculate the area of a triangle.
'            Return 0.5 * Base * Height
'        End Function
'    End Class

'    Private WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker

'    Private Sub TestArea2()
'        Dim AreaObject2 As New AreaClass2
'        AreaObject2.Base = 30
'        AreaObject2.Height = 40

'        ' Start the asynchronous operation.
'        BackgroundWorker1.RunWorkerAsync(AreaObject2)
'    End Sub

'    ' This method runs on the background thread when it starts.
'    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, 
'        ByVal e As System.ComponentModel.DoWorkEventArgs
'        ) Handles BackgroundWorker1.DoWork
'
'        Dim AreaObject2 As AreaClass2 = CType(e.Argument, AreaClass2)
'        ' Return the value through the Result property.
'        e.Result = AreaObject2.CalcArea()
'    End Sub

'    ' This method runs on the main thread when the background thread finishes.
'    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, 
'        ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs
'        ) Handles BackgroundWorker1.RunWorkerCompleted
'
'        ' Access the result through the Result property.
'        Dim Area As Double = CDbl(e.Result)
'        MsgBox("The area is: " & Area)
'    End Sub
'    ' </snippet7>

'End Class

' snippets are now in vbThreading
'Class Class9b72d48b4a6343bbaa60786cc9425182
'    ' Thread Timers

'    ' <snippet8>
'    Class StateObjClass
'        ' Used to hold parameters for calls to TimerTask
'        Public SomeValue As Integer
'        Public TimerReference As System.Threading.Timer
'        Public TimerCanceled As Boolean
'    End Class

'    Sub RunTimer()
'        Dim StateObj As New StateObjClass
'        StateObj.TimerCanceled = False
'        StateObj.SomeValue = 1
'        Dim TimerDelegate As New Threading.TimerCallback(AddressOf TimerTask)
'        ' Create a timer that calls a procedure every 2 seconds.
'        ' Note: There is no Start method; the timer starts running as soon as 
'        ' the instance is created.
'        Dim TimerItem As New System.Threading.Timer(TimerDelegate, StateObj, 
'                                                    2000, 2000)
'        StateObj.TimerReference = TimerItem  ' Save a reference for Dispose.

'        While StateObj.SomeValue < 10 ' Run for ten loops.
'            System.Threading.Thread.Sleep(1000)  ' Wait one second.
'        End While

'        StateObj.TimerCanceled = True  ' Request Dispose of the timer object.
'    End Sub

'    Sub TimerTask(ByVal StateObj As Object)
'        Dim State As StateObjClass = CType(StateObj, StateObjClass)
'        ' Use the interlocked class to increment the counter variable.
'        System.Threading.Interlocked.Increment(State.SomeValue)
'        System.Diagnostics.Debug.WriteLine("Launched new thread  " & Now)
'        If State.TimerCanceled Then    ' Dispose Requested.
'            State.TimerReference.Dispose()
'            System.Diagnostics.Debug.WriteLine("Done  " & Now)
'        End If
'    End Sub
'    ' </snippet8>

'End Class


' snippets are now in vbThreading.
'Class Classa06a1a56dd1644e8bc012c2255511bc6
'    ' Multithreaded Applications

'    Private WithEvents x As New System.ComponentModel.BackgroundWorker


'    Public Sub test()

'    End Sub

'    Public Sub Method9()
'        ' <snippet9>
'        Dim TestThread As New System.Threading.Thread(AddressOf TestSub)
'        ' </snippet9>
'        ' <snippet10>
'        TestThread.Start()
'        ' </snippet10>
'        ' <snippet11>
'        TestThread.Abort()
'        ' </snippet11>
'        ' <snippet12>
'        TestThread.Sleep(1000)
'        TestThread.Abort()
'        ' </snippet12>
'    End Sub

'    Sub TestSub()
'    End Sub

'    Private Sub x_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles x.DoWork

'    End Sub
'End Class

' topic moved to Not in Build.
'Class Classb9806af319d3454895c772f21296d83c
'    ' Thread Synchronization

'    ' <snippet13>
'    Sub JoinThreads()
'        Dim Thread1 As New System.Threading.Thread(AddressOf SomeTask)
'        Thread1.Start()
'        Thread1.Join()      ' Wait for the thread to finish.
'        MsgBox("Thread is done")
'    End Sub
'    Sub SomeTask()
'        ' Insert code to perform a task here.
'    End Sub
'    ' </snippet13>

'End Class



Option Strict On
Option Explicit On

Class Classa06a1a56dd1644e8bc012c2255511bc6
    ' Multithreaded Applications topic.

    Private Sub Method1()
        '<Snippet2>
        Dim newThread As New System.Threading.Thread(AddressOf AMethod)
        '</Snippet2>

        '<Snippet4>
        newThread.Start()
        '</Snippet4>

        '<Snippet6>
        newThread.Abort()
        '</Snippet6>
    End Sub

    Private Sub AMethod()

    End Sub
End Class


Class Class989134663d744f48a2c0f2a2c31a3049
    ' Parameters and Return Values for Multithreaded Procedures

    ' <snippet8>
    Function CalcArea(ByVal Base As Double, ByVal Height As Double) As Double
        CalcArea = 0.5 * Base * Height
    End Function
    ' </snippet8>

    ' <snippet10>
    Class AreaClass
        Public Base As Double
        Public Height As Double
        Public Area As Double
        Sub CalcArea()
            Area = 0.5 * Base * Height
            MessageBox.Show("The area is: " & Area.ToString)
        End Sub
    End Class
    ' </snippet10>

    ' <snippet12>
    Protected Sub TestArea()
        Dim AreaObject As New AreaClass
        Dim Thread As New System.Threading.Thread(
                            AddressOf AreaObject.CalcArea)
        AreaObject.Base = 30
        AreaObject.Height = 40
        Thread.Start()
    End Sub
    ' </snippet12>

    ' <snippet14>
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
    ' </snippet14>


    Public Sub RunExamples()
        MessageBox.Show(CalcArea(5, 6).ToString)
        TestArea()
        TestArea2()
    End Sub

End Class


Class Class9b72d48b4a6343bbaa60786cc9425182
    ' Thread Timers

    ' <snippet16>
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
    ' </snippet16>
End Class


Class Class4b8bb2c88ca4457c9afdd11bc9a05701
    ' Thread Pooling

    ' <snippet18>
    Public Sub DoWork()
        ' Queue a task.
        System.Threading.ThreadPool.QueueUserWorkItem(
            New System.Threading.WaitCallback(AddressOf SomeLongTask))
        ' Queue another task.
        System.Threading.ThreadPool.QueueUserWorkItem(
            New System.Threading.WaitCallback(AddressOf AnotherLongTask))
    End Sub
    Private Sub SomeLongTask(ByVal state As Object)
        ' Insert code to perform a long task.
    End Sub
    Private Sub AnotherLongTask(ByVal state As Object)
        ' Insert code to perform another long task.
    End Sub
    ' </snippet18>
End Class


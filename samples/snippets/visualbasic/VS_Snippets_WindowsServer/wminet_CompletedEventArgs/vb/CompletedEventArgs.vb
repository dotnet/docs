'<Snippet1>
Imports System
Imports System.Management

Public Class InvokeMethodAsync

    Private isFinished As Boolean = False
    Private returnObj As ManagementBaseObject

    Public Sub New()

        ' Get the object on which the method 
        ' will be invoked
        Dim processClass As ManagementClass = _
            New ManagementClass("Win32_Process")

        ' Create a results and completion handler
        Dim handler As ManagementOperationObserver = _
            New ManagementOperationObserver
        AddHandler handler.Completed, _
            AddressOf Me.Completed

        ' Invoke method asynchronously
        Dim inParams As ManagementBaseObject = _
            processClass.GetMethodParameters("Create")
        inParams("CommandLine") = "calc.exe"
        processClass.InvokeMethod( _
            handler, "Create", inParams, Nothing)

        ' Do something while method is executing
        While (Not Me.IsComplete)

            System.Threading.Thread.Sleep(1000)
        End While

    End Sub

    ' Property allows accessing the result
    ' object in the main function
    Private Function ReturnObject() As ManagementBaseObject

        Return returnObj

    End Function

    ' Delegate called when the method completes
    ' and results are available
    Private Sub NewObject(ByVal sender As Object, _
        ByVal e As ObjectReadyEventArgs)

        Console.WriteLine("New Object arrived!")
        returnObj = e.NewObject

    End Sub

    ' Used to determine whether the method
    ' execution has completed
    Private Function IsComplete() As Boolean

        Return isFinished

    End Function

    Private Sub Completed(ByVal sender As Object, _
        ByVal e As CompletedEventArgs)

        isFinished = True
        Console.WriteLine("Completed method invocation.")

    End Sub

    Public Shared Function _
            Main(ByVal args() As String) As Integer

        Dim invokeMethod As New InvokeMethodAsync

        Return 0

    End Function


End Class
'</Snippet1>
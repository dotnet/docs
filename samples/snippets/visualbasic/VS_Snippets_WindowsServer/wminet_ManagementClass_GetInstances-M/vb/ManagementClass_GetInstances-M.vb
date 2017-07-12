'<Snippet1>
Imports System
Imports System.Management

Public Class AsyncGetExample

    Public Sub New()

        Dim c As New ManagementClass("Win32_Process")
        Dim ob As New ManagementOperationObserver
        AddHandler ob.ObjectReady, AddressOf Me.NewObject
        AddHandler ob.Completed, AddressOf Me.Done

        c.GetInstances(ob)

        While Not Me.Completed
            System.Threading.Thread.Sleep(1000)
        End While

        'Here you can use the object

    End Sub

    Private finished As Boolean = False

    Private Sub NewObject(ByVal sender As Object, _
    ByVal e As ObjectReadyEventArgs)
        Console.WriteLine("New result arrived: {0}", _
         e.NewObject("Name"))
    End Sub

    Private Sub Done(ByVal sender As Object, _
    ByVal e As CompletedEventArgs)
        Console.WriteLine("async Get completed !")
        finished = True
    End Sub

    Private ReadOnly Property Completed() As Boolean
        Get
            Return finished
        End Get
    End Property


    Public Shared Function Main(ByVal args() _
        As String) As Integer

        Dim asyncGet As New AsyncGetExample

        Return 0

    End Function

End Class
'</Snippet1>
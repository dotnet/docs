'<Snippet1>
Imports System
Imports System.Management

Class AsyncGetExample

    Public Sub New()

        Dim o As New ManagementObject( _
            "Win32_Process.Name=""notepad.exe""")

        'Set up handlers for asynchronous get
        Dim ob As New ManagementOperationObserver
        AddHandler ob.Completed, AddressOf Me.Done

        'Get the object asynchronously
        o.Get(ob)

        'Wait until operation is completed
        While Not Me.Completed
            System.Threading.Thread.Sleep(1000)
        End While

        'Here you can use the object

    End Sub

    Private _completed As Boolean = False

    Private Sub Done(ByVal sender As Object, _
        ByVal e As CompletedEventArgs)
        Console.WriteLine("async Get completed !")
        _completed = True
    End Sub

    Private ReadOnly Property Completed() As Boolean
        Get
            Return _completed
        End Get
    End Property

    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim example As New AsyncGetExample

        Return 0

    End Function


End Class
'</Snippet1>
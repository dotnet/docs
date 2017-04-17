'<snippet6>
Imports System

Public Class MyEventArgs
    Inherits EventArgs
    Private msg As String

    Public Sub New(messageArg As String)
        msg = messageArg
    End Sub

    Public ReadOnly Property Message As String
        Get
            Return msg
        End Get
    End Property
End Class

Class Dummy
    '<snippet7>
    Public Event MyEvent As EventHandler(Of MyEventArgs)
    '</snippet7>

    Public Shared Sub Main()
        Dim dummo As New Dummy()

        dummo.DoEvent()
    End Sub

    Public Sub DoEvent()
        Dim eArgs As New MyEventArgs("My Event Message")

        ' AddHandler MyEvent, CType(AddressOf MyEventHandler, EventHandler(Of MyEventArgs))
        '    or ...
        AddHandler MyEvent, AddressOf MyEventHandler
        RaiseEvent MyEvent(Me, eArgs)
    End Sub

    Private Sub MyEventHandler(sender As Object, eArgs As MyEventArgs)
        Console.WriteLine(eArgs.Message)
    End Sub
End Class
'</snippet6>

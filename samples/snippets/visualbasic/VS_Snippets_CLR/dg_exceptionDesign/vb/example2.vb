'<snippet14>
Imports System

Public Class EmployeeListNotFoundException
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class
'</snippet14>

Public Class TestExample
    Public Shared Sub Main()
        Dim e1, e2, e3 As EmployeeListNotFoundException
        Dim ex As New Exception()

        e1 = New EmployeeListNotFoundException()
        e2 = New EmployeeListNotFoundException("Hi!")
        e3 = New EmployeeListNotFoundException("Hi!", ex)
    End Sub
End Class
Option Strict On
Imports System.Collections.Generic

Module Module1

    Sub Main()

    End Sub

    Public Class Class1
        '<Snippet1>
        Public Property Name As String
        Public Property Owner As String = "DefaultName"
        Public Property Items As New List(Of String) From {"M", "T", "W"}
        Public Property ID As New Guid()
        '</Snippet1>

        '<Snippet3>
        Property FirstName As String = "James"
        Property PartNo As Integer = 44302
        Property Orders As New List(Of Order)(500)
        '</Snippet3>

        '<Snippet4>
        Property Grades As Integer() = {90, 73}
        Property Temperatures As Integer() = New Integer() {68, 54, 71}
        '</Snippet4>

        '<Snippet5>
        Property Prop2 As String = "Empty"
        '</Snippet5>
    End Class

    Public Class Order
    End Class

    Public Class Class2
        '<Snippet2>
        Private _Prop2 As String = "Empty"
        Property Prop2 As String
            Get
                Return _Prop2
            End Get
            Set(ByVal value As String)
                _Prop2 = value
            End Set
        End Property
        '</Snippet2>
    End Class

End Module
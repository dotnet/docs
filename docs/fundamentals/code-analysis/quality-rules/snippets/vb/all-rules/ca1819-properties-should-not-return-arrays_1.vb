Imports System
Imports System.Collections.ObjectModel

Namespace ca1819

    '<snippet1>
    Public Class Book
        Public Sub New(ByVal pages As String())
            Me.Pages = pages
        End Sub

        Public ReadOnly Property Pages() As String()
    End Class
    '</snippet1>

End Namespace

Namespace ca1819_2

    '<snippet2>
    Public Class Book

        Private _Pages As String()

        Public Sub New(ByVal pages As String())
            _Pages = pages
        End Sub

        Public Function GetPages() As String()
            ' Need to return a clone of the array so that consumers            
            ' of this library cannot change its contents            
            Return DirectCast(_Pages.Clone(), String())
        End Function

    End Class
    '</snippet2>

End Namespace

Namespace ca1819_3

    '<snippet3>
    Public Class Book
        Public Sub New(ByVal pages As String())
            Me.Pages = New ReadOnlyCollection(Of String)(pages)
        End Sub

        Public ReadOnly Property Pages() As ReadOnlyCollection(Of String)

    End Class
    '</snippet3>

End Namespace

Namespace ca1819_4

    '<snippet4>
    Public Class Book
        Public Sub New(ByVal pages As String())
            Me.Pages = pages
        End Sub

        Public Property Pages() As String()

    End Class
    '</snippet4>

End Namespace

Namespace ca1819_5
    '<snippet5>
    Public Class Book
        Public Sub New(ByVal pages As String())
            Me.Pages = New Collection(Of String)(pages)
        End Sub

        Public ReadOnly Property Pages() As Collection(Of String)
    End Class
    '</snippet5>

End Namespace

'<Snippet1>
Imports System

Namespace Samples

    Public Class Book

        Private ReadOnly _Title As String

        Public Sub New(ByVal title As String)

            If title IsNot Nothing Then
                ' Violates this rule                
                title.Trim()
            End If

            _Title = title

        End Sub

        Public ReadOnly Property Title() As String
            Get
                Return _Title
            End Get
        End Property

    End Class

End Namespace
'</Snippet1>
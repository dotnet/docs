Imports System

Namespace ca2208
#Disable Warning CA2208 ' Instantiate argument exceptions correctly
    '<snippet1>
    Public Class Book

        Private ReadOnly _Title As String

        Public Sub New(ByVal title As String)
            ' Violates this rule (constructor arguments are switched)            
            If (title Is Nothing) Then
                Throw New ArgumentNullException("title cannot be a null reference (Nothing in Visual Basic)", "title")
            End If
            _Title = title
        End Sub

        Public ReadOnly Property Title()
            Get
                Return _Title
            End Get
        End Property

    End Class
    '</snippet1>
#Enable Warning CA2208 ' Instantiate argument exceptions correctly

End Namespace

Namespace ca2208_2
    '<snippet2>
    Public Class Book

        Private ReadOnly _Title As String

        Public Sub New(ByVal title As String)
            If (title Is Nothing) Then
                Throw New ArgumentNullException("title", "title cannot be a null reference (Nothing in Visual Basic)")
            End If

            _Title = title
        End Sub

        Public ReadOnly Property Title()
            Get
                Return _Title
            End Get
        End Property

    End Class
    '</snippet2>

End Namespace

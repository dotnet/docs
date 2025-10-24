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

Namespace ca2208_3
#Disable Warning CA2208 ' Instantiate argument exceptions correctly
    '<snippet3>
    Public Class Foo
        Public Property Bar As String
        Public Property Name As String = String.Empty
    End Class

    Public Class Example
        ' Violates CA2208: 'bar' is not a parameter of this method.
        Public Sub ProcessFoo(ByVal foo As Foo)
            Dim bar As String = foo.Bar
            If bar Is Nothing Then
                Throw New ArgumentNullException(NameOf(bar), $"Foo named {foo.Name} had no Bar!")
            End If
            ' Process bar...
        End Sub
    End Class
    '</snippet3>
#Enable Warning CA2208 ' Instantiate argument exceptions correctly

End Namespace

Namespace ca2208_4
    '<snippet4>
    Public Class Foo
        Public Property Bar As String
        Public Property Name As String = String.Empty
    End Class

    Public Class Example
        ' Fixed: Use InvalidOperationException for invalid object state.
        Public Sub ProcessFoo(ByVal foo As Foo)
            Dim bar As String = foo.Bar
            If bar Is Nothing Then
                Throw New InvalidOperationException($"Foo named {foo.Name} had no Bar!")
            End If
            ' Process bar...
        End Sub
    End Class
    '</snippet4>

End Namespace

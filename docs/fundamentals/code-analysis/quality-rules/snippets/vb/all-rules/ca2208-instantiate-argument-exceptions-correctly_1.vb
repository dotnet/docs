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
    Public Class Product
        Public Property Description As String
        Public Property Name As String = String.Empty
    End Class

    Public Class Example
        ' Violates CA2208: 'description' is not a parameter of this method.
        Public Sub ProcessProduct(ByVal product As Product)
            Dim description As String = product.Description
            If description Is Nothing Then
                Throw New ArgumentNullException(NameOf(description), $"Product named {product.Name} had no description!")
            End If
            ' Process description...
        End Sub
    End Class
    '</snippet3>
#Enable Warning CA2208 ' Instantiate argument exceptions correctly

End Namespace

Namespace ca2208_4
    '<snippet4>
    Public Class Product
        Public Property Description As String
        Public Property Name As String = String.Empty
    End Class

    Public Class Example
        ' Fixed: Use InvalidOperationException for invalid object state.
        Public Sub ProcessProduct(ByVal product As Product)
            Dim description As String = product.Description
            If description Is Nothing Then
                Throw New InvalidOperationException($"Product named {product.Name} had no description!")
            End If
            ' Process description...
        End Sub
    End Class
    '</snippet4>

End Namespace

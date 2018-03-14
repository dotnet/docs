' <Snippet2>
Imports System

Namespace ExampleA
    ' <Snippet3>
    Public Class ObsoleteAttribute
    End Class
    ' </Snippet3>
End Namespace

Namespace ExampleB
    ' <Snippet4>
    <AttributeUsage(AttributeTargets.All, Inherited := false, AllowMultiple := true)> _
    Public Class ObsoleteAttribute
        Inherits Attribute
    ' Insert code here.
    End Class
    ' </Snippet4>

    ' <Snippet5>
    Public Class NameAttribute
        Inherits Attribute
        Private userNameValue As String
        Private ageValue As Integer

        ' This is a positional argument.
        Public Sub NameAttribute(userName As String)
            userNameValue = userName
        End Sub

        Public ReadOnly Property UserName() As String
            Get
                Return userNameValue
            End Get
        End Property

        ' This is a named argument.
        Public Property Age() As Integer
            Get
                Return ageValue
            End Get
            Set
                ageValue = value
            End Set
        End Property
    End Class
    ' </Snippet5>

    Class Dummy
        Public Shared Sub Main()
            Console.WriteLine("Dummy.Main()")
        End Sub
    End Class
End Namespace
' </Snippet2>

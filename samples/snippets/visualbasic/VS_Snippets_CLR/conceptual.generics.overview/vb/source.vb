'<snippet1>
Namespace GenericsExample1
    '<snippet2>
    Public Class Generic(Of T)
        Public Field As T

    End Class
    '</snippet2>

    Public Class GenTest
        '<snippet3>
        Public Shared Sub Main()
            Dim g As New Generic(Of String)
            g.Field = "A string"
            '...
            Console.WriteLine("Generic.Field           = ""{0}""", g.Field)
            Console.WriteLine("Generic.Field.GetType() = {0}", g.Field.GetType().FullName)
        End Sub
        '</snippet3>

       '<snippet4>
        Function Generic(Of T)(ByVal arg As T) As T
            Dim temp As T = arg
            '...
            Return temp
        End Function
        '</snippet4>

    End Class
End Namespace 'GenericsExample1

Namespace GenericsExample2
    '<snippet5>
    Class A
        Function G(Of T)(ByVal arg As T) As T
            Dim temp As T = arg
            '...
            Return temp
        End Function
    End Class
    Class Generic(Of T)
        Function M(ByVal arg As T) As T
            Dim temp As T = arg
            '...
            Return temp
        End Function
    End Class
   '</snippet5>
End Namespace 'GenericsExample2
'</snippet1>

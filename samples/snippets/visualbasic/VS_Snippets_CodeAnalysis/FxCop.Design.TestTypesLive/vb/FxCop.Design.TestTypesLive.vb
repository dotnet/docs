'<Snippet1>
Imports System

Namespace ApplicationTester

    Public Class MainHolder

        Public Shared Sub Main()
            Dim t1 As New Test()
            Console.WriteLine(t1.ToString())

            Dim t2 As New GoodSpace.Test()
            Console.WriteLine(t2.ToString())
        End Sub

    End Class

End Namespace
'</Snippet1>
Namespace GoodSpace

    Public Class Test

        Public Overrides Function ToString() As String
            Return "Test lives in a namespace!"
        End Function

    End Class

End Namespace

Namespace ApplicationTester
    Public Class Test
    End Class
End Namespace

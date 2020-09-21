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
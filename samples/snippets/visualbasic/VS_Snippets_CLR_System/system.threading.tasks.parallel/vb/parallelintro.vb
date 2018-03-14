'<snippet07>
Imports System.Threading.Tasks
Module Module1

    Sub Main()
        Dim N As Integer = 1000

        ' Using a named method
        Parallel.For(0, N, AddressOf Method2)

        ' Using a lambda expression.
        Parallel.For(0, N, Sub(i)
                               ' Do Work
                           End Sub)
    End Sub

    Sub Method2(ByVal i As Integer)
        ' Do work.
    End Sub

End Module
'</snippet07>

'<snippet08>
' Imports System.Threading.Tasks
Class LoopStateDemo

    Sub TestMethod()
        Dim N As Integer = 1000

        Parallel.For(0, N, Sub(i, loopState)
                               Console.WriteLine(i)
                               If i = 100 Then
                                   loopState.Break()
                               End If
                           End Sub)
    End Sub

End Class
'</snippet08>

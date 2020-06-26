' *********************************************
'<Snippet90>
Option Strict On

Module Module1
    Sub Main()

        ' The assignment of m to n causes a compiler error when 
        ' Option Strict is on.
        Dim m As Long = 9876543210
        'Dim n As Integer = m

        Try
            ' The For Each loop requires the same conversion, but
            ' is not flagged by the compiler. A run-time error is 
            ' raised because 9876543210 is too large for type Integer.
            For Each p As Integer In New Long() {45, 3, 9876543210}
                Console.Write(p & " ")
            Next
            Console.WriteLine()
        Catch e As System.OverflowException
            Console.WriteLine()
            Console.WriteLine(e.Message)
        End Try
    End Sub
End Module

'</Snippet90>
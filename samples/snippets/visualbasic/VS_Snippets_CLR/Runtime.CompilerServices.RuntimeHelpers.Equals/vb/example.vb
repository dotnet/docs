'<snippet1>
Imports System.Runtime.CompilerServices


Module Program

    Sub Main(ByVal args() As String)


        Dim x As Integer = 1
        Dim y As Integer = 1

        Dim ret As Boolean
        ret = RuntimeHelpers.Equals(x, y)

        Console.WriteLine("The return value of RuntimeHelpers.Equals is: " + ret)
    End Sub


End Module
'</snippet1>
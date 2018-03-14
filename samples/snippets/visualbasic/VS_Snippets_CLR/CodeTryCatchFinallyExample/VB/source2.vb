'<snippet3>
Imports System

Class ArgumentOutOfRangeExample
    Public Shared Sub Main()
        Dim array1() As Integer = {0, 0}
        Dim array2() As Integer = {0, 0}

        Try
            Array.Copy(array1, array2 , -1)
        Catch e As ArgumentOutOfRangeException
            Console.WriteLine("Error: {0}", e)
        Finally
            Console.WriteLine("This statement is always executed.")
        End Try
    End Sub
End Class
'</snippet3>

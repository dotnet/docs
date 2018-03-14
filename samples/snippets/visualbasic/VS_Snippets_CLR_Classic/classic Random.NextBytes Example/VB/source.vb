' <Snippet1>
Public Class Example
    Public Shared Sub Main()
        Dim rnd As New Random()
        Dim b(9) As Byte
        rnd.NextBytes(b)
        Console.WriteLine("The Random bytes are: ")
        For i As Integer = 0 To b.GetUpperBound(0)
            Console.WriteLine("{0}: {1}", i, b(i))
        Next
    End Sub 
End Class 
' The example displays output similar to the following:
'       The Random bytes are:
'       0: 131
'       1: 96
'       2: 226
'       3: 213
'       4: 176
'       5: 208
'       6: 99
'       7: 89
'       8: 226
'       9: 194
' </Snippet1>   

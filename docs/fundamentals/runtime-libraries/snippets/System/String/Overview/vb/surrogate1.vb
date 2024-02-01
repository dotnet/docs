' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example20
    Public Sub Main()
        Dim surrogate As String = ChrW(&HD800) + ChrW(&HDC03)
        For ctr As Integer = 0 To surrogate.Length - 1
            Console.Write("U+{0:X2} ", Convert.ToUInt16(surrogate(ctr)))
        Next
        Console.WriteLine()
        Console.WriteLine("   Is Surrogate Pair: {0}",
                        Char.IsSurrogatePair(surrogate(0), surrogate(1)))
    End Sub
End Module

' The example displays the following output:
'       U+D800 U+DC03
'          Is Surrogate Pair: True
' </Snippet3>

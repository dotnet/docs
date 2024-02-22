' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example3
    Public Sub Main()
        Dim combining As String = ChrW(&H61) + ChrW(&H308)
        ShowString(combining)

        Dim normalized As String = combining.Normalize()
        ShowString(normalized)
    End Sub

    Private Sub ShowString(s As String)
        Console.Write("Length of string: {0} (", s.Length)
        For ctr As Integer = 0 To s.Length - 1
            Console.Write("U+{0:X4}", Convert.ToUInt16(s(ctr)))
            If ctr <> s.Length - 1 Then Console.Write(" ")
        Next
        Console.WriteLine(")")
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'       Length of string: 2 (U+0061 U+0308)
'       
'       Length of string: 1 (U+00E4)
' </Snippet5>
